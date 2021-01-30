using System;
using System.Windows;
using System.Windows.Input;

namespace VIKGroundStation
{
    /// <summary>
    /// Interaction logic for Window_Fly_Point.xaml
    /// </summary>
    public partial class Window_Fly_Point : Window
    {
        private static Window_Fly_Point m_wnd_fly_point = new Window_Fly_Point();
        public static Window_Fly_Point getInstance()
        {
            if (m_wnd_fly_point == null)
                m_wnd_fly_point = new Window_Fly_Point();
            return m_wnd_fly_point;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;
        public Window_Fly_Point()
        {
            InitializeComponent();
            Window_ZhiDian_Init();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        /*************************************************************
         * 功   能：窗口初始化
         * 参   数：
         * 返   回：
         * **********************************************************/
        private void Window_ZhiDian_Init()
        {
            this.Top = SystemParameters.PrimaryScreenHeight * 0.1;
            this.Left = SystemParameters.PrimaryScreenWidth * 0.3;

            TextBlock_Speed_Unit.Text = "m/s";

            if (App.plane_type == 0)
            {
                Combox_Zhidian_Mode.Items.Add(TryFindResource("TITLE_HOVER"));
                Combox_Zhidian_Mode.Items.Add(TryFindResource("TITLE_HORIZON_CIRCLE"));
                Combox_Zhidian_Mode.Items.Add(TryFindResource("TITLE_VERTICAL_CIRCLE"));
                Combox_Zhidian_Mode.Items.Add(TryFindResource("TITLE_LANDING"));
            }
            else
            {
                Combox_Zhidian_Mode.Items.Add(TryFindResource("TITLE_HORIZON_CIRCLE"));
                Combox_Zhidian_Mode.Items.Add("返航中继");
                Combox_Zhidian_Mode.Items.Add(TryFindResource("TITLE_LANDING"));

                TextBlock_Circle_Spd.Text = "降落点高度";
                TextBlock_Circle_Spd_Unit.Text = "m";

                Combox_Circle_Direction.Visibility = Visibility.Hidden;
                TextBox_Circle_Times.Visibility = Visibility.Hidden;
                TextBlock_Circle_Direction.Visibility = Visibility.Hidden;
                TextBlock_Circle_Times.Visibility = Visibility.Hidden;
                TextBlock_Head_Instruction.Visibility = Visibility.Hidden;
            }

            Combox_Zhidian_Mode.SelectedIndex = 0;

            this.Hide();
            Owner = MainWindow.getInstance();
        }


        /************************************************************************************
         * function: send flying point to the aircraft
         * para:
         * return:
         * **********************************************************************************/
        private void BTN_FLY_TO_POINT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataProcess_JD.mFly_Point.pointLongitude = (int)(double.Parse(jingdu.Text) * Math.Pow(10, 7));
                DataProcess_JD.mFly_Point.pointLattitude = (int)(double.Parse(weidu.Text) * Math.Pow(10, 7));
                DataProcess_JD.mFly_Point.pointAlt = (short)(double.Parse(gaodu.Text));

                DataProcess_JD.mFly_Point.pointSpeed = (short)(double.Parse(sudu.Text) * 10);     // dm/s
                if (App.plane_type == 0)
                {
                    DataProcess_JD.mFly_Point._point_mode = (byte)(Combox_Zhidian_Mode.SelectedIndex + 1);
                    DataProcess_JD.mFly_Point._circle_radius = (ushort)(double.Parse(TextBox_Circle_Radius.Text) * 10);   // dm
                    DataProcess_JD.mFly_Point._circle_speed = (ushort)(double.Parse(TextBox_Circle_Speed.Text) * 10);    // dm/s
                }
                else
                {
                    DataProcess_JD.mFly_Point._point_mode = (byte)(Combox_Zhidian_Mode.SelectedIndex);
                    DataProcess_JD.mFly_Point._circle_radius = (ushort)(double.Parse(TextBox_Circle_Radius.Text));   // m
                    DataProcess_JD.mFly_Point._circle_speed = (ushort)(double.Parse(TextBox_Circle_Speed.Text));    // m
                }

                DataProcess_JD.mFly_Point._circle_direction = (byte)(Combox_Circle_Direction.SelectedIndex + 1); // cicle direction
                DataProcess_JD.mFly_Point._circle_times = (short)(double.Parse(TextBox_Circle_Times.Text) * 100);  // circle times

                DATA_LINK.Send_Fly_Point_Pos(MsgDef.MSG_FLY_POINT);

                Page_2D_Map.Add_ZhiDian_Pt(double.Parse(weidu.Text), double.Parse(jingdu.Text), 0);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Input");
            }

            Page_2D_Map.addptbool = 0;
            this.Hide();
            mb_wnd_visible = false;
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

        /**********************************************************************
         * 功   能：取消指点功能
         * 参   数：
         * 返   回：
         * *******************************************************************/
        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();

            if (MainWindow.map_show_type == 2)
            {
                Page_2D_Map.addptbool = 0;
                Page_2D_Map.ZhiDian_Layer.Markers.Clear();
            }
            else if (MainWindow.map_show_type == 3)
            {
                m_PageGoogleMap.webBrowser_google_earth.InvokeScript("DeleteZhiDianPt", new object[] { });
                m_PageGoogleMap.webBrowser_google_earth.InvokeScript("setUAVLineState", new object[] { 0, 0 });
            }
            this.Hide();
            mb_wnd_visible = false;
        }

        /*******************************************************************
        * 功能：更新指点界面的经度和纬度
        * 参数：
        * ****************************************************************/
        public void Update_ZhiDian_Pos(double argLon, double argLat)
        {
            jingdu.Text = Math.Round(argLon, 7).ToString();
            weidu.Text = Math.Round(argLat, 7).ToString();
        }

        private void Combox_Zhidian_Mode_Changed(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (App.plane_type != 0)
                return;

            if (Combox_Zhidian_Mode.SelectedIndex == 0 || Combox_Zhidian_Mode.SelectedIndex == 3)
            {
                TextBox_Circle_Radius.IsEnabled = false;
                TextBox_Circle_Speed.IsEnabled = false;

                Combox_Circle_Direction.IsEnabled = false;
                Combox_Circle_Direction.Items.Clear();

                TextBlock_Circle_Times.Text = TryFindResource("TITLE_HEADING").ToString();
                TextBlock_Head_Instruction.Text = "(-180~180)°";
            }
            else
            {
                TextBox_Circle_Radius.IsEnabled = true;
                TextBox_Circle_Speed.IsEnabled = true;

                Combox_Circle_Direction.IsEnabled = true;
                Combox_Circle_Direction.Items.Clear();
                if (Combox_Zhidian_Mode.SelectedIndex == 1)
                {
                    Combox_Circle_Direction.Items.Add(TryFindResource("TITLE_CLOCK_WISE"));
                    Combox_Circle_Direction.Items.Add(TryFindResource("TITLE_COUNTER_CLOCK_WISE"));
                }
                else if (Combox_Zhidian_Mode.SelectedIndex == 2)
                {
                    Combox_Circle_Direction.Items.Add("向上开始");
                    Combox_Circle_Direction.Items.Add("向下开始");
                }
                Combox_Circle_Direction.SelectedIndex = 0;

                TextBlock_Circle_Times.Text = TryFindResource("TITLE_CIRCLE_TIMES").ToString();
                TextBlock_Head_Instruction.Text = "";
            }
        }
    }
}
