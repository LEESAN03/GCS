using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Version_Update.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Version_Update : Page
    {
        private static Page_Version_Update m_Page_Version_Update = new Page_Version_Update();
        public static Page_Version_Update getInstance()
        {
            if (m_Page_Version_Update == null)
                m_Page_Version_Update = new Page_Version_Update();

            return m_Page_Version_Update;
        }

        public static DispatcherTimer t_updateFirmware;
        public static DispatcherTimer timer_read_log_pos;
        private Page_Version_Update()
        {
            InitializeComponent();

            t_updateFirmware = new DispatcherTimer();                      //软件启动后开启语音提示播报 间隔是5秒
            t_updateFirmware.Interval = System.TimeSpan.FromMilliseconds(500);
            t_updateFirmware.Tick += timer_update_firmware_Tick;

            // 请求log、pos、航线下载定时器
            timer_read_log_pos = new DispatcherTimer();                      //软件启动后开启语音提示播报 间隔是5秒
            timer_read_log_pos.Interval = System.TimeSpan.FromMilliseconds(200);
            timer_read_log_pos.Tick += timer_read_log_pos_Tick;

            // 请求飞行数据定时器
            timer_read_playBack_Data = new DispatcherTimer();                      //软件启动后开启语音提示播报 间隔是5秒
            timer_read_playBack_Data.Interval = TimeSpan.FromMilliseconds(100);
            timer_read_playBack_Data.Tick += timer_read_playBack_Data_Tick;

            for (int i = 1; i <= 50; i++)
            {
                Combox_Jiaci.Items.Add(i.ToString());
            }
            Combox_Jiaci.Text = "1";
        }

        /************************************************************************
        * 功   能：升级固件定时器
        * 参   数：
        * 返   回：
        * **********************************************************************/
        public const byte control_BootLoader_Id = 200;
        public const byte imu_BootLoader_Id = 201;
        private void timer_update_firmware_Tick(object sender, EventArgs e)
        {
            // 如果是开始升级，则发送开始升级请求
            if (firmware_pack_index == 0)
            {
                if(update_component == 1)
                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_STA, control_BootLoader_Id);
                else if(update_component == 2)
                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_STA, imu_BootLoader_Id);
            }
            else if ((firmware_pack_index >= 1) && (firmware_pack_index <= firmware_total_pack))   // 开始发送升级数据
            {
                if(update_component == 1)
                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_DATA, control_BootLoader_Id);
                else if(update_component == 2)
                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_DATA, imu_BootLoader_Id);
            }
            else
            {
                if(update_component == 1)
                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_END, control_BootLoader_Id);
                else if(update_component == 2)
                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_END, imu_BootLoader_Id);
            }
        }

        /************************************************************************
        * 功   能：获取飞控固件号
        * 参   数：
        * 返   回：
        * **********************************************************************/
        private void Btn_Get_Control_Version_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_VER, 0);
        }

        /************************************************************************
        * 功   能：获取IMU固件号
        * 参   数：
        * 返   回：
        * **********************************************************************/
        private void Btn_Get_IMU_Version_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_VER, 0);
        }

        /************************************************************************
        * 功   能：升级IMU固件
        * 参   数：
        * 返   回：
        * **********************************************************************/
        public static byte update_component = 0;
        private void Btn_Update_IMU_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofr;    // 数据回放
            ofr = new Microsoft.Win32.OpenFileDialog();
            ofr.DefaultExt = ".bin";
            ofr.Filter = "bin file|*.bin";

            if (ofr.ShowDialog() == true)
            {
                // make sure the .bin file is correct
                if (ofr.FileName.Contains("IMU") == false)
                {
                    MessageBox.Show(TryFindResource("TITLE_FIRMWARE_NOT_CORRECT").ToString());
                    return;
                }

                FileStream ofrfile;
                BinaryReader ofrsr;

                ofrfile = new FileStream(ofr.FileName, FileMode.Open, FileAccess.Read);
                ofrsr = new BinaryReader(ofrfile);

                buf_update_firmware = new byte[ofrfile.Length];
                update_file_size = (UInt32)ofrfile.Length;

                for (int i = 0; i < update_file_size; i++)
                    buf_update_firmware[i] = ofrsr.ReadByte();

                ProgressBar_Update_IMU.Value = 0;
                firmware_pack_index = 0;

                // 计算固件的总包数
                if (update_file_size % 128 == 0)
                {
                    firmware_total_pack = (ushort)(update_file_size / 128);
                }
                else
                {
                    firmware_total_pack = (ushort)(update_file_size / 128 + 1);
                }
                update_component = 2;

                t_updateFirmware.Start();
                ofrfile.Close();
                ofrsr.Close();
            }
        }

        /************************************************************************
         * 功   能：升级控制固件
         * 参   数：
         * 返   回：
         * **********************************************************************/
        public static byte[] buf_update_firmware;
        public static UInt32 update_file_size = 0;         // 升级固件文件的大小
        public static ushort firmware_pack_index = 0;    //更新时数据包索引（1开始）
        public static ushort firmware_total_pack = 0;    //固件总包数
        private void Btn_Update_Controller_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofr;    // 数据回放
            ofr = new Microsoft.Win32.OpenFileDialog();
            ofr.DefaultExt = ".bin";
            ofr.Filter = "bin file|*.bin";

            if (ofr.ShowDialog() == true)
            {
                // make sure the .bin file is correct
                if (ofr.FileName.Contains("CONTROLL") == false)
                {
                    MessageBox.Show(TryFindResource("TITLE_FIRMWARE_NOT_CORRECT").ToString());
                    return;
                }
                FileStream ofrfile;
                BinaryReader ofrsr;

                ofrfile = new FileStream(ofr.FileName, FileMode.Open, FileAccess.Read);
                ofrsr = new BinaryReader(ofrfile);

                update_file_size = (UInt32)ofrfile.Length;
                buf_update_firmware = new byte[update_file_size];

                for (int i = 0; i < update_file_size; i++)
                    buf_update_firmware[i] = ofrsr.ReadByte();

                ProgressBar_Update_Control.Value = 0;
                firmware_pack_index = 0;

                // 计算固件的总包数
                if (update_file_size % 128 == 0)
                {
                    firmware_total_pack = (ushort)(update_file_size / 128);
                }
                else
                {
                    firmware_total_pack = (ushort)(update_file_size / 128 + 1);
                }

                update_component = 1;

                t_updateFirmware.Start();
                ofrfile.Close();
                ofrsr.Close();
            }
        }

        /************************************************************************
        * 功   能：升级控制固件
        * 参   数：
        * 返   回：
        * **********************************************************************/
        public static void Update_Finish()
        {
            t_updateFirmware.Stop();

            firmware_pack_index = 0;
            update_component = 0;
        }

        /************************************************************************
        * 功   能：显示飞控和IMU升级的进度
        * 参   数：
        * 返   回：
        * **********************************************************************/
        public static void Show_Update_Progress()
        {
            if (firmware_pack_index <= firmware_total_pack)
            {
                m_Page_Version_Update.Dispatcher.Invoke(new Action(delegate
                {
                    if (update_component == 1)    // 主控升级
                    {
                        m_Page_Version_Update.ProgressBar_Update_Control.Value = (double)firmware_pack_index / (double)firmware_total_pack;
                        m_Page_Version_Update.TextBlock_Control_Update_Percent.Text = (firmware_pack_index * 100 / firmware_total_pack).ToString() + "%";
                    }
                    else if (update_component == 2)  // IMU升级
                    {
                        m_Page_Version_Update.ProgressBar_Update_IMU.Value = (double)firmware_pack_index / (double)firmware_total_pack;
                        m_Page_Version_Update.TextBlock_Update_IMU_Percent.Text = (firmware_pack_index * 100 / firmware_total_pack).ToString() + "%";
                    }
                }));
            }
        }

        /************************************************************************
        * 功   能：显示飞控和IMU的版本号
        * 参   数：
        * 返   回：
        * **********************************************************************/
        public void Show_Version()
        {
            FW_VERSION m_FW_Version = DataProcess_JD.Get_FW_Version_Struct();
            String str = "";
            if (App.plane_type == 0)
            {
                TextBlock_SYSTEM_ID_NOW.Text = DataProcess_JD.mStruct_Version.system_id.ToString();

                if(DataProcess_JD.mStruct_Version.feikongname != null)
                    str = System.Text.Encoding.Default.GetString(DataProcess_JD.mStruct_Version.feikongname);

                TextBlock_Feikong_Name.Text = TryFindResource("TITLE_EQUIPMENT_NAME") + " " + str;
                TextBlock_Feikong_Xuliehao.Text = TryFindResource("TITLE_EQUIPMENT_NO").ToString() + " " + DataProcess_JD.mStruct_Version.xuliehao.ToString();

                TextBlock_Current_Controller_Version.Text = TryFindResource("TITLE_CONTROLLER_CURRENT_VERSION") + " " + DataProcess_JD.mStruct_Version.gujianhao.ToString();

                TextBlock_Current_IMU_Version.Text = TryFindResource("TITLE_IMU_CURRENT_VERSION") + " " +
                    (DataProcess_JD.mStruct_Version.imuhao / 10000 - (int)(DataProcess_JD.mStruct_Version.imuhao / 1000000) * 100).ToString().PadLeft(2, '0')
                    + DataProcess_JD.mStruct_Version.gps_type.ToString().PadLeft(2, '0') + (DataProcess_JD.mStruct_Version.imuhao / 1000000).ToString().PadLeft(2, '0')
                    + (DataProcess_JD.mStruct_Version.imuhao % 10000).ToString().PadLeft(4, '0');
            }
            else
            {
                if(m_FW_Version.feikongname != null)
                    str = System.Text.Encoding.Default.GetString(m_FW_Version.feikongname);

                TextBlock_Feikong_Name.Text = TryFindResource("TITLE_EQUIPMENT_NAME") + " " + str;
                TextBlock_Feikong_Xuliehao.Text = TryFindResource("TITLE_EQUIPMENT_NO").ToString() + " " + m_FW_Version._serial_id.ToString();

                TextBlock_Current_Controller_Version.Text = TryFindResource("TITLE_CONTROLLER_CURRENT_VERSION") + " " + m_FW_Version._firmware_id.ToString();

                TextBlock_Current_IMU_Version.Text = TryFindResource("TITLE_IMU_CURRENT_VERSION") + m_FW_Version._hardware_id.ToString();
            }
        }

        private void Btn_SET_SYSTEM_ID_Click(object sender, RoutedEventArgs e)
        {
            DataProcess_JD.mStruct_Version.system_id = byte.Parse(TextBox_SYSTEM_ID.Text);
            DATA_LINK.Send_Version();
        }


       // ===================================== download flight data/log/pos ================================
        public static byte Read_Data_Type = 0;
        public static ushort Req_Pic_Pos_Index = 1;     // 读取POS时请求的POS索引
        public static ushort Req_Pic_Pos_Count = 0;     // 读取POS时的发送的请求次数
        /**************************************************************************
         * 功   能：开始读取pos数据
         * 参   数：
         * 返   回：
         * ***********************************************************************/
        public static StreamWriter swrite_pos;
        private void Btn_Download_Pos_Click(object sender, RoutedEventArgs e)
        {
            if (DATA_LINK.data_suc_com == false)
                return;

            Microsoft.Win32.SaveFileDialog ofd = new Microsoft.Win32.SaveFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.Filter = "pos file|*.txt";

            if (ofd.ShowDialog() == true)
            {
                FileStream afile_pos = new FileStream(ofd.FileName, FileMode.Create);
                swrite_pos = new StreamWriter(afile_pos);
                swrite_pos.WriteLine("{0,5}  {1,12}  {2,12}  {3,12}  {4,10}  {5,8}  {6,8}  {7,8} {8,4} ", "id ", "time", "lon ", "lat", "GPS_Alt", "roll", "pitch", "yaw", "RTK");
                Read_Data_Type = 2;

                Req_Pic_Pos_Index = 1;     // 读取POS时请求的POS索引
                Req_Pic_Pos_Count = 0;     // 读取POS时的发送的请求次数

                timer_read_log_pos.Start();
            }
        }

        /**************************************************************************
        * 功   能：读取飞行数据
        * 参   数：
        * 返   回：
        * ***********************************************************************/
        private void Btn_Download_Fly_Data_Click(object sender, RoutedEventArgs e)
        {
            if (DATA_LINK.data_suc_com == false)
                return;

            Microsoft.Win32.SaveFileDialog ofd = new Microsoft.Win32.SaveFileDialog();
            ofd.DefaultExt = ".dat";
            ofd.Filter = "dat file|*.dat";

            if (ofd.ShowDialog() == true)
            {
                FileStream afile_data = new FileStream(ofd.FileName, FileMode.Create);
                sw_read_play_back_data = new BinaryWriter(afile_data);

                num_play_back_data = 1;
                num_jia_ci = (short)(short.Parse(Combox_Jiaci.Text) - 1);

                DataProcess_JD.mPlay_Data_From_FC.data_id = 0;

                timer_read_playBack_Data.Start();
            }
        }

        /**************************************************************************
        * 功   能：读取飞行LOG
        * 参   数：
        * 返   回：
        * ***********************************************************************/
        public static StreamWriter sw1_log;
        private void Btn_Download_Fly_Log_Click(object sender, RoutedEventArgs e)
        {
            if (DATA_LINK.data_suc_com == false)
                return;

            Microsoft.Win32.SaveFileDialog ofd = new Microsoft.Win32.SaveFileDialog();
            ofd.DefaultExt = ".txt";
            ofd.Filter = "txt file|*.txt";

            if (ofd.ShowDialog() == true)
            {
                FileStream afile_data = new FileStream(ofd.FileName, FileMode.Create);
                sw1_log = new StreamWriter(afile_data);

                DataProcess_JD.mFly_Log.log_id = 0;

                Read_Data_Type = 1;
                num_count_log = 1;

                timer_read_log_pos.Start();
            }
        }

        /************************************************************************
         * 功   能：在此定时器里读取LOG, POS, WPT
         * 参   数：
         * 返   回：
         * **********************************************************************/
        private static short num_count_log = 1;

        private void timer_read_log_pos_Tick(object sender, EventArgs e)
        {
            MainWindow m_MainWnd = MainWindow.getInstance();
            FLY_LOG mFly_Log = DataProcess_JD.Get_Fly_Log();

            // 请求LOG信息
            if (Read_Data_Type == 1)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_LOG, (short)(mFly_Log.log_id + 1));
                num_count_log = (short)(mFly_Log.log_id + 1);
            }
            // 请求POS信息
            else if (Read_Data_Type == 2)
            {
                Req_Pic_Pos_Count++;
                if (Req_Pic_Pos_Count >= 50)
                {
                    Req_Pic_Pos_Count = 0;
                    Req_Pic_Pos_Index = 1;
                    Read_Data_Type = 0;

                    swrite_pos.Close();
                    timer_read_log_pos.Stop();

                    System.Windows.MessageBox.Show(TryFindResource("TITLE_READ_POS_FAIL").ToString());
                }
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_PO, (short)Req_Pic_Pos_Index);
            }
            // 请求航点信息
            else if (Read_Data_Type == 3)
            {
                Window_Skyway.Req_Wpt_Count++;
                if (Window_Skyway.Req_Wpt_Count >= 50)
                {
                    Window_Skyway.Req_Wpt_Count = 0;
                    Window_Skyway.Req_Wpt_Index = 1;
                    Read_Data_Type = 0;
                    timer_read_log_pos.Stop();

                    MessageBox.Show(TryFindResource("TITLE_WPT_DOWN_LOAD_FAIL").ToString());
                }
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_WP, (short)Window_Skyway.Req_Wpt_Index);
            }
        }

        /************************************************************************
         * 功   能：在此定时器里读取飞行数据
         * 参   数：
         * 返   回：
         * **********************************************************************/
        private static DispatcherTimer timer_read_playBack_Data;
        private static int num_play_back_data = 1;
        private static short num_jia_ci = 0;
        private static BinaryWriter sw_read_play_back_data;
        private static uint send_playBack_data_req_count = 0;
        private void timer_read_playBack_Data_Tick(object sender, EventArgs e)
        {
            if (send_playBack_data_req_count++ < 50)
            {
                DATA_LINK.Send_Play_Back_Data_Req(MsgDef.MSG_REQ, MsgDef.MSG_DATA, num_jia_ci, num_play_back_data);
            }
            // 如果发送50次请求都失败，则终止请求
            else
            {
                send_playBack_data_req_count = 0;
                num_play_back_data = 1;

                sw_read_play_back_data.Close();
                timer_read_playBack_Data.Stop();

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Read fly data fail");
                MainWindow.stream_gcs_log.Flush();

                MessageBox.Show(TryFindResource("TITLE_READ_PLAY_BACK_DATA_FAIL").ToString());
            }
        }

        /**********************************************************************************
         * 功   能：保存下载的回放数据
         * 参   数：
         * 返   回：
         * *******************************************************************************/
        public static void Save_PlayBack_Data()
        {
            PLAY_DATA_FROM_FC mPlay_Data_From_FC = DataProcess_JD.Get_Play_Back_Data();

            send_playBack_data_req_count = 0;

            // 如果收到序号等于发送的序号，表明本次请求成功
            if (mPlay_Data_From_FC.data_id == num_play_back_data)
            {
                num_play_back_data = mPlay_Data_From_FC.data_id + 1;
                // 如果接收到的不是最后一包数据
                sw_read_play_back_data.Write(mPlay_Data_From_FC.data_);

                m_Page_Version_Update.Dispatcher.Invoke(new Action(delegate
                {
                    m_Page_Version_Update.ProgressBar_Download_FLy_Data.Value = (double)mPlay_Data_From_FC.data_id / (double)mPlay_Data_From_FC.data_num_all;
                    m_Page_Version_Update.TextBlock_Fly_Data_Percent.Text = (mPlay_Data_From_FC.data_id * 100 / mPlay_Data_From_FC.data_num_all).ToString() + "%";
                }));

                if (mPlay_Data_From_FC.data_num_all == mPlay_Data_From_FC.data_id)
                {
                    sw_read_play_back_data.Close();
                    timer_read_playBack_Data.Stop();
                }
            }
        }

        /**********************************************************************************
        * 功   能：保存下载的飞行日志
        * 参   数：
        * 返   回：
        * *******************************************************************************/
        public static void Save_Log_Data()
        {
            FLY_LOG mFly_Log = DataProcess_JD.Get_Fly_Log();

            if (mFly_Log.log_id == num_count_log)
            {
                if (mFly_Log.log_all_id > mFly_Log.log_id)
                {
                    sw1_log.WriteLine("");
                    sw1_log.WriteLine("*********************************************************************************************{0}/{1}***********************************************************************************************",
                        mFly_Log.log_id,
                        mFly_Log.log_all_id);
                    sw1_log.WriteLine("*飞行总架次:            {0,-8}      *飞行架次编号:         {1,-8}       *飞机类型:             {2,-8}        *飞机固件号:         {3,8}           *                                       *",
                        mFly_Log.log_all_id,
                        mFly_Log.log_id,
                        mFly_Log.log_plane_type,
                        mFly_Log.log_gujianhao
                        );
                    sw1_log.WriteLine("****************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*解锁点位置:  {0,-10},{1,10}  *解锁时间:   {2,2}年{3,2}月{4,2}日,{5,2}:{6,2}:{7,2}    *落锁点位置:   {8,-10},{9,-10}  *                                       *                                      *",
                        (double)mFly_Log.log_jiesuo_jingdu * Math.Pow(10, -7),
                        (double)mFly_Log.log_jiesuo_weidu * Math.Pow(10, -7),
                        mFly_Log.log_jiesuo_year,
                        mFly_Log.log_jiesuo_month,
                        mFly_Log.log_jiesuo_day,
                        mFly_Log.log_jiesuo_hour,
                        mFly_Log.log_jiesuo_min,
                        mFly_Log.log_jiesuo_second,
                        (double)mFly_Log.log_luosuo_jingdu * Math.Pow(10, -7),
                        (double)mFly_Log.log_luosuo_weidu * Math.Pow(10, -7)
                        );
                    sw1_log.WriteLine("***************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*本次飞行时间:     {0,5}s             *总飞行时间:      {1,5}min            *本次飞行里程:    {2,6}m              *总飞行里程:           {3,6}km         *                                      *",
                        mFly_Log.log_feixingshijian,
                        mFly_Log.log_all_feixingshijian / 60,
                        mFly_Log.log_feixinglicheng,
                        (double)mFly_Log.log_all_licheng * Math.Pow(10, -3)
                        );
                    sw1_log.WriteLine("**************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*解锁时电压: {0,12}V            *落锁时电压:{1,12}V             *                                      *                                       *                                      *",
                        (double)mFly_Log.log_jiesuo_dianya * 0.1,
                        (double)mFly_Log.log_luosuo_dianya * 0.1
                        );
                    sw1_log.WriteLine("***************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*最大横滚角: {0,12}             *最大俯仰角:{1,12}              *最大水平速度:   {2,8}m/s           * 最大上升速度:      {3,8}m/s        *最大下降速度:   {4,8}m/s           *   ",
                        mFly_Log.log_max_henggunjiao,
                        mFly_Log.log_max_fuyangjiao,
                        (double)mFly_Log.log_max_shuiping_speed * 0.1,
                        (double)mFly_Log.log_max_chuizhi_shangsheng_speed * 0.1,
                        (double)mFly_Log.log_max_chuizhi_xiajiang_speed * 0.1
                        );
                    sw1_log.WriteLine("***************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*GPS最大星数:    {0,8}             *GPS最小星数:   {1,8}              *GPS定位时间:      {2,8}s           *                                       *                                      *",
                        mFly_Log.log_max_GPS_num,
                        mFly_Log.log_min_GPS_num,
                        mFly_Log.log_min_GPS_timer
                        );
                    sw1_log.WriteLine("***************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*磁传感器:       {0,8}             *加计陀螺:      {1,8}              *气压计:         {2,8}              *GPS:           {3,8}                *雷达:      {4,8}                   *",
                        mFly_Log.log_ci_yichang,
                        mFly_Log.log_jiajituoluo_yichang,
                        mFly_Log.log_qiya_yichang,
                        mFly_Log.log_GPS_yichang,
                        mFly_Log.log_leida_yichang);
                    sw1_log.WriteLine("*******************************************************************{0}/{1}END**********************************************************************************************************************", mFly_Log.log_id, mFly_Log.log_all_id);
                    sw1_log.WriteLine("");
                }
                else
                {
                    sw1_log.WriteLine("");
                    sw1_log.WriteLine("*********************************************************************************************{0}/{1}***********************************************************************************************",
                        mFly_Log.log_id,
                        mFly_Log.log_all_id);
                    sw1_log.WriteLine("*飞行总架次:            {0,-8}      *飞行架次编号:         {1,-8}       *飞机类型:             {2,-8}        *飞机固件号:         {3,8}           *                                       *",
                        mFly_Log.log_all_id,
                        mFly_Log.log_id,
                        mFly_Log.log_plane_type,
                        mFly_Log.log_gujianhao
                        );
                    sw1_log.WriteLine("****************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*解锁点位置:  {0,-10},{1,10}  *解锁时间:   {2,2}年{3,2}月{4,2}日,{5,2}:{6,2}:{7,2}    *落锁点位置:   {8,-10},{9,-10}  *                                       *                                      *",
                        (double)mFly_Log.log_jiesuo_jingdu * Math.Pow(10, -7),
                        (double)mFly_Log.log_jiesuo_weidu * Math.Pow(10, -7),
                        mFly_Log.log_jiesuo_year,
                        mFly_Log.log_jiesuo_month,
                        mFly_Log.log_jiesuo_day,
                        mFly_Log.log_jiesuo_hour,
                        mFly_Log.log_jiesuo_min,
                        mFly_Log.log_jiesuo_second,
                        (double)mFly_Log.log_luosuo_jingdu * Math.Pow(10, -7),
                        (double)mFly_Log.log_luosuo_weidu * Math.Pow(10, -7)
                        );
                    sw1_log.WriteLine("***************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*本次飞行时间:     {0,5}s             *总飞行时间:      {1,5}min            *本次飞行里程:    {2,6}m              *总飞行里程:           {3,6}km         *                                      *",
                        mFly_Log.log_feixingshijian,
                        mFly_Log.log_all_feixingshijian / 60,
                        mFly_Log.log_feixinglicheng,
                        (double)mFly_Log.log_all_licheng * Math.Pow(10, -3)
                        );
                    sw1_log.WriteLine("**************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*解锁时电压: {0,12}V            *落锁时电压:{1,12}V             *                                      *                                       *                                      *",
                        (double)mFly_Log.log_jiesuo_dianya * 0.1,
                        (double)mFly_Log.log_luosuo_dianya * 0.1
                        );
                    sw1_log.WriteLine("***************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*最大横滚角: {0,12}             *最大俯仰角:{1,12}              *最大水平速度:   {2,8}m/s           * 最大上升速度:      {3,8}m/s        *最大下降速度:   {4,8}m/s           *   ",
                        mFly_Log.log_max_henggunjiao,
                        mFly_Log.log_max_fuyangjiao,
                        (double)mFly_Log.log_max_shuiping_speed * 0.1,
                        (double)mFly_Log.log_max_chuizhi_shangsheng_speed * 0.1,
                        (double)mFly_Log.log_max_chuizhi_xiajiang_speed * 0.1
                        );
                    sw1_log.WriteLine("***************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*GPS最大星数:    {0,8}             *GPS最小星数:   {1,8}              *GPS定位时间:      {2,8}s           *                                       *                                      *",
                        mFly_Log.log_max_GPS_num,
                        mFly_Log.log_min_GPS_num,
                        mFly_Log.log_min_GPS_timer
                        );
                    sw1_log.WriteLine("***************************************************************************************************************************************************************************************************");
                    sw1_log.WriteLine("*磁传感器:       {0,8}             *加计陀螺:      {1,8}              *气压计:         {2,8}              *GPS:           {3,8}                *雷达:      {4,8}                   *",
                        mFly_Log.log_ci_yichang,
                        mFly_Log.log_jiajituoluo_yichang,
                        mFly_Log.log_qiya_yichang,
                        mFly_Log.log_GPS_yichang,
                        mFly_Log.log_leida_yichang);
                    sw1_log.WriteLine("*******************************************************************{0}/{1}END**********************************************************************************************************************", mFly_Log.log_id, mFly_Log.log_all_id);
                    sw1_log.WriteLine("");
                    sw1_log.Close();

                    timer_read_log_pos.Stop();
                    Read_Data_Type = 0;
                }

                m_Page_Version_Update.Dispatcher.Invoke(new Action(delegate
                {
                    m_Page_Version_Update.ProgressBar_Download_FLy_Log.Value = (double)mFly_Log.log_id / (double)mFly_Log.log_all_id;
                    m_Page_Version_Update.TextBlock_Fly_Log_Percent.Text = (mFly_Log.log_id * 100 / mFly_Log.log_all_id).ToString() + "%";
                }));
            }
        }


    }
}
