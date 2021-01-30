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
    /// Window_Confirm.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Confirm : Window
    {
        private static Window_Confirm m_wnd_confirm = new Window_Confirm();
        public static Window_Confirm getInstance()
        {
            if (m_wnd_confirm == null)
                m_wnd_confirm = new Window_Confirm();
            return m_wnd_confirm;
        }

        public bool  Yes_No = false;

        public Window_Confirm()
        {
            InitializeComponent();
            Topmost = true;
        }

        private void BTN_Y_Click(object sender, RoutedEventArgs e)
        {
            Yes_No = true;
            this.Hide();
        }

        private void BTN_N_Click(object sender, RoutedEventArgs e)
        {
            Yes_No = false;
            this.Hide();
        }
    }
}
