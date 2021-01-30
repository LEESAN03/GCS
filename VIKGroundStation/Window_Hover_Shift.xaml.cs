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
using System.Windows.Threading;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_Hover_Shift.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Hover_Shift : Window
    {
        private static Window_Hover_Shift m_Window_Hover_SHIFT = new Window_Hover_Shift();
        public static Window_Hover_Shift getInstance()
        {
            if (m_Window_Hover_SHIFT == null)
                m_Window_Hover_SHIFT = new Window_Hover_Shift();
            return m_Window_Hover_SHIFT;
        }

        public static void Wnd_Show()
        {
            Window_Hover_Shift hWnd = getInstance();
            hWnd.Show();
            mb_wnd_visible = true;
            mb_wnd_initializaed = true;
        }

        public static void Wnd_Hide()
        {
            Window_Hover_Shift hWnd = getInstance();
            hWnd.Hide();
            mb_wnd_visible = false;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;
        public static DispatcherTimer timer_keyboard;
        public Window_Hover_Shift()
        {
            InitializeComponent();
            this.Top = SystemParameters.PrimaryScreenHeight * 0.1;
            this.Left = SystemParameters.PrimaryScreenWidth * 0.4;

            Hide();
            Owner = MainWindow.getInstance();

            timer_keyboard = new DispatcherTimer();
            timer_keyboard.Interval = System.TimeSpan.FromMilliseconds(50);
            timer_keyboard.Tick += timer_keyboard_Tick;

            combox_rock_12.Items.Add(1);
            combox_rock_12.Items.Add(2);
            combox_rock_12.Items.Add(3);
            combox_rock_12.Items.Add(4);
            combox_rock_12.Items.Add(5);
            combox_rock_12.Items.Add(6);
            combox_rock_12.SelectedIndex = 2;

            combox_rock_34.Items.Add(1);
            combox_rock_34.Items.Add(2);
            combox_rock_34.SelectedIndex = 0;
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
        public static short rock_aileron = 1500, rock_elevator = 1500,  rock_throttle = 1500,  rock_rudder = 1500;
        public static short rock_aileron_last = 1500, rock_elevator_last = 1500, rock_throttle_last = 1500, rock_rudder_last = 1500;

        private void Btn_EXIT_Click(object sender, RoutedEventArgs e)
        {
            timer_keyboard.Stop();
            this.Hide();
        }

        public static short rock_aileron_send = 1500, rock_elevator_send = 1500, rock_throttle_send = 1500, rock_rudder_send = 1500;
        public static short keyboard_control_count = 0;

        public static void Init_rock()
        {
            rock_aileron = 1500;
            rock_elevator = 1500;
            rock_throttle = 1500;
            rock_rudder = 1500;

            rock_aileron_last = 1500;
            rock_elevator_last = 1500;
            rock_throttle_last = 1500;
            rock_rudder_last = 1500;

            rock_aileron_send = 1500;
            rock_elevator_send = 1500;
            rock_throttle_send = 1500;
            rock_rudder_send = 1500;
        }

        private void timer_keyboard_Tick(object sender, EventArgs e)
        {
            rock_aileron_send = (short)Compute.Math_Constrain(rock_aileron, rock_aileron_last - 30, rock_aileron_last + 30);
            rock_aileron_last = rock_aileron_send;

            rock_elevator_send = (short)Compute.Math_Constrain(rock_elevator, rock_elevator_last - 30, rock_elevator_last + 30);
            rock_elevator_last = rock_elevator_send;

            rock_throttle_send = (short)Compute.Math_Constrain(rock_throttle, rock_throttle_last - 30, rock_throttle_last + 30);
            rock_throttle_last = rock_throttle_send;

            rock_rudder_send = (short)Compute.Math_Constrain(rock_rudder, rock_rudder_last - 30, rock_rudder_last + 30);
            rock_rudder_last = rock_rudder_send;

            if (keyboard_control_count++ > 10)
                keyboard_control_count = 10;

            if (keyboard_control_count <= 3)
            {
                DATA_LINK.Send_Rock_Msg(1);
            }
            else if (4 <= keyboard_control_count && keyboard_control_count <= 6)
            {
                DATA_LINK.Send_Rock_Msg(0);
            }
            else
            {
                DATA_LINK.Send_Rock_Msg(1);
            }
        }

        /***********************************************************************
        * function:
        * para:
        * return:
        * *********************************************************************/
        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down)
            {
                rock_elevator = 1500;
                GRID_KEYBOARD_FORWARD.Background = Brushes.Transparent;
                GRID_KEYBOARD_BACKWARD.Background = Brushes.Transparent;
            }
            else if (e.Key == Key.Left || e.Key == Key.Right)
            {
                rock_aileron = 1500;
                GRID_KEYBOARD_LEFT.Background = Brushes.Transparent;
                GRID_KEYBOARD_RIGHT.Background = Brushes.Transparent;
            }
            else if (e.Key == Key.W || e.Key == Key.S)
            {
                rock_throttle = 1500;
                GRID_KEYBOARD_UP.Background = Brushes.Transparent;
                GRID_KEYBOARD_DOWN.Background = Brushes.Transparent;
            }
            else if (e.Key == Key.A || e.Key == Key.D)
            {
                rock_rudder = 1500;
                GRID_KEYBOARD_COUTER_CLOCK_WISE.Background = Brushes.Transparent;
                GRID_KEYBOARD_CLOCK_WISE.Background = Brushes.Transparent;
            }
        }


        /***********************************************************************
        * function:
        * para:
        * return:
        * *********************************************************************/
        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            double rock_velocity = 0,  rock_climb_rate = 0;

            rock_velocity = (double)(combox_rock_12.SelectedIndex+1);
             rock_climb_rate = (double)(combox_rock_34.SelectedIndex+1);

            // forward-backward
            if (e.Key == Key.Up)
            {
                rock_elevator = (short)(1500 - (short)(rock_velocity / 6 * 500));
                GRID_KEYBOARD_FORWARD.Background = Brushes.Orange;
                GRID_KEYBOARD_BACKWARD.Background = Brushes.Transparent;
            }
            // go backward
            else if (e.Key == Key.Down)
            {
                rock_elevator = (short)(1500 + (short)(rock_velocity / 6 * 500));
                GRID_KEYBOARD_BACKWARD.Background = Brushes.Orange;
                GRID_KEYBOARD_FORWARD.Background = Brushes.Transparent;
            }
            
            // left-right
            if (e.Key == Key.Left)
            {
                rock_aileron = (short)(1500 - (short)(rock_velocity / 6 * 500));
                GRID_KEYBOARD_LEFT.Background = Brushes.Orange;
                GRID_KEYBOARD_RIGHT.Background = Brushes.Transparent;
            }
            // go right
            else if (e.Key == Key.Right)
            {
                rock_aileron = (short)(1500 + (short)(rock_velocity / 6 * 500));
                GRID_KEYBOARD_RIGHT.Background = Brushes.Orange;
                GRID_KEYBOARD_LEFT.Background = Brushes.Transparent;
            }

            // throttle
            if (e.Key == Key.W)
            {
                rock_throttle = (short)(1500 + (short)(rock_climb_rate / 2 * 500));
                GRID_KEYBOARD_UP.Background = Brushes.Orange;
                GRID_KEYBOARD_DOWN.Background = Brushes.Transparent;
            }
            // go right
            else if (e.Key == Key.S)
            {
                rock_throttle = (short)(1500 - (short)(rock_climb_rate / 2 * 500));
                GRID_KEYBOARD_DOWN.Background = Brushes.Orange;
                GRID_KEYBOARD_UP.Background = Brushes.Transparent;
            }

            // throttle
            if (e.Key == Key.A)
            {
                rock_rudder = (short)(1500 - (short)(rock_climb_rate / 2 * 500));
                GRID_KEYBOARD_COUTER_CLOCK_WISE.Background = Brushes.Orange;
                GRID_KEYBOARD_CLOCK_WISE.Background = Brushes.Transparent;
            }
            // go right
            else if (e.Key == Key.D)
            {
                rock_rudder = (short)(1500 + (short)(rock_climb_rate / 2 * 500));
                GRID_KEYBOARD_CLOCK_WISE.Background = Brushes.Orange;
                GRID_KEYBOARD_COUTER_CLOCK_WISE.Background = Brushes.Transparent;
            }
        }
    }
}
