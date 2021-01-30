using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_Video_Control.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Video_Control : Window
    {
        private static Window_Video_Control m_wnd_video_control = new Window_Video_Control();
        public static Window_Video_Control getInstance()
        {
            if (m_wnd_video_control == null)
                m_wnd_video_control = new Window_Video_Control();

            mb_wnd_initializaed = true;
            return m_wnd_video_control;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;
        private MyUSBJoy myUSBJoy  = new MyUSBJoy();
        public  void Show_Wnd()
        {
            Show();
            mb_wnd_visible = true;
            timer_control_yuntai.Start();
        }

        public  void Hide_Wnd()
        {
            Hide();
            mb_wnd_visible = false;
            timer_control_yuntai.Stop();
        }

        private static DispatcherTimer timer_control_yuntai;
        
        public List<USB_HID> m_usb_hid_list = new List<USB_HID>();
        public Window_Video_Control()
        {
            InitializeComponent();
            Owner = MainWindow.getInstance();

            this.Top = SystemParameters.PrimaryScreenHeight * 0.1;
            this.Left = SystemParameters.PrimaryScreenWidth * 0.5;

            for (byte i = 1; i <= 12; i++)
            {
                Combox_CH1_REFER.Items.Add(i.ToString());
                Combox_CH2_REFER.Items.Add(i.ToString());
                Combox_CH3_REFER.Items.Add(i.ToString());
                Combox_CH4_REFER.Items.Add(i.ToString());
                Combox_CH5_REFER.Items.Add(i.ToString());
                Combox_CH6_REFER.Items.Add(i.ToString());
                Combox_CH7_REFER.Items.Add(i.ToString());
                Combox_CH8_REFER.Items.Add(i.ToString());
                Combox_CH9_REFER.Items.Add(i.ToString());
                Combox_CH10_REFER.Items.Add(i.ToString());
                Combox_CH11_REFER.Items.Add(i.ToString());
                Combox_CH12_REFER.Items.Add(i.ToString());
            }

            Combox_CH1_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH1_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH2_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH2_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH3_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH3_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH4_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH4_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH5_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH5_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH6_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH6_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH7_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH7_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH8_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH8_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH9_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH9_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH10_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH10_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH11_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH11_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));
            Combox_CH12_REVERSE.Items.Add(TryFindResource("TITLE_NO_REVERSE"));
            Combox_CH12_REVERSE.Items.Add(TryFindResource("TITLE_REVERSE"));

            Combox_Usb_Device.Items.Add(TryFindResource("TITLE_USB_HID_VK"));
            Combox_Usb_Device.Items.Add(TryFindResource("TITLE_USB_HID_HUA_ZHI_YI"));
            Combox_Usb_Device.SelectedIndex = 0;

            timer_control_yuntai = new DispatcherTimer();
            timer_control_yuntai.Interval = TimeSpan.FromMilliseconds(20);
            timer_control_yuntai.Tick += timer_control_yuntai_Tick;

            myUSBJoy.ndXpos = 512;
            myUSBJoy.ndYpos = 512;
            myUSBJoy.ndZpos = 512;

            Hide();
        }

        /******************************************************************
        * 功能：开启始终上传SBUS信息
        * 参数：
        * 返回：
        * ****************************************************************/
        private byte yuntai_msg_type = 1;
        private short[] sbus_out_value = new short[12];
        private short[] sbus_out_value_last = new short[12];
        private byte hid_send_coun = 0;
        private void timer_control_yuntai_Tick(object sender, EventArgs e)
        {
            byte i = 0;
            USB_Joy.GetUSB_Joy(ref myUSBJoy);
            // ======================= vk joustick ========================
            if (Combox_Usb_Device.SelectedIndex == 0)
            {
                if (Combox_CH1_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH1_REFER.SelectedIndex] = (short)(myUSBJoy.ndXpos * 1000 / 1024 + 1000);
                else
                    sbus_out_value[Combox_CH1_REFER.SelectedIndex] = (short)(-myUSBJoy.ndXpos * 1000 / 1024 + 2000);
                TextBlock_Usb_Hid_Ch1.Text = sbus_out_value[Combox_CH1_REFER.SelectedIndex].ToString();

                if (Combox_CH2_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH2_REFER.SelectedIndex] = (short)(myUSBJoy.ndYpos * 1000 / 1024 + 1000);
                else
                    sbus_out_value[Combox_CH2_REFER.SelectedIndex] = (short)(-myUSBJoy.ndYpos * 1000 / 1024 + 2000);
                TextBlock_Usb_Hid_Ch2.Text = sbus_out_value[Combox_CH2_REFER.SelectedIndex].ToString();

                if (Combox_CH3_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH3_REFER.SelectedIndex] = (short)(myUSBJoy.ndZpos * 1000 / 1024 + 1000);
                else
                    sbus_out_value[Combox_CH3_REFER.SelectedIndex] = (short)(-myUSBJoy.ndZpos * 1000 / 1024 + 2000);
                TextBlock_Usb_Hid_Ch3.Text = sbus_out_value[Combox_CH3_REFER.SelectedIndex].ToString();

                sbus_out_value[Combox_CH4_REFER.SelectedIndex] = 1500;
                TextBlock_Usb_Hid_Ch4.Text = sbus_out_value[Combox_CH4_REFER.SelectedIndex].ToString();

                if (Combox_CH5_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH5_REFER.SelectedIndex] = (short)((myUSBJoy.dButton & 0x00000001) * 600 + 1200);
                else
                    sbus_out_value[Combox_CH5_REFER.SelectedIndex] = (short)((1 - (myUSBJoy.dButton & 0x00000001)) * 600 + 1200);
                TextBlock_Usb_Hid_Ch5.Text = sbus_out_value[Combox_CH5_REFER.SelectedIndex].ToString();

                if (Combox_CH6_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH6_REFER.SelectedIndex] = (short)(((myUSBJoy.dButton & 0x00000002) >> 1) * 600 + 1200);
                else
                    sbus_out_value[Combox_CH6_REFER.SelectedIndex] = (short)((1 - ((myUSBJoy.dButton & 0x00000002) >> 1)) * 600 + 1200);
                TextBlock_Usb_Hid_Ch6.Text = sbus_out_value[Combox_CH6_REFER.SelectedIndex].ToString();

                if (Combox_CH7_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH7_REFER.SelectedIndex] = (short)(((myUSBJoy.dButton & 0x00000004) >> 2) * 600 + 1200);
                else
                    sbus_out_value[Combox_CH7_REFER.SelectedIndex] = (short)((1 - ((myUSBJoy.dButton & 0x00000004) >> 2)) * 600 + 1200);
                TextBlock_Usb_Hid_Ch7.Text = sbus_out_value[Combox_CH7_REFER.SelectedIndex].ToString();

                if (Combox_CH8_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH8_REFER.SelectedIndex] = (short)(((myUSBJoy.dButton & 0x00000008) >> 3) * 600 + 1200);
                else
                    sbus_out_value[Combox_CH8_REFER.SelectedIndex] = (short)((1 - ((myUSBJoy.dButton & 0x00000008) >> 3)) * 600 + 1200);
                TextBlock_Usb_Hid_Ch8.Text = sbus_out_value[Combox_CH8_REFER.SelectedIndex].ToString();

                if (Combox_CH9_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH9_REFER.SelectedIndex] = (short)(((myUSBJoy.dButton & 0x00000010) >> 4) * 600 + 1200);
                else
                    sbus_out_value[Combox_CH9_REFER.SelectedIndex] = (short)((1 - ((myUSBJoy.dButton & 0x00000010) >> 4)) * 600 + 1200);
                TextBlock_Usb_Hid_Ch9.Text = sbus_out_value[Combox_CH9_REFER.SelectedIndex].ToString();

                if (Combox_CH10_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH10_REFER.SelectedIndex] = (short)(((myUSBJoy.dButton & 0x00000020) >> 5) * 600 + 1200);
                else
                    sbus_out_value[Combox_CH10_REFER.SelectedIndex] = (short)((1 - ((myUSBJoy.dButton & 0x00000020) >> 5)) * 600 + 1200);
                TextBlock_Usb_Hid_Ch10.Text = sbus_out_value[Combox_CH10_REFER.SelectedIndex].ToString();

                if (Combox_CH11_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH11_REFER.SelectedIndex] = (short)(((myUSBJoy.dButton & 0x00000040) >> 6) * 600 + 1200);
                else
                    sbus_out_value[Combox_CH11_REFER.SelectedIndex] = (short)((1 - ((myUSBJoy.dButton & 0x00000040) >> 6)) * 600 + 1200);
                TextBlock_Usb_Hid_Ch11.Text = sbus_out_value[Combox_CH11_REFER.SelectedIndex].ToString();

                if (Combox_CH12_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH12_REFER.SelectedIndex] = (short)(((myUSBJoy.dButton & 0x00000080) >> 7) * 600 + 1200);
                else
                    sbus_out_value[Combox_CH12_REFER.SelectedIndex] = (short)((1 - ((myUSBJoy.dButton & 0x00000080) >> 7)) * 600 + 1200);
                TextBlock_Usb_Hid_Ch12.Text = sbus_out_value[Combox_CH12_REFER.SelectedIndex].ToString();
            }
            // ================================ 华之翼遥控器 ===========================
            else
            {
                if (Combox_CH1_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH1_REFER.SelectedIndex] = (short)(myUSBJoy.ndXpos * 1000 / 65535 + 1000);
                else
                    sbus_out_value[Combox_CH1_REFER.SelectedIndex] = (short)(-myUSBJoy.ndXpos * 1000 / 65535 + 2000);
                TextBlock_Usb_Hid_Ch1.Text = sbus_out_value[Combox_CH1_REFER.SelectedIndex].ToString();

                if (Combox_CH2_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH2_REFER.SelectedIndex] = (short)(myUSBJoy.ndYpos * 1000 / 65535 + 1000);
                else
                    sbus_out_value[Combox_CH2_REFER.SelectedIndex] = (short)(-myUSBJoy.ndYpos * 1000 / 65535 + 2000);
                TextBlock_Usb_Hid_Ch2.Text = sbus_out_value[Combox_CH2_REFER.SelectedIndex].ToString();

                if (Combox_CH3_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH3_REFER.SelectedIndex] = (short)(myUSBJoy.ndZpos * 1000 / 65535 + 1000);
                else
                    sbus_out_value[Combox_CH3_REFER.SelectedIndex] = (short)(-myUSBJoy.ndZpos * 1000 / 65535 + 2000);
                TextBlock_Usb_Hid_Ch3.Text = sbus_out_value[Combox_CH3_REFER.SelectedIndex].ToString();

                if (Combox_CH4_REVERSE.SelectedIndex == 0)
                    sbus_out_value[Combox_CH4_REFER.SelectedIndex] = (short)(myUSBJoy.ndwVpos * 1000 / 4095 + 1000);
                else
                    sbus_out_value[Combox_CH4_REFER.SelectedIndex] = (short)(-myUSBJoy.ndwVpos * 1000 / 4095 + 2000);
                TextBlock_Usb_Hid_Ch4.Text = sbus_out_value[Combox_CH4_REFER.SelectedIndex].ToString();

                //  =================== ch5 =================
                if(((myUSBJoy.dButton >> 6) & 0x00000003) == 1)
                    sbus_out_value[Combox_CH5_REFER.SelectedIndex] = 1200;
                else if(((myUSBJoy.dButton >> 6) & 0x00000003) == 2)
                    sbus_out_value[Combox_CH5_REFER.SelectedIndex] = 1800;
                else
                    sbus_out_value[Combox_CH5_REFER.SelectedIndex] = 1500;
                if (Combox_CH5_REVERSE.SelectedIndex == 1)
                    sbus_out_value[Combox_CH5_REFER.SelectedIndex]  = (short)(3000 - sbus_out_value[Combox_CH5_REFER.SelectedIndex]);
                TextBlock_Usb_Hid_Ch5.Text = sbus_out_value[Combox_CH5_REFER.SelectedIndex].ToString();

                // ================== ch6 ====================
                if (((myUSBJoy.dButton >> 8) & 0x00000003) == 1)
                    sbus_out_value[Combox_CH6_REFER.SelectedIndex] = 1200;
                else if (((myUSBJoy.dButton >> 8) & 0x00000003) == 2)
                    sbus_out_value[Combox_CH6_REFER.SelectedIndex] = 1800;
                else
                    sbus_out_value[Combox_CH6_REFER.SelectedIndex] = 1500;
                if (Combox_CH6_REVERSE.SelectedIndex == 1)
                    sbus_out_value[Combox_CH6_REFER.SelectedIndex] = (short)(3000 - sbus_out_value[Combox_CH6_REFER.SelectedIndex]);
                TextBlock_Usb_Hid_Ch6.Text = sbus_out_value[Combox_CH6_REFER.SelectedIndex].ToString();

                // ================== ch7 ====================
                if (((myUSBJoy.dButton >> 12) & 0x00000001) == 1)
                    sbus_out_value[Combox_CH7_REFER.SelectedIndex] = 1800;
                else
                    sbus_out_value[Combox_CH7_REFER.SelectedIndex] = 1200;
                if (Combox_CH7_REVERSE.SelectedIndex == 1)
                    sbus_out_value[Combox_CH7_REFER.SelectedIndex] = (short)(3000 - sbus_out_value[Combox_CH7_REFER.SelectedIndex]);
                TextBlock_Usb_Hid_Ch7.Text = sbus_out_value[Combox_CH7_REFER.SelectedIndex].ToString();

                // ================== ch8 ====================
                if (((myUSBJoy.dButton >> 13) & 0x00000001) == 1)
                    sbus_out_value[Combox_CH8_REFER.SelectedIndex] = 1800;
                else
                    sbus_out_value[Combox_CH8_REFER.SelectedIndex] = 1200;
                if (Combox_CH8_REVERSE.SelectedIndex == 1)
                    sbus_out_value[Combox_CH8_REFER.SelectedIndex] = (short)(3000 - sbus_out_value[Combox_CH8_REFER.SelectedIndex]);
                TextBlock_Usb_Hid_Ch8.Text = sbus_out_value[Combox_CH8_REFER.SelectedIndex].ToString();

                // ================== ch9 ====================
                if (((myUSBJoy.dButton >> 14) & 0x00000001) == 1)
                    sbus_out_value[Combox_CH9_REFER.SelectedIndex] = 1800;
                else
                    sbus_out_value[Combox_CH9_REFER.SelectedIndex] = 1200;
                if (Combox_CH9_REVERSE.SelectedIndex == 1)
                    sbus_out_value[Combox_CH9_REFER.SelectedIndex] = (short)(3000 - sbus_out_value[Combox_CH9_REFER.SelectedIndex]);
                TextBlock_Usb_Hid_Ch9.Text = sbus_out_value[Combox_CH9_REFER.SelectedIndex].ToString();

                // ================== ch10 ====================
                if (((myUSBJoy.dButton >> 15) & 0x00000001) == 1)
                    sbus_out_value[Combox_CH10_REFER.SelectedIndex] = 1800;
                else
                    sbus_out_value[Combox_CH10_REFER.SelectedIndex] = 1200;
                if (Combox_CH10_REVERSE.SelectedIndex == 1)
                    sbus_out_value[Combox_CH10_REFER.SelectedIndex] = (short)(3000 - sbus_out_value[Combox_CH10_REFER.SelectedIndex]);
                TextBlock_Usb_Hid_Ch10.Text = sbus_out_value[Combox_CH10_REFER.SelectedIndex].ToString();

                // ================== ch11 ====================
                if (((myUSBJoy.dButton >> 16) & 0x00000001) == 1)
                    sbus_out_value[Combox_CH11_REFER.SelectedIndex] = 1800;
                else
                    sbus_out_value[Combox_CH11_REFER.SelectedIndex] = 1200;
                if (Combox_CH11_REVERSE.SelectedIndex == 1)
                    sbus_out_value[Combox_CH11_REFER.SelectedIndex] = (short)(3000 - sbus_out_value[Combox_CH11_REFER.SelectedIndex]);
                TextBlock_Usb_Hid_Ch11.Text = sbus_out_value[Combox_CH11_REFER.SelectedIndex].ToString();

                // ================== ch12 ====================
                if (((myUSBJoy.dButton>>4) & 0x00000001) == 1)
                    sbus_out_value[Combox_CH12_REFER.SelectedIndex] = 1800;
                else
                    sbus_out_value[Combox_CH12_REFER.SelectedIndex] = 1200;
                if (Combox_CH12_REVERSE.SelectedIndex == 1)
                    sbus_out_value[Combox_CH12_REFER.SelectedIndex] = (short)(3000 - sbus_out_value[Combox_CH12_REFER.SelectedIndex]);
                TextBlock_Usb_Hid_Ch12.Text = sbus_out_value[Combox_CH12_REFER.SelectedIndex].ToString();

                /*TextBlock_Usb_Hid_Ch7.Text = Convert.ToString(myUSBJoy.dButton, 2);//myUSBJoy.dButton.ToString();
                TextBlock_Usb_Hid_Ch8.Text = myUSBJoy.dButton.ToString();
                TextBlock_Usb_Hid_Ch9.Text = " ";
                TextBlock_Usb_Hid_Ch10.Text = "";
                TextBlock_Usb_Hid_Ch11.Text = "";
                TextBlock_Usb_Hid_Ch12.Text = " ";*/
            }
            // 如果4---12通道有按键发生了变化，则先发送
            for (i = 4; i < 12; i++)
            {
                if (sbus_out_value_last[i] != sbus_out_value[i])
                {
                    yuntai_msg_type = (byte)(i + 1);

                    if (hid_send_coun++ >= 5)
                    {
                        hid_send_coun = 0;
                        sbus_out_value_last[i] = sbus_out_value[i];
                    }
                    break;
                }
            }
            // 如果4---12通道没有操作，则将计数器置0
            if (i == 12)
                hid_send_coun = 0;

            DataProcess_JD.mSBus_JD.sbus_type = 0;
            DataProcess_JD.mSBus_JD.sbus_id = yuntai_msg_type;

            DataProcess_JD.mSBus_JD.sbus_value = sbus_out_value[yuntai_msg_type-1];
            DATA_LINK.sendbuf_VIK(MsgDef.MSG_GIMBAL);

            // 前4个通道循环发送
            yuntai_msg_type++;
            if (yuntai_msg_type >= 5)
                yuntai_msg_type = 1;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {
            }
        }

        /******************************************************************
         * function: save the usb hid information
         * para:
         * return:
         * ****************************************************************/
        public void Save_All_Usb_Hid_Device()
        {
            string str_path = Directory.GetCurrentDirectory() + "\\USB_HID_DEVICE.XML";

            FileStream afile = new FileStream(str_path, FileMode.Create);
            XmlTextWriter writer = new XmlTextWriter(afile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();

            writer.WriteStartElement("USB_HID_DEVICE");
            writer.WriteStartElement("Device_Num");
            writer.WriteElementString("Total_Num", m_usb_hid_list.Count.ToString());
            writer.WriteEndElement(); // 关闭元素

            //向先前创建的元素中添加一个属性
            for (int i = 0; i < m_usb_hid_list.Count; i++)
            {
                writer.WriteStartElement("Item" + (i + 1).ToString());
                writer.WriteElementString("Name_ID", m_usb_hid_list[i].nameId);

                writer.WriteElementString("Ch1_Name", m_usb_hid_list[i].ch1_name);
                writer.WriteElementString("Ch2_Name", m_usb_hid_list[i].ch2_name);
                writer.WriteElementString("Ch3_Name", m_usb_hid_list[i].ch3_name);
                writer.WriteElementString("Ch4_Name", m_usb_hid_list[i].ch4_name);
                writer.WriteElementString("Ch5_Name", m_usb_hid_list[i].ch5_name);
                writer.WriteElementString("Ch6_Name", m_usb_hid_list[i].ch6_name);
                writer.WriteElementString("Ch7_Name", m_usb_hid_list[i].ch7_name);
                writer.WriteElementString("Ch8_Name", m_usb_hid_list[i].ch8_name);
                writer.WriteElementString("Ch9_Name", m_usb_hid_list[i].ch9_name);
                writer.WriteElementString("Ch10_Name", m_usb_hid_list[i].ch10_name);
                writer.WriteElementString("Ch11_Name", m_usb_hid_list[i].ch11_name);
                writer.WriteElementString("Ch12_Name", m_usb_hid_list[i].ch12_name);

                writer.WriteElementString("Ch1_Mapping", m_usb_hid_list[i].ch1_mapping.ToString());
                writer.WriteElementString("Ch2_Mapping", m_usb_hid_list[i].ch2_mapping.ToString());
                writer.WriteElementString("Ch3_Mapping", m_usb_hid_list[i].ch3_mapping.ToString());
                writer.WriteElementString("Ch4_Mapping", m_usb_hid_list[i].ch4_mapping.ToString());
                writer.WriteElementString("Ch5_Mapping", m_usb_hid_list[i].ch5_mapping.ToString());
                writer.WriteElementString("Ch6_Mapping", m_usb_hid_list[i].ch6_mapping.ToString());
                writer.WriteElementString("Ch7_Mapping", m_usb_hid_list[i].ch7_mapping.ToString());
                writer.WriteElementString("Ch8_Mapping", m_usb_hid_list[i].ch8_mapping.ToString());
                writer.WriteElementString("Ch9_Mapping", m_usb_hid_list[i].ch9_mapping.ToString());
                writer.WriteElementString("Ch10_Mapping", m_usb_hid_list[i].ch10_mapping.ToString());
                writer.WriteElementString("Ch11_Mapping", m_usb_hid_list[i].ch11_mapping.ToString());
                writer.WriteElementString("Ch12_Mapping", m_usb_hid_list[i].ch12_mapping.ToString());

                writer.WriteElementString("Ch1_Reverse", m_usb_hid_list[i].ch1_reverse.ToString());
                writer.WriteElementString("Ch2_Reverse", m_usb_hid_list[i].ch2_reverse.ToString());
                writer.WriteElementString("Ch3_Reverse", m_usb_hid_list[i].ch3_reverse.ToString());
                writer.WriteElementString("Ch4_Reverse", m_usb_hid_list[i].ch4_reverse.ToString());
                writer.WriteElementString("Ch5_Reverse", m_usb_hid_list[i].ch5_reverse.ToString());
                writer.WriteElementString("Ch6_Reverse", m_usb_hid_list[i].ch6_reverse.ToString());
                writer.WriteElementString("Ch7_Reverse", m_usb_hid_list[i].ch7_reverse.ToString());
                writer.WriteElementString("Ch8_Reverse", m_usb_hid_list[i].ch8_reverse.ToString());
                writer.WriteElementString("Ch9_Reverse", m_usb_hid_list[i].ch9_reverse.ToString());
                writer.WriteElementString("Ch10_Reverse", m_usb_hid_list[i].ch10_reverse.ToString());
                writer.WriteElementString("Ch11_Reverse", m_usb_hid_list[i].ch11_reverse.ToString());
                writer.WriteElementString("Ch12_Reverse", m_usb_hid_list[i].ch12_reverse.ToString());

                writer.WriteElementString("RTSP", m_usb_hid_list[i].rtsp_addr.ToString());
                writer.WriteEndElement(); // 关闭元素
            }
            writer.Close();
            afile.Close();
        }

        /****************************************************************
        * 功   能：加载sbus配置列表
        * 参   数：
        * 返   回：
        * *************************************************************/
        private void Load_Usb_Hid_List()
        {
            string str_path = Directory.GetCurrentDirectory() + "\\USB_HID_DEVICE.XML";
            FileStream afile = new FileStream(str_path, FileMode.Open, FileAccess.Read);

            if (afile.Length < 50)
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(afile);

            XmlNode xn = doc.SelectSingleNode("USB_HID_DEVICE");
            XmlNode xn1 = xn.SelectSingleNode("Device_Num");
            XmlNode xn_IdAllNum = xn1.SelectSingleNode("Total_Num");

            int count_way = int.Parse(xn_IdAllNum.InnerText);
            if (count_way < 1)
                return;

            for (int i = 0; i < count_way; i++)
            {
                XmlNode xn_item = xn.SelectSingleNode("Item" + (i + 1).ToString());
                XmlNode xn_Name = xn_item.SelectSingleNode("Name_ID");

                XmlNode xn_Ch1_Name = xn_item.SelectSingleNode("Ch1_Name");
                XmlNode xn_Ch2_Name = xn_item.SelectSingleNode("Ch2_Name");
                XmlNode xn_Ch3_Name = xn_item.SelectSingleNode("Ch3_Name");
                XmlNode xn_Ch4_Name = xn_item.SelectSingleNode("Ch4_Name");
                XmlNode xn_Ch5_Name = xn_item.SelectSingleNode("Ch5_Name");
                XmlNode xn_Ch6_Name = xn_item.SelectSingleNode("Ch6_Name");
                XmlNode xn_Ch7_Name = xn_item.SelectSingleNode("Ch7_Name");
                XmlNode xn_Ch8_Name = xn_item.SelectSingleNode("Ch8_Name");
                XmlNode xn_Ch9_Name = xn_item.SelectSingleNode("Ch9_Name");
                XmlNode xn_Ch10_Name = xn_item.SelectSingleNode("Ch10_Name");
                XmlNode xn_Ch11_Name = xn_item.SelectSingleNode("Ch11_Name");
                XmlNode xn_Ch12_Name = xn_item.SelectSingleNode("Ch12_Name");

                XmlNode xn_Ch1_Mapping = xn_item.SelectSingleNode("Ch1_Mapping");
                XmlNode xn_Ch2_Mapping = xn_item.SelectSingleNode("Ch2_Mapping");
                XmlNode xn_Ch3_Mapping = xn_item.SelectSingleNode("Ch3_Mapping");
                XmlNode xn_Ch4_Mapping = xn_item.SelectSingleNode("Ch4_Mapping");
                XmlNode xn_Ch5_Mapping = xn_item.SelectSingleNode("Ch5_Mapping");
                XmlNode xn_Ch6_Mapping = xn_item.SelectSingleNode("Ch6_Mapping");
                XmlNode xn_Ch7_Mapping = xn_item.SelectSingleNode("Ch7_Mapping");
                XmlNode xn_Ch8_Mapping = xn_item.SelectSingleNode("Ch8_Mapping");
                XmlNode xn_Ch9_Mapping = xn_item.SelectSingleNode("Ch9_Mapping");
                XmlNode xn_Ch10_Mapping = xn_item.SelectSingleNode("Ch10_Mapping");
                XmlNode xn_Ch11_Mapping = xn_item.SelectSingleNode("Ch11_Mapping");
                XmlNode xn_Ch12_Mapping = xn_item.SelectSingleNode("Ch12_Mapping");

                XmlNode xn_Ch1_Reverse = xn_item.SelectSingleNode("Ch1_Reverse");
                XmlNode xn_Ch2_Reverse = xn_item.SelectSingleNode("Ch2_Reverse");
                XmlNode xn_Ch3_Reverse = xn_item.SelectSingleNode("Ch3_Reverse");
                XmlNode xn_Ch4_Reverse = xn_item.SelectSingleNode("Ch4_Reverse");
                XmlNode xn_Ch5_Reverse = xn_item.SelectSingleNode("Ch5_Reverse");
                XmlNode xn_Ch6_Reverse = xn_item.SelectSingleNode("Ch6_Reverse");
                XmlNode xn_Ch7_Reverse = xn_item.SelectSingleNode("Ch7_Reverse");
                XmlNode xn_Ch8_Reverse = xn_item.SelectSingleNode("Ch8_Reverse");
                XmlNode xn_Ch9_Reverse = xn_item.SelectSingleNode("Ch9_Reverse");
                XmlNode xn_Ch10_Reverse = xn_item.SelectSingleNode("Ch10_Reverse");
                XmlNode xn_Ch11_Reverse = xn_item.SelectSingleNode("Ch11_Reverse");
                XmlNode xn_Ch12_Reverse = xn_item.SelectSingleNode("Ch12_Reverse");

                XmlNode xn_rtsp_addr = xn_item.SelectSingleNode("RTSP");

                USB_HID usb_temp = new USB_HID();

                if (i == 0)
                    usb_temp.nameId = TryFindResource("TITLE_USB_HID_VK").ToString();
                else if(i == 1)
                    usb_temp.nameId = TryFindResource("TITLE_USB_HID_HUA_ZHI_YI").ToString();

                usb_temp.ch1_name = xn_Ch1_Name.InnerText;
                usb_temp.ch2_name = xn_Ch2_Name.InnerText;
                usb_temp.ch3_name = xn_Ch3_Name.InnerText;
                usb_temp.ch4_name = xn_Ch4_Name.InnerText;
                usb_temp.ch5_name = xn_Ch5_Name.InnerText;
                usb_temp.ch6_name = xn_Ch6_Name.InnerText;
                usb_temp.ch7_name = xn_Ch7_Name.InnerText;
                usb_temp.ch8_name = xn_Ch8_Name.InnerText;
                usb_temp.ch9_name = xn_Ch9_Name.InnerText;
                usb_temp.ch10_name = xn_Ch10_Name.InnerText;
                usb_temp.ch11_name = xn_Ch11_Name.InnerText;
                usb_temp.ch12_name = xn_Ch12_Name.InnerText;

                usb_temp.ch1_mapping = byte.Parse(xn_Ch1_Mapping.InnerText);
                usb_temp.ch2_mapping = byte.Parse(xn_Ch2_Mapping.InnerText);
                usb_temp.ch3_mapping = byte.Parse(xn_Ch3_Mapping.InnerText);
                usb_temp.ch4_mapping = byte.Parse(xn_Ch4_Mapping.InnerText);
                usb_temp.ch5_mapping = byte.Parse(xn_Ch5_Mapping.InnerText);
                usb_temp.ch6_mapping = byte.Parse(xn_Ch6_Mapping.InnerText);
                usb_temp.ch7_mapping = byte.Parse(xn_Ch7_Mapping.InnerText);
                usb_temp.ch8_mapping = byte.Parse(xn_Ch8_Mapping.InnerText);
                usb_temp.ch9_mapping = byte.Parse(xn_Ch9_Mapping.InnerText);
                usb_temp.ch10_mapping = byte.Parse(xn_Ch10_Mapping.InnerText);
                usb_temp.ch11_mapping = byte.Parse(xn_Ch11_Mapping.InnerText);
                usb_temp.ch12_mapping = byte.Parse(xn_Ch12_Mapping.InnerText);

                usb_temp.ch1_reverse = byte.Parse(xn_Ch1_Reverse.InnerText);
                usb_temp.ch2_reverse = byte.Parse(xn_Ch2_Reverse.InnerText);
                usb_temp.ch3_reverse = byte.Parse(xn_Ch3_Reverse.InnerText);
                usb_temp.ch4_reverse = byte.Parse(xn_Ch4_Reverse.InnerText);
                usb_temp.ch5_reverse = byte.Parse(xn_Ch5_Reverse.InnerText);
                usb_temp.ch6_reverse = byte.Parse(xn_Ch6_Reverse.InnerText);
                usb_temp.ch7_reverse = byte.Parse(xn_Ch7_Reverse.InnerText);
                usb_temp.ch8_reverse = byte.Parse(xn_Ch8_Reverse.InnerText);
                usb_temp.ch9_reverse = byte.Parse(xn_Ch9_Reverse.InnerText);
                usb_temp.ch10_reverse = byte.Parse(xn_Ch10_Reverse.InnerText);
                usb_temp.ch11_reverse = byte.Parse(xn_Ch11_Reverse.InnerText);
                usb_temp.ch12_reverse = byte.Parse(xn_Ch12_Reverse.InnerText);

                usb_temp.rtsp_addr = xn_rtsp_addr.InnerText;

                m_usb_hid_list.Add(usb_temp);
            }

            Show_Usb_Infor(m_usb_hid_list[0]);
            afile.Close();
        }

        private void Wnd_Video_Control_Loaded(object sender, RoutedEventArgs e)
        {
            Load_Usb_Hid_List();

            for (byte i = 0; i < 12; i++)
            {
                sbus_out_value[i] = 1200;
                sbus_out_value_last[i] = 1200;
            }
        }

        /*******************************************************************
         * function:
         * para:
         * return:
         * *****************************************************************/
        private void Show_Usb_Infor(USB_HID usbHid)
        {
            TextBox_Usb_Hid_Ch1_Description.Text = usbHid.ch1_name;
            TextBox_Usb_Hid_Ch2_Description.Text = usbHid.ch2_name;
            TextBox_Usb_Hid_Ch3_Description.Text = usbHid.ch3_name;
            TextBox_Usb_Hid_Ch4_Description.Text = usbHid.ch4_name;
            TextBox_Usb_Hid_Ch5_Description.Text = usbHid.ch5_name;
            TextBox_Usb_Hid_Ch6_Description.Text = usbHid.ch6_name;
            TextBox_Usb_Hid_Ch7_Description.Text = usbHid.ch7_name;
            TextBox_Usb_Hid_Ch8_Description.Text = usbHid.ch8_name;
            TextBox_Usb_Hid_Ch9_Description.Text = usbHid.ch9_name;
            TextBox_Usb_Hid_Ch10_Description.Text = usbHid.ch10_name;
            TextBox_Usb_Hid_Ch11_Description.Text = usbHid.ch11_name;
            TextBox_Usb_Hid_Ch12_Description.Text = usbHid.ch12_name;

            Combox_CH1_REFER.SelectedIndex = usbHid.ch1_mapping;
            Combox_CH2_REFER.SelectedIndex = usbHid.ch2_mapping;
            Combox_CH3_REFER.SelectedIndex = usbHid.ch3_mapping;
            Combox_CH4_REFER.SelectedIndex = usbHid.ch4_mapping;
            Combox_CH5_REFER.SelectedIndex = usbHid.ch5_mapping;
            Combox_CH6_REFER.SelectedIndex = usbHid.ch6_mapping;
            Combox_CH7_REFER.SelectedIndex = usbHid.ch7_mapping;
            Combox_CH8_REFER.SelectedIndex = usbHid.ch8_mapping;
            Combox_CH9_REFER.SelectedIndex = usbHid.ch9_mapping;
            Combox_CH10_REFER.SelectedIndex = usbHid.ch10_mapping;
            Combox_CH11_REFER.SelectedIndex = usbHid.ch11_mapping;
            Combox_CH12_REFER.SelectedIndex = usbHid.ch12_mapping;

            Combox_CH1_REVERSE.SelectedIndex = usbHid.ch1_reverse;
            Combox_CH2_REVERSE.SelectedIndex = usbHid.ch2_reverse;
            Combox_CH3_REVERSE.SelectedIndex = usbHid.ch3_reverse;
            Combox_CH4_REVERSE.SelectedIndex = usbHid.ch4_reverse;
            Combox_CH5_REVERSE.SelectedIndex = usbHid.ch5_reverse;
            Combox_CH6_REVERSE.SelectedIndex = usbHid.ch6_reverse;
            Combox_CH7_REVERSE.SelectedIndex = usbHid.ch7_reverse;
            Combox_CH8_REVERSE.SelectedIndex = usbHid.ch8_reverse;
            Combox_CH9_REVERSE.SelectedIndex = usbHid.ch9_reverse;
            Combox_CH10_REVERSE.SelectedIndex = usbHid.ch10_reverse;
            Combox_CH11_REVERSE.SelectedIndex = usbHid.ch11_reverse;
            Combox_CH12_REVERSE.SelectedIndex = usbHid.ch12_reverse;

            Page_Fly_Map.formWnd.Set_Rtsp_Addr(usbHid.rtsp_addr);
        }

        /*******************************************************************
         * function: save 
         * para:
         * return:
         * *****************************************************************/
        public void Save_Cur_Usb_Infor(byte index)
        {
            USB_HID usbHid = new USB_HID();
            usbHid.ch1_name = TextBox_Usb_Hid_Ch1_Description.Text;
            usbHid.ch2_name = TextBox_Usb_Hid_Ch2_Description.Text;
            usbHid.ch3_name = TextBox_Usb_Hid_Ch3_Description.Text;
            usbHid.ch4_name = TextBox_Usb_Hid_Ch4_Description.Text;
            usbHid.ch5_name = TextBox_Usb_Hid_Ch5_Description.Text;
            usbHid.ch6_name = TextBox_Usb_Hid_Ch6_Description.Text;
            usbHid.ch7_name = TextBox_Usb_Hid_Ch7_Description.Text;
            usbHid.ch8_name = TextBox_Usb_Hid_Ch8_Description.Text;
            usbHid.ch9_name = TextBox_Usb_Hid_Ch9_Description.Text;
            usbHid.ch10_name = TextBox_Usb_Hid_Ch10_Description.Text;
            usbHid.ch11_name = TextBox_Usb_Hid_Ch11_Description.Text;
            usbHid.ch12_name = TextBox_Usb_Hid_Ch12_Description.Text;

            usbHid.ch1_mapping = (byte)Combox_CH1_REFER.SelectedIndex;
            usbHid.ch2_mapping = (byte)Combox_CH2_REFER.SelectedIndex;
            usbHid.ch3_mapping = (byte)Combox_CH3_REFER.SelectedIndex;
            usbHid.ch4_mapping = (byte)Combox_CH4_REFER.SelectedIndex;
            usbHid.ch5_mapping = (byte)Combox_CH5_REFER.SelectedIndex;
            usbHid.ch6_mapping = (byte)Combox_CH6_REFER.SelectedIndex;
            usbHid.ch7_mapping = (byte)Combox_CH7_REFER.SelectedIndex;
            usbHid.ch8_mapping = (byte)Combox_CH8_REFER.SelectedIndex;
            usbHid.ch9_mapping = (byte)Combox_CH9_REFER.SelectedIndex;
            usbHid.ch10_mapping = (byte)Combox_CH10_REFER.SelectedIndex;
            usbHid.ch11_mapping = (byte)Combox_CH11_REFER.SelectedIndex;
            usbHid.ch12_mapping = (byte)Combox_CH12_REFER.SelectedIndex;

            usbHid.ch1_reverse = (byte)Combox_CH1_REVERSE.SelectedIndex;
            usbHid.ch2_reverse = (byte)Combox_CH2_REVERSE.SelectedIndex;
            usbHid.ch3_reverse = (byte)Combox_CH3_REVERSE.SelectedIndex;
            usbHid.ch4_reverse = (byte)Combox_CH4_REVERSE.SelectedIndex;
            usbHid.ch5_reverse = (byte)Combox_CH5_REVERSE.SelectedIndex;
            usbHid.ch6_reverse = (byte)Combox_CH6_REVERSE.SelectedIndex;
            usbHid.ch7_reverse = (byte)Combox_CH7_REVERSE.SelectedIndex;
            usbHid.ch8_reverse = (byte)Combox_CH8_REVERSE.SelectedIndex;
            usbHid.ch9_reverse = (byte)Combox_CH9_REVERSE.SelectedIndex;
            usbHid.ch10_reverse = (byte)Combox_CH10_REVERSE.SelectedIndex;
            usbHid.ch11_reverse = (byte)Combox_CH11_REVERSE.SelectedIndex;
            usbHid.ch12_reverse = (byte)Combox_CH12_REVERSE.SelectedIndex;

            usbHid.rtsp_addr = Page_Fly_Map.formWnd.Get_Rtsp_Addr();

            m_usb_hid_list.RemoveAt(index);
            m_usb_hid_list.Insert(index, usbHid);
        }

        /*************************************************************************
         * function: callback of combox selectoin changed
         * para:
         * return:
         * ************************************************************************/
        private byte select_last = 0;
        private void Combox_Usb_Device_Changed(object sender, SelectionChangedEventArgs e)
        {
            byte index = (byte)Combox_Usb_Device.SelectedIndex;

            if (index >= 0 && m_usb_hid_list.Count > 0)
            {
                Save_Cur_Usb_Infor(select_last);
                Show_Usb_Infor(m_usb_hid_list[index]);
            }

            select_last = index;
        }

        private void Btn_Save_Cur_Hid_Click(object sender, RoutedEventArgs e)
        {
            Save_Cur_Usb_Infor((byte)(Combox_Usb_Device.SelectedIndex));
            Save_All_Usb_Hid_Device();
        }
    }
}
