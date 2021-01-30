using System;
using System.IO;
using System.Threading;
using System.Windows;

namespace VIKGroundStation
{
    /// <summary>
    /// Interaction logic for winSplash.xaml
    /// </summary>
    public partial class winSplash : Window
    {
        public winSplash()
        {
            InitializeComponent();

            combox_plane_type.Items.Add("多旋翼 (Multi Motor)");
            combox_plane_type.Items.Add("垂起固定翼 (VTOL Fix Wing)");
            combox_plane_type.Items.Add("固定翼 (Fix Wing)");

            //combox_plane_type.Items.Add(TryFindResource("TITLE_MULTI_MOTOR"));
            //combox_plane_type.Items.Add(TryFindResource("TITLE_VERTICAL_LAUNCH"));
            //combox_plane_type.Items.Add(TryFindResource("TITLE_FIX_WING"));

            combox_single_many.Items.Add("单机版 (One-One)");
            combox_single_many.Items.Add("多机版 (One-Multi)");

            string str_path = Directory.GetCurrentDirectory();

            int plane_type = int.Parse(ReadConfigFile.ReadIniData("IP_SET", "plane_type", "", str_path + "\\Start_Up.ini"));
            combox_plane_type.SelectedIndex = plane_type;
            App.plane_type = plane_type;

            int single_many_type = int.Parse(ReadConfigFile.ReadIniData("IP_SET", "single_many", "", str_path + "\\Start_Up.ini"));
            combox_single_many.SelectedIndex = single_many_type;
            App.single_many_type = single_many_type;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //通知主线程自己已经启动完毕
            //App.mre.Set();
        }


        private void combox_plane_type_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            App.plane_type = combox_plane_type.SelectedIndex;

            if (App.plane_type == 0)
                App.str_plane_type = "Multi Motor";
            else if (App.plane_type == 1)
                App.str_plane_type = "VTOL Fix Wing";
            else
                App.str_plane_type = "Fix Wing";
        }

        private void combox_single_many_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            App.single_many_type = combox_single_many.SelectedIndex;

            if (App.single_many_type == 0)
                App.str_single_multi = "One-One";
            else
                App.str_single_multi = "One-Multi";
        }

        private void BTN_START_UP_Click(object sender, RoutedEventArgs e)
        {
            if (App.init_finish == false)
            {
                string str_path = Directory.GetCurrentDirectory();
                ReadConfigFile.WritePrivateProfileString("IP_SET", "plane_type", App.plane_type.ToString(), str_path + "\\Start_Up.ini");
                ReadConfigFile.WritePrivateProfileString("IP_SET", "single_many", App.single_many_type.ToString(), str_path + "\\Start_Up.ini");

                App.System_Init();
                Thread.Sleep(1000);
                this.Close();
            }
        }

        private void BTN_SHUT_DOWN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Application.Current.Shutdown();
                Environment.Exit(0);
            }
            catch
            {
            }
        }
    }
}
