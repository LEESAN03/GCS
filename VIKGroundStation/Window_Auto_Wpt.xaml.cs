using System.Windows;
using System.Windows.Input;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_Auto_Wpt.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Auto_Wpt : Window
    {
        private static Window_Auto_Wpt m_wnd_auto_wpt = new Window_Auto_Wpt();
        public static Window_Auto_Wpt getInstance()
        {
            if (m_wnd_auto_wpt == null)
                m_wnd_auto_wpt = new Window_Auto_Wpt();
            return m_wnd_auto_wpt;
        }

        public int skyline_space = 0;
        public int skyline_rotate = 0;
        public Window_Auto_Wpt()
        {
            InitializeComponent();

            // 初始化行间距和航线的方向
            skyline_space = int.Parse(TextBox_Skyline_Space.Text);
            skyline_rotate = int.Parse(TextBox_Skyline_Rotate.Text);

            this.Hide();
            Owner = MainWindow.getInstance();
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

        private void BTN_SKYLINE_ROTATE_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            skyline_rotate += 2;
            if (skyline_rotate >= 360)
                skyline_rotate -= 360;

            if (skyline_rotate < 0)
                skyline_rotate += 360;

            TextBox_Skyline_Rotate.Text = skyline_rotate.ToString();
            Window_Skyway.getInstance().Generate_PreWpt(Window_Skyway.bound_pt_list, Compute.wrap_360(skyline_rotate - 90), skyline_space);
        }

        private void BTN_SKYLINE_ROTATE_DECRESE_Click(object sender, RoutedEventArgs e)
        {
            skyline_rotate -= 2;
            if (skyline_rotate >= 360)
                skyline_rotate -= 360;

            if (skyline_rotate < 0)
                skyline_rotate += 360;

            TextBox_Skyline_Rotate.Text = skyline_rotate.ToString();
            Window_Skyway.getInstance().Generate_PreWpt(Window_Skyway.bound_pt_list, Compute.wrap_360(skyline_rotate - 90), skyline_space);
        }

        private void BTN_SKYLINE_SPACE_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            skyline_space += 1;
            TextBox_Skyline_Space.Text = skyline_space.ToString();
            Window_Skyway.getInstance().Generate_PreWpt(Window_Skyway.bound_pt_list, Compute.wrap_360(skyline_rotate - 90), skyline_space);
        }

        private void BTN_SKYLINE_SPACE_DECRESE_Click(object sender, RoutedEventArgs e)
        {
            if (skyline_space > 3)
                skyline_space -= 1;
            else
                return;

            TextBox_Skyline_Space.Text = skyline_space.ToString();
            Window_Skyway.getInstance().Generate_PreWpt(Window_Skyway.bound_pt_list, Compute.wrap_360(skyline_rotate - 90), skyline_space);
        }

        /*******************************************************************
         * 功能：规划边界时后退
         * 参数：
         * 返回：
         * ******************************************************************/
        private void BTN_BOUND_BACK_Click(object sender, RoutedEventArgs e)
        {
            int countTemp = Window_Skyway.bound_pt_list.Count;

            if (countTemp > 0)
            {
                Window_Skyway.bound_pt_list.RemoveAt(countTemp - 1);
                Window_Skyway.getInstance().Updatet_Bound_Skyway();
            }
        }

        /*******************************************************************
        * 功能：
        * 参数：
        * 返回：
        * ******************************************************************/
        private void BTN_BOUND_OK_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Skyline_Rotate.Text == "" || TextBox_Skyline_Space.Text == "")
                return;
            else
            {
                skyline_rotate = int.Parse(TextBox_Skyline_Rotate.Text);
                skyline_space = int.Parse(TextBox_Skyline_Space.Text);
                if (skyline_space < 3)
                    skyline_space = 3;
            }

            int countTemp = Window_Skyway.bound_pt_list.Count;

            if (countTemp > 2)
            {
                Window_Skyway.getInstance().Updatet_Bound_Skyway();
            }
        }
    }
}
