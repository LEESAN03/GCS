using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VIKGroundStation
{
    /// <summary>
    /// Interaction logic for MessageTimerWindow.xaml
    /// </summary>
    public partial class MessageTimerWindow : Window
    {
        private static MessageTimerWindow m_wnd_msg_timer = new MessageTimerWindow();
        public static MessageTimerWindow getInstance()
        {
            if (m_wnd_msg_timer == null)
                m_wnd_msg_timer = new MessageTimerWindow();
            return m_wnd_msg_timer;
        }

        public MessageTimerWindow()
        {
            InitializeComponent();
            Owner = MainWindow.getInstance();
            Show();

            Left = (SystemParameters.PrimaryScreenWidth - this.Width) * 0.5;
            Top = (SystemParameters.PrimaryScreenHeight) * 0.2;
        }

        /***********************************************************************
         * function:
         * para:
         * return:
         * *********************************************************************/
        public  static void Update_Data(string argStr)
        {
            getInstance().textBlock_message.Text = argStr;
        }
    }
}
