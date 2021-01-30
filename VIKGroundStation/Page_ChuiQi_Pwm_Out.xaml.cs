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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_ChuiQi_Pwm_Out.xaml 的交互逻辑
    /// </summary>
    public partial class Page_ChuiQi_Pwm_Out : Page
    {
        private static Page_ChuiQi_Pwm_Out m_Page_ChuiQi_Pwm = null;// new Page_Motor_Test();
        public static Page_ChuiQi_Pwm_Out getInstance()
        {
            if (m_Page_ChuiQi_Pwm == null)
                m_Page_ChuiQi_Pwm = new Page_ChuiQi_Pwm_Out();

            return m_Page_ChuiQi_Pwm;
        }

        public Page_ChuiQi_Pwm_Out()
        {
            InitializeComponent();
        }

        private void Btn_Motor1_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 14, 1);
        }

        private void Btn_Motor2_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 14, 2);
        }

        private void Btn_Motor3_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 14, 3);
        }

        private void Btn_Motor4_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 14, 4);
        }

        // ============================ 左副翼 ================================
        private void Btn_Aileron_Left_Set_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Rudder(CHUIQI_CHANNEL.AP_LEFT_AILERON_CH, short.Parse(TextBox_Aileron_Left_Min.Text),
                                            short.Parse(TextBox_Aileron_Left_Mid.Text), short.Parse(TextBox_Aileron_Left_Max.Text));
        }

        private void Btn_Aileron_Left_Get_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, 31, CHUIQI_CHANNEL.AP_LEFT_AILERON_CH);
        }

        private void Btn_Aileron_Left_Reverse_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 5, CHUIQI_CHANNEL.AP_LEFT_AILERON_CH);
        }

        private void Btn_Aileron_Left_Left_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Down, CHUIQI_CHANNEL.AP_LEFT_AILERON_CH);
        }

        private void Btn_Aileron_Left_Right_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_UP, CHUIQI_CHANNEL.AP_LEFT_AILERON_CH);
        }

        private void Btn_Aileron_Left_Mid_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Mid, CHUIQI_CHANNEL.AP_LEFT_AILERON_CH);
        }


        // ============================ 右副翼 ================================
        private void Btn_Aileron_Right_Set_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Rudder(CHUIQI_CHANNEL.AP_RIGHT_AILERON_CH, short.Parse(TextBox_Aileron_Right_Min.Text),
                                short.Parse(TextBox_Aileron_Right_Mid.Text), short.Parse(TextBox_Aileron_Right_Max.Text));
        }

        private void Btn_Aileron_Right_Get_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, 31, CHUIQI_CHANNEL.AP_RIGHT_AILERON_CH);
        }

        private void Btn_Aileron_Right_Reverse_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 5, CHUIQI_CHANNEL.AP_RIGHT_AILERON_CH);
        }

        private void Btn_Aileron_Right_Left_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Down, CHUIQI_CHANNEL.AP_RIGHT_AILERON_CH);
        }

        private void Btn_Aileron_Right_Right_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_UP, CHUIQI_CHANNEL.AP_RIGHT_AILERON_CH);
        }

        private void Btn_Aileron_Right_Mid_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Mid, CHUIQI_CHANNEL.AP_RIGHT_AILERON_CH);
        }


        // ============================ 左升降 ================================
        private void Btn_Left_Elevator_Set_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Rudder(CHUIQI_CHANNEL.AP_LEFT_ELEVATOR_CH, short.Parse(TextBox_Left_Elevator_Min.Text),
                    short.Parse(TextBox_Left_Elevator_Mid.Text), short.Parse(TextBox_Left_Elevator_Max.Text));
        }

        private void Btn_Left_Elevator_Get_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, 31, CHUIQI_CHANNEL.AP_LEFT_ELEVATOR_CH);
        }

        private void Btn_Left_Elevator_Reverse_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 5, CHUIQI_CHANNEL.AP_LEFT_ELEVATOR_CH);
        }

        private void Btn_Left_Elevator_Up_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_UP, CHUIQI_CHANNEL.AP_LEFT_ELEVATOR_CH);
        }

        private void Btn_Left_Elevator_Down_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Down, CHUIQI_CHANNEL.AP_LEFT_ELEVATOR_CH);
        }

        private void Btn_Left_Elevator_Mid_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Mid, CHUIQI_CHANNEL.AP_LEFT_ELEVATOR_CH);
        }


        // ============================ 右升降 ================================
        private void Btn_Right_Elevator_Set_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Rudder(CHUIQI_CHANNEL.AP_RIGHT_ELEVATOR_CH, short.Parse(TextBox_Right_Elevator_Min.Text),
                                    short.Parse(TextBox_Right_Elevator_Mid.Text), short.Parse(TextBox_Right_Elevator_Max.Text));
        }

        private void Btn_Right_Elevator_Get_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, 31, CHUIQI_CHANNEL.AP_RIGHT_ELEVATOR_CH);
        }

        private void Btn_Right_Elevator_Reverse_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 5, CHUIQI_CHANNEL.AP_RIGHT_ELEVATOR_CH);
        }

        private void Btn_Right_Elevator_Up_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_UP, CHUIQI_CHANNEL.AP_RIGHT_ELEVATOR_CH);
        }

        private void Btn_Right_Elevator_Down_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Down, CHUIQI_CHANNEL.AP_RIGHT_ELEVATOR_CH);
        }

        private void Btn_Right_Elevator_Mid_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Mid, CHUIQI_CHANNEL.AP_RIGHT_ELEVATOR_CH);
        }

        // ============================ 油门 ================================
        private void Btn_Throttle_Set_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Rudder(CHUIQI_CHANNEL.AP_THROTTLE_CH, short.Parse(TextBox_Throttle_Min.Text),
                            short.Parse(TextBox_Throttle_Mid.Text), short.Parse(TextBox_Throttle_Max.Text));
        }

        private void Btn_Throttle_Get_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, 31, CHUIQI_CHANNEL.AP_THROTTLE_CH);
        }

        private void Btn_Throttle_Reverse_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 5, CHUIQI_CHANNEL.AP_THROTTLE_CH);
        }

        private void Btn_Throttle_Min_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Down, CHUIQI_CHANNEL.AP_THROTTLE_CH);
        }

        private void Btn_Throttle_Max_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_UP, CHUIQI_CHANNEL.AP_THROTTLE_CH);
        }

        private void Btn_Throttle_Mid_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Mid, CHUIQI_CHANNEL.AP_THROTTLE_CH);
        }


        // ============================ 方向 ================================
        private void Btn_Rudder_Set_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Rudder(CHUIQI_CHANNEL.AP_LEFT_RUDDER_CH, short.Parse(TextBox_Rudder_Min.Text),
                    short.Parse(TextBox_Rudder_Mid.Text), short.Parse(TextBox_Rudder_Max.Text));
        }

        private void Btn_Rudder_Get_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, 31, CHUIQI_CHANNEL.AP_LEFT_RUDDER_CH);
        }

        private void Btn_Rudder_Reverse_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, 5, CHUIQI_CHANNEL.AP_LEFT_RUDDER_CH);
        }

        private void Btn_Rudder_Min_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Down, CHUIQI_CHANNEL.AP_LEFT_RUDDER_CH);
        }

        private void Btn_Rudder_Max_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_UP, CHUIQI_CHANNEL.AP_LEFT_RUDDER_CH);
        }

        private void Btn_Rudder_Mid_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Mid, CHUIQI_CHANNEL.AP_LEFT_RUDDER_CH);
        }


        // ============================ 左襟翼 ================================
        private void Btn_Left_Flap_Set_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Left_Flap_Get_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Left_Flap_Reverse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Left_Flap_Up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Left_Flap_Down_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Left_Flap_Mid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Right_Flap_Set_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Right_Flap_Get_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Right_Flap_Reverse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Right_Flap_Up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Right_Flap_Down_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Right_Flap_Mid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Front_Wheel_Set_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Front_Wheel_Get_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Front_Wheel_Reverse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Front_Wheel_Min_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Front_Wheel_Max_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Front_Wheel_Mid_Click(object sender, RoutedEventArgs e)
        {

        }

        /****************************************************************************
         * function:
         * para:
         * return:
         * ***************************************************************************/
        public void Update_Pwm_Out(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            TextBlock_Aileron_Left_Out.Text = (mFly_Infor_Display.pwm_out1 * 10).ToString();
            TextBlock_Aileron_Right_Out.Text = (mFly_Infor_Display.pwm_out5 * 10).ToString();

            TextBlock_Left_Elevator_Out.Text = (mFly_Infor_Display.pwm_out2 * 10).ToString();
            TextBlock_Right_Elevator_Out.Text = (mFly_Infor_Display.pwm_out6 * 10).ToString();

            TextBlock_Throttle.Text = (mFly_Infor_Display.pwm_out3 * 10).ToString();
            TextBlock_Rudder.Text = (mFly_Infor_Display.pwm_out4 * 10).ToString();

            TextBlock_Left_Flap_Out.Text = (mFly_Infor_Display.pwm_out7 * 10).ToString();
            TextBlock_Right_Flap_Out.Text = (mFly_Infor_Display.pwm_out8 * 10).ToString();
            TextBlock_Front_Wheel_Out.Text = (mFly_Infor_Display.pwm_out13 * 10).ToString();

            Motor1_Output.Value = (mFly_Infor_Display.pwm_out9 - 100) / 100.0;
            Motor2_Output.Value = (mFly_Infor_Display.pwm_out10 - 100) / 100.0;
            Motor3_Output.Value = (mFly_Infor_Display.pwm_out11 - 100) / 100.0;
            Motor4_Output.Value = (mFly_Infor_Display.pwm_out12 - 100) / 100.0;
        }


        /****************************************************************************
        * function: show the min/mid/max pwm out of the fix wing
        * para:
        * return:
        * ***************************************************************************/
        public void Show_FX_Channel_Config()
        {
            FX_CHANNEL_CONFIG m_Channel_Config = DataProcess_JD.Get_Channel_Config_Struct();

            switch (m_Channel_Config.channel_id)
            {
                case CHUIQI_CHANNEL.AP_LEFT_AILERON_CH:
                    TextBox_Aileron_Left_Min.Text = m_Channel_Config.min.ToString();
                    TextBox_Aileron_Left_Mid.Text = m_Channel_Config.mid.ToString();
                    TextBox_Aileron_Left_Max.Text = m_Channel_Config.max.ToString();
                    break;
                case CHUIQI_CHANNEL.AP_LEFT_ELEVATOR_CH:
                    TextBox_Left_Elevator_Min.Text = m_Channel_Config.min.ToString();
                    TextBox_Left_Elevator_Mid.Text = m_Channel_Config.mid.ToString();
                    TextBox_Left_Elevator_Max.Text = m_Channel_Config.max.ToString();
                    break;
                case CHUIQI_CHANNEL.AP_THROTTLE_CH:
                    TextBox_Throttle_Min.Text = m_Channel_Config.min.ToString();
                    TextBox_Throttle_Mid.Text = m_Channel_Config.mid.ToString();
                    TextBox_Throttle_Max.Text = m_Channel_Config.max.ToString();
                    break;
                case CHUIQI_CHANNEL.AP_LEFT_RUDDER_CH:
                    TextBox_Rudder_Min.Text = m_Channel_Config.min.ToString();
                    TextBox_Rudder_Mid.Text = m_Channel_Config.mid.ToString();
                    TextBox_Rudder_Max.Text = m_Channel_Config.max.ToString();
                    break;
                case CHUIQI_CHANNEL.AP_RIGHT_AILERON_CH:
                    TextBox_Aileron_Right_Min.Text = m_Channel_Config.min.ToString();
                    TextBox_Aileron_Right_Mid.Text = m_Channel_Config.mid.ToString();
                    TextBox_Aileron_Right_Max.Text = m_Channel_Config.max.ToString();
                    break;
                case CHUIQI_CHANNEL.AP_PARACHUTE_CH:
                    break;
                case CHUIQI_CHANNEL.AP_RIGHT_ELEVATOR_CH:
                    TextBox_Right_Elevator_Min.Text = m_Channel_Config.min.ToString();
                    TextBox_Right_Elevator_Mid.Text = m_Channel_Config.mid.ToString();
                    TextBox_Right_Elevator_Max.Text = m_Channel_Config.max.ToString();
                    break;
                case CHUIQI_CHANNEL.AP_FLAP_CH:
                    TextBox_Left_Flap_Min.Text = m_Channel_Config.min.ToString();
                    TextBox_Left_Flap_Mid.Text = m_Channel_Config.mid.ToString();
                    TextBox_Left_Flap_Max.Text = m_Channel_Config.max.ToString();
                    break;
                case CHUIQI_CHANNEL.AP_RIGHT_FLAP_CH:
                    TextBox_Right_Flap_Min.Text = m_Channel_Config.min.ToString();
                    TextBox_Right_Flap_Mid.Text = m_Channel_Config.mid.ToString();
                    TextBox_Right_Flap_Max.Text = m_Channel_Config.max.ToString();
                    break;
                case CHUIQI_CHANNEL.AP_FRONT_WHEEL_CH:
                    TextBox_Front_Wheel_Min.Text = m_Channel_Config.min.ToString();
                    TextBox_Front_Wheel_Mid.Text = m_Channel_Config.mid.ToString();
                    TextBox_Front_Wheel_Max.Text = m_Channel_Config.max.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
