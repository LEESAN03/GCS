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
    /// Window_Engine.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Engine : Window
    {
        private static Window_Engine m_wnd_engine = new Window_Engine();
        public static Window_Engine getInstance()
        {
            if (m_wnd_engine == null)
                m_wnd_engine = new Window_Engine();
            return m_wnd_engine;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;

        public static void Wnd_Show()
        {
            Window_Engine hWnd = getInstance();
            hWnd.Show();
            mb_wnd_visible = true;
            mb_wnd_initializaed = true;
        }

        public static void Wnd_Hide()
        {
            Window_Engine hWnd = getInstance();
            hWnd.Hide();
            mb_wnd_visible = false;
        }
        public Window_Engine()
        {
            InitializeComponent();

            Top = SystemParameters.PrimaryScreenHeight * 10 / 16;
            Left = SystemParameters.PrimaryScreenWidth * 0.05;

            Hide();
            Owner = MainWindow.getInstance();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch
            {
            }
        }

        /**************************************************************************
         * function:
         * para:
         * return:
         * ************************************************************************/
        public void Show_Engine_Infor()
        {
            YOUDIAN_STRUCT m_youdian = DataProcess_JD.Get_YouDian_Struct();

            TextBlock_Engine_Speed.Text = "转速: " + m_youdian._engine_speed + " rpm";
            TextBlock_Oil.Text = "油量: " + m_youdian._rest_oil.ToString() + "%";
            TextBlock_Engine1_Temp.Text = "缸1温度: " + m_youdian._cylinder1_temperature.ToString() + "  ℃";
            TextBlock_Engine2_Temp.Text = "缸2温度: " + m_youdian._cylinder2_temperature.ToString() + "  ℃";
            TextBlock_Adc.Text = "发动机电压: " + ((double)m_youdian._engine_volt / 10).ToString("0.0") + "  V";
            TextBlock_Current.Text = "充电电流: " + ((double)m_youdian._charge_current / 10).ToString("0.0") + "  A";
            TextBlock_Total_Time.Text = "总工作时间: " + m_youdian._total_time.ToString() + " min";
            TextBlock_Rest_Time.Text = "保养时间: " + m_youdian._work_time_rest.ToString() + " min";
        }
    }
}
