using System.Windows;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_Fan_Hang_Reason.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Fan_Hang_Reason : Window
    {
        private static Window_Fan_Hang_Reason m_wnd_fan_hang_reason = new Window_Fan_Hang_Reason();
        public static Window_Fan_Hang_Reason getInstance()
        {
            if (m_wnd_fan_hang_reason == null)
                m_wnd_fan_hang_reason = new Window_Fan_Hang_Reason();
            return m_wnd_fan_hang_reason;
        }

        public Window_Fan_Hang_Reason()
        {
            InitializeComponent();

            Show();
            Owner = MainWindow.getInstance();

            Top = SystemParameters.PrimaryScreenHeight * 0.85;
            Left = (SystemParameters.PrimaryScreenWidth - Width) * 0.5;
        }

        /*****************************************************************************
         * function: show the back home reason of professional version
         * para:
         * return:
         * ****************************************************************************/
        public void Update_Infor_Pro(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            switch (mFly_Infor_Display.home_reason)
            {
                case FAN_HANG_REASON.REMOTER_INDICATION_HOME:
                    TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_REMOTER_INDICATION_HOME").ToString();
                    break;
                case FAN_HANG_REASON.GCS_INDICATION_HOME:
                    TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_GCS_INDICATION_HOME").ToString();
                    break;
                case FAN_HANG_REASON.REMOTER_RRROR_HOME:
                    TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_REMOTER_RRROR_HOME").ToString();
                    break;
                case FAN_HANG_REASON.LOW_VOLT_HOME:
                    TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_LOW_VOLT_HOME").ToString();
                    break;
                case FAN_HANG_REASON.LINK_LOST_HOME:
                    TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_LINK_LOST_HOME").ToString();
                    break;
                case FAN_HANG_REASON.ROCK_LOST_HOME:
                    TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_ROCK_LOST_HOME").ToString();
                    break;
                case FAN_HANG_REASON.LIMIT_ALT_HOME:
                    TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_LIMIT_ALT_HOME").ToString();
                    break;
                case FAN_HANG_REASON.INFRARED_INVALID_HOME:
                    if (App.plane_type == 0)
                        TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_INFRARED_INVALID_HOME").ToString();
                    break;
                case FAN_HANG_REASON.HIGH_TEMPERATURE_HOME:
                    TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_HIGH_TEMPERATURE_HOME").ToString();
                    break;
                case FAN_HANG_REASON.REMOTER_LOST_HOME:
                    if (App.plane_type == 0)
                        TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_REMOTER_LOST_HOME").ToString();
                    else if (App.plane_type == 1)
                        TextBlock_Fan_Hang_Reason.Text = "固定翼切换超时返航";
                    break;
                case FAN_HANG_REASON.REMOTER_FS_HOME:
                    if (App.plane_type == 0)
                        TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_REMOTER_FS_HOME").ToString();
                    else
                        TextBlock_Fan_Hang_Reason.Text = "发送机转速异常";
                    break;
                case FAN_HANG_REASON.FORBIDDEN_AREA_HOME:
                    if (App.plane_type == 0)
                        TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_FORBIDDEN_AREA_HOME").ToString();
                    else
                        TextBlock_Fan_Hang_Reason.Text = "航点返航";
                    break;
                case FAN_HANG_REASON.FORBIDDEN_FIX_WING_ATTITUD_UNSTABLE:
                    TextBlock_Fan_Hang_Reason.Text = "固定翼姿态失稳旋翼返航";
                    break;
                default:
                    TextBlock_Fan_Hang_Reason.Text = "";
                    break;
            }
        }
    }
}
