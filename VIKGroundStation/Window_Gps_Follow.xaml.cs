using System;
using System.Collections.Generic;
using System.IO.Ports;
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
    /// Window_Gps_Follow.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Gps_Follow : Window
    {
        private static Window_Gps_Follow m_wnd_gps_follow = new Window_Gps_Follow();
        public static Window_Gps_Follow getInstance()
        {
            if (m_wnd_gps_follow == null)
                m_wnd_gps_follow = new Window_Gps_Follow();
            return m_wnd_gps_follow;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;
        public static byte get_dist_status = 0;

        public static void Wnd_Show()
        {
            Window_Gps_Follow hWnd = getInstance();
            hWnd.Show();
            mb_wnd_visible = true;
            mb_wnd_initializaed = true;
        }

        public static void Wnd_Hide()
        {
            Window_Gps_Follow hWnd = getInstance();
            hWnd.Hide();
            mb_wnd_visible = false;
        }

        public Window_Gps_Follow()
        {
            InitializeComponent();
            Hide();
            Owner = MainWindow.getInstance();

            combox_data_source.Items.Add(TryFindResource("TITLE_FLIGHT_CONTROL"));
            combox_data_source.Items.Add(TryFindResource("TITLE_BASE_STATION"));
            combox_data_source.SelectedIndex = 0;

            combox_base_mode.Items.Add(TryFindResource("TITLE_MODE_FIX_BASE"));
            combox_base_mode.Items.Add(TryFindResource("TITLE_MODE_MOVING_BASE"));
            combox_base_mode.SelectedIndex = 0;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
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

        /****************************************************************************
         * function: end gps follow mode
         * para:
         * return:
         * **************************************************************************/
        private void Btn_Gps_Follow_End_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.FollowGps_Layer.Markers.Clear();

            if (DATA_LINK.Follow_SerialPort.IsOpen == true)
            {
                try
                {
                    System.Windows.Forms.Application.DoEvents();
                    DATA_LINK.Follow_SerialPort.Close();
                }
                catch { };
            }

            if (DATA_LINK.thread_gps_link != null)
            {
                DATA_LINK.thread_gps_link.Abort();
                DATA_LINK.thread_gps_link = null;
            }

            this.Hide();
            mb_wnd_visible = false;
        }

        /***********************************************************************
         * function:
         * para:
         * return:
        * **********************************************************************/
        private void Btn_Follow_Connect_Click(object sender, RoutedEventArgs e)
        {
            if (combox_follow.Text == "")
                return;

            if (DATA_LINK.Follow_SerialPort != null)
            {
                if (DATA_LINK.thread_gps_link != null)
                {
                    DATA_LINK.thread_gps_link.Abort();
                    DATA_LINK.thread_gps_link = null;
                }

                if (DATA_LINK.Follow_SerialPort.IsOpen == true)
                {
                    try
                    {
                        while (DATA_LINK.follow_is_listen)
                            System.Windows.Forms.Application.DoEvents();

                        DATA_LINK.Follow_SerialPort.Close();
                    }
                    catch
                    {
                    }
                }
                DATA_LINK.Gps_Connect(combox_follow.Text);
            }
        }

        /***********************************************************************************
        * functon:
        * para:
        * return:
        * ********************************************************************************/
        private byte base_show_count = 0;
        public void Follow_Infor_Display()
        {
            FOLLOW_GPS_POS m_FollowGps = DataProcess_JD.Get_Follow_Gps_Struct();

            byte sys_id_set = DATA_LINK.Get_System_Set_Id();
            FLY_INFOR_DISPLAY fly_display = DataProcess_JD.Get_Fly_Display(sys_id_set);

            this.Dispatcher.Invoke(new Action(delegate
            {
                // base pos/vel/heading from fc
                if (combox_data_source.SelectedIndex == 0)
                {
                    TextBlock_Gps_Num.Text = "ANT1: " + fly_display.base_ant1_num.ToString() + "     " + "ANT2: " + fly_display.base_ant2_num.ToString();

                    TextBlock_Follow_Lon.Text = ((double)(fly_display.base_lon) / 10000000).ToString();
                    TextBlock_Follow_Lat.Text = ((double)(fly_display.base_lat) / 10000000).ToString();
                    TextBlock_Base_Level_Alt.Text = ((double)(fly_display.base_gps_alt) / 100).ToString("0.0");

                    TextBlock_EW_Vel.Text = ((double)(fly_display.base_ew_vel) / 100).ToString("0.0");
                    TextBlock_NS_Vel.Text = ((double)(fly_display.base_ns_vel) / 100).ToString("0.0");
                    TextBlock_Up_Vel.Text = ((double)(fly_display.base_up_vel) / 100).ToString("0.0");

                    if (fly_display.base_heading_type == 1)
                    {
                        TextBlock_Heading_Type.Text = "RTK定向" + "   " + (fly_display.base_heading).ToString();
                    }
                    else
                    {
                        TextBlock_Heading_Type.Text = "未锁定" + "   " + (fly_display.base_heading).ToString();
                    }
                }
                // base pos/vel/heading from rtk base station
                else if (combox_data_source.SelectedIndex == 1)
                {
                    TextBlock_Gps_Num.Text = "ANT1: " + m_FollowGps.StaNum.ToString() + "     " + "ANT2: " + m_FollowGps.StaNum_ant2.ToString();

                    TextBlock_Follow_Lon.Text = ((double)(m_FollowGps.nLon_Follow) / 10000000).ToString();
                    TextBlock_Follow_Lat.Text = ((double)(m_FollowGps.nLat_Follow) / 10000000).ToString();
                    TextBlock_Base_Level_Alt.Text = ((double)(m_FollowGps.nAlt_Follow) / 1000).ToString("0.0");

                    TextBlock_Up_Vel.Text = ((double)(m_FollowGps.nGps_D_Follow) / 1000).ToString("0.0");
                    TextBlock_EW_Vel.Text = ((double)(m_FollowGps.nGps_E_Follow) / 1000).ToString("0.0");
                    TextBlock_NS_Vel.Text = ((double)(m_FollowGps.nGps_N_Follow) / 1000).ToString("0.0");

                    if (m_FollowGps.base_mode == 0)
                    {
                        TextBlock_Base_Mode.Text = TryFindResource("TITLE_MODE_ROVER").ToString();
                    }
                    else if (m_FollowGps.base_mode == 1)
                    {
                        TextBlock_Base_Mode.Text = TryFindResource("TITLE_MODE_FIX_BASE").ToString();
                    }
                    else if (m_FollowGps.base_mode == 2)
                    {
                        TextBlock_Base_Mode.Text = TryFindResource("TITLE_MODE_MOVING_BASE").ToString();
                    }

                    if (m_FollowGps.heading_status == 1)
                    {
                        TextBlock_Heading_Type.Text = "RTK定向" + "   " + (m_FollowGps.nHeading / 10).ToString();
                    }
                    else if (m_FollowGps.heading_status == 0)
                    {
                        TextBlock_Heading_Type.Text = "未锁定" + "   " + (m_FollowGps.nHeading / 10).ToString();
                    }
                }
                // show the rtk base station product information
                if (DataProcess_JD.m_base_infor.base_product_name != null)
                {
                    string str = System.Text.Encoding.Default.GetString(DataProcess_JD.m_base_infor.base_product_name);
                    TextBlock_Base_Infor.Text = "PN: " + str + "   " + "SN: " + DataProcess_JD.m_base_infor._serial_id.ToString()
                                                                    + "   " + "SV: " + DataProcess_JD.m_base_infor._firmwareVersion.ToString();
                }
                else
                {
                    DATA_LINK.Get_Base_Version();
                }

                if ((fly_display.ins_flag & 0xf0) == 0x10)
                {
                    TextBlock_Allign_Status.Text = TryFindResource("TITLE_ALLIGH_LOCK").ToString() +"   " + "东西: " + ((double)fly_display.allign_ew_dist / 100).ToString("0.0") + " m"
                                                                        +"   " + "南北: " + ((double)fly_display.allign_ns_dist / 100).ToString("0.0") + " m";
                }
                else
                {
                    TextBlock_Allign_Status.Text = TryFindResource("TITLE_ALLIGH_UNLOCK").ToString() + "   " + "东西: " + ((double)fly_display.allign_ew_dist / 100).ToString("0.0") + " m"
                                                                        + "   " + "南北: " + ((double)fly_display.allign_ns_dist / 100).ToString("0.0") + " m";
                }

                if (base_show_count++ >= 5)
                {
                    base_show_count = 0;
                    try
                    {
                        //Page_2D_Map.AddFollowGpsOnMap(m_FollowGps.StaNum, (double)(m_FollowGps.nLat_Follow) / 10000000, (double)(m_FollowGps.nLon_Follow) / 10000000);
                        Page_2D_Map.AddFollowGpsOnMap(fly_display.base_ant1_num, (double)(fly_display.base_lat) / 10000000, (double)(fly_display.base_lon) / 10000000);
                    }
                    catch { }
                }
            }));
        }
        private void Btn_Follow_TakeOff_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_TakeOff_Follow, 0);
        }

        private void Btn_Follow_Landing_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Landing_Follow, 0);
        }

        private void Btn_Gps_Follow_Start_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Fly_Follow, 0);
        }

        byte[] send_buf_to_base = new byte[100];
        private void combox_base_mode_changed(object sender, SelectionChangedEventArgs e)
        {
            byte index = 0;

            send_buf_to_base[index++] = (byte)0xfe;
            send_buf_to_base[index++] = (byte)14;
            send_buf_to_base[index++] = (byte)0;
            send_buf_to_base[index++] = (byte)0;
            send_buf_to_base[index++] = (byte)0;

            if (combox_base_mode.SelectedIndex == 0)
            {
                send_buf_to_base[index++] = (byte)22;
                send_buf_to_base[index++] = (byte)114;
            }
            else if (combox_base_mode.SelectedIndex == 1)
            {
                send_buf_to_base[index++] = (byte)22;
                send_buf_to_base[index++] = (byte)115;
            }

            send_buf_to_base[1] = (byte)(index - 6);

            send_buf_to_base[index] = CRC.Get_Crc16(send_buf_to_base, 0, (short)(index))[0];
            send_buf_to_base[index + 1] = CRC.Get_Crc16(send_buf_to_base, 0, (short)(index))[1];
            DATA_LINK.Send_Buf_To_Base(send_buf_to_base, index + 2);
        }

        private void Btn_Set_Right_Dist_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Single_Para(65, (short)(double.Parse(TextBox_Right_Dist.Text) * 100));
        }

        private void Btn_Set_Front_Dist_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Single_Para(66, (short)(double.Parse(TextBox_Front_Dist.Text) * 100));
        }

        private void Btn_Set_Yaw_Error_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Single_Para(67, (short)(double.Parse(TextBox_Yaw_Error.Text)));
        }

        private void Btn_Left_Shift_Click(object sender, RoutedEventArgs e)
        {
            double dfTemp = double.Parse(TextBox_Right_Dist.Text);
            dfTemp -= 1;
            TextBox_Right_Dist.Text = dfTemp.ToString("0.0");
            DATA_LINK.Send_Single_Para(65, (short)(dfTemp * 100));
        }

        private void Btn_Right_Shift_Click(object sender, RoutedEventArgs e)
        {
            double dfTemp = double.Parse(TextBox_Right_Dist.Text);
            dfTemp += 1;
            TextBox_Right_Dist.Text = dfTemp.ToString("0.0");
            DATA_LINK.Send_Single_Para(65, (short)(dfTemp * 100));
        }

        private void Btn_Head_Shift_Click(object sender, RoutedEventArgs e)
        {
            double dfTemp = double.Parse(TextBox_Front_Dist.Text);
            dfTemp += 1;
            TextBox_Front_Dist.Text = dfTemp.ToString("0.0");
            DATA_LINK.Send_Single_Para(66, (short)(dfTemp * 100));
        }

        private void Btn_Back_Shift_Click(object sender, RoutedEventArgs e)
        {
            double dfTemp = double.Parse(TextBox_Front_Dist.Text);
            dfTemp -= 1;
            TextBox_Front_Dist.Text = dfTemp.ToString("0.0");
            DATA_LINK.Send_Single_Para(66, (short)(dfTemp * 100));
        }

        private void Btn_Left_Rotate_Click(object sender, RoutedEventArgs e)
        {
            double dfTemp = double.Parse(TextBox_Yaw_Error.Text);
            dfTemp -= 1;
            TextBox_Yaw_Error.Text = dfTemp.ToString("0.0");
            DATA_LINK.Send_Single_Para(67, (short)(dfTemp));
        }

        private void Btn_Right_Rotate_Click(object sender, RoutedEventArgs e)
        {
            double dfTemp = double.Parse(TextBox_Yaw_Error.Text);
            dfTemp += 1;
            TextBox_Yaw_Error.Text = dfTemp.ToString("0.0");
            DATA_LINK.Send_Single_Para(67, (short)(dfTemp));
        }


        private void Combox_Data_Source_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (combox_data_source.SelectedIndex == 0)
            {
                combox_follow.Visibility = Visibility.Hidden;
                Btn_Follow_Connect.Visibility = Visibility.Hidden;
            }
            else
            {
                combox_follow.Visibility = Visibility.Visible;
                Btn_Follow_Connect.Visibility = Visibility.Visible;
            }
        }
    }
}
