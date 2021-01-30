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
    /// Page_FW_MM_PID.xaml 的交互逻辑
    /// </summary>
    public partial class Page_FW_MM_PID : Page
    {
        private static Page_FW_MM_PID m_Page_FW_MM_PID = null;
        public static Page_FW_MM_PID getInstance()
        {
            if (m_Page_FW_MM_PID == null)
                m_Page_FW_MM_PID = new Page_FW_MM_PID();

            return m_Page_FW_MM_PID;
        }

        public Page_FW_MM_PID()
        {
            InitializeComponent();
        }

        private void BTN_GET_FW_MM_PID_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_FW_MM_PID, 0);
        }

        /***************************************************************************
         * function: send fix wing's multiple motor pid
         * para:
         * return:
         * **************************************************************************/
        private void BTN_SET_FW_MM_PID_Click(object sender, RoutedEventArgs e)
        {
            byte[] buf_msg_send = new byte[255];
            byte system_id = DATA_LINK.Get_System_Set_Id();
            byte index = 0;

            try
            {
                buf_msg_send[index++] = (byte)0xfe;
                buf_msg_send[index++] = (byte)14;
                buf_msg_send[index++] = (byte)0;
                buf_msg_send[index++] = (byte)system_id;
                buf_msg_send[index++] = (byte)0;
                buf_msg_send[index++] = (byte)MsgDef.MSG_FW_MM_PID;

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Horizon_Dist_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Horizon_Dist_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Horizon_Vel_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Horizon_Vel_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Horizon_Vel_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Horizon_Vel_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Horizon_Vel_D.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Horizon_Vel_D.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_Dist_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_Dist_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_Vel_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_Vel_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_Acc_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_Acc_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_Acc_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_Acc_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Roll_Angle_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Roll_Angle_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Pitch_Angle_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Pitch_Angle_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Yaw_Angle_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Yaw_Angle_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Roll_Gyro_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Roll_Gyro_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Pitch_Gyro_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Pitch_Gyro_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Yaw_Gyro_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Yaw_Gyro_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Roll_Gyro_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Roll_Gyro_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Pitch_Gyro_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Pitch_Gyro_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Yaw_Gyro_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Yaw_Gyro_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Roll_Gyro_D.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Roll_Gyro_D.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Pitch_Gyro_D.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Pitch_Gyro_D.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Yaw_Gyro_D.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Yaw_Gyro_D.Text))[1];


                buf_msg_send[1] = (byte)(index - 6);

                buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
                buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
                DATA_LINK.Send_Buf(buf_msg_send, index + 2);
            }
            catch { }

            string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
            string str_temp = "Send FW MM pid";
            MainWindow.stream_gcs_log.WriteLine(str_time + str_temp);
            MainWindow.stream_gcs_log.Flush();
        }


        private void BTN_GET_FW_PID_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_FW_PID, 0);
        }

        /***************************************************************************
        * function: send fix wing pid
        * para:
        * return:
        * **************************************************************************/
        private void BTN_SET_FW_PID_Click(object sender, RoutedEventArgs e)
        {
            byte[] buf_msg_send = new byte[255];
            byte index = 0;
            byte system_id = DATA_LINK.Get_System_Set_Id();

            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)14;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_FW_PID;

            try
            {
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Roll_Angle_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Roll_Angle_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Roll_Angle_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Roll_Angle_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Roll_Angle_D.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Roll_Angle_D.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Roll_Angle_Imax.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Roll_Angle_Imax.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Pitch_Angle_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Pitch_Angle_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Pitch_Angle_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Pitch_Angle_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Pitch_Angle_D.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Pitch_Angle_D.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Pitch_Angle_Imax.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_FW_Pitch_Angle_Imax.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Height_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Up_Vel_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Up_Vel_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Up_Vel_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Up_Vel_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_AirSpeed_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_AirSpeed_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_AirSpeed_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_AirSpeed_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Cross_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Cross_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Track_Angle_P.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Track_Angle_P.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_L1_Interval.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_L1_Interval.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_L1_D.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_L1_D.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_L1_I.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_L1_I.Text))[1];

                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_L1_Dist.Text))[0];
                buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_L1_Dist.Text))[1];

                buf_msg_send[1] = (byte)(index - 6);

                buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
                buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
                DATA_LINK.Send_Buf(buf_msg_send, index + 2);
            }
            catch { }

            string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
            string str_temp = "Send FW pid";
            MainWindow.stream_gcs_log.WriteLine(str_time + str_temp);
            MainWindow.stream_gcs_log.Flush();
        }

        /*****************************************************************
         * functoin: 
         * para:
         * return:
         * ***************************************************************/
        public void Update_FW_MM_Pid()
        {
            FW_MM_PID m_fw_mm_pid = DataProcess_JD.Get_FW_MM_PID_Struct();

            TextBox_Horizon_Dist_P.Text = m_fw_mm_pid._horizontal_dist_p.ToString();
            TextBox_Horizon_Vel_P.Text = m_fw_mm_pid._horizontal_vel_p.ToString();
            TextBox_Horizon_Vel_I.Text = m_fw_mm_pid._horizontal_vel_i.ToString();
            TextBox_Horizon_Vel_D.Text = m_fw_mm_pid._horizontal_vel_d.ToString();

            TextBox_Height_Dist_P.Text = m_fw_mm_pid._height_dist_p.ToString();
            TextBox_Height_Vel_P.Text = m_fw_mm_pid._height_vel_p.ToString();
            TextBox_Height_Acc_P.Text = m_fw_mm_pid._height_acc_p.ToString();
            TextBox_Height_Acc_I.Text = m_fw_mm_pid._height_acc_i.ToString();

            TextBox_Roll_Angle_P.Text = m_fw_mm_pid._roll_angle_p.ToString();
            TextBox_Pitch_Angle_P.Text = m_fw_mm_pid._pitch_angle_p.ToString();
            TextBox_Yaw_Angle_P.Text = m_fw_mm_pid._yaw_angle_p.ToString();

            TextBox_Roll_Gyro_P.Text = m_fw_mm_pid._roll_gyro_p.ToString();
            TextBox_Pitch_Gyro_P.Text = m_fw_mm_pid._pitch_gyro_p.ToString();
            TextBox_Yaw_Gyro_P.Text = m_fw_mm_pid._yaw_gyro_p.ToString();

            TextBox_Roll_Gyro_I.Text = m_fw_mm_pid._roll_gyro_i.ToString();
            TextBox_Pitch_Gyro_I.Text = m_fw_mm_pid._pitch_gyro_i.ToString();
            TextBox_Yaw_Gyro_I.Text = m_fw_mm_pid._yaw_gyro_i.ToString();

            TextBox_Roll_Gyro_D.Text = m_fw_mm_pid._roll_gyro_d.ToString();
            TextBox_Pitch_Gyro_D.Text = m_fw_mm_pid._pitch_gyro_d.ToString();
            TextBox_Yaw_Gyro_D.Text = m_fw_mm_pid._yaw_gyro_d.ToString();
        }

        /*****************************************************************
       * functoin:  update the fix wing pid
       * para:
       * return:
       * ***************************************************************/
        public void Update_FW_Pid()
        {
            FW_PID m_fw_pid = DataProcess_JD.Get_FW_PID_Struct();

            TextBox_FW_Roll_Angle_P.Text = m_fw_pid._roll_p.ToString();
            TextBox_FW_Roll_Angle_I.Text = m_fw_pid._roll_i.ToString();
            TextBox_FW_Roll_Angle_D.Text = m_fw_pid._roll_d.ToString();
            TextBox_FW_Roll_Angle_Imax.Text = m_fw_pid._roll_imax.ToString();

            TextBox_FW_Pitch_Angle_P.Text = m_fw_pid._pitch_p.ToString();
            TextBox_FW_Pitch_Angle_I.Text = m_fw_pid._pitch_i.ToString();
            TextBox_FW_Pitch_Angle_D.Text = m_fw_pid._pitch_d.ToString();
            TextBox_FW_Pitch_Angle_Imax.Text = m_fw_pid._pitch_imax.ToString();

            TextBox_Height_P.Text = m_fw_pid._height_p.ToString();
            TextBox_Up_Vel_P.Text = m_fw_pid._up_vel_p.ToString();
            TextBox_Up_Vel_I.Text = m_fw_pid._up_vel_i.ToString();

            TextBox_AirSpeed_P.Text = m_fw_pid._airspeed_p.ToString();
            TextBox_AirSpeed_I.Text = m_fw_pid._airspeed_i.ToString();

            TextBox_Cross_P.Text = m_fw_pid._crosss_p.ToString();
            TextBox_Track_Angle_P.Text = m_fw_pid._yaw_p.ToString();

            TextBox_L1_Interval.Text = m_fw_pid._L1_interval.ToString();
            TextBox_L1_D.Text = m_fw_pid._L1_d.ToString();
            TextBox_L1_I.Text = m_fw_pid._L1_i.ToString();
            TextBox_L1_Dist.Text = m_fw_pid._L1_dist.ToString();
        }
    }
}
