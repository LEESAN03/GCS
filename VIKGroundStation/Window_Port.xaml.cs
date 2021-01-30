using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_Port.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Port : Window
    {
        private static Window_Port m_wnd_port = new Window_Port();
        public static Window_Port getInstance()
        {
            if (m_wnd_port == null)
                m_wnd_port = new Window_Port();
            return m_wnd_port;
        }

        public Window_Port()
        {
            InitializeComponent();

            Top = SystemParameters.PrimaryScreenHeight * 0.05;
            Left = SystemParameters.PrimaryScreenWidth * 0.5;

            combox_link_mode.Items.Add(TryFindResource("TITLE_SERIAL_LINK"));
            combox_link_mode.Items.Add(TryFindResource("TITLE_NET_LINK"));

            Owner = MainWindow.getInstance();
        }


        /*********************************************************************************
         * function: connect by serial
         * para:
         * return:
         * *******************************************************************************/
        private void Btn_Manual_Connect_Click(object sender, RoutedEventArgs e)
        {
            if (combox_serial_array.Text == "")
                return;
            // 如果通信为串口连接
            if (DATA_LINK.link_mode == 1)
            {
                if (DATA_LINK.DonwLink_SerialPort != null)
                {
                    // abort the connect thread
                    if (DATA_LINK.thread_serial_link != null)
                    {
                        DATA_LINK.thread_serial_link.Abort();
                        DATA_LINK.thread_serial_link = null;
                    }

                    if (DATA_LINK.DonwLink_SerialPort.IsOpen == true)
                    {
                        try
                        {
                            while (DATA_LINK.serial_is_listen)
                                System.Windows.Forms.Application.DoEvents();

                            DATA_LINK.DonwLink_SerialPort.Close();
                        }
                        catch
                        {
                        }
                    }
                    DATA_LINK.Serial_Connect(combox_serial_array.Text);
                }
            }
            else
            {
                Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_SELECT_SERIAL_MODE").ToString());
            }
        }

        /***************************************************************************
         * function: connect by wifi net
         * para:
         * return:
         * **************************************************************************/
        private void Btn_WIFI_Connect_Click(object sender, RoutedEventArgs e)
        {
            if (DATA_LINK.link_mode == 2)
            {
                string str_path = Directory.GetCurrentDirectory();

                String str_ip = TextBox_IP.Text;
                String str_port = TextBox_port.Text;

                ReadConfigFile.WritePrivateProfileString("IP_SET", "ipAddr", str_ip, str_path + "\\Start_Up.ini");
                ReadConfigFile.WritePrivateProfileString("IP_SET", "_port", str_port, str_path + "\\Start_Up.ini");

                DATA_LINK.wificonnect(str_ip, str_port);
            }
            else
            {
                Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_SELECT_NET_MODE").ToString());
            }
        }


        /**************************************************************************************
         * function: change the data link mode
         * para:
         * return:
         * *************************************************************************************/
        private static byte link_mode_last = 1;
        private void ComBox_Link_Mode_Changed(object sender, SelectionChangedEventArgs e)
        {
            DATA_LINK.link_mode = combox_link_mode.SelectedIndex + 1;

            string str_path = Directory.GetCurrentDirectory();
            ReadConfigFile.WritePrivateProfileString("IP_SET", "link_mode", DATA_LINK.link_mode.ToString(), str_path + "\\Start_Up.ini");

            if (link_mode_last == 1 && DATA_LINK.link_mode == 2)
            {
                DATA_LINK.Close_Serial_Port();
            }
            link_mode_last = (byte)DATA_LINK.link_mode;
        }
       
        private void Btn_Manual_Disconnect_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Serial_Disconnect();
        }

        private void Btn_WIFI_Disconnect_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Net_Disconnect();
        }

        private void Btn_EXIT_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        private void Btn_Udp_Connect_Click(object sender, RoutedEventArgs e)
        {
            string str_path = Directory.GetCurrentDirectory();
            String str_ip = TextBox_UDP.Text;
            String str_port = TextBox_Udp_Port.Text;

            ReadConfigFile.WritePrivateProfileString("IP_SET", "ipAddr_udp", str_ip, str_path + "\\Start_Up.ini");
            ReadConfigFile.WritePrivateProfileString("IP_SET", "_port_udp", str_port, str_path + "\\Start_Up.ini");

            DATA_LINK.Udp_Connect(str_ip, str_port);
        }
        private void Btn_Udp_Disconnect_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Udp_Disconnect();
        }

        /***************************************************************************
         * function:
         * para:
         * return:
         * *************************************************************************/
        private void Wnd_Port_Load(object sender, RoutedEventArgs e)
        {
            string str_path = Directory.GetCurrentDirectory();
            if (int.Parse(ReadConfigFile.ReadIniData("IP_SET", "link_mode", "", str_path + "\\Start_Up.ini")) == 1)  // 串口连接
            {
                DATA_LINK.link_mode = 1;
                combox_link_mode.SelectedIndex = 0;
            }
            else if (int.Parse(ReadConfigFile.ReadIniData("IP_SET", "link_mode", "", str_path + "\\Start_Up.ini")) == 2)   // wifi 连接
            {
                DATA_LINK.link_mode = 2;
                combox_link_mode.SelectedIndex = 1;
            }
            // tcp ip and address
            TextBox_IP.Text = ReadConfigFile.ReadIniData("IP_SET", "ipAddr", "", str_path + "\\Start_Up.ini");
            TextBox_port.Text = ReadConfigFile.ReadIniData("IP_SET", "_port", "", str_path + "\\Start_Up.ini");

            // udp ip and address
            TextBox_UDP.Text = ReadConfigFile.ReadIniData("IP_SET", "ipAddr_udp", "", str_path + "\\Start_Up.ini");
            TextBox_Udp_Port.Text = ReadConfigFile.ReadIniData("IP_SET", "_port_udp", "", str_path + "\\Start_Up.ini");

            string[] portsName = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(portsName);
            combox_serial_array.ItemsSource = portsName;
            combox_serial_array.SelectedIndex = 0;
        }
    }
}
