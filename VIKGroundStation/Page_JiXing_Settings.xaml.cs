using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_JiXing_Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Page_JiXing_Settings : Page
    {
        private static Page_JiXing_Settings m_Page_JiXing_Settings = new Page_JiXing_Settings();
        public static Page_JiXing_Settings getInstance()
        {
            if (m_Page_JiXing_Settings == null)
                m_Page_JiXing_Settings = new Page_JiXing_Settings();

            return m_Page_JiXing_Settings;
        }

        private Page_JiXing_Settings()
        {
            InitializeComponent();

            combox_volt_level1.Items.Add(TryFindResource("TITLE_LED_INDICATOR")); 
            combox_volt_level1.Items.Add(TryFindResource("TITLE_HOVER"));
            combox_volt_level1.Items.Add(TryFindResource("TITLE_BACK_HOME"));
            combox_volt_level1.SelectedIndex = 0;

            combox_volt_level2.Items.Add(TryFindResource("TITLE_BACK_HOME"));
            combox_volt_level2.Items.Add(TryFindResource("TITLE_LANDING"));
            combox_volt_level2.SelectedIndex = 0;
        }

        /*****************************************************************
         * 功   能：将所有的机型图片还原白色底色
         * 参   数：
         * 返   回：
         * ***************************************************************/
        private void Clear_All_JiXing_Brush()
        {
            BTN_PLANE_41_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
            BTN_PLANE_42_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;

            BTN_PLANE_61_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
            BTN_PLANE_62_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
            BTN_PLANE_63_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
            BTN_PLANE_64_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;

            BTN_PLANE_81_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
            BTN_PLANE_82_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
            BTN_PLANE_84_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
            BTN_PLANE_83_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
            BTN_PLANE_85_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
            BTN_PLANE_86_TYPE.BorderBrush = System.Windows.Media.Brushes.Transparent;
        }

        public static byte type_plane = 41;
        private void BTN_PLANE_63_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_63_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\63.png", UriKind.Relative));
            type_plane = 63;

        }

        private void BTN_PLANE_42_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_42_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\42.png", UriKind.Relative));
            type_plane = 42;
        }

        private void BTN_PLANE_41_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_41_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\41.png", UriKind.Relative));
            type_plane = 41;
        }

        private void BTN_PLANE_83_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_83_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\83.png", UriKind.Relative));
            type_plane = 83;
        }

        private void BTN_PLANE_84_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_84_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\84.png", UriKind.Relative));
            type_plane = 84;
        }

        private void BTN_PLANE_81_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_81_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\81.png", UriKind.Relative));
            type_plane = 81;
        }

        private void BTN_PLANE_61_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_61_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\61.png", UriKind.Relative));
            type_plane = 61;
        }

        private void BTN_PLANE_82_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_82_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\82.png", UriKind.Relative));
            type_plane = 82;
        }

        private void BTN_PLANE_62_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_62_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\62.png", UriKind.Relative));
            type_plane = 62;
        }

        private void BTN_PLANE_64_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_64_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\64.png", UriKind.Relative));
            type_plane = 64;
        }

        private void BTN_PLANE_85_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_85_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\85.png", UriKind.Relative));
            type_plane = 85;
        }

        private void BTN_PLANE_86_TYPE_Click(object sender, RoutedEventArgs e)
        {
            Clear_All_JiXing_Brush();
            BTN_PLANE_86_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;

            image_Plane.Source = new BitmapImage(new Uri(@"Images\86.png", UriKind.Relative));
            type_plane = 86;
        }

        private void Disable_All_Filter()
        {
            CHECK_BOX_FILTER_SUPER_HIGH.IsChecked = false;
            CHECK_BOX_FILTER_VERY_HIGH.IsChecked = false;
            CHECK_BOX_FILTER_HIGH.IsChecked = false;
            CHECK_BOX_FILTER_MID.IsChecked = false;
            CHECK_BOX_FILTER_LOW.IsChecked = false;
            CHECK_BOX_FILTER_VERY_LOW.IsChecked = false;
        }

        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
        * *********************************************************************/
        public byte filterType = 0;
        private void CHECK_BOX_FILTER_HIGH_Click(object sender, RoutedEventArgs e)
        {
            Disable_All_Filter();
            CHECK_BOX_FILTER_HIGH.IsChecked = true;

            filterType = 1;
        }

        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void CHECK_BOX_FILTER_MID_Click(object sender, RoutedEventArgs e)
        {
            Disable_All_Filter();
            CHECK_BOX_FILTER_MID.IsChecked = true;
            filterType = 2;
        }

        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void CHECK_BOX_FILTER_LOW_Click(object sender, RoutedEventArgs e)
        {
            Disable_All_Filter();
            CHECK_BOX_FILTER_LOW.IsChecked = true;
            filterType = 3;
        }

        private void CHECK_BOX_FILTER_VERY_LOW_Click(object sender, RoutedEventArgs e)
        {
            Disable_All_Filter();
            CHECK_BOX_FILTER_VERY_LOW.IsChecked = true;
            filterType = 4;
        }

        private void CHECK_BOX_FILTER_VERY_HIGH_Click(object sender, RoutedEventArgs e)
        {
            Disable_All_Filter();
            CHECK_BOX_FILTER_VERY_HIGH.IsChecked = true;
            filterType = 0;
        }

        private void CHECK_BOX_FILTER_SUPER_HIGH_Click(object sender, RoutedEventArgs e)
        {
            Disable_All_Filter();
            CHECK_BOX_FILTER_SUPER_HIGH.IsChecked = true;
            filterType = 5;
        }
        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
        * *********************************************************************/
        public byte daisu = 0;
        private void CHECK_BOX_DAISU_LOW_Click(object sender, RoutedEventArgs e)
        {
            CHECK_BOX_DAISU_LOW.IsChecked = true;
            CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = false;
            CHECK_BOX_DAISU_MID.IsChecked = false;
            CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = false;
            CHECK_BOX_DAISU_HIGH.IsChecked = false;
            daisu = 1;
        }

        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void CHECK_BOX_DAISU_LITTLE_LOW_Click(object sender, RoutedEventArgs e)
        {
            CHECK_BOX_DAISU_LOW.IsChecked = false;
            CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = true;
            CHECK_BOX_DAISU_MID.IsChecked = false;
            CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = false;
            CHECK_BOX_DAISU_HIGH.IsChecked = false;
            daisu = 2;
        }

        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void CHECK_BOX_DAISU_MID_Click(object sender, RoutedEventArgs e)
        {
            CHECK_BOX_DAISU_LOW.IsChecked = false;
            CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = false;
            CHECK_BOX_DAISU_MID.IsChecked = true;
            CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = false;
            CHECK_BOX_DAISU_HIGH.IsChecked = false;
            daisu = 3;
        }

        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void CHECK_BOX_DAISU_LITTLE_HIGH_Click(object sender, RoutedEventArgs e)
        {
            CHECK_BOX_DAISU_LOW.IsChecked = false;
            CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = false;
            CHECK_BOX_DAISU_MID.IsChecked = false;
            CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = true;
            CHECK_BOX_DAISU_HIGH.IsChecked = false;
            daisu = 4;
        }

        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
         * *********************************************************************/
        private void CHECK_BOX_DAISU_HIGH_Click(object sender, RoutedEventArgs e)
        {
            CHECK_BOX_DAISU_LOW.IsChecked = false;
            CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = false;
            CHECK_BOX_DAISU_MID.IsChecked = false;
            CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = false;
            CHECK_BOX_DAISU_HIGH.IsChecked = true;
            daisu = 5;
        }

        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void BTN_GET_JIXING_PARA_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_APTYPE, 0);
        }

        /************************************************************************
        * 功   能：
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void BTN_SET_JIXING_PARA_Click(object sender, RoutedEventArgs e)
        {
            byte[] buf_msg_send = new byte[255];
            byte index = 0;
            byte system_id = DATA_LINK.Get_System_Set_Id();

            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)14;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_APTYPE;

            buf_msg_send[index++] = type_plane;
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Circle_R.Text))[0];
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Circle_R.Text))[1];
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Link_Lost_Time.Text))[0];
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Link_Lost_Time.Text))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Safe_Volt_Level1.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Safe_Volt_Level1.Text) * 10))[1];
            buf_msg_send[index++] = (byte)combox_volt_level1.SelectedIndex;

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Safe_Volt_Level2.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Safe_Volt_Level2.Text) * 10))[1];
            buf_msg_send[index++] = (byte)(combox_volt_level2.SelectedIndex + 2);

            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_TakeOff_Alt.Text))[0];
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_TakeOff_Alt.Text))[1];

            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Fanhang_Alt.Text))[0];
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Fanhang_Alt.Text))[1];

            buf_msg_send[index++] = (byte)(sbyte.Parse(TextBox_Mag_Error.Text));
            buf_msg_send[index++] = filterType;
            buf_msg_send[index++] = daisu;

            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Remoter_Lost.Text))[0];
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Remoter_Lost.Text))[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            DATA_LINK.Send_Buf(buf_msg_send, index + 2);

            string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
            string str_temp = "plane_type" + " " + type_plane.ToString();
            MainWindow.stream_gcs_log.WriteLine(str_time + str_temp);
            MainWindow.stream_gcs_log.Flush();
        }

        /************************************************************************
        * 功   能：获取并显示飞行器的设置
        * 参   数：
        * 返   回：
        * *********************************************************************/
        public void Show_Plane_Settings()
        {
            PLANE_SETTING mPlane_Setting = DataProcess_JD.Get_Plane_Setting();

            image_background(mPlane_Setting._plane_type);
            TextBox_Circle_R.Text = mPlane_Setting._circle_r.ToString();
            TextBox_Link_Lost_Time.Text = (mPlane_Setting._link_lost).ToString();

            TextBox_Safe_Volt_Level1.Text = ((double)mPlane_Setting._saft_volt_level1 / 10).ToString("0.0");

            if (mPlane_Setting._saft_volt_level1_action >= 0 && mPlane_Setting._saft_volt_level1_action <= 2)
                combox_volt_level1.SelectedIndex = mPlane_Setting._saft_volt_level1_action;
            else
                combox_volt_level1.SelectedIndex = 0;

            TextBox_Safe_Volt_Level2.Text = ((double)(mPlane_Setting._saft_volt_level2) / 10).ToString("0.0");

            if(mPlane_Setting._saft_volt_level2_action >= 2 && mPlane_Setting._saft_volt_level2_action <= 3)
                combox_volt_level2.SelectedIndex = mPlane_Setting._saft_volt_level2_action - 2;
            else
                combox_volt_level2.SelectedIndex = 0;

            TextBox_TakeOff_Alt.Text = mPlane_Setting._takeoff_alt.ToString();
            TextBox_Fanhang_Alt.Text = (mPlane_Setting._return_alt).ToString();

            TextBox_Mag_Error.Text = mPlane_Setting._mag_bias.ToString();
            filterType = mPlane_Setting._filter_level;
            daisu = mPlane_Setting._daisu;

            TextBox_Remoter_Lost.Text = mPlane_Setting._remoter_lost.ToString();

            Disable_All_Filter();
            if (filterType == 0)
            {
                CHECK_BOX_FILTER_VERY_HIGH.IsChecked = true;
            }
            else if (filterType == 1)
            {
                CHECK_BOX_FILTER_HIGH.IsChecked = true;
            }
            else if (filterType == 2)
            {
                CHECK_BOX_FILTER_MID.IsChecked = true;
            }
            else if (filterType == 3)
            {
                CHECK_BOX_FILTER_LOW.IsChecked = true;
            }
            else if (filterType == 4)
            {
                CHECK_BOX_FILTER_VERY_LOW.IsChecked = true;
            }
            else if (filterType == 5)
            {
                CHECK_BOX_FILTER_SUPER_HIGH.IsChecked = true;
            }

            if (daisu == 1)
            {
                CHECK_BOX_DAISU_LOW.IsChecked = true;
                CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = false;
                CHECK_BOX_DAISU_MID.IsChecked = false;
                CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = false;
                CHECK_BOX_DAISU_HIGH.IsChecked = false;
            }
            else if(daisu == 2)
            {
                CHECK_BOX_DAISU_LOW.IsChecked = false;
                CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = true;
                CHECK_BOX_DAISU_MID.IsChecked = false;
                CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = false;
                CHECK_BOX_DAISU_HIGH.IsChecked = false;
            }
            else if (daisu == 3)
            {
                CHECK_BOX_DAISU_LOW.IsChecked = false;
                CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = false;
                CHECK_BOX_DAISU_MID.IsChecked = true;
                CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = false;
                CHECK_BOX_DAISU_HIGH.IsChecked = false;
            }
            else if (daisu == 4)
            {
                CHECK_BOX_DAISU_LOW.IsChecked = false;
                CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = false;
                CHECK_BOX_DAISU_MID.IsChecked = false;
                CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = true;
                CHECK_BOX_DAISU_HIGH.IsChecked = false;
            }
            else if (daisu == 5)
            {
                CHECK_BOX_DAISU_LOW.IsChecked = false;
                CHECK_BOX_DAISU_LITTLE_LOW.IsChecked = false;
                CHECK_BOX_DAISU_MID.IsChecked = false;
                CHECK_BOX_DAISU_LITTLE_HIGH.IsChecked = false;
                CHECK_BOX_DAISU_HIGH.IsChecked = true;
            }
        }

        /************************************************************************
        * 功   能：获取并显示飞行器类型
        * 参   数：
        * 返   回：
        * *********************************************************************/
        public void image_background(byte type_plane_type)
        {
            type_plane = type_plane_type;
            Clear_All_JiXing_Brush();

            switch (type_plane_type)
            {
                case 41:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\41.png", UriKind.Relative));
                    BTN_PLANE_41_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 61:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\61.png", UriKind.Relative));
                    BTN_PLANE_61_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 81:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\81.png", UriKind.Relative));
                    BTN_PLANE_81_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 42:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\42.png", UriKind.Relative));
                    BTN_PLANE_42_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 62:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\62.png", UriKind.Relative));
                    BTN_PLANE_62_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 82:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\82.png", UriKind.Relative));
                    BTN_PLANE_82_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 83:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\83.png", UriKind.Relative));
                    BTN_PLANE_83_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 84:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\84.png", UriKind.Relative));
                    BTN_PLANE_84_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 85:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\85.png", UriKind.Relative));
                    BTN_PLANE_85_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 86:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\86.png", UriKind.Relative));
                    BTN_PLANE_86_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 64:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\32.bmp", UriKind.Relative));
                    BTN_PLANE_64_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 63:
                    image_Plane.Source = new BitmapImage(new Uri(@"Images\63.png", UriKind.Relative));
                    BTN_PLANE_63_TYPE.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
            }
        }

        private void TextBox_TakeOff_Alt_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Link_Lost_Time_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Fanhang_Alt_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Circle_R_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_Radar_Kx_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox_TakeOff_Alt_KeyDown_LostFocus(object sender, RoutedEventArgs e)
        {
            if ("" == TextBox_TakeOff_Alt.Text)
                TextBox_TakeOff_Alt.Text = "0";
        }
    }
}
