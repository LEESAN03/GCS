using System;
using System.Windows;
using System.Windows.Controls;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Par_Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Par_Setting : Page
    {
        private static Page_Par_Setting m_Page_Par_Setting = new Page_Par_Setting();
        public static Page_Par_Setting getInstance()
        {
            if (m_Page_Par_Setting == null)
                m_Page_Par_Setting = new Page_Par_Setting();

            return m_Page_Par_Setting;
        }

        private Page_Par_Setting()
        {
            InitializeComponent();
        }

        private void BTN_GET_PAR_SETTING_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_PAR, 0);
        }

        /************************************************************************
         * function: send fly settings para to the plane
         * para:
         * return:
         * ***********************************************************************/
        private void BTN_SET_PAR_SETTING_Click(object sender, RoutedEventArgs e)
        {
            byte[] buf_msg_send = new byte[255];
            byte index = 0;
            byte system_id = DATA_LINK.Get_System_Set_Id();

            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)14;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_PAR;

            buf_msg_send[index++] = byte.Parse(TextBox_Max_Angle_Gps_Mode.Text);
            buf_msg_send[index++] = (byte)(float.Parse(TextBox_Max_Hori_Vel_Gps_Mode.Text) * 10);

            buf_msg_send[index++] = (byte)(float.Parse(TextBox_Max_Climb_Vel_Gps_Mode.Text) * 10);
            buf_msg_send[index++] = (byte)(float.Parse(TextBox_Max_Down_Vel_Gps_Mode.Text) * 10);

            buf_msg_send[index++] = 0;
            buf_msg_send[index++] = 0;

            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Limit_Alt1.Text))[0];
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Limit_Alt1.Text))[1];

            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Limit_Alt2.Text))[0];
            buf_msg_send[index++] = BitConverter.GetBytes(short.Parse(TextBox_Limit_Alt2.Text))[1];

            buf_msg_send[index++] = byte.Parse(TextBox_Max_Yaw_Rate.Text);
            buf_msg_send[index++] = (byte)(double.Parse(TextBox_AD0_Bias.Text) * 10);
            buf_msg_send[index++] = 0;
            buf_msg_send[index++] = 0;

            buf_msg_send[index++] = byte.Parse(TextBox_Follow_Dist.Text);
            buf_msg_send[index++] = (byte)(float.Parse(TextBox_Max_Climb_Rate_Auto.Text) * 10);
            buf_msg_send[index++] = (byte)(float.Parse(TextBox_Max_Down_Rate_Auto.Text) * 10);
            buf_msg_send[index++] = (byte)(float.Parse(TextBox_Min_Down_Rate_Auto.Text) * 10);
            buf_msg_send[index++] = (byte)(float.Parse(TextBox_Max_Cruise_Vel_Auto.Text) * 10);

            buf_msg_send[index++] = 0;
            buf_msg_send[index++] = 0;
            buf_msg_send[index++] = 0;
            buf_msg_send[index++] = 0;
            buf_msg_send[index++] = 0;
            buf_msg_send[index++] = 0;

            buf_msg_send[index++] = BitConverter.GetBytes(UInt16.Parse(TextBox_Dist_Limit.Text))[0];
            buf_msg_send[index++] = BitConverter.GetBytes(UInt16.Parse(TextBox_Dist_Limit.Text))[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            DATA_LINK.Send_Buf(buf_msg_send, index + 2);
        }

        /************************************************************************
        * function: update para settings
        * para:
        * return:
        * ***********************************************************************/
        public void Update_Para_Setting()
        {
            STRUCT_PAR mStruct_Par = DataProcess_JD.Get_Par();

            TextBox_Max_Angle_Gps_Mode.Text = mStruct_Par.Max_Angle_GPS_Mode.ToString();
            TextBox_Max_Hori_Vel_Gps_Mode.Text = ((float)mStruct_Par.Max_Hori_Vel_GPS_Mode / 10).ToString();

            TextBox_Max_Climb_Vel_Gps_Mode.Text = ((float)mStruct_Par.Max_Climb_Rate_GPS_Mode / 10).ToString();
            TextBox_Max_Down_Vel_Gps_Mode.Text = ((float)mStruct_Par.Max_Down_Rate_GPS_Mode / 10).ToString();

            TextBox_Max_Cruise_Vel_Auto.Text = ((float)mStruct_Par.Max_Cruise_Vel_Auto / 10).ToString();
            TextBox_Max_Climb_Rate_Auto.Text = ((float)mStruct_Par.Max_Climb_Rate_Auto / 10).ToString();

            TextBox_Max_Down_Rate_Auto.Text = ((float)mStruct_Par.Max_Down_Rate_Auto / 10).ToString();
            TextBox_Min_Down_Rate_Auto.Text = ((float)mStruct_Par.Min_Down_Rate_Auto / 10).ToString();

            TextBox_Limit_Alt1.Text = mStruct_Par.Limit_Alt1.ToString();
            TextBox_Limit_Alt2.Text = mStruct_Par.Limit_Alt2.ToString();

            TextBox_Max_Yaw_Rate.Text = mStruct_Par.Max_Yaw_Rate.ToString();
            TextBox_Follow_Dist.Text = mStruct_Par.Follow_Dist.ToString();

            TextBox_AD0_Bias.Text = Math.Round((double)mStruct_Par.AD0_Bias / 10, 1).ToString();
            TextBox_Dist_Limit.Text = mStruct_Par.Dist_limit.ToString();
        }
    }
}
