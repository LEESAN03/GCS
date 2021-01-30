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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_ChuiQi_Settings2.xaml 的交互逻辑
    /// </summary>
    public partial class Page_ChuiQi_Settings2 : Page
    {
        private static Page_ChuiQi_Settings2 m_Page_ChuiQi_JiXing2 = null;
        public static Page_ChuiQi_Settings2 getInstance()
        {
            if (m_Page_ChuiQi_JiXing2 == null)
                m_Page_ChuiQi_JiXing2 = new Page_ChuiQi_Settings2();

            return m_Page_ChuiQi_JiXing2;
        }

        public Page_ChuiQi_Settings2()
        {
            InitializeComponent();

            combox_volt_level1.Items.Add("不开启");
            combox_volt_level1.Items.Add("提示");
            combox_volt_level1.Items.Add("返航");
            combox_volt_level1.SelectedIndex = 1;

            combox_zhuansu_protect.Items.Add("不开启");
            combox_zhuansu_protect.Items.Add("开启");
            combox_zhuansu_protect.SelectedIndex = 1;

            combox_volt_level2.Items.Add("不开启");
            combox_volt_level2.Items.Add("提示");
            combox_volt_level2.Items.Add("旋翼迫降");
            combox_volt_level2.SelectedIndex = 0;

            combox_action_after_takeoff.Items.Add("飞1点");
            combox_action_after_takeoff.Items.Add("盘旋");
            combox_action_after_takeoff.SelectedIndex = 0;

            combox_circle_direction.Items.Add("逆时针");
            combox_circle_direction.Items.Add("顺时针");
            combox_circle_direction.Items.Add("自适应");
            combox_circle_direction.SelectedIndex = 0;

            Combox_Filter_Level.Items.Add("VH");
            Combox_Filter_Level.Items.Add("H");
            Combox_Filter_Level.Items.Add("M");
            Combox_Filter_Level.Items.Add("L");
            Combox_Filter_Level.Items.Add("VL");
            Combox_Filter_Level.Items.Add("VVH");
            Combox_Filter_Level.SelectedIndex = 0;
        }

        private void combox_volt_level1_Changed(object sender, SelectionChangedEventArgs e)
        {

        }

        private void combox_volt_level2_Changed(object sender, SelectionChangedEventArgs e)
        {

        }

        /**********************************************************************************
        * function: send req to fetch the fix wing settings
        * para:
        * return:
        * *********************************************************************************/
        private void BTN_GET_FW_SETTING2_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_APTYPE, 0);
        }


        /**********************************************************************************
         * function: send fix wing settings
         * para:
         * return:
         * *********************************************************************************/
        private void BTN_SET_FW_SETTING2_Click(object sender, RoutedEventArgs e)
        {
            byte[] buf_temp = new byte[255];
            byte system_id = DATA_LINK.Get_System_Set_Id();
            byte index = 0;
            try
            {
                buf_temp[index++] = (byte)0xfe;
                buf_temp[index++] = (byte)14;
                buf_temp[index++] = (byte)0;
                buf_temp[index++] = (byte)system_id;
                buf_temp[index++] = (byte)0;
                buf_temp[index++] = (byte)MsgDef.MSG_APTYPE;

                buf_temp[index++] = 0;
                buf_temp[index++] = BitConverter.GetBytes(short.Parse(TextBox_Circle_R.Text))[0];
                buf_temp[index++] = BitConverter.GetBytes(short.Parse(TextBox_Circle_R.Text))[1];

                buf_temp[index++] = BitConverter.GetBytes(short.Parse(TextBox_Link_Lost_Time.Text))[0];
                buf_temp[index++] = BitConverter.GetBytes(short.Parse(TextBox_Link_Lost_Time.Text))[1];

                buf_temp[index++] = (byte)combox_volt_level1.SelectedIndex;

                buf_temp[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Safe_Volt_Level1.Text) * 10))[0];
                buf_temp[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Safe_Volt_Level1.Text) * 10))[1];

                buf_temp[index++] = byte.Parse(TextBox_TakeOff_Alt.Text);
                buf_temp[index++] = byte.Parse(TextBox_Return_Alt.Text);
                buf_temp[index++] = byte.Parse(TextBox_Mag_Bias.Text);

                buf_temp[index++] = (byte)combox_zhuansu_protect.SelectedIndex;
                buf_temp[index++] = BitConverter.GetBytes(short.Parse(TextBox_Min_ZhuanSu.Text))[0];
                buf_temp[index++] = BitConverter.GetBytes(short.Parse(TextBox_Min_ZhuanSu.Text))[1];

                buf_temp[index++] = (byte)combox_volt_level2.SelectedIndex;
                buf_temp[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Safe_Volt_Level2.Text) * 10))[0];
                buf_temp[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Safe_Volt_Level2.Text) * 10))[1];

                buf_temp[index++] = (byte)combox_action_after_takeoff.SelectedIndex;
                buf_temp[index++] = (byte)combox_circle_direction.SelectedIndex;

                buf_temp[1] = (byte)(index - 6);

                buf_temp[index] = CRC.Get_Crc16(buf_temp, 0, (short)(index))[0];
                buf_temp[index + 1] = CRC.Get_Crc16(buf_temp, 0, (short)(index))[1];
                DATA_LINK.Send_Buf(buf_temp, index + 2);
            }
            catch
            { }

            string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
            string str_temp = "Send FW settings2";
            MainWindow.stream_gcs_log.WriteLine(str_time + str_temp);
            MainWindow.stream_gcs_log.Flush();
        }


        /**********************************************************************************
        * function: update fix wing settings2 information
        * para:
        * return:
        * *********************************************************************************/
        public void Update_Fw_Settings2()
        {
            FW_SETTING2 m_fw_settings2 = DataProcess_JD.Get_FW_Settings2_Struct();

            TextBox_Circle_R.Text = m_fw_settings2._circle_r.ToString();
            TextBox_Link_Lost_Time.Text = m_fw_settings2._link_lost.ToString();
            TextBox_Safe_Volt_Level1.Text = ((double)m_fw_settings2._saft_volt_level1 / 10).ToString("0.0");
            combox_volt_level1.SelectedIndex = m_fw_settings2._saft_volt_level1_action;
            TextBox_TakeOff_Alt.Text = m_fw_settings2._takeoff_alt.ToString();
            TextBox_Return_Alt.Text = m_fw_settings2._return_alt.ToString();
            TextBox_Mag_Bias.Text = m_fw_settings2._mag_bias.ToString();
            TextBox_Min_ZhuanSu.Text = m_fw_settings2._zhuansu_limit.ToString();
            combox_zhuansu_protect.SelectedIndex = m_fw_settings2._zhuansu_protect;
            TextBox_Safe_Volt_Level2.Text = ((double)m_fw_settings2._saft_volt_level2 / 10).ToString("0.0");
            combox_volt_level2.SelectedIndex = m_fw_settings2._saft_volt_level2_action;
            combox_action_after_takeoff.SelectedIndex = m_fw_settings2._action_after_take_off;
            combox_circle_direction.SelectedIndex = m_fw_settings2._circle_direction;
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

        private void BTN_GET_GPS_HEADING_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, 24, 16);
        }

        private void BTN_SET_GPS_HEADING_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Single_Para(16, (short)(Combox_Gps_Heading.SelectedIndex));
        }

        /*************************************************************************
     * 功   能：显示安装方向信息
     * 参   数：
     * 返   回：
     * **********************************************************************/
        public void ShowFixInfor(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            FORWARD_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.White;
            FORWARD_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.White;

            RIGHT_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.White;
            RIGHT_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.White;

            BACK_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.White;
            BACK_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.White;

            LEFT_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.White;
            LEFT_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.White;

            switch (mFly_Infor_Display.direction_filter & (byte)0x0f)
            {
                case 1:
                    FORWARD_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.Orange;
                    FORWARD_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 2:
                    RIGHT_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.Orange;
                    RIGHT_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 3:
                    BACK_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.Orange;
                    BACK_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                case 4:
                    LEFT_AN_ZHUANG.Foreground = System.Windows.Media.Brushes.Orange;
                    LEFT_AN_ZHUANG.BorderBrush = System.Windows.Media.Brushes.Orange;
                    break;
                default:
                    break;
            }

            switch ((mFly_Infor_Display.direction_filter >> 4) & (byte)0x0f)
            {
                case 0:
                    TextBlock_Filter.Text = "VH";
                    break;
                case 1:
                    TextBlock_Filter.Text = "H";
                    break;
                case 2:
                    TextBlock_Filter.Text = "M";
                    break;
                case 3:
                    TextBlock_Filter.Text = "L";
                    break;
                case 4:
                    TextBlock_Filter.Text = "VL";
                    break;
                case 5:
                    TextBlock_Filter.Text = "VVH";
                    break;
                default:
                    break;
            }
        }

        private void BTN_SET_FILTER_LEVEL_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CAL, MSG_CAL_ID.CAL_Filter, (short)Combox_Filter_Level.SelectedIndex);
        }
    }
}
