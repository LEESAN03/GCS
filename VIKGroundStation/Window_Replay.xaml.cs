using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace VIKGroundStation
{
    /// <summary>
    /// Interaction logic for Window_Replay.xaml
    /// </summary>
    public partial class Window_Replay : Window
    {
        private static Window_Replay m_wnd_replay = new Window_Replay();
        public static Window_Replay getInstance()
        {
            if (m_wnd_replay == null)
                m_wnd_replay = new Window_Replay();

            mb_wnd_initialized = true;
            return m_wnd_replay;
        }

        public static bool mb_wnd_initialized = false;
        public static bool mb_wnd_visible = false;

        public void Show_Wnd()
        {
            Show();
            mb_wnd_visible = true;
        }
        public void Hide_Wnd()
        {
            Hide();
            mb_wnd_visible = false;
        }

        public Window_Replay()
        {
            InitializeComponent();
            Owner = MainWindow.getInstance();

            Slider_Replay_Progress.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(Slider_Replay_Progress_MouseLeftButtonUp), true);
            Slider_Replay_Progress.AddHandler(Slider.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Slider_Replay_Progress_MouseLeftButtonDown), true);

            Slider_Replay_Rate.AddHandler(Slider.MouseLeftButtonUpEvent, new MouseButtonEventHandler(Slider_Replay_Rate_MouseLeftButtonUp), true);
            Slider_Replay_Rate.AddHandler(Slider.MouseLeftButtonDownEvent, new MouseButtonEventHandler(Slider_Replay_Rate_MouseLeftButtonDown), true);

            // 自动回放时钟
            t_playBack = new DispatcherTimer();
            t_playBack.Interval = TimeSpan.FromMilliseconds(TimerSpan);
            t_playBack.Tick += Timer_Play_Back;
        }

        // 数据回放
        public DispatcherTimer t_playBack;
        public double TimerSpan = 50;


        /******************************************************************
        * 函数功能：数据回放定时器
        * ***************************************************************/
        public byte[] buf_play_back;
        // 每个时钟读取的字节数
        private const ushort bytes_rach_while = 200;
        void Timer_Play_Back(object sender, EventArgs e)
        {
            if (DATA_LINK.byteToBeParse + bytes_rach_while <= 10000)
            {
                if ((int)Slider_Replay_Progress.Value + bytes_rach_while <= Slider_Replay_Progress.Maximum)
                {
                    Array.Copy(buf_play_back, (int)Slider_Replay_Progress.Value, DATA_LINK.destinationArray, DATA_LINK.byteToBeParse, bytes_rach_while);
                    DATA_LINK.byteToBeParse += bytes_rach_while;
                }
                else
                {
                    short restCount = (short)(Slider_Replay_Progress.Maximum - Slider_Replay_Progress.Value);
                    Array.Copy(buf_play_back, (int)Slider_Replay_Progress.Value, DATA_LINK.destinationArray, DATA_LINK.byteToBeParse, restCount);
                }
            }
            else
            {
                Array.Copy(buf_play_back, (int)Slider_Replay_Progress.Value, DATA_LINK.destinationArray, 0, bytes_rach_while);
                DATA_LINK.byteToBeParse = bytes_rach_while;
            }

            DATA_LINK.Decode_SerialPort_Data();
            Slider_Replay_Progress.Value += bytes_rach_while;

            if (Slider_Replay_Progress.Value >= Slider_Replay_Progress.Maximum)
            {
                t_playBack.Stop();
            }
        }

        private void Slider_Replay_Rate_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            t_playBack.Stop();
        }

        private void Slider_Replay_Progress_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            t_playBack.Stop();
        }

        private void Slider_Replay_Progress_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Slider_Replay_Progress.Maximum == 100)
                return;

            t_playBack.Start();
        }

        private void Slider_Replay_Rate_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Slider_Replay_Progress.Maximum == 100)
                return;

            TimerSpan = (100 - Slider_Replay_Rate.Value) * 1000 / 100.0;
            t_playBack.Interval = TimeSpan.FromMilliseconds(TimerSpan);
            t_playBack.Start();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
        }

        /**************************************************************************
        * 功   能：打开回放数据
        * 参   数：
        * 返   回：
        * ***********************************************************************/
        private void BTN_OPEN_REPLAY_DATA_Click(object sender, RoutedEventArgs e)
        {
            if (DATA_LINK.DonwLink_SerialPort.IsOpen == true)
            {
                Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_PLEASE_CLOSE_SERIAL").ToString());
                return;
            }

            if (DATA_LINK.con != null)
            {
                if (DATA_LINK.con.readClientThread != null)
                { 
                    if (DATA_LINK.con.readClientThread.IsAlive)
                    {
                        Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_PLEASE_CLOSE_SERIAL").ToString());
                        return;
                    }
                }
            }

            Microsoft.Win32.OpenFileDialog ofr;    // 数据回放
            ofr = new Microsoft.Win32.OpenFileDialog();
            ofr.DefaultExt = ".dat";
            ofr.Filter = "dat file|*.dat";

            if (ofr.ShowDialog() == true)
            {
                playback_data_type = 1;

                TextBlock_Replay_Data_Path.Text = ofr.FileName;
                FileStream ofrfile;
                BinaryReader ofrsr;

                ofrfile = new FileStream(ofr.FileName, FileMode.Open, FileAccess.Read);
                ofrsr = new BinaryReader(ofrfile);

                buf_play_back = new byte[ofrfile.Length];
                int n = (int)ofrfile.Length;
                for (int i = 0; i < n; i++)
                    buf_play_back[i] = ofrsr.ReadByte();

                Slider_Replay_Progress.Maximum = ofrfile.Length;

                t_playBack.Start();
                DATA_LINK.byteToBeParse = 0;
                Slider_Replay_Progress.Value = 0;
            }
        }

        private void BTN_REPLAY_CONTINUE_Click(object sender, RoutedEventArgs e)
        {
            if (Slider_Replay_Progress.Maximum == 100)
                return;
            t_playBack.Start();
        }

        private void BTN_REPLAY_PAUSE_Click(object sender, RoutedEventArgs e)
        {
            if (Slider_Replay_Progress.Maximum == 100)
                return;
            t_playBack.Stop();
        }

        public static byte playback_data_type = 0; 
        private void BTN_REPLAY_EXIT_Click(object sender, RoutedEventArgs e)
        {
            playback_data_type = 0;
            t_playBack.Stop();

            this.Hide();
        }
    }
}
