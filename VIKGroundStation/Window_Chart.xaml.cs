using Microsoft.Research.DynamicDataDisplay;
using System;
using System.Windows;
using System.Windows.Media;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_Chart.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Chart : Window
    {
        private static Window_Chart m_wnd_chart = new Window_Chart();
        public static Window_Chart getInstance()
        {
            if (m_wnd_chart == null)
                m_wnd_chart = new Window_Chart();

            mb_wnd_initialized = true;
            return m_wnd_chart;
        }

        public static bool mb_wnd_initialized = false;
        public static bool mb_wnd_visible = false;

        public void Show_Wnd()
        {
            Show();
            mb_wnd_visible = true;
        }
        public void Hide_Wnd()
        {
            Hide();
            mb_wnd_visible = false;
        }

        public Window_Chart()
        {
            InitializeComponent();
            Owner = MainWindow.getInstance();
        }

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private ObservableDataSource<System.Windows.Point> dataSource_tRoll = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_roll = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_tPitch = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pitch = new ObservableDataSource<System.Windows.Point>();

        private ObservableDataSource<System.Windows.Point> dataSource_xGyro = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_yGyro = new ObservableDataSource<System.Windows.Point>();

        private ObservableDataSource<System.Windows.Point> dataSource_tYaw = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_yaw = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_zGyro = new ObservableDataSource<System.Windows.Point>();

        private ObservableDataSource<System.Windows.Point> dataSource_acc_E = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_speed_E = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_acc_N = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_speed_N = new ObservableDataSource<System.Windows.Point>();

        private ObservableDataSource<System.Windows.Point> dataSource_acc_V = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_speed_V = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_alt = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_tSpeed_V = new ObservableDataSource<System.Windows.Point>();


        private ObservableDataSource<System.Windows.Point> dataSource_pwm_input1 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_input2 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_input3 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_input4 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_input5 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_input6 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_input7 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_input8 = new ObservableDataSource<System.Windows.Point>();

        private ObservableDataSource<System.Windows.Point> dataSource_pwm_output1 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_output2 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_output3 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_output4 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_output5 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_output6 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_output7 = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_pwm_output8 = new ObservableDataSource<System.Windows.Point>();

        private ObservableDataSource<System.Windows.Point> dataSource_x_mag = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_y_mag = new ObservableDataSource<System.Windows.Point>();
        private ObservableDataSource<System.Windows.Point> dataSource_z_mag = new ObservableDataSource<System.Windows.Point>();

        LineGraph chart_tRoll, chart_roll, chart_tPitch, chart_pitch;
        LineGraph chart_xGyro, chart_yGyro;
        LineGraph chart_tYaw, chart_yaw, chart_zGyro;
        LineGraph chart_acc_E, chart_speed_E, chart_acc_N, chart_speed_N, chart_acc_V, chart_speed_V, chart_alt, chart_tSpeed_V;
        LineGraph chart_pwm_input1, chart_pwm_input2, chart_pwm_input3, chart_pwm_input4, chart_pwm_input5, chart_pwm_input6, chart_pwm_input7, chart_pwm_input8;
        LineGraph chart_pwm_output1, chart_pwm_output2, chart_pwm_output3, chart_pwm_output4, chart_pwm_output5, chart_pwm_output6, chart_pwm_output7, chart_pwm_output8;
        LineGraph chart_x_mag, chart_y_mag, chart_z_mag;
        private void MENUE_BTN_CHART_CENTRAL_Click(object sender, RoutedEventArgs e)
        {
            plotter_attitude.Viewport.FitToView();
            plotter_xyGyro.Viewport.FitToView();
            plotter_yaw.Viewport.FitToView();
            plotter_speed.Viewport.FitToView();
            plotter_pwm_input.Viewport.FitToView();
            plotter_pwm_output.Viewport.FitToView();
            plotter_mag.Viewport.FitToView();
            plotter_climb_rate.Viewport.FitToView();
        }

        private void MENUE_BTN_CHART_ZOOM_IN_Click(object sender, RoutedEventArgs e)
        {
            plotter_attitude.Viewport.Zoom(0.9);
            plotter_xyGyro.Viewport.Zoom(0.9);
            plotter_yaw.Viewport.Zoom(0.9);
            plotter_speed.Viewport.Zoom(0.9);
            plotter_pwm_input.Viewport.Zoom(0.9);
            plotter_pwm_output.Viewport.Zoom(0.9);
            plotter_mag.Viewport.Zoom(0.9);
            plotter_climb_rate.Viewport.Zoom(0.9);
        }

        private void MENUE_BTN_CHART_ZOOM_OUT_Click(object sender, RoutedEventArgs e)
        {
            plotter_attitude.Viewport.Zoom(1.1);
            plotter_xyGyro.Viewport.Zoom(1.1);
            plotter_yaw.Viewport.Zoom(1.1);
            plotter_speed.Viewport.Zoom(1.1);
            plotter_pwm_input.Viewport.Zoom(1.1);
            plotter_pwm_output.Viewport.Zoom(1.1);
            plotter_mag.Viewport.Zoom(1.1);
            plotter_climb_rate.Viewport.Zoom(1.1);
        }

        private int xDataLen = 0;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = MainWindow.getInstance();
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);

            chart_tRoll = plotter_attitude.AddLineGraph(dataSource_tRoll, Colors.Red, 2, TryFindResource("TITLE_TARGET_ROLL").ToString());
            chart_roll = plotter_attitude.AddLineGraph(dataSource_roll, Colors.Blue, 2, TryFindResource("TITLE_CURRENT_ROLL").ToString());
            chart_tPitch = plotter_attitude.AddLineGraph(dataSource_tPitch, Colors.Purple, 2, TryFindResource("TITLE_TARGET_PITCH").ToString());
            chart_pitch = plotter_attitude.AddLineGraph(dataSource_pitch, Colors.Green, 2, TryFindResource("TITLE_CURRENT_PITCH").ToString());

            chart_yGyro = plotter_xyGyro.AddLineGraph(dataSource_yGyro, Colors.Red, 2, TryFindResource("TITLE_ROLL_GYRO").ToString());
            chart_xGyro = plotter_xyGyro.AddLineGraph(dataSource_xGyro, Colors.Green, 2, TryFindResource("TITLE_PITCH_GYRO").ToString());

            chart_tYaw = plotter_yaw.AddLineGraph(dataSource_tYaw, Colors.Red, 2, TryFindResource("TITLE_TARGET_YAW").ToString());
            chart_yaw = plotter_yaw.AddLineGraph(dataSource_yaw, Colors.Blue, 2, TryFindResource("TITLE_CURRENT_YAW").ToString());
            chart_zGyro = plotter_yaw.AddLineGraph(dataSource_zGyro, Colors.Green, 2, TryFindResource("TITLE_YAW_GYRO").ToString());

            chart_acc_E = plotter_speed.AddLineGraph(dataSource_acc_E, Colors.Red, 2, TryFindResource("TITLE_EW_ACC").ToString());
            chart_speed_E = plotter_speed.AddLineGraph(dataSource_speed_E, Colors.Blue, 2, TryFindResource("TITLE_EW_SPEED").ToString());
            chart_acc_N = plotter_speed.AddLineGraph(dataSource_acc_N, Colors.Purple, 2, TryFindResource("TITLE_NS_ACC").ToString());
            chart_speed_N = plotter_speed.AddLineGraph(dataSource_speed_N, Colors.Green, 2, TryFindResource("TITLE_NS_SPEED").ToString());

            chart_tSpeed_V = plotter_climb_rate.AddLineGraph(dataSource_tSpeed_V, Colors.Red, 2, TryFindResource("TITLE_TARGET_CLIMB").ToString());
            chart_speed_V = plotter_climb_rate.AddLineGraph(dataSource_speed_V, Colors.Blue, 2, TryFindResource("TITLE_CURRENT_CLIMB").ToString());
            chart_alt = plotter_climb_rate.AddLineGraph(dataSource_alt, Colors.Yellow, 2, TryFindResource("TITLE_CURRENT_ALT").ToString());
            chart_acc_V = plotter_climb_rate.AddLineGraph(dataSource_acc_V, Colors.Green, 2, TryFindResource("TITLE_UP_ACC").ToString());

            chart_pwm_input1 = plotter_pwm_input.AddLineGraph(dataSource_pwm_input1, Colors.Red, 2, "pwm_input1");
            chart_pwm_input2 = plotter_pwm_input.AddLineGraph(dataSource_pwm_input2, Colors.Blue, 2, "pwm_input2");
            chart_pwm_input3 = plotter_pwm_input.AddLineGraph(dataSource_pwm_input3, Colors.Purple, 2, "pwm_input3");
            chart_pwm_input4 = plotter_pwm_input.AddLineGraph(dataSource_pwm_input4, Colors.Green, 2, "pwm_input4");
            chart_pwm_input5 = plotter_pwm_input.AddLineGraph(dataSource_pwm_input5, Colors.Orange, 2, "pwm_input5");
            chart_pwm_input6 = plotter_pwm_input.AddLineGraph(dataSource_pwm_input6, Colors.Yellow, 2, "pwm_input6");
            chart_pwm_input7 = plotter_pwm_input.AddLineGraph(dataSource_pwm_input7, Colors.Magenta, 2, "pwm_input7");
            chart_pwm_input8 = plotter_pwm_input.AddLineGraph(dataSource_pwm_input8, Colors.Black, 2, "pwm_input8");

            chart_pwm_output1 = plotter_pwm_output.AddLineGraph(dataSource_pwm_output1, Colors.Red, 2, "pwm_output1");
            chart_pwm_output2 = plotter_pwm_output.AddLineGraph(dataSource_pwm_output2, Colors.Blue, 2, "pwm_output2");
            chart_pwm_output3 = plotter_pwm_output.AddLineGraph(dataSource_pwm_output3, Colors.Purple, 2, "pwm_output3");
            chart_pwm_output4 = plotter_pwm_output.AddLineGraph(dataSource_pwm_output4, Colors.Green, 2, "pwm_output4");
            chart_pwm_output5 = plotter_pwm_output.AddLineGraph(dataSource_pwm_output5, Colors.Orange, 2, "pwm_output5");
            chart_pwm_output6 = plotter_pwm_output.AddLineGraph(dataSource_pwm_output6, Colors.Yellow, 2, "pwm_output6");
            chart_pwm_output7 = plotter_pwm_output.AddLineGraph(dataSource_pwm_output7, Colors.Magenta, 2, "pwm_output7");
            chart_pwm_output8 = plotter_pwm_output.AddLineGraph(dataSource_pwm_output8, Colors.Black, 2, "pwm_output8");

            chart_x_mag = plotter_mag.AddLineGraph(dataSource_x_mag, Colors.Red, 2, "x_mag");
            chart_y_mag = plotter_mag.AddLineGraph(dataSource_y_mag, Colors.Blue, 2, "y_mag");
            chart_z_mag = plotter_mag.AddLineGraph(dataSource_z_mag, Colors.Green, 2, "z_mag");
        }
                
        public void Update_Chart()
        {
            MSG_Databack_JD mMSG_Databack_JD = DataProcess_JD.Get_Play_Back_Infor();
            xDataLen++;
            // =============================== roll pitch ===============================
            System.Windows.Point point1 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.target_roll / 10);
            System.Windows.Point point2 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.roll / 10);
            System.Windows.Point point3 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.target_pitch / 10);
            System.Windows.Point point4 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.pitch / 10);

            dataSource_tRoll.AppendAsync(base.Dispatcher, point1);
            dataSource_roll.AppendAsync(base.Dispatcher, point2);
            dataSource_tPitch.AppendAsync(base.Dispatcher, point3);
            dataSource_pitch.AppendAsync(base.Dispatcher, point4);

            // ============================ xy gyro =========================
            System.Windows.Point point5 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.x_gyro / 10);
            System.Windows.Point point6 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.y_gyro / 10);

            dataSource_xGyro.AppendAsync(base.Dispatcher, point5);
            dataSource_yGyro.AppendAsync(base.Dispatcher, point6);

            // ============================ 航向 =========================
            System.Windows.Point point7 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.target_yaw / 10);
            System.Windows.Point point8 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.yaw / 10);
            System.Windows.Point point9 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.z_gyro / 10);

            dataSource_tYaw.AppendAsync(base.Dispatcher, point7);
            dataSource_yaw.AppendAsync(base.Dispatcher, point8);
            dataSource_zGyro.AppendAsync(base.Dispatcher, point9);

            // ============================ 速度 =========================
            System.Windows.Point point10 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.x_acc / 100);
            System.Windows.Point point11 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.east_solved_speed / 100);
            System.Windows.Point point12 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.y_acc / 100);
            System.Windows.Point point13 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.north_solved_speed / 100);
            System.Windows.Point point14 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.z_acc / 100);
            System.Windows.Point point15 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.climb_rate / 100);
            System.Windows.Point point16 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.solved_alt / 10);
            System.Windows.Point point17 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.target_climb_rate / 100);

            dataSource_acc_E.AppendAsync(base.Dispatcher, point10);
            dataSource_speed_E.AppendAsync(base.Dispatcher, point11);
            dataSource_acc_N.AppendAsync(base.Dispatcher, point12);
            dataSource_speed_N.AppendAsync(base.Dispatcher, point13);

            dataSource_acc_V.AppendAsync(base.Dispatcher, point14);
            dataSource_speed_V.AppendAsync(base.Dispatcher, point15);
            dataSource_alt.AppendAsync(base.Dispatcher, point16);
            dataSource_tSpeed_V.AppendAsync(base.Dispatcher, point17);

            // ============================ pwm_input =========================
            System.Windows.Point point18 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmin1);
            System.Windows.Point point19 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmin2);
            System.Windows.Point point20 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmin3);
            System.Windows.Point point21 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmin4);
            System.Windows.Point point22 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmin5);
            System.Windows.Point point23 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmin6);
            System.Windows.Point point24 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmin7);
            System.Windows.Point point25 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmin8);

            dataSource_pwm_input1.AppendAsync(base.Dispatcher, point18);
            dataSource_pwm_input2.AppendAsync(base.Dispatcher, point19);
            dataSource_pwm_input3.AppendAsync(base.Dispatcher, point20);
            dataSource_pwm_input4.AppendAsync(base.Dispatcher, point21);
            dataSource_pwm_input5.AppendAsync(base.Dispatcher, point22);
            dataSource_pwm_input6.AppendAsync(base.Dispatcher, point23);
            dataSource_pwm_input7.AppendAsync(base.Dispatcher, point24);
            dataSource_pwm_input8.AppendAsync(base.Dispatcher, point25);

            // ============================ pwm_output =========================
            System.Windows.Point point26 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmout1);
            System.Windows.Point point27 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmout2);
            System.Windows.Point point28 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmout3);
            System.Windows.Point point29 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmout4);
            System.Windows.Point point30 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmout5);
            System.Windows.Point point31 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmout6);
            System.Windows.Point point32 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmout7);
            System.Windows.Point point33 = new System.Windows.Point(xDataLen, (byte)mMSG_Databack_JD.pwmout8);

            dataSource_pwm_output1.AppendAsync(base.Dispatcher, point26);
            dataSource_pwm_output2.AppendAsync(base.Dispatcher, point27);
            dataSource_pwm_output3.AppendAsync(base.Dispatcher, point28);
            dataSource_pwm_output4.AppendAsync(base.Dispatcher, point29);
            dataSource_pwm_output5.AppendAsync(base.Dispatcher, point30);
            dataSource_pwm_output6.AppendAsync(base.Dispatcher, point31);
            dataSource_pwm_output7.AppendAsync(base.Dispatcher, point32);
            dataSource_pwm_output8.AppendAsync(base.Dispatcher, point33);

            // ============================ 磁力计 =========================
            System.Windows.Point point34 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.x_raw_mag1 / 10);
            System.Windows.Point point35 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.y_raw_mag1 / 10);
            System.Windows.Point point36 = new System.Windows.Point(xDataLen, (double)mMSG_Databack_JD.z_raw_mag1 / 10);

            dataSource_x_mag.AppendAsync(base.Dispatcher, point34);
            dataSource_y_mag.AppendAsync(base.Dispatcher, point35);
            dataSource_z_mag.AppendAsync(base.Dispatcher, point36);
        }
    }
}
