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
    /// Window_Set_Home.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Set_Home : Window
    {
        private static Window_Set_Home m_wnd_set_home = new Window_Set_Home();
        public static Window_Set_Home getInstance()
        {
            if (m_wnd_set_home == null)
                m_wnd_set_home = new Window_Set_Home();
            return m_wnd_set_home;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;

        public static void Wnd_Show()
        {
            Window_Set_Home hWnd = getInstance();
            hWnd.Show();
            mb_wnd_visible = true;
            mb_wnd_initializaed = true;
        }

        public static void Wnd_Hide()
        {
            Window_Set_Home hWnd = getInstance();
            hWnd.Hide();
            mb_wnd_visible = false;
        }

        public Window_Set_Home()
        {
            InitializeComponent();
            Top = SystemParameters.PrimaryScreenHeight * 10 / 16;
            Left = SystemParameters.PrimaryScreenWidth * 0.05;

            TextBox_Home_Lon.Text = ((double)lon_home / 10000000).ToString("0.0000000");
            TextBox_Home_Lat.Text = ((double)lat_home / 10000000).ToString("0.0000000");

            Hide();
            Owner = MainWindow.getInstance();
        }

        /****************************************************************************
         * function: send home information to the plane
         * para:
         * return:
         * **************************************************************************/
        private static int lon_home = 0, lat_home = 0;
        private void BTN_CONFIRM_HOME_POS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lon_home = (int)(double.Parse(TextBox_Home_Lon.Text) * 10000000);
                lat_home = (int)(double.Parse(TextBox_Home_Lat.Text) * 10000000);

                int gps_alt_home = (int)(double.Parse(TextBox_Home_Gps_Alt.Text) * 100);
                short heading_home = (short)(double.Parse(TextBox_Home_Heading.Text));

                DATA_LINK.Send_Home_Pos(0, lon_home, lat_home, gps_alt_home, heading_home);

                Page_2D_Map.Add_Home_Marker("", (double)lon_home / 10000000, (double)lat_home / 10000000, 0);

                this.Hide();
                mb_wnd_visible = false;

                Page_2D_Map.addptbool = 0;
            }
            catch//(Exception ex)
            {
                MessageBox.Show("Error Input"); 
            }
        }


        /****************************************************************************
        * function:
        * para:
        * return:
        * **************************************************************************/
        private void BTN_EXIT_HOME_POS_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            mb_wnd_visible = false;

            Page_2D_Map.addptbool = 0;
            Page_2D_Map.Del_Home_Marker();
        }


        /****************************************************************************
        * function:
        * para:
        * return:
        * **************************************************************************/
        public static void Update_Home_Pos_Text(double argLon, double argLat)
        {
            Window_Set_Home hWnd = getInstance();

            hWnd.TextBox_Home_Lon.Text = argLon.ToString("0.0000000");
            hWnd.TextBox_Home_Lat.Text = argLat.ToString("0.0000000");
        }
    }
}
