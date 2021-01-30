using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
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
    /// Window_Radar.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Radar : Window
    {
        private static Window_Radar m_wnd_radar = new Window_Radar();
        public static Window_Radar getInstance()
        {
            if (m_wnd_radar == null)
                m_wnd_radar = new Window_Radar();
            return m_wnd_radar;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;

        private SoundPlayer player = new SoundPlayer();

        public Window_Radar()
        {
            InitializeComponent();
            player.SoundLocation = Environment.CurrentDirectory + "//wav//radar_alert.wav";

            this.Top = (SystemParameters.PrimaryScreenHeight - this.Height) * 0.1;
            this.Left = (SystemParameters.PrimaryScreenWidth - this.Width) * 0.5;

            Hide();
            Owner = MainWindow.getInstance();
        }

        /***************************************************************
         * function:
         * para:
         * return:
         * **************************************************************/
        private byte radar_arrive_count = 0;
        public  void Radar_Display(double front_radar_dist, double back_radar_dist)
        {
            if (MainWindow.page_Index != 2)
            {
                Hide();
                return;
            }

            if ((front_radar_dist > 20 || front_radar_dist <= 0) && (back_radar_dist > 20 || back_radar_dist <= 0))
            {
                Hide();
                return;
            }
            else
            {
                Show();

                if (front_radar_dist > 15 && front_radar_dist <= 20)
                {
                    BitmapImage bitImage = new BitmapImage(new Uri(@"Images\warn_front_iii.png", UriKind.Relative));
                    Image_Radar.Source = bitImage;
                }
                else if (front_radar_dist > 10 && front_radar_dist <= 15)
                {
                    BitmapImage bitImage = new BitmapImage(new Uri(@"Images\warn_front_ii.png", UriKind.Relative));
                    Image_Radar.Source = bitImage;
                }
                else if (front_radar_dist > 0 && front_radar_dist <= 10)
                {
                    BitmapImage bitImage = new BitmapImage(new Uri(@"Images\warn_front_i.png", UriKind.Relative));
                    Image_Radar.Source = bitImage;
                }
                else if (back_radar_dist > 15 && back_radar_dist <= 20)
                {
                    BitmapImage bitImage = new BitmapImage(new Uri(@"Images\warn_back_iii.png", UriKind.Relative));
                    Image_Radar.Source = bitImage;
                }
                else if (back_radar_dist > 10 && back_radar_dist <= 15)
                {
                    BitmapImage bitImage = new BitmapImage(new Uri(@"Images\warn_back_ii.png", UriKind.Relative));
                    Image_Radar.Source = bitImage;
                }
                else if (back_radar_dist > 0 && back_radar_dist <= 10)
                {
                    BitmapImage bitImage = new BitmapImage(new Uri(@"Images\warn_back_i.png", UriKind.Relative));
                    Image_Radar.Source = bitImage;
                }

                TextBlock_Front_Radar_Dist.Text = TryFindResource("TITLE_OBSTACLE_FRONT") + "  " + front_radar_dist.ToString("0.0") + " m";
                TextBlock_Back_Radar_Dist.Text = TryFindResource("TITLE_OBSTACLE_BACK") + "  " + back_radar_dist.ToString("0.0") + " m";

                if (MainWindow.enable_voice == true)
                {
                    if (radar_arrive_count++ >= 5)
                    {
                        radar_arrive_count = 0;
                        player.Play();
                    }
                }
                else
                {
                    radar_arrive_count = 0;
                }
            }
        }
    }
}
