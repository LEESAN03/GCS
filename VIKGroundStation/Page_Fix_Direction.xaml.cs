using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Fix_Direction.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Fix_Direction : Page
    {
        private static Page_Fix_Direction m_Page_Fix_Direction = new Page_Fix_Direction();
        public static Page_Fix_Direction getInstance()
        {
            if (m_Page_Fix_Direction == null)
                m_Page_Fix_Direction = new Page_Fix_Direction();

            return m_Page_Fix_Direction;
        }

        private Page_Fix_Instruction m_PageFixInstruction = Page_Fix_Instruction.getInstance();
        public Page_Fix_Direction()
        {
            InitializeComponent();

            Combox_Gps_Heading.Items.Add(TryFindResource("TITLE_ANTENNA_FRONT_BACK"));
            Combox_Gps_Heading.Items.Add(TryFindResource("TITLE_ANTENNA_LEFT_RIGHT"));
        }

        private void MAG_CALIBRATE_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_MAG, 0);
            }
        }

        private void HORIZONTAL_CALIBRATE_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Attuide, 0);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Horizontal calibration done");
                MainWindow.stream_gcs_log.Flush();
            }
        }

        private void FORWARD_AN_ZHUANG_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_ANZHUANG, AN_Zhuang.Cout_qian);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Forward installation");
                MainWindow.stream_gcs_log.Flush();
            }
        }

        private void RIGHT_AN_ZHUANG_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_ANZHUANG, AN_Zhuang.Cout_you);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Right installation");
                MainWindow.stream_gcs_log.Flush();
            }
        }

        private void BACK_AN_ZHUANG_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_ANZHUANG, AN_Zhuang.Cout_hou);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Back installation");
                MainWindow.stream_gcs_log.Flush();
            }
        }

        private void LEFT_AN_ZHUANG_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_ANZHUANG, AN_Zhuang.Cout_zuo);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Left installation");
                MainWindow.stream_gcs_log.Flush();
            }
        }


        /*************************************************************************
         * 功   能：显示安装方向信息
         * 参   数：
         * 返   回：
         * **********************************************************************/
        public void ShowFixInfor(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            FORWARD_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.White;
            FORWARD_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.White;

            RIGHT_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.White;
            RIGHT_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.White;

            BACK_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.White;
            BACK_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.White;

            LEFT_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.White;
            LEFT_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.White;

            switch (mFly_Infor_Display.direction_filter & (byte)0x0f)
            {
                case 1:
                    FORWARD_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.Orange;
                    FORWARD_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.Orange;
                    break;
                case 2:
                    RIGHT_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.Orange;
                    RIGHT_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.Orange;
                    break;
                case 3:
                    BACK_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.Orange;
                    BACK_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.Orange;
                    break;
                case 4:
                    LEFT_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.Orange;
                    LEFT_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.Orange;
                    break;
                default:
                    break;
            }
        }

        /****************************************************************************
        * 功   能：获取GPS的安装位置
        * 参   数：
        * 返   回：
        * *************************************************************************/
        private void BTN_GET_GPS_BIAS_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_GPS_BIAS, 0);
        }

        /****************************************************************************
         * 功   能：设置GPS的安装偏差
         * 参   数：
         * 返   回：
         * *************************************************************************/
        private void BTN_SET_GPS_BIAS_Click(object sender, RoutedEventArgs e)
        {
            short xBias_A, yBias_A, zBias_A, xBias_B, yBias_B, zBias_B;

            xBias_A = (short)(double.Parse(TextBox_GPS_X_BIAS.Text));
            yBias_A = (short)(double.Parse(TextBox_GPS_Y_BIAS.Text));
            zBias_A = (short)(double.Parse(TextBox_GPS_Z_BIAS.Text));
            xBias_B = (short)(double.Parse(TextBox_GPS_B_X_BIAS.Text));
            yBias_B = (short)(double.Parse(TextBox_GPS_B_Y_BIAS.Text));
            zBias_B = (short)(double.Parse(TextBox_GPS_B_Z_BIAS.Text));

            DATA_LINK.Send_GPS_Bias_Msg(MsgDef.MSG_GPS_BIAS, xBias_A, yBias_A, zBias_A, xBias_B, yBias_B, zBias_B);
        }

        /****************************************************************************
        * 功   能：显示当前GPS安装偏差
        * 参   数：
        * 返   回：
        * *************************************************************************/
        public void Update_Gps_Bias()
        {
            TextBox_GPS_X_BIAS.Text = DataProcess_JD.mStruct_Gps_Bias._gpsA_x_bias.ToString();
            TextBox_GPS_Y_BIAS.Text = DataProcess_JD.mStruct_Gps_Bias._gpsA_y_bias.ToString();
            TextBox_GPS_Z_BIAS.Text = DataProcess_JD.mStruct_Gps_Bias._gpsA_z_bias.ToString();

            TextBox_GPS_B_X_BIAS.Text = DataProcess_JD.mStruct_Gps_Bias._gpsB_x_bias.ToString();
            TextBox_GPS_B_Y_BIAS.Text = DataProcess_JD.mStruct_Gps_Bias._gpsB_y_bias.ToString();
            TextBox_GPS_B_Z_BIAS.Text = DataProcess_JD.mStruct_Gps_Bias._gpsB_z_bias.ToString();
        }

        private void BTN_GET_GPS_HEADING_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, 24, 16);
        }

        /*****************************************************************
         * 功能：设置GPS双天线安装方向
         * ***************************************************************/
        private void BTN_SET_GPS_HEADING_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Single_Para(16, (short)(Combox_Gps_Heading.SelectedIndex));
        }

        private void TextBox_GPS_X_BIAS_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key <= Key.OemMinus))
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
        
        private void TextBox_GPS_Y_BIAS_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key <= Key.OemMinus))
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

        private void TextBox_GPS_Z_BIAS_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key <= Key.OemMinus))
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
    }
}
