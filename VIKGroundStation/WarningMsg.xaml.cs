using System;
using System.Windows;

namespace VIKGroundStation
{
    /// <summary>
    /// Interaction logic for WarningMsg.xaml
    /// </summary>
    public partial class WarningMsg : Window
    {
        private static WarningMsg m_wnd_warnning = new WarningMsg();
        public static WarningMsg getInstance()
        {
            if (m_wnd_warnning == null)
                m_wnd_warnning = new WarningMsg();
            return m_wnd_warnning;
        }

        public WarningMsg()
        {
            InitializeComponent();
            Owner = MainWindow.getInstance();
            Show();
        }

        public  static void Update_Warnning_Msg(string str)
        {
                getInstance().Msg_Warnning_Type.Text = str;
        }
    }
}
