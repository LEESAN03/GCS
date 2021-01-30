using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Pid_Para.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Pid_Para : Page
    {
        private static Page_Pid_Para m_Page_Pid_Para = new Page_Pid_Para();
        public static Page_Pid_Para getInstance()
        {
            if (m_Page_Pid_Para == null)
                m_Page_Pid_Para = new Page_Pid_Para();

            return m_Page_Pid_Para;
        }
        private Page_Pid_Para()
        {
            InitializeComponent();

            SLIDER_ROLL_GYRO_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_ROLL_GYRO_P_MouseLeftButtonUp), true);
            SLIDER_ROLL_ANGLE_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_ROLL_ANGLE_P_MouseLeftButtonUp), true);
            SLIDER_ROLL_ZUNI.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_ROLL_ZUNI_MouseLeftButtonUp), true);

            SLIDER_PITCH_GYRO_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_PITCH_GYRO_P_MouseLeftButtonUp), true);
            SLIDER_PITCH_ANGLE_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_PITCH_ANGLE_P_MouseLeftButtonUp), true);
            SLIDER_PITCH_ZUNI.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_PITCH_ZUNI_MouseLeftButtonUp), true);

            SLIDER_YAW_GYRO_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_YAW_GYRO_P_MouseLeftButtonUp), true);
            SLIDER_YAW_ANGLE_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_YAW_ANGLE_P_MouseLeftButtonUp), true);
            SLIDER_YAW_ZUNI.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_YAW_ZUNI_MouseLeftButtonUp), true);

            SLIDER_VERTICAL_DIST_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_VERTICAL_DIST_P_MouseLeftButtonUp), true);
            SLIDER_VERTICAL_SPEED_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_VERTICAL_SPEED_P_MouseLeftButtonUp), true);
            SLIDER_VERTICAL_ACC_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_VERTICAL_ACC_P_MouseLeftButtonUp), true);
            SLIDER_VERTICAL_ACC_I.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_VERTICAL_ACC_I_MouseLeftButtonUp), true);

            SLIDER_HORIZON_DIST_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_HORIZON_DIST_P_MouseLeftButtonUp), true);
            SLIDER_HORIZON_SPEED_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_HORIZON_SPEED_P_MouseLeftButtonUp), true);
            SLIDER_HORIZON_ACC_P.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_HORIZON_ACC_P_MouseLeftButtonUp), true);
            SLIDER_HORIZON_ACC_I.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_HORIZON_ACC_I_MouseLeftButtonUp), true);

            SLIDER_HORIZON_BREAK.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(SLIDER_HORIZON_BREAK_MouseLeftButtonUp), true);
        }


        private void SLIDER_ROLL_GYRO_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_ROLL_GYRO_P.Text = ((ushort)(SLIDER_ROLL_GYRO_P.Value)).ToString();
        }

        private void SLIDER_ROLL_ANGLE_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_ROLL_ANGLE_P.Text = ((ushort)(SLIDER_ROLL_ANGLE_P.Value)).ToString();
        }

        private void SLIDER_ROLL_ZUNI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_ROLL_ZUNI.Text = ((ushort)(SLIDER_ROLL_ZUNI.Value)).ToString();
        }

        private void SLIDER_PITCH_GYRO_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_PITCH_GYRO_P.Text = ((ushort)(SLIDER_PITCH_GYRO_P.Value)).ToString();
        }

        private void SLIDER_PITCH_ANGLE_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_PITCH_ANGLE_P.Text = ((ushort)(SLIDER_PITCH_ANGLE_P.Value)).ToString();
        }

        private void SLIDER_PITCH_ZUNI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_PITCH_ZUNI.Text = ((ushort)(SLIDER_PITCH_ZUNI.Value)).ToString();
        }

        private void SLIDER_YAW_GYRO_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_YAW_GYRO_P.Text = ((ushort)(SLIDER_YAW_GYRO_P.Value)).ToString();
        }

        private void SLIDER_YAW_ANGLE_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_YAW_ANGLE_P.Text = ((ushort)(SLIDER_YAW_ANGLE_P.Value)).ToString();
        }

        private void SLIDER_YAW_ZUNI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_YAW_ZUNI.Text = ((ushort)(SLIDER_YAW_ZUNI.Value)).ToString();
        }

        private void SLIDER_VERTICAL_DIST_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_VERTICAL_DIST_P.Text = ((ushort)(SLIDER_VERTICAL_DIST_P.Value)).ToString();
        }

        private void SLIDER_VERTICAL_SPEED_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_VERTICAL_SPEED_P.Text = ((ushort)(SLIDER_VERTICAL_SPEED_P.Value)).ToString();
        }

        private void SLIDER_VERTICAL_ACC_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_VERTICAL_ACC_P.Text = ((ushort)(SLIDER_VERTICAL_ACC_P.Value)).ToString();
        }

        private void SLIDER_VERTICAL_ACC_I_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_VERTICAL_ACC_I.Text = ((ushort)(SLIDER_VERTICAL_ACC_I.Value)).ToString();
        }

        private void SLIDER_HORIZON_DIST_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_HORIZON_DIST_P.Text = ((ushort)(SLIDER_HORIZON_DIST_P.Value)).ToString();
        }

        private void SLIDER_HORIZON_SPEED_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_HORIZON_SPEED_P.Text = ((ushort)(SLIDER_HORIZON_SPEED_P.Value)).ToString();
        }

        private void SLIDER_HORIZON_ACC_P_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_HORIZON_ACC_P.Text = ((ushort)(SLIDER_HORIZON_ACC_P.Value)).ToString();
        }

        private void SLIDER_HORIZON_ACC_I_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_HORIZON_ACC_I.Text = ((ushort)(SLIDER_HORIZON_ACC_I.Value)).ToString();
        }

        private void SLIDER_HORIZON_BREAK_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock_HORIZON_BREAK.Text = ((ushort)(SLIDER_HORIZON_BREAK.Value)).ToString();
        }
        /***********************************************************************
         * function:
         * para:
         * return:
         * **********************************************************************/
        private void BTN_SET_BASIC_PID_Click(object sender, RoutedEventArgs e)
        {
            DataProcess_JD.mPid.henggun_angle_P = ushort.Parse(TextBlock_ROLL_ANGLE_P.Text);
            DataProcess_JD.mPid.henggun_gyro_P = ushort.Parse(TextBlock_ROLL_GYRO_P.Text);

            DataProcess_JD.mPid.fuyang_angle_P = ushort.Parse(TextBlock_PITCH_ANGLE_P.Text);
            DataProcess_JD.mPid.fuyang_gyro_P = ushort.Parse(TextBlock_PITCH_GYRO_P.Text);

            DataProcess_JD.mPid.hangxiang_angle_P = ushort.Parse(TextBlock_YAW_ANGLE_P.Text);
            DataProcess_JD.mPid.hangxiang_gyro_P = ushort.Parse(TextBlock_YAW_GYRO_P.Text);

            DataProcess_JD.mPid.dinggao_speed_P = ushort.Parse(TextBlock_VERTICAL_SPEED_P.Text);

            DataProcess_JD.mPid.henggun_gyro_D = byte.Parse(TextBlock_ROLL_ZUNI.Text);
            DataProcess_JD.mPid.fuyang_gyro_D = byte.Parse(TextBlock_PITCH_ZUNI.Text);
            DataProcess_JD.mPid.hangxiang_gyro_D = byte.Parse(TextBlock_YAW_ZUNI.Text);

            DataProcess_JD.mPid.dinggao_dist_P = ushort.Parse(TextBlock_VERTICAL_DIST_P.Text);
            DataProcess_JD.mPid.dinggao_acc_P = ushort.Parse(TextBlock_VERTICAL_ACC_P.Text);
            DataProcess_JD.mPid.dinggao_acc_I = byte.Parse(TextBlock_VERTICAL_ACC_I.Text);

            DataProcess_JD.mPid.dingdian_dist_P = ushort.Parse(TextBlock_HORIZON_DIST_P.Text);
            DataProcess_JD.mPid.dingdian_speed_P = ushort.Parse(TextBlock_HORIZON_SPEED_P.Text);
            DataProcess_JD.mPid.dingdian_acc_P = ushort.Parse(TextBlock_HORIZON_ACC_P.Text);
            DataProcess_JD.mPid.dingdian_speed_I = byte.Parse(TextBlock_HORIZON_ACC_I.Text);

            DataProcess_JD.mPid.gyro_limit = byte.Parse(TextBlock_HORIZON_BREAK.Text);

            DATA_LINK.sendbuf_VIK(MsgDef.MSG_LPID);
        }

        /***********************************************************************
        * function:
        * para:
        * return:
        * **********************************************************************/
        private void BTN_GET_BASIC_PID_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_LPID, 0);
        }

      
        /*********************************************************************
        * 功   能：显示多选翼基础PID参数
        * 参   数：
        * 返   回：
        * ******************************************************************/
        public void Show_Multi_Motor_Basic_Pid()
        {
            PID_B mPid = DataProcess_JD.Get_PID();

            TextBlock_ROLL_ANGLE_P.Text = mPid.henggun_angle_P.ToString();
            SLIDER_ROLL_ANGLE_P.Value = mPid.henggun_angle_P;

            TextBlock_ROLL_GYRO_P.Text = mPid.henggun_gyro_P.ToString();
            SLIDER_ROLL_GYRO_P.Value = mPid.henggun_gyro_P;

            TextBlock_PITCH_ANGLE_P.Text = mPid.fuyang_angle_P.ToString();
            SLIDER_PITCH_ANGLE_P.Value = mPid.fuyang_angle_P;

            TextBlock_PITCH_GYRO_P.Text = mPid.fuyang_gyro_P.ToString();
            SLIDER_PITCH_GYRO_P.Value = mPid.fuyang_gyro_P;

            TextBlock_YAW_ANGLE_P.Text = mPid.hangxiang_angle_P.ToString();
            SLIDER_YAW_ANGLE_P.Value = mPid.hangxiang_angle_P;

            TextBlock_YAW_GYRO_P.Text = mPid.hangxiang_gyro_P.ToString();
            SLIDER_YAW_GYRO_P.Value = mPid.hangxiang_gyro_P;

            TextBlock_VERTICAL_SPEED_P.Text = mPid.dinggao_speed_P.ToString();
            SLIDER_VERTICAL_SPEED_P.Value = mPid.dinggao_speed_P;

            TextBlock_ROLL_ZUNI.Text = mPid.henggun_gyro_D.ToString();
            SLIDER_ROLL_ZUNI.Value = mPid.henggun_gyro_D;

            TextBlock_PITCH_ZUNI.Text = mPid.fuyang_gyro_D.ToString();
            SLIDER_PITCH_ZUNI.Value = mPid.fuyang_gyro_D;

            TextBlock_YAW_ZUNI.Text = mPid.hangxiang_gyro_D.ToString();
            SLIDER_YAW_ZUNI.Value = mPid.hangxiang_gyro_D;

            TextBlock_VERTICAL_DIST_P.Text = mPid.dinggao_dist_P.ToString();
            SLIDER_VERTICAL_DIST_P.Value = mPid.dinggao_dist_P;

            TextBlock_VERTICAL_ACC_P.Text = mPid.dinggao_acc_P.ToString();
            SLIDER_VERTICAL_ACC_P.Value = mPid.dinggao_acc_P;

            TextBlock_VERTICAL_ACC_I.Text = mPid.dinggao_acc_I.ToString();
            SLIDER_VERTICAL_ACC_I.Value = mPid.dinggao_acc_I;

            TextBlock_HORIZON_DIST_P.Text = mPid.dingdian_dist_P.ToString();
            SLIDER_HORIZON_DIST_P.Value = mPid.dingdian_dist_P;

            TextBlock_HORIZON_SPEED_P.Text = mPid.dingdian_speed_P.ToString();
            SLIDER_HORIZON_SPEED_P.Value = mPid.dingdian_speed_P;

            TextBlock_HORIZON_ACC_P.Text = mPid.dingdian_acc_P.ToString();
            SLIDER_HORIZON_ACC_P.Value = mPid.dingdian_acc_P;

            TextBlock_HORIZON_ACC_I.Text = mPid.dingdian_speed_I.ToString();
            SLIDER_HORIZON_ACC_I.Value = mPid.dingdian_speed_I;

            TextBlock_HORIZON_BREAK.Text = mPid.gyro_limit.ToString();
            SLIDER_HORIZON_BREAK.Value = mPid.gyro_limit;
        }
  

        private void TextBox_Roll_Gyro_P_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Pitch_Gyro_P_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Yaw_Gyro_P_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_VerVel_P_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Roll_Angle_P_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Pitch_Angle_P_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Yaw_Angle_P_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Roll_I_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Pitch_I_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Yaw_I_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Roll_Imax_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Yaw_Imax_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Roll_DD_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Yaw_DD_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Dist_P_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Speed_P_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Speed_D_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Speed_I_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Alt_P_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_AccZ_P_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_AccZ_I_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Pitch_Imax_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Pitch_DD_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void BTN_ROLL_GYRO_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_ROLL_GYRO_P.Value < 300)
            {
                SLIDER_ROLL_GYRO_P.Value += 1;
                TextBlock_ROLL_GYRO_P.Text = ((ushort)SLIDER_ROLL_GYRO_P.Value).ToString();
            }
        }

        private void BTN_ROLL_GYRO_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_ROLL_GYRO_P.Value > 50)
            {
                SLIDER_ROLL_GYRO_P.Value -= 1;
                TextBlock_ROLL_GYRO_P.Text = ((ushort)SLIDER_ROLL_GYRO_P.Value).ToString();
            }
        }

        private void BTN_ROLL_ANGLE_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_ROLL_ANGLE_P.Value > 200)
            {
                SLIDER_ROLL_ANGLE_P.Value -= 1;
                TextBlock_ROLL_ANGLE_P.Text = ((ushort)SLIDER_ROLL_ANGLE_P.Value).ToString();
            }
        }

        private void BTN_ROLL_ANGLE_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_ROLL_ANGLE_P.Value < 700)
            {
                SLIDER_ROLL_ANGLE_P.Value += 1;
                TextBlock_ROLL_ANGLE_P.Text = ((ushort)SLIDER_ROLL_ANGLE_P.Value).ToString();
            }
        }

        private void BTN_ROLL_ZUNI_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_ROLL_ZUNI.Value > 0)
            {
                SLIDER_ROLL_ZUNI.Value -= 1;
                TextBlock_ROLL_ZUNI.Text = ((ushort)SLIDER_ROLL_ZUNI.Value).ToString();
            }
        }

        private void BTN_ROLL_ZUNI_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_ROLL_ZUNI.Value < 20)
            {
                SLIDER_ROLL_ZUNI.Value += 1;
                TextBlock_ROLL_ZUNI.Text = ((ushort)SLIDER_ROLL_ZUNI.Value).ToString();
            }
        }

        private void BTN_PITCH_GYRO_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_PITCH_GYRO_P.Value < 300)
            {
                SLIDER_PITCH_GYRO_P.Value += 1;
                TextBlock_PITCH_GYRO_P.Text = ((ushort)(SLIDER_PITCH_GYRO_P.Value)).ToString();
            }
        }

        private void BTN_PITCH_GYRO_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_PITCH_GYRO_P.Value > 50)
            {
                SLIDER_PITCH_GYRO_P.Value -= 1;
                TextBlock_PITCH_GYRO_P.Text = ((ushort)(SLIDER_PITCH_GYRO_P.Value)).ToString();
            }
        }

        private void BTN_PITCH_ANGLE_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_PITCH_ANGLE_P.Value > 200)
            {
                SLIDER_PITCH_ANGLE_P.Value -= 1;
                TextBlock_PITCH_ANGLE_P.Text = ((ushort)(SLIDER_PITCH_ANGLE_P.Value)).ToString();
            }
        }

        private void BTN_PITCH_ANGLE_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_PITCH_ANGLE_P.Value < 700)
            {
                SLIDER_PITCH_ANGLE_P.Value += 1;
                TextBlock_PITCH_ANGLE_P.Text = ((ushort)SLIDER_PITCH_ANGLE_P.Value).ToString();
            }
        }

        private void BTN_PITCH_ZUNI_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_PITCH_ZUNI.Value > 0)
            {
                SLIDER_PITCH_ZUNI.Value -= 1;
                TextBlock_PITCH_ZUNI.Text = ((ushort)SLIDER_PITCH_ZUNI.Value).ToString();
            }
        }

        private void BTN_PITCH_ZUNI_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_PITCH_ZUNI.Value < 20)
            {
                SLIDER_PITCH_ZUNI.Value += 1;
                TextBlock_PITCH_ZUNI.Text = ((ushort)SLIDER_PITCH_ZUNI.Value).ToString();
            }
        }



        private void BTN_YAW_GYRO_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_YAW_GYRO_P.Value < 600)
            {
                SLIDER_YAW_GYRO_P.Value += 1;
                TextBlock_YAW_GYRO_P.Text = ((ushort)(SLIDER_YAW_GYRO_P.Value)).ToString();
            }
        }

        private void BTN_YAW_GYRO_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_YAW_GYRO_P.Value > 100)
            {
                SLIDER_YAW_GYRO_P.Value -= 1;
                TextBlock_YAW_GYRO_P.Text = ((ushort)(SLIDER_YAW_GYRO_P.Value)).ToString();
            }
        }

        private void BTN_YAW_ANGLE_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_YAW_ANGLE_P.Value > 200)
            {
                SLIDER_YAW_ANGLE_P.Value -= 1;
                TextBlock_YAW_ANGLE_P.Text = ((ushort)(SLIDER_YAW_ANGLE_P.Value)).ToString();
            }
        }

        private void BTN_YAW_ANGLE_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_YAW_ANGLE_P.Value < 700)
            {
                SLIDER_YAW_ANGLE_P.Value += 1;
                TextBlock_YAW_ANGLE_P.Text = ((ushort)SLIDER_YAW_ANGLE_P.Value).ToString();
            }
        }

        private void BTN_YAW_ZUNI_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_YAW_ZUNI.Value > 0)
            {
                SLIDER_YAW_ZUNI.Value -= 1;
                TextBlock_YAW_ZUNI.Text = ((ushort)SLIDER_YAW_ZUNI.Value).ToString();
            }
        }

        private void BTN_YAW_ZUNI_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_YAW_ZUNI.Value < 20)
            {
                SLIDER_YAW_ZUNI.Value += 1;
                TextBlock_YAW_ZUNI.Text = ((ushort)SLIDER_YAW_ZUNI.Value).ToString();
            }
        }

        private void BTN_VERTICAL_SPEED_P_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_VERTICAL_SPEED_P.Value > 200)
            {
                SLIDER_VERTICAL_SPEED_P.Value -= 1;
                TextBlock_VERTICAL_SPEED_P.Text = ((ushort)SLIDER_VERTICAL_SPEED_P.Value).ToString();
            }
        }

        private void BTN_VERTICAL_SPEED_P_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_VERTICAL_SPEED_P.Value < 500)
            {
                SLIDER_VERTICAL_SPEED_P.Value += 1;
                TextBlock_VERTICAL_SPEED_P.Text = ((ushort)SLIDER_VERTICAL_SPEED_P.Value).ToString();
            }
        }

        private void BTN_VERTICAL_DIST_P_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_VERTICAL_DIST_P.Value > 20)
            {
                SLIDER_VERTICAL_DIST_P.Value -= 1;
                TextBlock_VERTICAL_DIST_P.Text = ((ushort)SLIDER_VERTICAL_DIST_P.Value).ToString();
            }
        }

        private void BTN_VERTICAL_DIST_P_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_VERTICAL_DIST_P.Value < 150)
            {
                SLIDER_VERTICAL_DIST_P.Value += 1;
                TextBlock_VERTICAL_DIST_P.Text = ((ushort)SLIDER_VERTICAL_DIST_P.Value).ToString();
            }
        }

        private void BTN_VERTICAL_ACC_P_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_VERTICAL_ACC_P.Value > 10)
            {
                SLIDER_VERTICAL_ACC_P.Value -= 1;
                TextBlock_VERTICAL_ACC_P.Text = ((ushort)SLIDER_VERTICAL_ACC_P.Value).ToString();
            }
        }

        private void BTN_VERTICAL_ACC_P_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_VERTICAL_ACC_P.Value < 100)
            {
                SLIDER_VERTICAL_ACC_P.Value += 1;
                TextBlock_VERTICAL_ACC_P.Text = ((ushort)SLIDER_VERTICAL_ACC_P.Value).ToString();
            }
        }

        private void BTN_VERTICAL_ACC_I_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_VERTICAL_ACC_I.Value > 5)
            {
                SLIDER_VERTICAL_ACC_I.Value -= 1;
                TextBlock_VERTICAL_ACC_I.Text = ((ushort)SLIDER_VERTICAL_ACC_I.Value).ToString();
            }
        }

        private void BTN_VERTICAL_ACC_I_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_VERTICAL_ACC_I.Value < 50)
            {
                SLIDER_VERTICAL_ACC_I.Value += 1;
                TextBlock_VERTICAL_ACC_I.Text = ((ushort)SLIDER_VERTICAL_ACC_I.Value).ToString();
            }
        }


        private void BTN_HORIZON_SPEED_P_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_SPEED_P.Value > 80)
            {
                SLIDER_HORIZON_SPEED_P.Value -= 1;
                TextBlock_HORIZON_SPEED_P.Text = ((ushort)SLIDER_HORIZON_SPEED_P.Value).ToString();
            }
        }

        private void BTN_HORIZON_SPEED_P_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_SPEED_P.Value < 200)
            {
                SLIDER_HORIZON_SPEED_P.Value += 1;
                TextBlock_HORIZON_SPEED_P.Text = ((ushort)SLIDER_HORIZON_SPEED_P.Value).ToString();
            }
        }

        private void BTN_HORIZON_DIST_P_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_DIST_P.Value > 50)
            {
                SLIDER_HORIZON_DIST_P.Value -= 1;
                TextBlock_HORIZON_DIST_P.Text = ((ushort)SLIDER_HORIZON_DIST_P.Value).ToString();
            }
        }

        private void BTN_HORIZON_DIST_P_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_DIST_P.Value < 150)
            {
                SLIDER_HORIZON_DIST_P.Value += 1;
                TextBlock_HORIZON_DIST_P.Text = ((ushort)SLIDER_HORIZON_DIST_P.Value).ToString();
            }
        }

        private void BTN_HORIZON_ACC_P_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_ACC_P.Value > 10)
            {
                SLIDER_HORIZON_ACC_P.Value -= 1;
                TextBlock_HORIZON_ACC_P.Text = ((ushort)SLIDER_HORIZON_ACC_P.Value).ToString();
            }
        }

        private void BTN_HORIZON_ACC_P_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_ACC_P.Value < 100)
            {
                SLIDER_HORIZON_ACC_P.Value += 1;
                TextBlock_HORIZON_ACC_P.Text = ((ushort)SLIDER_HORIZON_ACC_P.Value).ToString();
            }
        }

        private void BTN_HORIZON_ACC_I_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_ACC_I.Value > 0)
            {
                SLIDER_HORIZON_ACC_I.Value -= 1;
                TextBlock_HORIZON_ACC_I.Text = ((ushort)SLIDER_HORIZON_ACC_I.Value).ToString();
            }
        }

        private void BTN_HORIZON_ACC_I_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_ACC_I.Value < 50)
            {
                SLIDER_HORIZON_ACC_I.Value += 1;
                TextBlock_HORIZON_ACC_I.Text = ((ushort)SLIDER_HORIZON_ACC_I.Value).ToString();
            }
        }

        private void BTN_HORIZON_BREAK_INCREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_BREAK.Value < 20)
            {
                SLIDER_HORIZON_BREAK.Value += 1;
                TextBlock_HORIZON_BREAK.Text = ((ushort)SLIDER_HORIZON_BREAK.Value).ToString();
            }
        }

        private void BTN_HORIZON_BREAK_DECREASE_Click(object sender, RoutedEventArgs e)
        {
            if (SLIDER_HORIZON_BREAK.Value > 10)
            {
                SLIDER_HORIZON_BREAK.Value -= 1;
                TextBlock_HORIZON_BREAK.Text = ((ushort)SLIDER_HORIZON_BREAK.Value).ToString();
            }
        }
    }
}
