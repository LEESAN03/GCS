using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Task_Function.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Task_Function : Page
    {
        // 实例化
        private static Page_Task_Function m_PageTaskFunction = new Page_Task_Function();
        public static Page_Task_Function getInstance()
        {
            if (m_PageTaskFunction == null)
                m_PageTaskFunction = new Page_Task_Function();
            return m_PageTaskFunction;
        }

        private Page_Camera_Setting m_PageCameraSetting = Page_Camera_Setting.getInstance();
        private Page_Version_Update m_PageVersionUpdate = Page_Version_Update.getInstance();

        private Page_Task_Function()
        {
            InitializeComponent();
            Frm_Task_Function.Navigate(m_PageVersionUpdate);
        }

        /********************************************************************
         * 功   能：reset所有按键的边框颜色
         * 参   数：
         * 返   回：
         * ******************************************************************/
        private void Reset_All_Btn_BordBrush()
        {
            GRID_CAMERA_SETTINGS.Background = Brushes.Black;
            GRID_VERSION_MANAGE.Background = Brushes.Black;
        }


        /***********************************************************************************
         * function:
         * para:
         * return:
         * *********************************************************************************/
        private void BTN_CAMERA_SETTINGS_Click(object sender, RoutedEventArgs e)
        {
            Reset_All_Btn_BordBrush();
            GRID_CAMERA_SETTINGS.Background = System.Windows.Media.Brushes.Orange;

            Frm_Task_Function.Navigate(m_PageCameraSetting);            
        }


        /***********************************************************************************
         * function:
         * para:
         * return:
         * *********************************************************************************/
        private void BTN_VERSION_MANAGE_Click(object sender, RoutedEventArgs e)
        {
            Reset_All_Btn_BordBrush();
            GRID_VERSION_MANAGE.Background = System.Windows.Media.Brushes.Orange;

            Frm_Task_Function.Navigate(m_PageVersionUpdate);
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_VER, 0);
        }

        /***********************************************************************************
        * function:
        * para:
        * return:
        * *********************************************************************************/
        public void Show_Version()
        {
            m_PageVersionUpdate.Show_Version();
        }
    }
}
