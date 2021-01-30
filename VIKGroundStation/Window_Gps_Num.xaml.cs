using System;
using System.Collections.Generic;
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
    /// Window_Gps_Num.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Gps_Num : Window
    {
        private static Window_Gps_Num m_wnd_gps_num = new Window_Gps_Num();
        public static Window_Gps_Num getInstance()
        {
            if (m_wnd_gps_num == null)
                m_wnd_gps_num = new Window_Gps_Num();
            return m_wnd_gps_num;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;

        public static void Wnd_Show()
        {
            Window_Gps_Num hWnd = getInstance();
            hWnd.Show();
            mb_wnd_visible = true;
            mb_wnd_initializaed = true;
        }

        public static void Wnd_Hide()
        {
            Window_Gps_Num hWnd = getInstance();
            hWnd.Hide();
            mb_wnd_visible = false;
        }

        public Window_Gps_Num()
        {
            InitializeComponent();
            Top = SystemParameters.PrimaryScreenHeight * 0.95 - this.Height;
            Left = SystemParameters.PrimaryScreenWidth * 0.03;

            Hide();
            Owner = MainWindow.getInstance();
        }

        /*******************************************************************************
         * function: show m8n/ant1/ant2 gps number
         * para:
         * return:
         * *****************************************************************************/
        public void UpdateInfor()
        {
            byte sys_id_set = DATA_LINK.Get_System_Set_Id();
            FLY_INFOR_DISPLAY mFly_Infor_Display = DataProcess_JD.Get_Fly_Display(sys_id_set);

            if ((byte)(mFly_Infor_Display.gps_status & 0x04) == (byte)0x04)
            {
                TextBlock_ANT1.Text = "RTK ANT1: " + mFly_Infor_Display.gps_num2.ToString();
                TextBlock_ANT2.Text = "RTK ANT2: " + mFly_Infor_Display.rtk_ant2.ToString();
                TextBlock_GPS_Num.Text = "GPS NUM: " + mFly_Infor_Display.gps_num.ToString();
            }
            else
            {
                TextBlock_ANT1.Text = "RTK ANT1:  " + mFly_Infor_Display.gps_num.ToString();
                TextBlock_ANT2.Text = "RTK ANT2:  " + mFly_Infor_Display.rtk_ant2.ToString();
                TextBlock_GPS_Num.Text = "GPS NUM:  " + mFly_Infor_Display.gps_num2.ToString();
            }
        }
    }
}
