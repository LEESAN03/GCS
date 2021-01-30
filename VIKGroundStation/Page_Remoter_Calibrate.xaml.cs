using System.Windows;
using System.Windows.Controls;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Remoter_Calibrate.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Remoter_Calibrate : Page
    {
        private static Page_Remoter_Calibrate m_Page_Remoter_Calibrate = new Page_Remoter_Calibrate();
        public static Page_Remoter_Calibrate getInstance()
        {
            if (m_Page_Remoter_Calibrate == null)
                m_Page_Remoter_Calibrate = new Page_Remoter_Calibrate();

            return m_Page_Remoter_Calibrate;
        }

        public Page_Remoter_Calibrate()
        {
            InitializeComponent();

            if (App.plane_type == 0)
            {
                pad4.Visibility = Visibility.Hidden;
                Turn_Channel8.Hide();
            }
            if (App.plane_type == 1)
            {
                PWM5_SECTOR1.Text = "固定翼手动";
                PWM5_SECTOR2.Text = "旋翼GPS";
                PWM5_SECTOR3.Text = "旋翼姿态";

                PWM6_SECTOR1.Text = "手动关伞";
                PWM6_SECTOR2.Text = "";
                PWM6_SECTOR3.Text = "手动开伞";

                PWM7_SECTOR1.Text = "";
                PWM7_SECTOR2.Text = "";
                PWM7_SECTOR3.Text = "";

                PWM8_SECTOR1.Text = "手动油门关";
                PWM8_SECTOR2.Text = "";
                PWM8_SECTOR3.Text = "手动油门开";
            }
            else if (App.plane_type == 2)
            {
                PWM5_SECTOR1.Text = "固定翼手动";
                PWM5_SECTOR2.Text = "固定翼增稳";
                PWM5_SECTOR3.Text = "自主飞行";

                PWM6_SECTOR1.Text = "手动开伞";
                PWM6_SECTOR2.Text = "";
                PWM6_SECTOR3.Text = "手动关伞";

                PWM7_SECTOR1.Text = "";
                PWM7_SECTOR2.Text = "";
                PWM7_SECTOR3.Text = "";

                PWM8_SECTOR1.Text = "手动油门关";
                PWM8_SECTOR2.Text = "";
                PWM8_SECTOR3.Text = "手动油门开";
            }

            combox_remoter_type.Items.Add(TryFindResource("TITLE_REMOTER_RIGHT_THROTTLE"));
            combox_remoter_type.Items.Add(TryFindResource("TITLE_REMOTER_LEFT_THROTTLE"));
            combox_remoter_type.SelectedIndex = 0;
        }

        private void BTN_RC_CALIBRATE_START_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_RC_ON, 0);
        }

        private void BTN_RC_CALIBRATE_END_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_RC_OFF, 0);
        }

        /***********************************************************************************
  * function:
  * para:
  * return:
  * *********************************************************************************/
        public void Show_Pwm_In_Information(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            byte pwmInput1, pwmInput2, pwmInput3, pwmInput4, pwmInput5, pwmInput6, pwmInput7, pwmInput8;
            pwmInput1 = mFly_Infor_Display.controllerInput1;
            pwmInput2 = mFly_Infor_Display.controllerInput2;
            pwmInput3 = mFly_Infor_Display.controllerInput3;
            pwmInput4 = mFly_Infor_Display.controllerInput4;
            pwmInput5 = mFly_Infor_Display.controllerInput5;
            pwmInput6 = mFly_Infor_Display.controllerInput6;
            pwmInput7 = mFly_Infor_Display.controllerInput7;
            pwmInput8 = mFly_Infor_Display.controllerInput8;

            Text_Block_Elevator.Text = TryFindResource("TITLE_ELEVATOR").ToString() + ":" + (pwmInput2 * 10).ToString();      //升降
            Text_Block_Aileron.Text = TryFindResource("TITLE_AILERON").ToString() + ":" + (pwmInput1 * 10).ToString();        //副翼
            Text_Block_Throttle.Text = TryFindResource("TITLE_THROTTLE").ToString() + ":" + (pwmInput3 * 10).ToString();      //油门
            Text_Block_Rudder.Text = TryFindResource("TITLE_RUDDER").ToString() + ":" + (pwmInput4 * 10).ToString();          //方向

            pwmInput1 = (byte)Compute.Math_Constrain(pwmInput1, 100, 200);
            pwmInput2 = (byte)Compute.Math_Constrain(pwmInput2, 100, 200);
            pwmInput3 = (byte)Compute.Math_Constrain(pwmInput3, 100, 200);
            pwmInput4 = (byte)Compute.Math_Constrain(pwmInput4, 100, 200);

            Turn_Channel5.SetVerticalSpeedIndicatorParameters(pwmInput5 - 100);
            Turn_Channel6.SetVerticalSpeedIndicatorParameters(pwmInput6 - 100);

            if (App.plane_type == 0)
                Turn_Channel7.SetVerticalSpeedIndicatorParameters((pwmInput7 - 100) * 2 / 3 + 33);
            else
                Turn_Channel7.SetVerticalSpeedIndicatorParameters(pwmInput7 - 100);

            Turn_Channel8.SetVerticalSpeedIndicatorParameters(pwmInput8 - 100);

            if (combox_remoter_type.SelectedIndex == 0)
            {
                Turn_Aileron_Throttle.SetTurnCoordinatorParameters(((int)(pwmInput3) - 150) * 3, ((int)(pwmInput1) - 150) * 3);//升降
                Turn_Elevator_Direction.SetTurnCoordinatorParameters(((int)(150 - pwmInput2)) * 3, ((int)(pwmInput4) - 150) * 3);//副翼
            }
            else if(combox_remoter_type.SelectedIndex == 1)
            {
                Turn_Aileron_Throttle.SetTurnCoordinatorParameters(((int)(150 - pwmInput2)) * 3, ((int)(pwmInput1) - 150) * 3);//升降
                Turn_Elevator_Direction.SetTurnCoordinatorParameters(((int)(pwmInput3) - 150) * 3, ((int)(pwmInput4) - 150) * 3);//副翼
            }
        }
    }
}
