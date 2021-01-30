using GMap.NET;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace VIKGroundStation
{
    public class DataProcess_JD
    {
        private static DataProcess_JD m_DataProcess_JD = new DataProcess_JD();
        public static DataProcess_JD getInstance()
        {
            if (m_DataProcess_JD == null)
                m_DataProcess_JD = new DataProcess_JD();

            return m_DataProcess_JD;
        }

        // =================================== 多旋翼参数 ==================================
        private static PLANE_DOWN_LINK_MSG plane_downlink_msg = new PLANE_DOWN_LINK_MSG();
        public static PID_B mPid = new PID_B();
        private static PLANE_SETTING mPlane_Setting = new PLANE_SETTING();
        private static ACKid mACKid = new ACKid();
        private static PIC_POS mPic_Pos = new PIC_POS();
        public static FLY_POINT mFly_Point = new FLY_POINT();
        public static SBus_jd mSBus_JD = new SBus_jd();
        public static PLAY_DATA_FROM_FC mPlay_Data_From_FC = new PLAY_DATA_FROM_FC();
        public static FLY_LOG mFly_Log = new FLY_LOG();
        public static STRUCT_VERSION mStruct_Version = new STRUCT_VERSION();
        private static STRUCT_WPT mStruct_Wpt = new STRUCT_WPT();
        public static STRUCT_GPS_BIAS mStruct_Gps_Bias = new STRUCT_GPS_BIAS();
        private static STRUCT_PAR mStruct_Par = new STRUCT_PAR();
        private static MSG_Databack_JD mMSG_Databack_JD = new MSG_Databack_JD();
        public static MSG_SINGLE_PARA m_Msg_Single_Para = new MSG_SINGLE_PARA();
        private static FOLLOW_GPS_POS m_FollowGps = new FOLLOW_GPS_POS();
        private static FX_CHANNEL_CONFIG m_Channel_Config = new FX_CHANNEL_CONFIG();

        // =================================== 固定翼参数 ==================================
        private static CHUIQI_DOWN_LINK_MSG chuiqi_downlink_msg = new CHUIQI_DOWN_LINK_MSG();
        private static FLY_INFOR_DISPLAY[] mFly_Infor_Display = new FLY_INFOR_DISPLAY[21];
        private static FW_FLY_SETTINGS m_FW_Fly_Settings = new FW_FLY_SETTINGS();
        private static FW_SETTING2 m_FW_Fly_Settings2 = new FW_SETTING2();
        private static FW_MM_PID m_FW_MM_Pid = new FW_MM_PID();
        private static FW_PID m_FW_Pid = new FW_PID();
        private static FW_VERSION m_FW_Version = new FW_VERSION();

        private static YOUDIAN_STRUCT m_YouDian = new YOUDIAN_STRUCT();
        //构造函数
        private DataProcess_JD()
        {
        }

        public static FLY_INFOR_DISPLAY Get_Fly_Display(byte argSys_Id)
        {
            return mFly_Infor_Display[argSys_Id];
        }

        public static PID_B Get_PID()
        {
            return mPid;
        }
        public static PLANE_SETTING Get_Plane_Setting()
        {
            return mPlane_Setting;
        }
        public static PIC_POS Get_Pic_Pos()
        {
            return mPic_Pos;
        }
        public static FLY_POINT Get_Fly_Point()
        {
            return mFly_Point;
        }
        public static PLAY_DATA_FROM_FC Get_Play_Back_Data()
        {
            return mPlay_Data_From_FC;
        }
        public static FLY_LOG Get_Fly_Log()
        {
            return mFly_Log;
        }
        public static STRUCT_WPT Get_WPT()
        {
            return mStruct_Wpt;
        }
        public static STRUCT_PAR Get_Par()
        {
            return mStruct_Par;
        }
        public static MSG_Databack_JD Get_Play_Back_Infor()
        {
            return mMSG_Databack_JD;
        }
        public static FOLLOW_GPS_POS Get_Follow_Gps_Struct()
        {
            return m_FollowGps;
        }

        public static FX_CHANNEL_CONFIG Get_Channel_Config_Struct()
        {
            return m_Channel_Config;
        }

        public static FW_FLY_SETTINGS Get_FW_Settings_Struct()
        {
            return m_FW_Fly_Settings;
        }

        public static FW_SETTING2 Get_FW_Settings2_Struct()
        {
            return m_FW_Fly_Settings2;
        }

        public static FW_MM_PID Get_FW_MM_PID_Struct()
        {
            return m_FW_MM_Pid;
        }

        public static FW_PID Get_FW_PID_Struct()
        {
            return m_FW_Pid;
        }

        public static FW_VERSION Get_FW_Version_Struct()
        {
            return m_FW_Version;
        }

        public static YOUDIAN_STRUCT Get_YouDian_Struct()
        {
            return m_YouDian;
        }

        /**************************************************************************************
        function: decode the information from plane
        para:
        return:
        * *************************************************************************************/
        private static void Decode_MM_Infor(byte argSys_Id, PLANE_DOWN_LINK_MSG plane_msg)
        {
            mFly_Infor_Display[argSys_Id].flight_id = plane_msg.flight_id;
            mFly_Infor_Display[argSys_Id].imu_hangxiangjiao = (double)plane_msg.imu_hangxiangjiao * 0.1;   //  deg
            mFly_Infor_Display[argSys_Id].imu_henggunjiao = (double)plane_msg.imu_henggunjiao * 0.1;     //  deg
            mFly_Infor_Display[argSys_Id].imu_fuyangjiao = (double)plane_msg.imu_fuyangjiao * 0.1;        //  deg

            mFly_Infor_Display[argSys_Id].imu_jisuan_gaodu = (double)plane_msg.imu_jisuan_gaodu * 0.1;    // m
            mFly_Infor_Display[argSys_Id].imu_chuizhisudu = (double)plane_msg.imu_chuizhisudu * 0.1;    // m
            mFly_Infor_Display[argSys_Id].imu_shuipingsudu = (double)plane_msg.imu_shuipingsudu * 0.1;   // m/s
            mFly_Infor_Display[argSys_Id].imu_kongsu = 0;            // m/s
            mFly_Infor_Display[argSys_Id].imu_jiesuan_lon = (double)plane_msg.imu_jiesuan_lon / 10000000;         // deg
            mFly_Infor_Display[argSys_Id].imu_jiesuan_lat = (double)plane_msg.imu_jiesuan_lat / 10000000;         // deg
            mFly_Infor_Display[argSys_Id].gps_lon = (double)plane_msg.gps_lon / 10000000;         //deg
            mFly_Infor_Display[argSys_Id].gps_lat = (double)plane_msg.gps_lat / 10000000;         // deg
            mFly_Infor_Display[argSys_Id].gps_alt = (double)plane_msg.gps_alt / 10;         // m
            mFly_Infor_Display[argSys_Id].gps_track_angle = (double)plane_msg.gps_track_angle / 10;         // deg
            mFly_Infor_Display[argSys_Id].gps_speed = (double)plane_msg.gps_speed / 10; ;         // m/s
            mFly_Infor_Display[argSys_Id].gps_num = plane_msg.gps_num;
            mFly_Infor_Display[argSys_Id].gps_pdop = (double)plane_msg.gps_pdop / 10;
            mFly_Infor_Display[argSys_Id].rtk_status = plane_msg.rtk_status;
            mFly_Infor_Display[argSys_Id].noise_kx = (double)plane_msg.noise_kx / 200;  // 0--200
            mFly_Infor_Display[argSys_Id].gps_year = plane_msg.gps_year;
            mFly_Infor_Display[argSys_Id].gps_month = plane_msg.gps_month;
            mFly_Infor_Display[argSys_Id].gps_day = plane_msg.gps_day;
            mFly_Infor_Display[argSys_Id].gps_hour = plane_msg.gps_hour;
            mFly_Infor_Display[argSys_Id].gps_minute = plane_msg.gps_minute;
            mFly_Infor_Display[argSys_Id].gps_second = plane_msg.gps_second;
            mFly_Infor_Display[argSys_Id].gps_mini_second = plane_msg.gps_mini_second;   // 100 ms
            mFly_Infor_Display[argSys_Id].gps_num2 = plane_msg.gps_num2;
            mFly_Infor_Display[argSys_Id].rtk_ant2 = plane_msg.rtk_ant2;
            mFly_Infor_Display[argSys_Id].dist_to_home = plane_msg.dist_to_home;   // m
            mFly_Infor_Display[argSys_Id].warnning_flag = plane_msg.warnning_flag;
            mFly_Infor_Display[argSys_Id].home_reason = plane_msg.home_reason;
            mFly_Infor_Display[argSys_Id].flied_time = plane_msg.flied_time;  // second
            mFly_Infor_Display[argSys_Id].cross_dist = (double)plane_msg.cross_dist / 10;    // m
            mFly_Infor_Display[argSys_Id].target_wpt_dist = (double)plane_msg.target_wpt_dist / 10;    // m
            mFly_Infor_Display[argSys_Id].target_alt = (double)plane_msg.target_alt / 10;    // m
            mFly_Infor_Display[argSys_Id].total_wpt_dist = plane_msg.total_wpt_dist;    // m
            mFly_Infor_Display[argSys_Id].wpt_flied_dist = plane_msg.wpt_flied_dist;    // m
            mFly_Infor_Display[argSys_Id].rest_circle_time = plane_msg.rest_circle_time;
            mFly_Infor_Display[argSys_Id].radar_alt = (double)plane_msg.radar_alt / 100;    // m     -1----radar unavalable
            mFly_Infor_Display[argSys_Id].radar_front = (double)plane_msg.radar_front / 100;    // m
            mFly_Infor_Display[argSys_Id].radar_back = (double)plane_msg.radar_back / 100;    // m
            mFly_Infor_Display[argSys_Id].fly_mode = plane_msg.fly_mode;
            mFly_Infor_Display[argSys_Id].total_wpt_count = plane_msg.total_wpt_count;
            mFly_Infor_Display[argSys_Id].target_wpt_index = plane_msg.target_wpt_index;
            mFly_Infor_Display[argSys_Id].total_pic_count = plane_msg.total_pic_count;
            mFly_Infor_Display[argSys_Id].batter_volt = (double)plane_msg.batter_volt / 10;    // v
            mFly_Infor_Display[argSys_Id].lock_status = plane_msg.lock_status;
            mFly_Infor_Display[argSys_Id].temperature = plane_msg.temperature;
            mFly_Infor_Display[argSys_Id].total_flied_time = plane_msg.total_flied_time;   //minute
            mFly_Infor_Display[argSys_Id].ins_flag = plane_msg.ins_flag;
            mFly_Infor_Display[argSys_Id].motor_balance = plane_msg.motor_balance;
            mFly_Infor_Display[argSys_Id].direction_filter = plane_msg.direction_filter;
            mFly_Infor_Display[argSys_Id].in_forbidden_area_count = plane_msg.in_forbidden_area_count;
            mFly_Infor_Display[argSys_Id].mag_calibrate_status = plane_msg.mag_calibrate_status; // 1---calibrate xy   2---calibrate xz    3---succuss    4---fail
            mFly_Infor_Display[argSys_Id].plane_status = plane_msg.plane_status; // 1---normal  2---mag calibrate   3---remoter calibrate    4---esc calibrate   5---imu update
            mFly_Infor_Display[argSys_Id].adc1_volt = (double)plane_msg.adc1_volt / 10;
            mFly_Infor_Display[argSys_Id].adc2_volt = (double)plane_msg.adc2_volt / 10;
            mFly_Infor_Display[argSys_Id].base_throttle = plane_msg.base_throttle;
            mFly_Infor_Display[argSys_Id].gps_status = plane_msg.gps_status;
            mFly_Infor_Display[argSys_Id].baro_status = plane_msg.baro_status;
            mFly_Infor_Display[argSys_Id].gyro_acc_status = plane_msg.gyro_acc_status;
            mFly_Infor_Display[argSys_Id].mag_status = plane_msg.mag_status;

            mFly_Infor_Display[argSys_Id].controllerInput1 = plane_msg.controllerInput1;
            mFly_Infor_Display[argSys_Id].controllerInput2 = plane_msg.controllerInput2;
            mFly_Infor_Display[argSys_Id].controllerInput3 = plane_msg.controllerInput3;
            mFly_Infor_Display[argSys_Id].controllerInput4 = plane_msg.controllerInput4;
            mFly_Infor_Display[argSys_Id].controllerInput5 = plane_msg.controllerInput5;
            mFly_Infor_Display[argSys_Id].controllerInput6 = plane_msg.controllerInput6;
            mFly_Infor_Display[argSys_Id].controllerInput7 = plane_msg.controllerInput7;
            mFly_Infor_Display[argSys_Id].controllerInput8 = plane_msg.controllerInput8;

            mFly_Infor_Display[argSys_Id].pwm_out1 = plane_msg.ElectricMachineOutput1;
            mFly_Infor_Display[argSys_Id].pwm_out2 = plane_msg.ElectricMachineOutput2;
            mFly_Infor_Display[argSys_Id].pwm_out3 = plane_msg.ElectricMachineOutput3;
            mFly_Infor_Display[argSys_Id].pwm_out4 = plane_msg.ElectricMachineOutput4;
            mFly_Infor_Display[argSys_Id].pwm_out5 = plane_msg.ElectricMachineOutput5;
            mFly_Infor_Display[argSys_Id].pwm_out6 = plane_msg.ElectricMachineOutput6;
            mFly_Infor_Display[argSys_Id].pwm_out7 = plane_msg.ElectricMachineOutput7;
            mFly_Infor_Display[argSys_Id].pwm_out8 = plane_msg.ElectricMachineOutput8;

            mFly_Infor_Display[argSys_Id].pwm_out9 = 0;
            mFly_Infor_Display[argSys_Id].pwm_out10 = 0;
            mFly_Infor_Display[argSys_Id].pwm_out11 = 0;
            mFly_Infor_Display[argSys_Id].pwm_out12 = 0;
            mFly_Infor_Display[argSys_Id].pwm_out13 = 0;
            mFly_Infor_Display[argSys_Id].pwm_out14 = 0;
            mFly_Infor_Display[argSys_Id].pwm_out15 = 0;
            mFly_Infor_Display[argSys_Id].pwm_out16 = 0;

            mFly_Infor_Display[argSys_Id].signal_out1 = 0;
            mFly_Infor_Display[argSys_Id].signal_out2 = 0;
            mFly_Infor_Display[argSys_Id].signal_out3 = 0;
            mFly_Infor_Display[argSys_Id].signal_out4 = 0;
            mFly_Infor_Display[argSys_Id].signal_out5 = 0;
            mFly_Infor_Display[argSys_Id].signal_out6 = 0;
            mFly_Infor_Display[argSys_Id].signal_out7 = 0;
            mFly_Infor_Display[argSys_Id].signal_out8 = 0;
            mFly_Infor_Display[argSys_Id].signal_out9 = 0;

            mFly_Infor_Display[argSys_Id].engine_speed = 0;
            mFly_Infor_Display[argSys_Id].bian_gao = 0;
            mFly_Infor_Display[argSys_Id].power_type = 0;

            mFly_Infor_Display[argSys_Id].allign_ew_dist = plane_msg.allign_ew_dist;
            mFly_Infor_Display[argSys_Id].allign_ns_dist = plane_msg.allign_ns_dist;
            mFly_Infor_Display[argSys_Id].allign_up_dist = plane_msg.allign_up_dist;

            mFly_Infor_Display[argSys_Id].base_lon = plane_msg.base_lon;
            mFly_Infor_Display[argSys_Id].base_lat = plane_msg.base_lat;
            mFly_Infor_Display[argSys_Id].base_gps_alt = plane_msg.base_gps_alt;
            mFly_Infor_Display[argSys_Id].base_ew_vel = plane_msg.base_ew_vel;
            mFly_Infor_Display[argSys_Id].base_ns_vel = plane_msg.base_ns_vel;
            mFly_Infor_Display[argSys_Id].base_up_vel = plane_msg.base_up_vel;

            mFly_Infor_Display[argSys_Id].base_heading = plane_msg.base_heading;
            mFly_Infor_Display[argSys_Id].base_ant1_num = plane_msg.base_ant1_num;
            mFly_Infor_Display[argSys_Id].base_heading_type = plane_msg.base_heading_type;
            mFly_Infor_Display[argSys_Id].base_ant2_num = plane_msg.base_ant2_num;
        }

        /**************************************************************************************
        function: decode the information from plane
        para:
        return:
        * *************************************************************************************/
        private static void Decode_FW_Infor(byte argSys_Id, CHUIQI_DOWN_LINK_MSG plane_msg)
        {
            mFly_Infor_Display[argSys_Id].flight_id = 0;// plane_msg.flight_id;
            mFly_Infor_Display[argSys_Id].imu_hangxiangjiao = (double)plane_msg.imu_hangxiangjiao * 0.01;   //  deg
            mFly_Infor_Display[argSys_Id].imu_henggunjiao = (double)plane_msg.imu_henggunjiao * 0.01;     //  deg
            mFly_Infor_Display[argSys_Id].imu_fuyangjiao = (double)plane_msg.imu_fuyangjiao * 0.01;        //  deg

            mFly_Infor_Display[argSys_Id].imu_jisuan_gaodu = (double)plane_msg.imu_jisuan_gaodu * 0.01;    // m
            mFly_Infor_Display[argSys_Id].imu_chuizhisudu = (double)plane_msg.vel_d * 0.01;    // m
            mFly_Infor_Display[argSys_Id].imu_shuipingsudu = (double)plane_msg.gps_speed * 0.1;   // m/s
            mFly_Infor_Display[argSys_Id].imu_kongsu = (double)plane_msg.cur_airspeed * 0.1;            // m/s
            mFly_Infor_Display[argSys_Id].imu_jiesuan_lon = (double)plane_msg.imu_jiesuan_lon / 10000000;         // deg
            mFly_Infor_Display[argSys_Id].imu_jiesuan_lat = (double)plane_msg.imu_jiesuan_lat / 10000000;         // deg
            mFly_Infor_Display[argSys_Id].gps_lon = (double)plane_msg.gps_lon / 10000000;         //deg
            mFly_Infor_Display[argSys_Id].gps_lat = (double)plane_msg.gps_lat / 10000000;         // deg
            mFly_Infor_Display[argSys_Id].gps_alt = (double)plane_msg.gps_alt / 10;         // m
            mFly_Infor_Display[argSys_Id].gps_track_angle = (double)plane_msg.gps_track_angle / 10;         // deg
            mFly_Infor_Display[argSys_Id].gps_speed = (double)plane_msg.gps_speed / 10; ;         // m/s
            mFly_Infor_Display[argSys_Id].gps_num = plane_msg.gps_num;
            mFly_Infor_Display[argSys_Id].gps_pdop = (double)plane_msg.gps_pdop / 10;
            mFly_Infor_Display[argSys_Id].rtk_status = plane_msg.rtk_status;
            mFly_Infor_Display[argSys_Id].noise_kx = (double)plane_msg.noise_kx / 200;  // 0--200
            mFly_Infor_Display[argSys_Id].gps_year = plane_msg.gps_year;
            mFly_Infor_Display[argSys_Id].gps_month = plane_msg.gps_month;
            mFly_Infor_Display[argSys_Id].gps_day = plane_msg.gps_day;
            mFly_Infor_Display[argSys_Id].gps_hour = plane_msg.gps_hour;
            mFly_Infor_Display[argSys_Id].gps_minute = plane_msg.gps_minute;
            mFly_Infor_Display[argSys_Id].gps_second = plane_msg.gps_second;
            mFly_Infor_Display[argSys_Id].gps_mini_second = plane_msg.gps_mini_second;   // 100 ms
            mFly_Infor_Display[argSys_Id].gps_num2 = 0;
            mFly_Infor_Display[argSys_Id].rtk_ant2 = 0;
            mFly_Infor_Display[argSys_Id].dist_to_home = (ushort)plane_msg.dist_to_home;   // m
            mFly_Infor_Display[argSys_Id].warnning_flag = (byte)plane_msg.warnning_flag;
            mFly_Infor_Display[argSys_Id].home_reason = plane_msg.home_reason;
            mFly_Infor_Display[argSys_Id].flied_time = plane_msg.flied_time;  // second
            mFly_Infor_Display[argSys_Id].cross_dist = (double)plane_msg.cross_dist / 10;    // m
            mFly_Infor_Display[argSys_Id].target_wpt_dist = (double)plane_msg.target_wpt_dist / 10;    // m
            mFly_Infor_Display[argSys_Id].target_alt = (double)plane_msg.target_alt / 10;    // m
            mFly_Infor_Display[argSys_Id].total_wpt_dist = 0;    // m
            mFly_Infor_Display[argSys_Id].wpt_flied_dist = 0;    // m
            mFly_Infor_Display[argSys_Id].rest_circle_time = 0;
            mFly_Infor_Display[argSys_Id].radar_alt = 0;    // m     -1----radar unavalable
            mFly_Infor_Display[argSys_Id].radar_front = 0;    // m
            mFly_Infor_Display[argSys_Id].radar_back = 0;    // m
            mFly_Infor_Display[argSys_Id].fly_mode = plane_msg.fly_mode;
            mFly_Infor_Display[argSys_Id].total_wpt_count = plane_msg.total_wpt_count;
            mFly_Infor_Display[argSys_Id].target_wpt_index = plane_msg.target_wpt_index;
            mFly_Infor_Display[argSys_Id].total_pic_count = plane_msg.total_pic_count;
            mFly_Infor_Display[argSys_Id].batter_volt = (double)plane_msg.adc1_volt / 10;    // v
            mFly_Infor_Display[argSys_Id].lock_status = plane_msg.lock_status;
            mFly_Infor_Display[argSys_Id].temperature = plane_msg.temperature;
            mFly_Infor_Display[argSys_Id].total_flied_time = 0;   //minute
            mFly_Infor_Display[argSys_Id].ins_flag = plane_msg.ins_flag;
            mFly_Infor_Display[argSys_Id].motor_balance = 0;
            mFly_Infor_Display[argSys_Id].direction_filter = plane_msg.direction_filter;
            mFly_Infor_Display[argSys_Id].in_forbidden_area_count = plane_msg.in_forbidden_area_count;
            mFly_Infor_Display[argSys_Id].mag_calibrate_status = plane_msg.mag_calibrate_status; // 1---calibrate xy   2---calibrate xz    3---succuss    4---fail
            mFly_Infor_Display[argSys_Id].plane_status = 0; // 1---normal  2---mag calibrate   3---remoter calibrate    4---esc calibrate   5---imu update
            mFly_Infor_Display[argSys_Id].adc1_volt = (double)plane_msg.adc2_volt / 10;
            mFly_Infor_Display[argSys_Id].adc2_volt = (double)plane_msg.reserve_volt / 10;
            mFly_Infor_Display[argSys_Id].base_throttle = 0;
            mFly_Infor_Display[argSys_Id].gps_status = plane_msg.gps_status;
            mFly_Infor_Display[argSys_Id].baro_status = plane_msg.baro_status;
            mFly_Infor_Display[argSys_Id].gyro_acc_status = plane_msg.gyro_acc_status;
            mFly_Infor_Display[argSys_Id].mag_status = plane_msg.mag_status;

            mFly_Infor_Display[argSys_Id].controllerInput1 = plane_msg.controllerInput1;
            mFly_Infor_Display[argSys_Id].controllerInput2 = plane_msg.controllerInput2;
            mFly_Infor_Display[argSys_Id].controllerInput3 = plane_msg.controllerInput3;
            mFly_Infor_Display[argSys_Id].controllerInput4 = plane_msg.controllerInput4;
            mFly_Infor_Display[argSys_Id].controllerInput5 = plane_msg.controllerInput5;
            mFly_Infor_Display[argSys_Id].controllerInput6 = plane_msg.controllerInput6;
            mFly_Infor_Display[argSys_Id].controllerInput7 = plane_msg.controllerInput7;
            mFly_Infor_Display[argSys_Id].controllerInput8 = plane_msg.controllerInput8;

            mFly_Infor_Display[argSys_Id].pwm_out1 = plane_msg.pwm_out1;
            mFly_Infor_Display[argSys_Id].pwm_out2 = plane_msg.pwm_out2;
            mFly_Infor_Display[argSys_Id].pwm_out3 = plane_msg.pwm_out3;
            mFly_Infor_Display[argSys_Id].pwm_out4 = plane_msg.pwm_out4;
            mFly_Infor_Display[argSys_Id].pwm_out5 = plane_msg.pwm_out5;
            mFly_Infor_Display[argSys_Id].pwm_out6 = plane_msg.pwm_out6;
            mFly_Infor_Display[argSys_Id].pwm_out7 = plane_msg.pwm_out7;
            mFly_Infor_Display[argSys_Id].pwm_out8 = plane_msg.pwm_out8;

            mFly_Infor_Display[argSys_Id].pwm_out9 = plane_msg.pwm_out9;
            mFly_Infor_Display[argSys_Id].pwm_out10 = plane_msg.pwm_out10;
            mFly_Infor_Display[argSys_Id].pwm_out11 = plane_msg.pwm_out11;
            mFly_Infor_Display[argSys_Id].pwm_out12 = plane_msg.pwm_out12;
            mFly_Infor_Display[argSys_Id].pwm_out13 = plane_msg.pwm_out13;
            mFly_Infor_Display[argSys_Id].pwm_out14 = plane_msg.pwm_out14;
            mFly_Infor_Display[argSys_Id].pwm_out15 = plane_msg.pwm_out15;
            mFly_Infor_Display[argSys_Id].pwm_out16 = plane_msg.pwm_out16;

            mFly_Infor_Display[argSys_Id].signal_out1 = plane_msg.signal_out1;
            mFly_Infor_Display[argSys_Id].signal_out2 = plane_msg.signal_out2;
            mFly_Infor_Display[argSys_Id].signal_out3 = plane_msg.signal_out3;
            mFly_Infor_Display[argSys_Id].signal_out4 = plane_msg.signal_out4;
            mFly_Infor_Display[argSys_Id].signal_out5 = plane_msg.signal_out5;
            mFly_Infor_Display[argSys_Id].signal_out6 = plane_msg.signal_out6;
            mFly_Infor_Display[argSys_Id].signal_out7 = plane_msg.signal_out7;
            mFly_Infor_Display[argSys_Id].signal_out8 = plane_msg.signal_out8;
            mFly_Infor_Display[argSys_Id].signal_out9 = plane_msg.signal_out9;

            mFly_Infor_Display[argSys_Id].engine_speed = plane_msg.engine_speed;
            mFly_Infor_Display[argSys_Id].bian_gao = plane_msg.bian_gao;
            mFly_Infor_Display[argSys_Id].power_type = plane_msg.power_type;

            mFly_Infor_Display[argSys_Id].target_Airspeed = (double)plane_msg.target_airspeed * 0.1;
        }

        /************************************************************************************
     * 功   能：解析跟随gps数据
     * 参   数：
     * 返   回：
     * *************************************************************************************/
        public static byte mPlane_Id = 0;
        public static UDP_MSG m_udp_msg = new UDP_MSG();
        public static void Construct_Udp_Data(byte plane_id)
        {
            m_udp_msg.start_flag = (ushort)0xAA55;
            m_udp_msg.source_id = 0x40;
            m_udp_msg.plane_id = plane_id;
            m_udp_msg.data_len = 0x1A;

            m_udp_msg.yaw = (short)(mFly_Infor_Display[plane_id].imu_hangxiangjiao * 10);
            m_udp_msg.roll = (short)(mFly_Infor_Display[plane_id].imu_henggunjiao * 10);
            m_udp_msg.pitch = (short)(mFly_Infor_Display[plane_id].imu_fuyangjiao * 10);

            m_udp_msg.plane_lon = (int)(mFly_Infor_Display[plane_id].imu_jiesuan_lon * 1e7);
            m_udp_msg.plane_lat = (int)(mFly_Infor_Display[plane_id].imu_jiesuan_lat * 1e7);

            m_udp_msg.gps_alt = (short)(mFly_Infor_Display[plane_id].gps_alt * 10);
            m_udp_msg.gps_vel = (short)(mFly_Infor_Display[plane_id].imu_shuipingsudu * 10);

            m_udp_msg.gps_year = mFly_Infor_Display[plane_id].gps_year;
            m_udp_msg.gps_month = mFly_Infor_Display[plane_id].gps_month;
            m_udp_msg.gps_day = mFly_Infor_Display[plane_id].gps_day;

            m_udp_msg.gps_hour = mFly_Infor_Display[plane_id].gps_hour;
            m_udp_msg.gps_minute = mFly_Infor_Display[plane_id].gps_minute;
            m_udp_msg.gps_second = mFly_Infor_Display[plane_id].gps_second;
            m_udp_msg.gps_minisecond = mFly_Infor_Display[plane_id].gps_mini_second;

            ushort plane_msg_len = (ushort)Marshal.SizeOf(m_udp_msg);
            byte[] data = new byte[plane_msg_len + 2];

            IntPtr structPtr = Marshal.AllocHGlobal(plane_msg_len);
            //将结构体拷贝到分配好的内存空间
            Marshal.StructureToPtr(m_udp_msg, structPtr, false);
            //从内存空间拷贝到byte数组
            Marshal.Copy(structPtr, data, 0, plane_msg_len);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);

            data[plane_msg_len] = CRC.Get_Crc16(data, 0, (short)plane_msg_len)[0];
            data[plane_msg_len + 1] = CRC.Get_Crc16(data, 0, (short)plane_msg_len)[1];

            DATA_LINK.Send_Udp_Msg(data);
        }

        /**************************************************************************************
        function: decode the information from plane
        para:
        return:
        * *************************************************************************************/
        public static bool Decode_Downlink_Data(byte argSysIdReciev, byte dataType, byte[] buf_revdata, int startPosition)
        {
            byte cur_system_id_set = DATA_LINK.Get_System_Set_Id();
            switch (dataType)
            {
                case MsgDef.MSG_DATA:               // 如果是在下载回放数据
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    mPlay_Data_From_FC.data_id = (int)(BitConverter.ToInt32(buf_revdata, startPosition));
                    mPlay_Data_From_FC.data_length = buf_revdata[startPosition + 4];
                    mPlay_Data_From_FC.data_num_all = (int)(BitConverter.ToInt32(buf_revdata, startPosition + 5));
                    mPlay_Data_From_FC.data_ = new byte[mPlay_Data_From_FC.data_length];

                    Array.Copy(buf_revdata, startPosition + 9, mPlay_Data_From_FC.data_, 0, mPlay_Data_From_FC.data_length);
                    Page_Version_Update.Save_PlayBack_Data();
                    break;

                case MsgDef.MSG_IMU:                // IMU 信息
                    if (App.plane_type == 0)         // 多旋翼
                    {
                        plane_downlink_msg = (PLANE_DOWN_LINK_MSG)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(PLANE_DOWN_LINK_MSG));
                        Decode_MM_Infor(argSysIdReciev, plane_downlink_msg);
                    }
                    else
                    {
                        chuiqi_downlink_msg = (CHUIQI_DOWN_LINK_MSG)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(CHUIQI_DOWN_LINK_MSG));
                        Decode_FW_Infor(argSysIdReciev, chuiqi_downlink_msg);
                    }
                    Construct_Udp_Data(argSysIdReciev);
                    break;

                case MsgDef.MSG_LOG:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    mFly_Log = (FLY_LOG)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(FLY_LOG));
                    Page_Version_Update.Save_Log_Data();
                    break;

                case MsgDef.MSG_PO:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    mPic_Pos = (PIC_POS)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(PIC_POS));
                    mPic_Pos.min_seconds = (UInt16)(mPic_Pos.min_seconds / 100);
                    break;

                case MsgDef.MSG_ACK:
                    if ((argSysIdReciev != cur_system_id_set) && (argSysIdReciev > 0))
                        break;

                    mACKid.ackidnum = buf_revdata[startPosition];
                    mACKid.ackmsg = (short)(BitConverter.ToUInt16(buf_revdata, startPosition + 1));

                    switch ((byte)mACKid.ackidnum)
                    {
                        case (byte)MsgDef.MSG_WP:   // 航点信息

                            short num = mACKid.ackmsg;
                            if (num - Window_Skyway.curWaypointSeq == 1)
                            {
                                Window_Skyway.curWaypointTransferSucceed = true;
                            }
                            break;
                        case MsgDef.MSG_UPDATE_STA:  // 固件更新请求
                            Page_Version_Update.t_updateFirmware.Stop();
                            Page_Version_Update.firmware_pack_index = 1;

                            if (Page_Version_Update.update_component == 1)   // 升级主控
                                DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_DATA, 200);
                            else if (Page_Version_Update.update_component == 2)   // 升级IMU
                                DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_DATA, 201);

                            Page_Version_Update.t_updateFirmware.Start();
                            break;
                        case MsgDef.MSG_UPDATE_DATA: // 固件更新数据包信号
                            if ((ushort)(mACKid.ackmsg + 1) <= Page_Version_Update.firmware_pack_index)
                                break;
                            Page_Version_Update.t_updateFirmware.Stop();
                            Page_Version_Update.firmware_pack_index = (ushort)(mACKid.ackmsg + 1);

                            if (Page_Version_Update.firmware_pack_index <= Page_Version_Update.firmware_total_pack)
                            {
                                if (Page_Version_Update.update_component == 1)   // 升级主控
                                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_DATA, 200);
                                else if (Page_Version_Update.update_component == 2)  // 升级IMU
                                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_DATA, 201);
                                Page_Version_Update.Show_Update_Progress();
                            }
                            else
                            {
                                if (Page_Version_Update.update_component == 1)
                                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_END, 200);
                                else if (Page_Version_Update.update_component == 2)
                                    DATA_LINK.Send_Update_Msg(MsgDef.MSG_UPDATE_END, 201);
                            }
                            Page_Version_Update.t_updateFirmware.Start();
                            break;
                        case MsgDef.MSG_UPDATE_END: // 固件更新完成
                            Page_Version_Update.Update_Finish();
                            break;
                        default:
                            break;
                    }
                    break;

                case MsgDef.MSG_PAR:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    mStruct_Par = (STRUCT_PAR)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(STRUCT_PAR));
                    break;

                case MsgDef.MSG_HOME:
                    break;

                case MsgDef.MSG_APTYPE:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    if (App.plane_type == 0)
                        mPlane_Setting = (PLANE_SETTING)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(PLANE_SETTING));
                    else
                        m_FW_Fly_Settings2 = (FW_SETTING2)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(FW_SETTING2));
                    break;

                case MsgDef.MSG_LPID:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    if (App.plane_type == 0)
                        mPid = (PID_B)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(PID_B));
                    else
                        m_Channel_Config = (FX_CHANNEL_CONFIG)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(FX_CHANNEL_CONFIG));
                    break;

                case MsgDef.MSG_FW_MM_PID:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    if ((App.plane_type == 1) || (App.plane_type == 2))
                        m_FW_MM_Pid = (FW_MM_PID)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(FW_MM_PID));
                    break;

                case MsgDef.MSG_FW_PID:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    if ((App.plane_type == 1) || (App.plane_type == 2))
                        m_FW_Pid = (FW_PID)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(FW_PID));
                    break;

                case MsgDef.MSG_SINGLE_CONFIG:      // 单个参数下传
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    m_Msg_Single_Para.single_msg_id = BitConverter.ToUInt16(buf_revdata, startPosition);
                    m_Msg_Single_Para.msg_value = BitConverter.ToInt16(buf_revdata, startPosition + 2);
                    break;

                case MsgDef.MSG_WP:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    mStruct_Wpt = (STRUCT_WPT)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(STRUCT_WPT));
                    break;

                case MsgDef.MSG_VER:
                    if ((App.single_many_type == 1) && (argSysIdReciev != cur_system_id_set))
                        break;
                    if (App.plane_type == 0)
                        mStruct_Version = (STRUCT_VERSION)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(STRUCT_VERSION));
                    else
                        m_FW_Version = (FW_VERSION)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(FW_VERSION));
                    break;

                case MsgDef.MSG_GPS_BIAS:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    mStruct_Gps_Bias = (STRUCT_GPS_BIAS)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(STRUCT_GPS_BIAS));
                    break;

                case MsgDef.MSG_FORBID_AREA:
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    if (buf_revdata[startPosition] < 1)
                        break;
                    for (byte k = 0; k < buf_revdata[startPosition + 2]; k++)
                    {
                        PointLatLng forbidTemp = new PointLatLng();
                        forbidTemp.Lng = (double)BitConverter.ToInt32(buf_revdata, startPosition + 3 + k * 12) / Compute.E_7;
                        forbidTemp.Lat = (double)BitConverter.ToInt32(buf_revdata, startPosition + 7 + k * 12) / Compute.E_7;
                        Page_2D_Map.Points_Forbid.Add(forbidTemp);
                    }
                    break;

                case MsgDef.PICTURE_TRIGGER_MODE: // 复用固定翼的参数设置
                    if (argSysIdReciev != cur_system_id_set)
                        break;
                    if ((App.plane_type == 1) || (App.plane_type == 2))
                        m_FW_Fly_Settings = (FW_FLY_SETTINGS)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(FW_FLY_SETTINGS));
                    break;
                case MsgDef.MSG_TRANSPARENT:
                    m_YouDian = (YOUDIAN_STRUCT)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(YOUDIAN_STRUCT));
                    break;
                // 解析回放数据
                case MsgDef.MSG_DATABACK:
                    DATA_LINK.Set_System_Id(0);
                    DATA_LINK.syste_id_recev = 0;
                    mMSG_Databack_JD = (MSG_Databack_JD)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(MSG_Databack_JD));

                    mFly_Infor_Display[0].imu_jiesuan_lon = (double)mMSG_Databack_JD.solved_lon / 10000000;
                    mFly_Infor_Display[0].imu_jiesuan_lat = (double)mMSG_Databack_JD.solved_lat / 10000000;

                    mFly_Infor_Display[0].gps_lon = (double)mMSG_Databack_JD.raw_lon / 10000000;
                    mFly_Infor_Display[0].gps_lat = (double)mMSG_Databack_JD.raw_lat / 10000000;
                    mFly_Infor_Display[0].flied_time = (ushort)(mMSG_Databack_JD.flight_time);

                    mFly_Infor_Display[0].imu_henggunjiao = (double)mMSG_Databack_JD.roll * 0.1;
                    mFly_Infor_Display[0].imu_fuyangjiao = (double)mMSG_Databack_JD.pitch * 0.1;
                    mFly_Infor_Display[0].imu_hangxiangjiao = (double)mMSG_Databack_JD.yaw * 0.1;

                    mFly_Infor_Display[0].imu_jisuan_gaodu = (double)mMSG_Databack_JD.solved_alt * 0.1;
                    mFly_Infor_Display[0].imu_chuizhisudu = (double)(mMSG_Databack_JD.climb_rate * 0.01);

                    mFly_Infor_Display[0].total_wpt_count = (ushort)mMSG_Databack_JD.total_wp_number;
                    mFly_Infor_Display[0].target_wpt_index = (ushort)mMSG_Databack_JD.target_wp_number;

                    mFly_Infor_Display[0].total_pic_count = (ushort)(mMSG_Databack_JD.picture_number);
                    mFly_Infor_Display[0].batter_volt = (double)(mMSG_Databack_JD.voltage_value) * 0.1;

                    mFly_Infor_Display[0].dist_to_home = (ushort)mMSG_Databack_JD.dist_2_home;
                    mFly_Infor_Display[0].target_wpt_dist = (double)(mMSG_Databack_JD.dist_2_target);

                    mFly_Infor_Display[0].gps_alt = (double)(mMSG_Databack_JD.gps_alt) * 0.1;
                    mFly_Infor_Display[0].gps_track_angle = (double)(mMSG_Databack_JD.gps_yaw);
                    mFly_Infor_Display[0].gps_speed = (double)(mMSG_Databack_JD.gps_speed) * 0.01;
                    mFly_Infor_Display[0].gps_num = mMSG_Databack_JD.gps_num;
                    mFly_Infor_Display[0].imu_shuipingsudu = (double)(mMSG_Databack_JD.gps_speed * 0.01);

                    mFly_Infor_Display[0].controllerInput1 = (byte)mMSG_Databack_JD.pwmin1;
                    mFly_Infor_Display[0].controllerInput2 = (byte)mMSG_Databack_JD.pwmin2;
                    mFly_Infor_Display[0].controllerInput3 = (byte)mMSG_Databack_JD.pwmin3;
                    mFly_Infor_Display[0].controllerInput4 = (byte)mMSG_Databack_JD.pwmin4;
                    mFly_Infor_Display[0].controllerInput5 = (byte)mMSG_Databack_JD.pwmin5;
                    mFly_Infor_Display[0].controllerInput6 = (byte)mMSG_Databack_JD.pwmin6;
                    mFly_Infor_Display[0].controllerInput7 = (byte)mMSG_Databack_JD.pwmin7;
                    mFly_Infor_Display[0].controllerInput8 = (byte)mMSG_Databack_JD.pwmin8;

                    mFly_Infor_Display[0].pwm_out1 = (byte)mMSG_Databack_JD.pwmout1;
                    mFly_Infor_Display[0].pwm_out2 = (byte)mMSG_Databack_JD.pwmout2;
                    mFly_Infor_Display[0].pwm_out3 = (byte)mMSG_Databack_JD.pwmout3;
                    mFly_Infor_Display[0].pwm_out4 = (byte)mMSG_Databack_JD.pwmout4;
                    mFly_Infor_Display[0].pwm_out5 = (byte)mMSG_Databack_JD.pwmout5;
                    mFly_Infor_Display[0].pwm_out6 = (byte)mMSG_Databack_JD.pwmout6;
                    mFly_Infor_Display[0].pwm_out7 = (byte)mMSG_Databack_JD.pwmout7;
                    mFly_Infor_Display[0].pwm_out8 = (byte)mMSG_Databack_JD.pwmout8;

                    mFly_Infor_Display[0].rtk_status = mMSG_Databack_JD.rtk_flag;
                    mFly_Infor_Display[0].home_reason = mMSG_Databack_JD.rth_reason_flag;
                    mFly_Infor_Display[0].ins_flag = mMSG_Databack_JD.ins_flag;

                    mFly_Infor_Display[0].warnning_flag = mMSG_Databack_JD.warn_flag;

                    mFly_Infor_Display[0].gps_status = mMSG_Databack_JD.gps_status_flag;
                    mFly_Infor_Display[0].baro_status = mMSG_Databack_JD.barometer_status_flag;
                    mFly_Infor_Display[0].gyro_acc_status = mMSG_Databack_JD.acc_gyro_status_flag;
                    mFly_Infor_Display[0].mag_status = mMSG_Databack_JD.mag_status_flag;

                    mFly_Infor_Display[0].fly_mode = mMSG_Databack_JD.flight_mode;
                    break;
                default:
                    break;
            }
            return true;
        }

        /****************************************************************************************
      * 功   能：解析跟随gps数据
      * 参   数：
      * 返   回：
      * *************************************************************************************/
        public static byte follow_gps_type = 0;
        public static BASE_INFOR m_base_infor = new BASE_INFOR();
        public static bool Decode_Gps(byte dataType, byte[] buf_revdata, int startPosition)
        {
            switch (dataType)
            {
                case 1:               // ground  gps from m8n module
                    follow_gps_type = 0;
                    m_FollowGps.nLon_Follow = BitConverter.ToInt32(buf_revdata, startPosition);
                    m_FollowGps.nLat_Follow = BitConverter.ToInt32(buf_revdata, startPosition + 4);
                    m_FollowGps.nGps_E_Follow = BitConverter.ToInt32(buf_revdata, startPosition + 8);
                    m_FollowGps.nGps_N_Follow = BitConverter.ToInt32(buf_revdata, startPosition + 12);
                    m_FollowGps.nGps_D_Follow = BitConverter.ToInt32(buf_revdata, startPosition + 16);
                    m_FollowGps.nAlt_Follow = BitConverter.ToInt32(buf_revdata, startPosition + 22);
                    m_FollowGps.nGroundSpeed_Follow = BitConverter.ToInt32(buf_revdata, startPosition + 26);
                    m_FollowGps.StaNum = buf_revdata[startPosition + 30];
                    m_FollowGps.nHeading = 0;
                    m_FollowGps.pos_status = 0;
                    m_FollowGps.heading_status = 0;
                    DATA_LINK.Send_Gps_Gnd_Msg();
                    break;
                case 46:   // ground gps from rtk base station
                    follow_gps_type = 1;
                    m_FollowGps.nLon_Follow = BitConverter.ToInt32(buf_revdata, startPosition);
                    m_FollowGps.nLat_Follow = BitConverter.ToInt32(buf_revdata, startPosition + 4);
                    m_FollowGps.nAlt_Follow = BitConverter.ToInt32(buf_revdata, startPosition + 8);

                    m_FollowGps.StaNum = buf_revdata[startPosition + 12];
                    m_FollowGps.pos_status = buf_revdata[startPosition + 13];
                    m_FollowGps.heading_status = buf_revdata[startPosition + 14];
                    m_FollowGps.base_mode = buf_revdata[startPosition + 15];
                    m_FollowGps.StaNum_ant2 = buf_revdata[startPosition + 16];

                    m_FollowGps.nGps_E_Follow = BitConverter.ToInt16(buf_revdata, startPosition + 17) * 10;
                    m_FollowGps.nGps_N_Follow = BitConverter.ToInt16(buf_revdata, startPosition + 19) * 10;
                    m_FollowGps.nGps_D_Follow = BitConverter.ToInt16(buf_revdata, startPosition + 21) * 10;
                    m_FollowGps.nHeading = (short)Compute.wrap_3600(BitConverter.ToInt16(buf_revdata, startPosition + 23) - 900);
                    break;
                case 35:
                    m_base_infor = (BASE_INFOR)Compute.ByteToStruct(buf_revdata, (UInt16)startPosition, typeof(BASE_INFOR));
                    break;
                default:
                    break;
            }
            return true;
        }
    }
}
