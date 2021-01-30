using System;
using System.IO.Ports;
using System.Linq;
using System.IO;
using System.Windows.Threading;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using GMap.NET;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace VIKGroundStation
{
    public class DATA_LINK
    {
        private static DATA_LINK m_DATA_LINK = new DATA_LINK();
        public static DATA_LINK getInstance()
        {
            if (m_DATA_LINK == null)
                m_DATA_LINK = new DATA_LINK();
            return m_DATA_LINK;
        }

        private static byte system_id_set = 0;
        public static byte syste_id_recev = 0;
        public static byte system_id_for_all = 0;

        public static SerialPort DonwLink_SerialPort;// = new System.IO.Ports.SerialPort();
        public static SerialPort Follow_SerialPort;// = new System.IO.Ports.SerialPort();
        private static byte[] buf_serial_downlink = new byte[10000];
        public static byte[] destinationArray = new byte[10000];
        public static int byteToBeParse = 0;

        private static DispatcherTimer heart_timer;
        private DATA_LINK()
        {
            DonwLink_SerialPort = new SerialPort();
            Follow_SerialPort = new SerialPort();

            DonwLink_SerialPort.DataReceived += new SerialDataReceivedEventHandler(mySerialPort_DataReceived);     //数据接收
            Follow_SerialPort.DataReceived += new SerialDataReceivedEventHandler(FollowSerial_DataReceived);     //数据接收

            heart_timer = new DispatcherTimer();                      //软件启动后开启语音提示播报 间隔是5秒
            heart_timer.Interval = System.TimeSpan.FromMilliseconds(1000);
            heart_timer.Tick += heart_timer_Tick;
            heart_timer.Start();
        }

        /******************************************************************
        * function: timer to send heart msg to the plane
        * para:
        * return:
        * ****************************************************************/
        private void heart_timer_Tick(object sender, EventArgs e)
        {
            sendbuf_VIK(MsgDef.MSG_HEART);
            Page_2D_Map.Check_Plane_Link_Status();

            if (Window_Gps_Follow.get_dist_status == 3)
            {
                Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_SINGLE_CONFIG, 65);
                Window_Gps_Follow.get_dist_status = 2;
            }
            else if (Window_Gps_Follow.get_dist_status == 2)
            {
                Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_SINGLE_CONFIG, 66);
                Window_Gps_Follow.get_dist_status = 1;
            }
            else if (Window_Gps_Follow.get_dist_status == 1)
            {
                Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_SINGLE_CONFIG, 67);
                Window_Gps_Follow.get_dist_status = 0;
            }
        }


        /******************************************************************
        * function: set the current system id
        * para:
        * return:
        * ****************************************************************/
        public static void Set_System_Id(byte argId)
        {
            system_id_set = argId;
        }

        /******************************************************************
        * function: set the current system id
        * para:
        * return:
        * ****************************************************************/
        public static byte Get_System_Set_Id()
        {
            return system_id_set;
        }

        /******************************************************************
        * function: set the current system id
        * para:
        * return:
        * ****************************************************************/
        public static byte Get_System_Recv_Id()
        {
            return syste_id_recev;
        }

        /******************************************************************
        * function: set the current system id
        * para:
        * return:
        * ****************************************************************/
        public static void Set_System_All_Id(byte argId)
        {
            system_id_for_all = argId;
        }
        /**************************************************************************
         * 功   能：从串口读取数据
         * 参   数：
         * 返   回：
         * ***********************************************************************/
        public static int link_mode = 0;
        public static bool serial_is_listen = false;
        public void mySerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (DonwLink_SerialPort.IsOpen)
                {
                    serial_is_listen = true;
                    int n = DonwLink_SerialPort.BytesToRead;

                    if (n > 10000)
                        return;

                    DonwLink_SerialPort.Read(buf_serial_downlink, 0, n);

                    Save_DownLink_Data(buf_serial_downlink, (uint)n);

                    if (byteToBeParse + n <= 10000)
                    {
                        Array.Copy(buf_serial_downlink, 0, destinationArray, byteToBeParse, n);
                        byteToBeParse += n;
                    }
                    else
                    {
                        Array.Copy(buf_serial_downlink, 0, destinationArray, 0, n);
                        byteToBeParse = n;
                    }

                    Decode_SerialPort_Data();
                }
            }
            finally
            {
                serial_is_listen = false;
            }
        }


        /************************************************************************
         * function: read gps information
         * para:
         * return:
         * ***********************************************************************/
        private static byte[] buf_serial_gps = new byte[3000];
        private static byte[] destinationArray_gps = new byte[3000];
        private static int byteToBeParse_gps = 0;
        public static bool follow_is_listen = false;
        public static void FollowSerial_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (Follow_SerialPort.IsOpen)
                {
                    follow_is_listen = true;
                    int n = Follow_SerialPort.BytesToRead;
                    Follow_SerialPort.Read(buf_serial_gps, 0, n);

                    if (byteToBeParse_gps + n <= 3000)
                    {
                        Array.Copy(buf_serial_gps, 0, destinationArray_gps, byteToBeParse_gps, n);
                        byteToBeParse_gps += n;
                    }
                    else
                    {
                        Array.Copy(buf_serial_gps, 0, destinationArray_gps, 0, n);
                        byteToBeParse_gps = n;
                    }

                    Decode_SerialPort_Gps();
                }
            }
            finally
            {
                follow_is_listen = false;
            }
        }

        /************************************************************************
        * function: send bytes buf through serial or wifi
        * para:
        * return:
        * ***********************************************************************/
        public static void Send_Buf(byte[] buf, int argBuf_len)
        {
            if (link_mode == 1)
            {
                if (DonwLink_SerialPort.IsOpen == true)
                {
                    DonwLink_SerialPort.Write(buf, 0, argBuf_len);
                }
            }
            else if (link_mode == 2 && net_connect_succeed == true)
            {
                try
                {
                    con.clientSend(buf, argBuf_len);
                }
                catch
                { }
            }
        }

        private static byte[] buf_msg_send = new byte[300];
        /***************************************************************************************
         * function:
         * para:
         * return:
         * **************************************************************************************/
        public static void Send_Play_Back_Data_Req(byte msg_id, byte msg_id2, short takeoff_seq, int pack_seq)
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)7;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)msg_id;

            buf_msg_send[index++] = (byte)msg_id2;
            buf_msg_send[index++] = BitConverter.GetBytes(takeoff_seq)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(takeoff_seq)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(pack_seq)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(pack_seq)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(pack_seq)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(pack_seq)[3];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /***************************************************************************************
         * function:
         * para:
         * return:
         * **************************************************************************************/
        private const short LINK_VERSION = 300;
        public static void sendbuf_VIK(byte msg_id)
        {
            byte index = 0;
            byte[] temp_buf;
            int struct_size = 0;

            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)14;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)msg_id;

            switch (msg_id)
            {
                case MsgDef.MSG_LPID:
                    struct_size = Marshal.SizeOf(DataProcess_JD.mPid);
                    temp_buf = Compute.StructToBytes(DataProcess_JD.mPid);
                    Array.Copy(temp_buf, 0, buf_msg_send, index, struct_size);
                    index += (byte)struct_size;
                    break;
                case MsgDef.MSG_GIMBAL:
                    buf_msg_send[index++] = DataProcess_JD.mSBus_JD.sbus_type;
                    buf_msg_send[index++] = DataProcess_JD.mSBus_JD.sbus_id;
                    buf_msg_send[index++] = BitConverter.GetBytes(DataProcess_JD.mSBus_JD.sbus_value)[0];
                    buf_msg_send[index++] = BitConverter.GetBytes(DataProcess_JD.mSBus_JD.sbus_value)[1];
                    break;
                case MsgDef.MSG_HEART:
                    buf_msg_send[index++] = BitConverter.GetBytes(LINK_VERSION)[0];
                    buf_msg_send[index++] = BitConverter.GetBytes(LINK_VERSION)[1];
                    break;
                default:
                    break;
            }
            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /**********************************************************************
         * 功   能：向飞控发送请求读取指令
         * 参   数：
         * 返   回：
         * *******************************************************************/
        public static void Send_Req_Ctl_Cal_Msg(byte msg_id, byte msg_id2, short msg)
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)3;
            buf_msg_send[index++] = (byte)0;

            if (msg_id2 == MsgDef.MSG_VER)
                buf_msg_send[index++] = (byte)0xff;
            else
                buf_msg_send[index++] = (byte)system_id_set;

            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)msg_id;

            buf_msg_send[index++] = (byte)msg_id2;
            buf_msg_send[index++] = BitConverter.GetBytes(msg)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(msg)[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /**********************************************************************
        * 功   能：固定翼设置舵面中位、最大值、最小值
        * 参   数：
        * 返   回：
        * *******************************************************************/
        public static void Send_Rudder(byte channel, short min, short mid, short max)
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)3;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)31;

            buf_msg_send[index++] = (byte)channel;

            buf_msg_send[index++] = BitConverter.GetBytes(min)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(min)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(mid)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(mid)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(max)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(max)[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /**********************************************************************
        * 功   能：向飞控发送GPS安装偏差
        * 参   数：
        * 返   回：
        * *******************************************************************/
        public static void Send_GPS_Bias_Msg(byte msg_id, short x_bias_A, short y_bias_A, short z_bias_A, short x_bias_B, short y_bias_B, short z_bias_B)
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)6;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)msg_id;

            buf_msg_send[index++] = BitConverter.GetBytes(x_bias_A)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(x_bias_A)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(y_bias_A)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(y_bias_A)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(z_bias_A)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(z_bias_A)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(x_bias_B)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(x_bias_B)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(y_bias_B)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(y_bias_B)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(z_bias_B)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(z_bias_B)[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /**********************************************************************
        * 功   能：向飞控发送相机拍照的触发方式
        * 参   数：
        * 返   回：
        * *******************************************************************/
        public static void Send_Picture_Trigger_Mode(byte msg_id, byte argPicMode, short argTiggerTime, short argPwmOn, short argPwmOff)
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)7;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)msg_id;

            buf_msg_send[index++] = argPicMode;
            buf_msg_send[index++] = BitConverter.GetBytes(argTiggerTime)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argTiggerTime)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argPwmOn)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argPwmOn)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argPwmOff)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argPwmOff)[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /********************************************************************************
         * function:    send flying point position
         * para:   none
         * return:   none
         * ******************************************************************************/
        public static void Send_Fly_Point_Pos(byte msg_id)
        {
            FLY_POINT mFly_Point = DataProcess_JD.Get_Fly_Point();
            byte index = 0;

            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)13;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)msg_id;

            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointLongitude)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointLongitude)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointLongitude)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointLongitude)[3];

            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointLattitude)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointLattitude)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointLattitude)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointLattitude)[3];

            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointAlt)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointAlt)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointSpeed)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point.pointSpeed)[1];

            buf_msg_send[index++] = mFly_Point._point_mode;
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point._circle_radius)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point._circle_radius)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point._circle_speed)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point._circle_speed)[1];

            buf_msg_send[index++] = mFly_Point._circle_direction;

            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point._circle_times)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(mFly_Point._circle_times)[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /********************************************************************************
         * function:    send single msg
         * para:   none
         * return:   none
         * ******************************************************************************/
        public static void Send_Single_Para(short argMsgId, short argValue)
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)4;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_SINGLE_CONFIG;

            buf_msg_send[index++] = BitConverter.GetBytes(argMsgId)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argMsgId)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(argValue)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argValue)[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /**********************************************************************
         * 功   能：发送升级数据
         * 参   数：
         * 返   回：
         * *******************************************************************/
        public static void Send_Update_Msg(byte msg_id, byte com_id)
        {
            byte[] buf_msg_update;
            byte send_firmware_bytes = 0;

            switch (msg_id)
            {
                case MsgDef.MSG_UPDATE_STA:
                    buf_msg_update = new byte[12];
                    buf_msg_update[0] = (byte)0xfe;
                    buf_msg_update[1] = (byte)4;
                    buf_msg_update[2] = (byte)0;
                    buf_msg_update[3] = (byte)system_id_set;
                    buf_msg_update[4] = (byte)com_id;
                    buf_msg_update[5] = (byte)msg_id;

                    buf_msg_update[6] = BitConverter.GetBytes(Page_Version_Update.update_file_size)[0];
                    buf_msg_update[7] = BitConverter.GetBytes(Page_Version_Update.update_file_size)[1];
                    buf_msg_update[8] = BitConverter.GetBytes(Page_Version_Update.update_file_size)[2];
                    buf_msg_update[9] = BitConverter.GetBytes(Page_Version_Update.update_file_size)[3];
                    buf_msg_update[10] = CRC.Get_Crc16(buf_msg_update, 0, (short)(10))[0];
                    buf_msg_update[11] = CRC.Get_Crc16(buf_msg_update, 0, (short)(10))[1];
                    Send_Buf(buf_msg_update, 12);
                    break;
                case MsgDef.MSG_UPDATE_DATA:
                    buf_msg_update = new byte[138];
                    buf_msg_update[0] = (byte)0xfe;
                    // 如果是最后一包
                    if (Page_Version_Update.firmware_pack_index == Page_Version_Update.firmware_total_pack)
                    {
                        send_firmware_bytes = (byte)(Page_Version_Update.update_file_size - (Page_Version_Update.firmware_pack_index - 1) * 128);
                        buf_msg_update[1] = (byte)(send_firmware_bytes + 2);
                    }
                    else
                    {
                        send_firmware_bytes = 128;
                        buf_msg_update[1] = 130;
                    }
                    buf_msg_update[2] = (byte)0;
                    buf_msg_update[3] = (byte)system_id_set;
                    buf_msg_update[4] = (byte)com_id;
                    buf_msg_update[5] = (byte)msg_id;

                    buf_msg_update[6] = BitConverter.GetBytes(Page_Version_Update.firmware_pack_index)[0];
                    buf_msg_update[7] = BitConverter.GetBytes(Page_Version_Update.firmware_pack_index)[1];
                    for (int i = 0; i < send_firmware_bytes; i++)
                    {
                        buf_msg_update[8 + i] = Page_Version_Update.buf_update_firmware[(Page_Version_Update.firmware_pack_index - 1) * 128 + i];
                    }
                    buf_msg_update[send_firmware_bytes + 8] = CRC.Get_Crc16(buf_msg_update, 0, (short)(send_firmware_bytes + 8))[0];
                    buf_msg_update[send_firmware_bytes + 9] = CRC.Get_Crc16(buf_msg_update, 0, (short)(send_firmware_bytes + 8))[1];
                    Send_Buf(buf_msg_update, 138);
                    break;
                case MsgDef.MSG_UPDATE_END:
                    buf_msg_update = new byte[8];
                    buf_msg_update[0] = (byte)0xfe;
                    buf_msg_update[1] = (byte)0;
                    buf_msg_update[2] = (byte)0;
                    buf_msg_update[3] = (byte)system_id_set;
                    buf_msg_update[4] = (byte)com_id;
                    buf_msg_update[5] = (byte)msg_id;
                    buf_msg_update[6] = CRC.Get_Crc16(buf_msg_update, 0, (short)(6))[0];
                    buf_msg_update[7] = CRC.Get_Crc16(buf_msg_update, 0, (short)(6))[1];
                    Send_Buf(buf_msg_update, 8);
                    break;
                default:
                    break;
            }
        }

        /**********************************************************************
       * function:send ground gps information to the drone
       * para:
       * return:
       * *******************************************************************/
        public static void Send_Gps_Gnd_Msg()
        {
            FOLLOW_GPS_POS m_FollowGps = DataProcess_JD.Get_Follow_Gps_Struct();

            byte index = 0;

            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)28;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_GPS_GND;
            // longitude
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nLon_Follow)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nLon_Follow)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nLon_Follow)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nLon_Follow)[3];
            // latitude
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nLat_Follow)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nLat_Follow)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nLat_Follow)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nLat_Follow)[3];
            // altitude
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nAlt_Follow)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nAlt_Follow)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nAlt_Follow)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nAlt_Follow)[3];
            // gps_e
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_E_Follow)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_E_Follow)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_E_Follow)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_E_Follow)[3];
            // gps_n
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_N_Follow)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_N_Follow)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_N_Follow)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_N_Follow)[3];
            // gps_d
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_D_Follow)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_D_Follow)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_D_Follow)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nGps_D_Follow)[3];
            // ground rtk heading
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nHeading)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(m_FollowGps.nHeading)[1];

            buf_msg_send[index++] = DataProcess_JD.follow_gps_type;

            byte temp = 0;
            if (m_FollowGps.heading_status == 1)
                temp |= 0x01;

            if (m_FollowGps.pos_status == 1)           // single 
                temp |= 0x10;
            else if (m_FollowGps.pos_status == 4)   // fix rtk
                temp |= 0x30;
            else if (m_FollowGps.pos_status == 5)   // float rtk
                temp |= 0x20;

            buf_msg_send[index++] = temp;

            buf_msg_send[index++] = m_FollowGps.base_mode;

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /**********************************************************************
      * function:send forbid area to plane
      * para:   argTotalNum-- total forbid area number
      *              argTotalNum-- current forbid area index
      *               argPoints_Forbid--  forbid area points
      * return:
      * ***********************************************************************/
        public static void Send_Forbid_Msg(byte argTotalNum, byte argCurNum, List<PointLatLng> argPoints_Forbid)
        {
            byte index = 0;
            int nTemp = 0;

            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_FORBID_AREA;

            buf_msg_send[index++] = argTotalNum;
            buf_msg_send[index++] = argCurNum;
            buf_msg_send[index++] = (byte)argPoints_Forbid.Count;

            for (int i = 0; i < argPoints_Forbid.Count; i++)
            {
                nTemp = (int)(argPoints_Forbid[i].Lng * Compute.E_7);
                buf_msg_send[index++] = BitConverter.GetBytes(nTemp)[0];
                buf_msg_send[index++] = BitConverter.GetBytes(nTemp)[1];
                buf_msg_send[index++] = BitConverter.GetBytes(nTemp)[2];
                buf_msg_send[index++] = BitConverter.GetBytes(nTemp)[3];

                nTemp = (int)(argPoints_Forbid[i].Lat * Compute.E_7);
                buf_msg_send[index++] = BitConverter.GetBytes(nTemp)[0];
                buf_msg_send[index++] = BitConverter.GetBytes(nTemp)[1];
                buf_msg_send[index++] = BitConverter.GetBytes(nTemp)[2];
                buf_msg_send[index++] = BitConverter.GetBytes(nTemp)[3];

                buf_msg_send[index++] = 0;
                buf_msg_send[index++] = 0;
                buf_msg_send[index++] = 0;
                buf_msg_send[index++] = 0;
            }

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }


        /***************************************************************************************
         *功   能：解析从串口接收到的数据
         *参   数：
         *返   回：
         * *************************************************************************************/
        public static bool data_suc_com = false;       //判断接受数据是否成功
        public static string str_update_warnning = "";
        public static void Decode_SerialPort_Data()
        {
            MainWindow mMainWnd = MainWindow.getInstance();

            byte dataType = 0;
            byte dataLength = 0;

            if (byteToBeParse < 9)       //6是最小数据包长度
                return;                           //此种情况数据予以保留，等待后续数据到来一起解析

            int restCount = 0;
            int j = 0;
            int i = 0;

            for (i = 0; i <= byteToBeParse - 7;)
            {
                // 数据解析 
                if (destinationArray[i] == 0xFE)
                {
                    dataLength = destinationArray[i + 1];
                    dataType = destinationArray[i + 5];

                    syste_id_recev = destinationArray[i + 3];
                    if (syste_id_recev > 20)
                        syste_id_recev = 0;

                    // 如果接受数组的长度不够，则等待下一包数据再解析
                    if (i + dataLength + 8 > byteToBeParse)
                    {
                        break;
                    }
                    else
                    {
                        byte[] buf_checkrcr = new byte[2];
                        buf_checkrcr = CRC.Get_Crc16(destinationArray, i, (short)(dataLength + 6));

                        if (destinationArray[i + dataLength + 6] == buf_checkrcr[0] && destinationArray[i + dataLength + 7] == buf_checkrcr[1]) //i是这包数的头
                        {
                            // ================ check if firmware update is fail and the system is in bootloader ===============
                            if (dataType == 199)
                            {
                                if (destinationArray[i + 4] == 200)
                                    str_update_warnning = "控制器";
                                else if (destinationArray[i + 4] == 201)
                                    str_update_warnning = "IMU";

                                switch (destinationArray[i + 6])
                                {
                                    case 1:
                                        str_update_warnning += "需要升级";
                                        break;
                                    case 2:
                                        str_update_warnning += "擦除FLASH失败";
                                        break;
                                    case 3:
                                        str_update_warnning += "写入FLASH失败";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                str_update_warnning = "";
                            }
                            // ========================= decode downlink msg =============================
                            if (dataType == MsgDef.MSG_IMU && data_suc_com == false)
                            {
                                data_suc_com = true;
                                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                                MainWindow.stream_gcs_log.WriteLine(str_time + "Data Link Success");
                                MainWindow.stream_gcs_log.Flush();

                                if (MainWindow.enable_voice == true)
                                {
                                    MainWindow.Speaker.SpeakAsyncCancelAll();
                                    MainWindow.Speaker.SpeakAsync("通信已连接");
                                }
                            }

                            DataProcess_JD.Decode_Downlink_Data(syste_id_recev, dataType, destinationArray, i + 6);
                            // 如果是数据回放
                            if (dataType == MsgDef.MSG_DATABACK)
                            {
                                mMainWnd.Show_PlayBack_Info(dataType);
                            }
                            // 如果是实时数据下传
                            else
                            {
                                mMainWnd.Fly_Info_Display(dataType);
                            }

                            i = i + (dataLength + 8);    //i跑到下个包的头
                        }
                        else
                            i++; //i偏移到数据位，重新找包头FE
                    }
                }
                else
                {
                    i++;
                }
            }

            restCount = byteToBeParse - i;
            for (j = 0; j < restCount; j++)
                destinationArray[j] = destinationArray[i + j];

            byteToBeParse = restCount;
        }


        /************************************************************************
         * function: get connection to the flight controller by  serial
         * para:
         * return:
         * **********************************************************************/
        public static void Serial_Connect(string serial_text)
        {
            DonwLink_SerialPort.PortName = serial_text;
            DonwLink_SerialPort.BaudRate = 115200;
            DonwLink_SerialPort.Parity = Parity.None;
            DonwLink_SerialPort.StopBits = StopBits.One;
            DonwLink_SerialPort.DataBits = 8;
            DonwLink_SerialPort.ReceivedBytesThreshold = 1;

            if (thread_serial_link == null)
            {
                thread_serial_link = new Thread(Serial_Connect_Thread);
                thread_serial_link.SetApartmentState(ApartmentState.STA);
                thread_serial_link.IsBackground = true;
                thread_serial_link.Start();
            }
        }


        /************************************************************************
        * function: the thread to open serial interface
        * para:
        * return:
        * **********************************************************************/
        public static void Serial_Connect_Thread()
        {
            while (true)
            {
                if (!DonwLink_SerialPort.IsOpen)
                {
                    try
                    {
                        DonwLink_SerialPort.Open();
                    }
                    catch
                    {
                        //连接失败，需要重连
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    thread_serial_link.Abort();
                    thread_serial_link = null;
                }
            }
        }

        //======================================== 以下为和地面GPS和基站通信 ==========================

        /************************************************************************
         * function: get connection to the gps module by  serial
         * para:
         * return:
         * **********************************************************************/
        public static void Gps_Connect(string serial_text)
        {
            Follow_SerialPort.PortName = serial_text;
            Follow_SerialPort.BaudRate = 115200;
            Follow_SerialPort.Parity = Parity.None;
            Follow_SerialPort.StopBits = StopBits.One;
            Follow_SerialPort.DataBits = 8;
            Follow_SerialPort.ReceivedBytesThreshold = 1;

            if (thread_gps_link == null)
            {
                thread_gps_link = new Thread(Gps_Connect_Thread);
                thread_gps_link.SetApartmentState(ApartmentState.STA);
                thread_gps_link.IsBackground = true;
                thread_gps_link.Start();
            }
        }


        /************************************************************************
        * function: the thread to connect gps module
        * para:
        * return:
        * **********************************************************************/
        public static void Gps_Connect_Thread()
        {
            while (true)
            {
                if (!Follow_SerialPort.IsOpen)
                {
                    try
                    {
                        Follow_SerialPort.Open();
                    }
                    catch
                    {
                        //连接失败，需要重连
                        Thread.Sleep(2000);
                    }
                }
                else
                {
                    thread_gps_link.Abort();
                    thread_gps_link = null;

                    Get_Base_Version();
                }
            }
        }


        /***************************************************************************************
       *function:
       *para:
       *return:
       * *************************************************************************************/
        public static bool follow_gps_exist = false;
        public static void Decode_SerialPort_Gps()
        {
            ushort dataLength_gps = 0;
            byte dataType_gps = 0;

            if (byteToBeParse_gps < 9)
                return;

            int restCount_gps = 0;
            int j = 0;
            int i = 0;

            for (i = 0; i <= byteToBeParse_gps - 7;)
            {
                //  ================== GPS data from m8n module =====================
                if (destinationArray_gps[i] == 0xFE)
                {
                    dataLength_gps = (ushort)(destinationArray_gps[i + 1]);
                    dataType_gps = destinationArray_gps[i + 5];

                    // 如果接受数组的长度不够，则等待下一包数据再解析
                    if (i + dataLength_gps + 8 > byteToBeParse_gps)
                    {
                        break;
                    }
                    else
                    {
                        byte[] buf_checkrcr_gps = new byte[2];

                        buf_checkrcr_gps = CRC.Get_Crc16(destinationArray_gps, i, (short)(dataLength_gps + 6));

                        if (destinationArray_gps[i + dataLength_gps + 6] == buf_checkrcr_gps[0] && destinationArray_gps[i + dataLength_gps + 7] == buf_checkrcr_gps[1]) //i是这包数的头
                        {
                            follow_gps_exist = true;
                            //解析数据
                            DataProcess_JD.Decode_Gps(dataType_gps, destinationArray_gps, i + 6);

                            if (Window_Gps_Follow.mb_wnd_initializaed == true && Window_Gps_Follow.mb_wnd_visible == true)
                                Window_Gps_Follow.getInstance().Follow_Infor_Display();

                            i = i + (dataLength_gps + 8);    //i跑到下个包的头
                        }
                        else
                            i++; //i偏移到数据位，重新找包头FE
                    }
                }
                else
                {
                    i++;
                }
            }

            restCount_gps = byteToBeParse_gps - i;
            for (j = 0; j < restCount_gps; j++)
                destinationArray_gps[j] = destinationArray_gps[i + j];

            byteToBeParse_gps = restCount_gps;
        }
        /**********************************************************
         * 功   能：
         * 参   数：
         * 返   回：
         * *******************************************************/
        private static IPAddress _ipAddr = null;
        private static int _port = 0;
        public static MySocket con;
        public static Thread thread_client = null, thread_serial_link = null, thread_gps_link = null;
        public static void wificonnect(string argId, string argPort)
        {
            _port = int.Parse(argPort);
            _ipAddr = IPAddress.Parse(argId);

            if (con == null)
            {
                con = new MySocket(); //建立连接

                //启动连接线程
                thread_client = new Thread(th_client);
                thread_client.SetApartmentState(ApartmentState.STA);
                thread_client.IsBackground = true;
                thread_client.Start();
            }
        }

        /**********************************************************
      * 功   能：
      * 参   数：
      * 返   回：
      * *******************************************************/
        public static bool net_connect_succeed = false;
        public static void th_client()
        {
            while (true)
            {
                if (!net_connect_succeed)
                {
                    try
                    {
                        net_connect_succeed = con.ClientStart(_ipAddr, _port);
                    }
                    catch
                    {
                        //连接失败，需要重连
                        Thread.Sleep(3000);
                    }
                }
                else
                {
                    thread_client.Abort();
                }
            }
        }

        /***********************************************************************************
       * 功  能：实时保存飞控的下传数据
       * 参  数：
       * 返  回：
       * *********************************************************************************/
        private static FileStream afile_save_downlink_data = null;
        public static BinaryWriter sw_save_downlink_data = null;
        public static void Save_DownLink_Data(byte[] arg_Buf, uint sizeByte)
        {
            if (afile_save_downlink_data == null)
            {
                string str_path = Directory.GetCurrentDirectory() + "\\FLY_DATA\\" + DateTime.Now.ToLongDateString()
                        + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + ".dat";
                afile_save_downlink_data = new FileStream(str_path, FileMode.Create);
                sw_save_downlink_data = new BinaryWriter(afile_save_downlink_data);
            }

            if (afile_save_downlink_data != null)
            {
                byte[] but_temp = new byte[sizeByte];
                Array.Copy(arg_Buf, 0, but_temp, 0, sizeByte);
                sw_save_downlink_data.Write(but_temp);
            }
        }

        /***********************************************************************
         * function:
         * para:
         * return:
         * **********************************************************************/
        public static void Send_Rock_Msg(byte argMode)
        {
            short index = 0;

            buf_msg_send[index++] = 0xfe;
            buf_msg_send[index++] = 9;
            buf_msg_send[index++] = 0;
            buf_msg_send[index++] = system_id_set;
            buf_msg_send[index++] = 0;
            buf_msg_send[index++] = MsgDef.MSG_ROCK;

            buf_msg_send[index++] = BitConverter.GetBytes(Window_Hover_Shift.rock_aileron)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(Window_Hover_Shift.rock_aileron)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(Window_Hover_Shift.rock_elevator)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(Window_Hover_Shift.rock_elevator)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(Window_Hover_Shift.rock_throttle)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(Window_Hover_Shift.rock_throttle)[1];

            buf_msg_send[index++] = BitConverter.GetBytes(Window_Hover_Shift.rock_rudder)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(Window_Hover_Shift.rock_rudder)[1];

            buf_msg_send[index++] = argMode;

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /***********************************************************************
        * function: disconnect the net work
        * para:
        * return:
        * **********************************************************************/
        public static void Net_Disconnect()
        {
            if (net_connect_succeed == true)
            {
                thread_client.Abort();
                con.readClientThread.Abort();
                con = null;
                net_connect_succeed = false;
            }
        }

        /*******************************************************************************
        * function: close the serial data link
        * para:
        * return:
        * *****************************************************************************/
        public static void Close_Serial_Port()
        {
            if (DonwLink_SerialPort != null)
            {
                if (DonwLink_SerialPort.IsOpen == true)
                {
                    try
                    {
                        while (serial_is_listen)
                            System.Windows.Forms.Application.DoEvents();

                        DonwLink_SerialPort.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }

        /***********************************************************************
        * function: disconnect the net work
        * para:
        * return:
        * **********************************************************************/
        public static void Serial_Disconnect()
        {
            Close_Serial_Port();
            data_suc_com = false;

            if (MainWindow.enable_voice == true)
            {
                MainWindow.Speaker.SpeakAsyncCancelAll();
                MainWindow.Speaker.SpeakAsync("通信已断开");
            }

            if (thread_serial_link != null)
            {
                thread_serial_link.Abort();
                thread_serial_link = null;
            }
        }

        /**********************************************************************
       * 功   能：设置飞机的返航点
       * 参   数：
       * 返   回：
       * *******************************************************************/
        public static void Send_Home_Pos(byte plane_id, int argLon, int argLat, int argAlt, short argHeading)
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)3;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_HOME;

            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[3];

            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[3];

            buf_msg_send[index++] = BitConverter.GetBytes(argAlt)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argAlt)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argAlt)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(argAlt)[3];

            buf_msg_send[index++] = BitConverter.GetBytes(argHeading)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argHeading)[1];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /***********************************************************************
        * function:
        * para:
        * return:
        * **********************************************************************/
        public static void Send_Hot_Point_Pos(byte plane_id, int argLon, int argLat, int argAlt, byte argStyle)
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)3;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_CTL;

            buf_msg_send[index++] = (byte)MsgDef.MSG_HEAD_FOCUS;

            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[3];

            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[3];

            buf_msg_send[index++] = BitConverter.GetBytes(argAlt)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argAlt)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argAlt)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(argAlt)[3];

            buf_msg_send[index++] = argStyle;

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /***********************************************************************
        * function:
        * para:
        * return:
        * **********************************************************************/
        public static void Send_Return_Circle_Pos(int argLon, int argLat)
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)3;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)system_id_set;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_RETURN_CIRCLE_PT;

            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(argLon)[3];

            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[0];
            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[1];
            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[2];
            buf_msg_send[index++] = BitConverter.GetBytes(argLat)[3];

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }

        /***********************************************************************
       * function: set verion to flight controller
       * para:
       * return:
       * **********************************************************************/
        public static void Send_Version()
        {
            byte index = 0;
            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)3;
            buf_msg_send[index++] = (byte)0;

            if (App.single_many_type == 0)
                buf_msg_send[index++] = (byte)0xFF;
            else
                buf_msg_send[index++] = (byte)system_id_set;

            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)MsgDef.MSG_VER;

            int len = Marshal.SizeOf(typeof(STRUCT_VERSION));
            byte[] data = new byte[len];

            IntPtr structPtr = Marshal.AllocHGlobal(len);
            //将结构体拷贝到分配好的内存空间
            Marshal.StructureToPtr(DataProcess_JD.mStruct_Version, structPtr, false);
            //从内存空间拷贝到byte数组
            Marshal.Copy(structPtr, data, 0, len);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            Array.Copy(data, 0, buf_msg_send, index, len);

            index += (byte)len;
            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf(buf_msg_send, index + 2);
        }


        /***********************************************************************
     * function:
     * para:
     * return:
     * **********************************************************************/
        public static void Send_Heart_Msg(byte argMsg1, byte argMsg2)
        {
            byte[] buf_msg_HEART = new byte[10];

            buf_msg_HEART[0] = (byte)0xfe;
            buf_msg_HEART[1] = (byte)2;
            buf_msg_HEART[2] = (byte)0;
            buf_msg_HEART[3] = 0xff;
            buf_msg_HEART[4] = (byte)0;
            buf_msg_HEART[5] = (byte)argMsg1;

            buf_msg_HEART[6] = (byte)argMsg2;
            buf_msg_HEART[7] = (byte)0;
            buf_msg_HEART[8] = CRC.Get_Crc16(buf_msg_HEART, 0, (short)(8))[0];
            buf_msg_HEART[9] = CRC.Get_Crc16(buf_msg_HEART, 0, (short)(8))[1];
            Send_Buf(buf_msg_HEART, 10);
        }

        public static void Get_Base_Version()
        {
            byte index = 0;

            buf_msg_send[index++] = (byte)0xfe;
            buf_msg_send[index++] = (byte)14;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)0;
            buf_msg_send[index++] = (byte)20;

            buf_msg_send[index++] = (byte)35;

            buf_msg_send[1] = (byte)(index - 6);

            buf_msg_send[index] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[0];
            buf_msg_send[index + 1] = CRC.Get_Crc16(buf_msg_send, 0, (short)(index))[1];
            Send_Buf_To_Base(buf_msg_send, index + 2);
        }

        public static void Send_Buf_To_Base(byte[] buf, int argBuf_len)
        {
            if (Follow_SerialPort.IsOpen == true)
            {
                Follow_SerialPort.Write(buf, 0, argBuf_len);
            }
        }

        /***********************************************************************
        * function: disconnect the udp link
        * para:
        * return:
        * **********************************************************************/
        private static IPAddress _ipAddr_udp = null;
        private static int _port_udp = 0;
        public static UdpClient udp_client;
        public static IPEndPoint ipendpoint_udp;
        public static void Udp_Connect(string argId, string argPort)
        {
            MainWindow mMainWnd = MainWindow.getInstance();

            _port_udp = int.Parse(argPort);
            _ipAddr_udp = IPAddress.Parse(argId);

            if (_port_udp != 0 && _ipAddr_udp != null)
            {
                if (udp_client == null)
                {
                    udp_client = new UdpClient();
                    ipendpoint_udp = new IPEndPoint(_ipAddr_udp, _port_udp);
                }
            }
            else
            {
                Window_Operation_Indication.Set_Indication_Text(mMainWnd.TryFindResource("TITLE_IP_CHECK_FAIL").ToString());
            }
        }

        /***********************************************************************
        * function: disconnect the udp link
        * para:
        * return:
        * **********************************************************************/
        public static void Udp_Disconnect()
        {
            if (udp_client != null)
            {
                udp_client.Close();
                udp_client = null;
            }
        }

        /***********************************************************************
        * function: disconnect the udp link
        * para:
        * return:
        * **********************************************************************/
        public static void Send_Udp_Msg(byte[] argData)
        {
            if (udp_client != null)
            {
                udp_client.Send(argData, argData.Length, ipendpoint_udp);
                udp_client.Client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 128);
            }
        }
    }
}
