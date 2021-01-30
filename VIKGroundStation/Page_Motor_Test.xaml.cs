using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Motor_Test.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Motor_Test : Page
    {
        private static Page_Motor_Test m_Page_Motor_Test = null;// new Page_Motor_Test();
        public static Page_Motor_Test getInstance()
        {
            if (m_Page_Motor_Test == null)
                m_Page_Motor_Test = new Page_Motor_Test();

            return m_Page_Motor_Test;
        }

        private Page_Motor_Test()
        {
            InitializeComponent();
        }

        private void Btn_Motor1_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_OUT, 1);

            Init_All_Btn_Background();
            Btn_Motor1_Test.Background = System.Windows.Media.Brushes.Orange;
        }

        private void Btn_Motor2_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_OUT, 2);

            Init_All_Btn_Background();
            Btn_Motor2_Test.Background = System.Windows.Media.Brushes.Orange;
        }

        private void Btn_Motor3_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_OUT, 3);

            Init_All_Btn_Background();
            Btn_Motor3_Test.Background = System.Windows.Media.Brushes.Orange;
        }

        private void Btn_Motor4_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_OUT, 4);

            Init_All_Btn_Background();
            Btn_Motor4_Test.Background = System.Windows.Media.Brushes.Orange;
        }

        private void Btn_Motor5_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_OUT, 5);

            Init_All_Btn_Background();
            Btn_Motor5_Test.Background = System.Windows.Media.Brushes.Orange;
        }

        private void Btn_Motor6_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_OUT, 6);

            Init_All_Btn_Background();
            Btn_Motor6_Test.Background = System.Windows.Media.Brushes.Orange;
        }

        private void Btn_Motor7_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_OUT, 7);

            Init_All_Btn_Background();
            Btn_Motor7_Test.Background = System.Windows.Media.Brushes.Orange;
        }

        private void Btn_Motor8_Test_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_OUT, 8);

            Init_All_Btn_Background();
            Btn_Motor8_Test.Background = System.Windows.Media.Brushes.Orange;
        }

        private void Init_All_Btn_Background()
        {
            Btn_Motor1_Test.Background = System.Windows.Media.Brushes.Black;
            Btn_Motor2_Test.Background = System.Windows.Media.Brushes.Black;
            Btn_Motor3_Test.Background = System.Windows.Media.Brushes.Black;
            Btn_Motor4_Test.Background = System.Windows.Media.Brushes.Black;
            Btn_Motor5_Test.Background = System.Windows.Media.Brushes.Black;
            Btn_Motor6_Test.Background = System.Windows.Media.Brushes.Black;
            Btn_Motor7_Test.Background = System.Windows.Media.Brushes.Black;
            Btn_Motor8_Test.Background = System.Windows.Media.Brushes.Black;
        }

        public void Update_Pwm_Out(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            Motor1_Output.Value = (mFly_Infor_Display.pwm_out1 - 100) / 100.0;
            Motor2_Output.Value = (mFly_Infor_Display.pwm_out2 - 100) / 100.0;
            Motor3_Output.Value = (mFly_Infor_Display.pwm_out3 - 100) / 100.0;
            Motor4_Output.Value = (mFly_Infor_Display.pwm_out4 - 100) / 100.0;
            Motor5_Output.Value = (mFly_Infor_Display.pwm_out5 - 100) / 100.0;
            Motor6_Output.Value = (mFly_Infor_Display.pwm_out6 - 100) / 100.0;
            Motor7_Output.Value = (mFly_Infor_Display.pwm_out7 - 100) / 100.0;
            Motor8_Output.Value = (mFly_Infor_Display.pwm_out8 - 100) / 100.0;
        }
    }
}
