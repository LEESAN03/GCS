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
    /// Window_Target.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Target : Window
    {
        private static Window_Target m_wnd_target = new Window_Target();
        public static Window_Target getInstance()
        {
            if (m_wnd_target == null)
                m_wnd_target = new Window_Target();
            return m_wnd_target;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;

        public static void Wnd_Show()
        {
            Window_Target hWnd = getInstance();
            hWnd.Show();
            mb_wnd_visible = true;
            mb_wnd_initializaed = true;
        }

        public static void Wnd_Hide()
        {
            Window_Target hWnd = getInstance();
            hWnd.Hide();
            mb_wnd_visible = false;
        }
        public Window_Target()
        {
            InitializeComponent();
            Owner = MainWindow.getInstance();

            if (App.plane_type == 0)
            {
                BTN_TARGET_CANCEL.Visibility = Visibility.Hidden;
            }
        }

        private void BTN_TARGET_OK_Click(object sender, RoutedEventArgs e)
        {
            switch (Page_Fly_Map.change_target_type)
            {
                case 1:
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_BianGao, (short)(double.Parse(TextBox_Target_Value.Text) * 10));
                    break;
                case 2:
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Change_Spd, (short)(float.Parse(TextBox_Target_Value.Text) * 10));
                    break;
                case 3:
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_BianDian, short.Parse(TextBox_Target_Value.Text));
                    break;
                case 4:
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_FLyTimes, short.Parse(TextBox_Target_Value.Text));
                    break;
                default:
                    break;
            }
        }

        private void BTN_TARGET_CANCEL_Click(object sender, RoutedEventArgs e)
        {
            switch (Page_Fly_Map.change_target_type)
            {
                case 1:
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Cancel_Spd, 1);
                    break;
                case 2:
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Cancel_Spd, 2);
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }

        private void BTN_TARGET_EXIT_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
