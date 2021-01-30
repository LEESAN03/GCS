using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Plane_Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Plane_Settings : Page
    {
        private static Page_Plane_Settings m_Page_Plane_Settings = new Page_Plane_Settings();
        public static Page_Plane_Settings getInstance()
        {
            if (m_Page_Plane_Settings == null)
                m_Page_Plane_Settings = new Page_Plane_Settings();

            return m_Page_Plane_Settings;
        }

        private Page_JiXing_Settings m_PageJiXingSettings = Page_JiXing_Settings.getInstance();
        private Page_Remoter_Calibrate m_PageRemoterCalibrate = Page_Remoter_Calibrate.getInstance();
        private Page_Pid_Para m_PagePidPara = Page_Pid_Para.getInstance();
        private Page_Motor_Test m_PageMotorTest = Page_Motor_Test.getInstance();
        private Page_Fix_Direction m_PageFixDirection = Page_Fix_Direction.getInstance();
        private Page_Fix_Instruction m_PageFixInstruction = Page_Fix_Instruction.getInstance();
        private Page_JiXing_Instruction m_PageJiXingInstruction = Page_JiXing_Instruction.getInstance();
        private Page_Remoter_Calibrate_Instruction m_PageRemoterInstruction = Page_Remoter_Calibrate_Instruction.getInstance();
        private Page_Pid_Instruction m_PagePidInstruction = Page_Pid_Instruction.getInstance();
        private Page_Motor_Instruction m_PageMotorInstruction = Page_Motor_Instruction.getInstance();
        private Page_Par_Setting m_PageParSetting = Page_Par_Setting.getInstance();

        // setting page for chuiqi
        private Page_ChuiQi_Pwm_Out m_Page_ChuiQi_Pwm = Page_ChuiQi_Pwm_Out.getInstance();
        private Page_ChuiQi_JIXing m_Page_ChuiQi_JiXing = Page_ChuiQi_JIXing.getInstance();
        private Page_ChuiQi_Settings2 m_Page_ChuiQi_JiXing2 = Page_ChuiQi_Settings2.getInstance();
        private Page_FW_MM_PID m_Page_FW_MM_PID = Page_FW_MM_PID.getInstance();


        private Page_Plane_Settings()
        {
            InitializeComponent();

            if (App.plane_type == 0)
            {
                Frm_Plane_Para.Navigate(m_PageJiXingSettings);
                Frm_Plane_Para_Instruction.Navigate(m_PageJiXingInstruction);
            }
            else if (App.plane_type == 1 || App.plane_type == 2)
            {
                Frm_Plane_Para.Navigate(m_Page_ChuiQi_JiXing);

                GRID_PAR_SETTINGS.Visibility = Visibility.Hidden;
            }
        }

        /************************************************************************
         * 功   能：reset所有按键的边框颜色
         * 参   数：
         * 返   回：
         * **********************************************************************/
        private void Reset_All_Btn_Background()
        {
            GRID_PID_SETTINGS.Background = Brushes.Black;
            GRID_PLANE_TYPE_SETTINGS.Background = Brushes.Black;
            GRID_DIRECT_SELECT.Background = Brushes.Black;
            GRID_REMOTER_CALIBRATE.Background = Brushes.Black;
            GRID_MOTOR_TEST.Background = Brushes.Black;
            GRID_PAR_SETTINGS.Background = Brushes.Black; 
        }

        /************************************************************************
         * function: set pid 
         * para:
         * return:
         * **********************************************************************/
        private void BTN_PID_SETTINGS_Click(object sender, RoutedEventArgs e)
        {
            Reset_All_Btn_Background();
            GRID_PID_SETTINGS.Background = System.Windows.Media.Brushes.Orange;

            if (App.plane_type == 0)
            {
                Frm_Plane_Para.Navigate(m_PagePidPara);
                Frm_Plane_Para_Instruction.Navigate(m_PagePidInstruction);
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_LPID, 0);
            }
            else
            {
                Frm_Plane_Para.Navigate(m_Page_FW_MM_PID);
                Frm_Plane_Para_Instruction.Navigate(m_PagePidInstruction);
            }
        }

        /******************************************************************************
         * function: Switch to plane setttings page
         * para:
         * return:
         * *****************************************************************************/
        private void BTN_PLANE_TYPE_SETTINGS_Click(object sender, RoutedEventArgs e)
        {
            Reset_All_Btn_Background();
            GRID_PLANE_TYPE_SETTINGS.Background = System.Windows.Media.Brushes.Orange;
            // 导航到机型设置页
            if (App.plane_type == 0)
            {
                Frm_Plane_Para.Navigate(m_PageJiXingSettings);
                Frm_Plane_Para_Instruction.Navigate(m_PageJiXingInstruction);
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_APTYPE, 0);
            }
            else
            {
                Frm_Plane_Para.Navigate(m_Page_ChuiQi_JiXing);
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.PICTURE_TRIGGER_MODE, 0);
            }
        }

        private void BTN_REMOTER_CALIBRATE_Click(object sender, RoutedEventArgs e)
        {
            Reset_All_Btn_Background();
            GRID_REMOTER_CALIBRATE.Background = System.Windows.Media.Brushes.Orange;

            // 导航到遥控器校准页
            Frm_Plane_Para.Navigate(m_PageRemoterCalibrate);
            Frm_Plane_Para_Instruction.Navigate(m_PageRemoterInstruction);
        }

        private void BTN_MOTOR_TEST_Click(object sender, RoutedEventArgs e)
        {
            Reset_All_Btn_Background();
            GRID_MOTOR_TEST.Background = System.Windows.Media.Brushes.Orange;

            // 导航到电机检测
            if(App.plane_type == 0)
                Frm_Plane_Para.Navigate(m_PageMotorTest);
            else if(App.plane_type == 1)
                Frm_Plane_Para.Navigate(m_Page_ChuiQi_Pwm);

            Frm_Plane_Para_Instruction.Navigate(m_PageMotorInstruction);
        }

        /****************************************************************************
         * 功   能：切换到安装方向页面
         * 参   数：
         * 返   回：
         * *************************************************************************/
        private void BTN_DIRECT_SELECT_Click(object sender, RoutedEventArgs e)
        {
            Reset_All_Btn_Background();
            GRID_DIRECT_SELECT.Background = System.Windows.Media.Brushes.Orange;

            // 导航到安装方向页面
            if (App.plane_type == 0)
            {
                Frm_Plane_Para.Navigate(m_PageFixDirection);
            }
            else
            {
                Frm_Plane_Para.Navigate(m_Page_ChuiQi_JiXing2);
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_APTYPE, 0);
            }

            Frm_Plane_Para_Instruction.Navigate(m_PageFixInstruction);
        }

        /****************************************************************************
        * 功   能：切换到飞行参数设置页面
        * 参   数：
        * 返   回：
        * *************************************************************************/
        private void BTN_PAR_SETTINGS_Click(object sender, RoutedEventArgs e)
        {
            Reset_All_Btn_Background();
            GRID_PAR_SETTINGS.Background = System.Windows.Media.Brushes.Orange;

            // 导航到飞行参数设置页面
            Frm_Plane_Para.Navigate(m_PageParSetting);
            Frm_Plane_Para_Instruction.Navigate(m_PageMotorInstruction);

            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_PAR, 0);
        }

        public void Show_Plane_Settings()
        {
            m_PageJiXingSettings.Show_Plane_Settings();
        }

        /**********************************************************************
         * function:
         * para:
         * return:
         * ********************************************************************/
        public void Show_FX_Channel_Config()
        {
            m_Page_ChuiQi_Pwm.Show_FX_Channel_Config();
        }

        /**********************************************************************
        * function:
        * para:
        * return:
        * ********************************************************************/
        public void Update_Fw_Settings()
        {
            m_Page_ChuiQi_JiXing.Update_Fw_Settings();
        }

        /**********************************************************************
        * function:
        * para:
        * return:
        * ********************************************************************/
        public void Update_Fw_Settings2()
        {
            m_Page_ChuiQi_JiXing2.Update_Fw_Settings2();
        }

        /**********************************************************************
        * function:
        * para:
        * return:
        * ********************************************************************/
        public void Update_FW_MM_Pid()
        {
            m_Page_FW_MM_PID.Update_FW_MM_Pid();
        }

        /**********************************************************************
        * function:
        * para:
        * return:
        * ********************************************************************/
        public void Update_FW_Pid()
        {
            m_Page_FW_MM_PID.Update_FW_Pid();
        }
    }
}
