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
using System.Windows.Shapes;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_Operation_Indication.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Operation_Indication : Window
    {
        private static Window_Operation_Indication m_wnd_operation_indication = new Window_Operation_Indication();
        public static Window_Operation_Indication getInstance()
        {
            if (m_wnd_operation_indication == null)
                m_wnd_operation_indication = new Window_Operation_Indication();
            return m_wnd_operation_indication;
        }
        public Window_Operation_Indication()
        {
            InitializeComponent();
            Topmost = true;
        }

        private void BTN_CONFIRM_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public static void Set_Indication_Text(string str)
        {
            Window_Operation_Indication nWnd = getInstance();
            nWnd.TextBlock_Operation_Indication.Text = str;
            nWnd.ShowDialog();
        }
    }
}
