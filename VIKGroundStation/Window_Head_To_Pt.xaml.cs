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
    /// Window_Head_To_Pt.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Head_To_Pt : Window
    {
        private static Window_Head_To_Pt m_wnd_head_to_pt = new Window_Head_To_Pt();
        public static Window_Head_To_Pt getInstance()
        {
            if (m_wnd_head_to_pt == null)
                m_wnd_head_to_pt = new Window_Head_To_Pt();
            return m_wnd_head_to_pt;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;

        public static void Wnd_Show()
        {
            Window_Head_To_Pt hWnd = getInstance();
            hWnd.Show();
            mb_wnd_visible = true;
            mb_wnd_initializaed = true;
        }

        public static void Wnd_Hide()
        {
            Window_Head_To_Pt hWnd = getInstance();
            hWnd.Hide();
            mb_wnd_visible = false;
        }


        public Window_Head_To_Pt()
        {
            InitializeComponent();

            Top = SystemParameters.PrimaryScreenHeight * 10 / 16;
            Left = SystemParameters.PrimaryScreenWidth * 0.05;

            Hide();
            Owner = MainWindow.getInstance();

            Combox_Hot_Style.Items.Add(TryFindResource("TITLE_PLANE_FOCUS"));
            Combox_Hot_Style.Items.Add(TryFindResource("TITLE_GIMBLE_FOCUS"));
            Combox_Hot_Style.SelectedIndex = hot_style;

            TextBox_HOT_PT_LON.Text = ((double)hot_pt_lon / 10000000).ToString("0.0000000");
            TextBox_HOT_PT_LAT.Text = ((double)hot_pt_lat / 10000000).ToString("0.0000000");
            TextBox_HOT_PT_LEVEL_ALT.Text = ((double)hot_pt_alt / 100).ToString("0.0");

            if (App.plane_type == 1 || App.plane_type == 2)
            {
                TextBlock_Wnd_Name.Text = TryFindResource("TITLE_RETURN_CIRCLE_PT").ToString();
                TextBox_HOT_PT_LEVEL_ALT.IsEnabled = false;
                TextBox_HOT_PT_LEVEL_ALT.Foreground = Brushes.Gray;

                Combox_Hot_Style.IsEnabled = false;
                Combox_Hot_Style.Foreground = Brushes.Gray;
            }
        }

        public static int hot_pt_lon = 0, hot_pt_lat = 0, hot_pt_alt = 0;
        public static byte hot_style = 0;
        private void BTN_CONFIRM_HOT_PT_POS_Click(object sender, RoutedEventArgs e)
        {
            hot_pt_lon = (int)(double.Parse(TextBox_HOT_PT_LON.Text) * 10000000);
            hot_pt_lat = (int)(double.Parse(TextBox_HOT_PT_LAT.Text) * 10000000);
            hot_pt_alt = (int)(double.Parse(TextBox_HOT_PT_LEVEL_ALT.Text) * 100);
            hot_style = (byte)Combox_Hot_Style.SelectedIndex;

            if (App.plane_type == 0)
            {
                DATA_LINK.Send_Hot_Point_Pos(0, hot_pt_lon, hot_pt_lat, hot_pt_alt, hot_style);
            }
            else
            {
                DATA_LINK.Send_Return_Circle_Pos(hot_pt_lon, hot_pt_lat);
            }
            Page_2D_Map.Add_Hot_Point_Marker("", (double)hot_pt_lon / 10000000, (double)hot_pt_lat / 10000000, 0);

            this.Hide();
            mb_wnd_visible = false;
            Page_2D_Map.addptbool = 0;
        }

        private void BTN_EXIT_HOT_PT_POS_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, 47, 0);

            this.Hide();
            mb_wnd_visible = false;

            Page_2D_Map.Del_Hot_Point_Marker();
            Page_2D_Map.addptbool = 0;
        }

        /****************************************************************************
        * function:
        * para:
        * return:
        * **************************************************************************/
        public void Update_Home_Pos_Text(double argLon, double argLat)
        {
            TextBox_HOT_PT_LON.Text = argLon.ToString("0.0000000");
            TextBox_HOT_PT_LAT.Text = argLat.ToString("0.0000000");
        }
    }
}
