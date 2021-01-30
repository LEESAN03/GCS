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
    /// Page_ChuiQi_JIXing.xaml 的交互逻辑
    /// </summary>
    public partial class Page_ChuiQi_JIXing : Page
    {
        private static Page_ChuiQi_JIXing m_Page_ChuiQi_JiXing = null;
        public static Page_ChuiQi_JIXing getInstance()
        {
            if (m_Page_ChuiQi_JiXing == null)
                m_Page_ChuiQi_JiXing = new Page_ChuiQi_JIXing();

            return m_Page_ChuiQi_JiXing;
        }

        public Page_ChuiQi_JIXing()
        {
            InitializeComponent();

            combox_chuiqi_type.Items.Add("平垂尾");
            combox_chuiqi_type.Items.Add("三角翼");
            combox_chuiqi_type.Items.Add("V尾");
        }

        private void combox_chuiqi_type_Changed(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BTN_GET_PAR_SETTING_Click(object sender, RoutedEventArgs e)
        {

        }

        /****************************************************************************
         * function: send fix wing 
         * para:
         * return:
         * **************************************************************************/
        private void BTN_SET_FW_SETTING_Click(object sender, RoutedEventArgs e)
        {
            byte[] buf_msg_send = new byte[255];
            byte index = 0;
            byte system_id = DATA_LINK.Get_System_Set_Id();

            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)14;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.PICTURE_TRIGGER_MODE;

            buf_msg_send[index++] = (byte)(combox_chuiqi_type.SelectedIndex + 1);
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Turn_Dist.Text))[0];
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Turn_Dist.Text))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_FW_Max_Roll.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_FW_Max_Roll.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_FW_Max_Pitch.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_FW_Max_Pitch.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Speed_Lost.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Speed_Lost.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Cruise_AirSpeed.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Cruise_AirSpeed.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Max_Climb_Rate.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Max_Climb_Rate.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Min_Down_Rate_Auto.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Min_Down_Rate_Auto.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Take_Off_Speed.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Take_Off_Speed.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Flap_Angle.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Flap_Angle.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Break_Speed.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Break_Speed.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Correct_Speed.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Correct_Speed.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Land_Flap_Angle.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Land_Flap_Angle.Text) * 10))[1];

            buf_msg_send[index++] = (byte)(double.Parse(TextBox_Land_Break_Time.Text) * 10);
            buf_msg_send[index++] = (byte)(double.Parse(TextBox_Land_Break_Interval.Text) * 10);

            buf_msg_send[index++] = (byte)(double.Parse(TextBox_Take_Off_Pitch.Text) * 10);

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Take_Off_Vel_Compensate_Value.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Take_Off_Vel_Compensate_Value.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Take_Off_Vel_Compensate_Kx.Text) * 100))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Take_Off_Vel_Compensate_Kx.Text) * 100))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Cruise_Vel_Compensate_Kx.Text) * 100))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Cruise_Vel_Compensate_Kx.Text) * 100))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Roll_Compensate_Kx.Text)))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Roll_Compensate_Kx.Text)))[1];


            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Break_Start_Dist.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Break_Start_Dist.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Engine_Stop_Speed.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Engine_Stop_Speed.Text) * 10))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Start_Break_Speed.Text) * 10))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_Start_Break_Speed.Text) * 10))[1];

            buf_msg_send[index++] = byte.Parse(TextBox_Throttle_Value.Text);
            buf_msg_send[index++] = (byte)(double.Parse(TextBox_HuaPao_Max_Speed_Bias.Text) * 10);
            buf_msg_send[index++] = byte.Parse(TextBox_TanShe_Compensate_Kx.Text);

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_FW_To_MM_Dist.Text)))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_FW_To_MM_Dist.Text)))[1];

            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_MM_To_FW_Airspeed.Text)))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((short)(double.Parse(TextBox_MM_To_FW_Airspeed.Text)))[1];

            buf_msg_send[index++] = byte.Parse(TextBox_MM_To_FW_Time_Late.Text);

            buf_msg_send[index++] = BitConverter.GetBytes((ushort)(double.Parse(TextBox_MM_DaiSu.Text)))[0];
            buf_msg_send[index++] = BitConverter.GetBytes((ushort)(double.Parse(TextBox_MM_DaiSu.Text)))[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            DATA_LINK.Send_Buf(buf_msg_send, index + 2);

            string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
            string str_temp = "Send FW Jixing settings";
            MainWindow.stream_gcs_log.WriteLine(str_time + str_temp);
            MainWindow.stream_gcs_log.Flush();
        }


        /****************************************************************************
        * function: send fix wing settings
        * para:
        * return:
        * **************************************************************************/
        private void BTN_GET_FW_SETTING_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.PICTURE_TRIGGER_MODE, 0);
        }

        /****************************************************************************
        * function: send fix wing settings
        * para:
        * return:
        * **************************************************************************/
        public void Update_Fw_Settings()
        {
            FW_FLY_SETTINGS mFw_Settings = DataProcess_JD.Get_FW_Settings_Struct();

            combox_chuiqi_type.SelectedIndex = mFw_Settings._fw_plane_type - 1;

            TextBox_Turn_Dist.Text = mFw_Settings._turn_dist.ToString();
            TextBox_FW_Max_Roll.Text = (mFw_Settings._max_roll / 10).ToString();
            TextBox_FW_Max_Pitch.Text = (mFw_Settings._max_pitch / 10).ToString();

            TextBox_Speed_Lost.Text = ((double)(mFw_Settings._lost_airspeed) / 10).ToString("0.0");
            TextBox_Cruise_AirSpeed.Text = ((double)(mFw_Settings._cruise_airspeed) / 10).ToString("0.0");

            TextBox_Max_Climb_Rate.Text = ((double)(mFw_Settings._max_climb_rate) / 10).ToString("0.0");
            TextBox_Min_Down_Rate_Auto.Text = ((double)(mFw_Settings._max_down_rate) / 10).ToString("0.0");

            TextBox_Take_Off_Speed.Text = ((double)(mFw_Settings._takeoff_speed) / 10).ToString("0.0");
            TextBox_Flap_Angle.Text = (mFw_Settings._takeoff_flap_angle / 10).ToString();

            TextBox_Break_Speed.Text = ((double)(mFw_Settings._break_speed) / 10).ToString("0.0");
            TextBox_Correct_Speed.Text = ((double)(mFw_Settings._front_wheel_speed) / 10).ToString("0.0");

            TextBox_Land_Flap_Angle.Text = (mFw_Settings._land_flap_angle / 10).ToString();
            TextBox_Land_Break_Time.Text = ((double)(mFw_Settings._break_time) / 10).ToString("0.0");
            TextBox_Land_Break_Interval.Text = ((double)(mFw_Settings._break_intervel) / 10).ToString("0.0");

            TextBox_Take_Off_Pitch.Text = ((double)(mFw_Settings._takeoff_angle) / 10).ToString("0.0");
            TextBox_Take_Off_Vel_Compensate_Value.Text = ((double)(mFw_Settings._takeoff_speed_compensate_value) / 10).ToString("0.0");
            TextBox_Take_Off_Vel_Compensate_Kx.Text = ((double)(mFw_Settings._takeoff_speed_compensate_kx) / 100).ToString("0.0");

            TextBox_Cruise_Vel_Compensate_Kx.Text = ((double)(mFw_Settings._cruise_speed_compensate_kx) / 100).ToString("0.0");
            TextBox_Roll_Compensate_Kx.Text = mFw_Settings._roll_compensate_kx.ToString();
            TextBox_Break_Start_Dist.Text = ((double)(mFw_Settings._start_break_dist) / 10).ToString("0.0");

            TextBox_Engine_Stop_Speed.Text = ((double)(mFw_Settings._stop_speed) / 10).ToString("0.0");
            TextBox_Start_Break_Speed.Text = ((double)(mFw_Settings._start_break_speed) / 10).ToString("0.0");

            TextBox_Throttle_Value.Text = mFw_Settings._throttle.ToString();
            TextBox_HuaPao_Max_Speed_Bias.Text = ((double)(mFw_Settings._max_speed_bias) / 10).ToString("0.0");
            TextBox_TanShe_Compensate_Kx.Text = mFw_Settings._lagan_compensate.ToString();

            TextBox_FW_To_MM_Dist.Text = (mFw_Settings._fw_to_mm_dist).ToString();
            TextBox_MM_To_FW_Airspeed.Text = mFw_Settings._mm_to_fw_airspeed.ToString();
            TextBox_MM_To_FW_Time_Late.Text = (mFw_Settings._mm_to_fw_time_excced).ToString();
            TextBox_MM_DaiSu.Text = (mFw_Settings._mm_daisi).ToString();
        }
    }
}
