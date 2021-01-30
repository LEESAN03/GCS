using GMap.NET;
using GMap.NET.WindowsForms;
using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace VIKGroundStation
{
    struct MsgDef
    {
        public const byte MSG_HEART = 0x01;                  //  握手信息
        public const byte MSG_IMU = 0x03;                    //  IMU信息
        public const byte MSG_GPS = 0x04;                    //  gps信息
        public const byte MSG_FLY = 0x05;                    //  飞行信息
        public const byte MSG_STATUS = 0x06;                 //  状态信息
        public const byte MSG_PWM = 0x07;                    //  PWM信息
        public const byte MSG_SENSOR = 0x08;                    //  PWM信息
        public const byte MSG_HOME = (byte)10;               //  设置返航点
        public const byte MSG_PO = (byte)11;                 //  POS基础参数信息
        public const byte MSG_RETURN_CIRCLE_PT = (byte)12;                 //  返航盘旋点
        public const byte MSG_REQ = (byte)20;                //  数据请求命令
        public const byte MSG_ACK = (byte)21;                // 数据反馈
        public const byte MSG_CTL = (byte)22;                //  控制命令
        public const byte MSG_CAL = (byte)23;                //  校准命令
        public const byte MSG_SINGLE_CONFIG = (byte)24;         //  参数单独设置
        public const byte MSG_APTYPE = (byte)30;             //  机型参数消息
        public const byte MSG_LPID = (byte)31;               //  基础PID消息
        public const byte MSG_FW_MM_PID = (byte)32;               //  高级PID消息   // 复用垂起旋翼PID
        public const byte MSG_PAR = (byte)33;                //  设置高级参数消息
        public const byte MSG_VER = (byte)35;                //  读取飞行日P
        public const byte MSG_LOG = (byte)36;
        public const byte MSG_FW_PID = (byte)39;
        public const byte PICTURE_TRIGGER_MODE = (byte)38;          //拍照模式，复用固定翼设置
        public const byte MSG_WP = (byte)40;                 //  航点信息
        public const byte MSG_ROCK = 41;                 // rock msg
        public const byte MSG_GIMBAL = (byte)42;                //sbus协议
        public const byte MSG_GPS_GND = (byte)43;                // gps position from ground
        public const byte MSG_FLY_POINT = (byte)44;                 //  指点飞行
        public const byte MSG_GPS_BIAS = (byte)45;              //  GPS安装偏差
        public const byte MSG_HEAD_FOCUS = (byte)46;       //  机头聚焦
        public const byte MSG_HOVER_SHIFT = (byte)47;      //  悬停微调
        public const byte MSG_FORBID_AREA = (byte)48;      // 禁飞区
        public const byte MSG_DATA = (byte)150;
        public const byte MSG_TRANSPARENT = (byte)201;
        public const byte MSG_DATABACK = (byte)255;

        public const byte MSG_UPDATE_STA = (byte)200;      //开始升级
        public const byte MSG_UPDATE_DATA = (byte)201;     //正在升级
        public const byte MSG_UPDATE_END = (byte)202;      //升级结束
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct Ctrl_ID
    {
        public const byte Ctrl_Unlock = 0x01;                         //  解锁
        public const byte Ctrl_Auto_TakeOff = 0x02;            //  起飞
        public const byte Ctrl_Point = 0x03;                        //  去一点
        public const byte Ctrl_Xufei = 0x04;                        //  飞断点
        public const byte Ctrl_XunHang = 0x05;                      //  巡航
        public const byte Ctrl_ZanTing = 0x06;                      //  旋翼暂停       复用固定翼盘旋
        public const byte Ctrl_JiXu = (byte)0x07;                   //  继续
        public const byte Ctrl_FanHang = (byte)0x08;                // 返航
        public const byte Ctrl_JiangLuo = (byte)9;                  //  降落
        public const byte Ctrl_BianGao = (byte)10;                  //  一键变高
        public const byte Ctrl_BianDian = (byte)11;                  //  一键变航点
        public const byte Ctrl_Airspeed_Clear = (byte)12;        //  空速清零
        public const byte Ctrl_Open_RC = (byte)15;            //  开接收机
        public const byte Ctrl_Close_RC = (byte)16;           //  关接收机
        public const byte Ctrl_Stop = (byte)17;                   //  灭车
        public const byte Ctrl_FuFei = (byte)18;                   //  复飞
        public const byte Ctrl_Ground_Spd_Control = (byte)19;          //  切换地速控制
        public const byte Ctrl_AirSpeed_Control = (byte)20;          // 恢复空速控制
        public const byte Ctrl_Open_Throttle = (byte)21;          //启动油门量
        public const byte Ctrl_Change_Spd = (byte)22;          //变速
        public const byte Ctrl_Cancel_Spd = (byte)23;          //取消变速变高
        public const byte Ctrl_Enable_Fufei = (byte)24;          //使能/取消复飞
        public const byte Ctrl_Take_Photo = (byte)30;                 //  take photo
        public const byte Ctrl_FLyTimes = (byte)50;                  // 航线循环次数
        public const byte Ctrl_Open_Parachute = (byte)58;                 //  控制命令
        public const byte Ctrl_TakeOff_Follow = (byte)60;                 //  take off with movement
        public const byte Ctrl_Fly_Follow = (byte)61;                         //  fly following gps
        public const byte Ctrl_Landing_Follow = (byte)62;                 //  landing with movement
        public const byte Ctrl_Enter_Attack_Mode = (byte)70;                 //  enter attack mode
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct MSG_CAL_ID
    {
        public const byte CAL_Attuide = 0x01;
        public const byte CAL_MAG = 0x02;
        public const byte CAL_RC_ON = 0x03;
        public const byte CAL_RC_OFF = 0x04;
        public const byte CAL_OUT = 0x05;   // 复用固定翼的多机反向
        public const byte CAL_ANZHUANG = 0x06;

        public const byte CAL_UP = 11;      //舵面上偏 / 左偏 / 大油门
        public const byte CAL_Down = 12;    //舵面下偏 / 右偏 / 小油门
        public const byte CAL_Mid = 13;    //检测中位
        public const byte CAL_Filter = 15;    //filter level
    }

    struct CHUIQI_CHANNEL
    {
        /* 左副翼 */
        public const byte AP_LEFT_AILERON_CH = 1;
        /* 左升降 */
        public const byte AP_LEFT_ELEVATOR_CH = 2;
        /* 油门 */
        public const byte AP_THROTTLE_CH = 3;
        /* 方向舵 */
        public const byte AP_LEFT_RUDDER_CH = 4;
        /* 右副翼 */
        public const byte AP_RIGHT_AILERON_CH = 5;
        /* 伞 */
        public const byte AP_PARACHUTE_CH = 6;
        /* 右升降 */
        public const byte AP_RIGHT_ELEVATOR_CH = 7;
        /* 襟翼 */
        public const byte AP_FLAP_CH = 8;
        /* 右襟翼 */
        public const byte AP_RIGHT_FLAP_CH = 9;
        /* 前轮通道 */
        public const byte AP_FRONT_WHEEL_CH = 10;
    }

    public class WAY_POINT
    {
        public short NumberId { get; set; }           //编号
        public double lon { get; set; }              //经度
        public double lat { get; set; }             //纬度
        public double speed { get; set; }            //速度
        public double alt { get; set; }                //高度
        public string str_turn_mode { get; set; }        //转弯模式，字符串表达
        public byte byte_turn_mode { get; set; }       //转弯模式，数字表达
        public short turn_time { get; set; }        //转弯时间
        public string str_renwu { get; set; }           //飞行任务， 字符串表达
        public byte byte_renwunum { get; set; }         //飞行任务，数字表达
        public short pic_interval { get; set; }      //任务间隔；拍照间隔，0
        public double alt_level { get; set; }       //海拔高度
        public double lon_X { get; set; }           //经度
        public double lat_Y { get; set; }           //纬度         
        public bool drag_enable { get; set; }       // 是否拖拽
        public short wpt_heading { get; set; }    // 航点的
        public byte wpt_alt_type { get; set; }
    }

    public class SKY_WAY
    {
        public byte sky_way_no { get; set; }
        public List<WAY_POINT> wayPointSet = new List<WAY_POINT>();
        public List<PointLatLngAlt> wptListOnMap = new List<PointLatLngAlt>();
        public GMapRoute route_wptLine = new GMapRoute("wp route");
        public GMapOverlay Wpt_Layer = new GMapOverlay();
    }

    public class PLANE_STRUCT
    {
        public byte plane_id { get; set; }
        public int plane_data_count;
        public bool plane_exist;
        public GMapOverlay Plane_Layer;
        public PointLatLng point_last;
        public float alt_last;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    // 相机参数结构体
    public struct CAMERA_PARA
    {
        public string nameId;       // 相机名称

        public uint Pang_CCD_Num;  // 旁向像元数
        public uint Hang_CCD_Num;  // 航向像元数

        public float Xiang_Yuan_Size; // 像元大小
        public float Jiao_Ju;         // 焦距

        public byte Pic_Mode;    // 拍照方式
        public short Trigger_Time;  // 拍照时间
        public short Pwm_On;        // 拍照pwm
        public short Pwm_Off;       // 停拍pwm
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    // 云台参数结构体
    public struct USB_HID
    {
        public string nameId;       // 云台名称

        public string ch1_name;
        public string ch2_name;
        public string ch3_name;
        public string ch4_name;
        public string ch5_name;
        public string ch6_name;
        public string ch7_name;
        public string ch8_name;
        public string ch9_name;
        public string ch10_name;
        public string ch11_name;
        public string ch12_name;

        public byte ch1_mapping;
        public byte ch2_mapping;
        public byte ch3_mapping;
        public byte ch4_mapping;
        public byte ch5_mapping;
        public byte ch6_mapping;
        public byte ch7_mapping;
        public byte ch8_mapping;
        public byte ch9_mapping;
        public byte ch10_mapping;
        public byte ch11_mapping;
        public byte ch12_mapping;

        public byte ch1_reverse;
        public byte ch2_reverse;
        public byte ch3_reverse;
        public byte ch4_reverse;
        public byte ch5_reverse;
        public byte ch6_reverse;
        public byte ch7_reverse;
        public byte ch8_reverse;
        public byte ch9_reverse;
        public byte ch10_reverse;
        public byte ch11_reverse;
        public byte ch12_reverse;

        public string rtsp_addr;
    }

    // 边界结构体
    public class BOUND_PT
    {
        public double lon { get; set; }
        public double lat { get; set; }
        public double alt { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct AN_Zhuang
    {
        public const short Cout_qian = 1;
        public const short Cout_hou = 3;
        public const short Cout_zuo = 4;
        public const short Cout_you = 2;
    }

    public struct MSG_SINGLE_PARA
    {
        public ushort single_msg_id;
        public short msg_value;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SINGLE_MSG_DEFINE
    {
        public const byte Single_Msg_Jixing = 0;
        public const byte Single_Msg_Link_Lost = 1;
        public const byte Single_Msg_Low_Volt_Action = 2;
        public const byte Single_Msg_Low_Volt = 3;
        public const byte Single_Msg_Circle_Radius = 4;
        public const byte Single_Msg_Home_Alt = 5;
        public const byte Single_Msg_Take_Off_Alt = 6;
        public const byte Single_Msg_Mag_Bias = 7;
        public const byte Single_Msg_Radar_Kx = 8;
        public const byte Single_Msg_Filter_Level = 9;
        public const byte Single_Msg_Fix_Direction = 10;
        public const byte Single_Msg_Dai_Su = 11;
        public const byte Single_Msg_Gps_xBias = 12;
        public const byte Single_Msg_Gps_yBias = 13;
        public const byte Single_Msg_Gps_zBias = 14;
        public const byte Single_Msg_MC_COM_Config = 15;
        public const byte Single_Msg_Gps_Heading = 16;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MSG_Databack_JD
    {
        public int solved_lon;                  //解算经度，cm
        public int solved_lat;                  //解算纬度，cm
        public int target_lon;                  //目标经度，cm
        public int target_lat;                  //目标纬度，cm
        public int raw_lon;                     //原始经度，cm
        public int raw_lat;                     //原始纬度，cm
        public float flight_time;                 //已飞时间，s
        public short roll;                      //横滚角 0.1deg
        public short pitch;                     //俯仰角 0.1deg
        public short yaw;                       //航向角 0.1deg
        public short target_roll;               //目标横滚 0.1deg
        public short target_pitch;              //目标俯仰 0.1deg
        public short target_yaw;                //目标航向 0.1deg
        public short x_gyro;                    //X陀螺 0.1deg/s
        public short y_gyro;                    //Y陀螺 0.1deg/s
        public short z_gyro;                    //Z陀螺 0.1deg/s
        public short x_acc;                     //X加速度 cm/s^2
        public short y_acc;                     //Y加速度 cm/s^2
        public short z_acc;                     //Z加速度 cm/s^2
        public short x_raw_gyro1;               // deg/s
        public short y_raw_gyro1;               // deg/s
        public short z_raw_gyro1;               // deg/s
        public short x_raw_gyro2;               // deg/s
        public short y_raw_gyro2;               // deg/s
        public short z_raw_gyro2;               // deg/s
        public short x_raw_acc1;                // cm/s^2
        public short y_raw_acc1;                // cm/s^2
        public short z_raw_acc1;                // cm/s^2
        public short x_raw_acc2;                // cm/s^2
        public short y_raw_acc2;                // cm/s^2
        public short z_raw_acc2;                // cm/s^2
        public short x_raw_mag1;                // 0.1mGause
        public short y_raw_mag1;                // 0.1mGause
        public short z_raw_mag1;                // 0.1mGause
        public short x_raw_mag2;                // 0.1mGause
        public short y_raw_mag2;                // 0.1mGause
        public short z_raw_mag2;                // 0.1mGause
        public short air_speed;                 //空速 0.1m/s
        public short solved_alt;                //解算当前高度 0.1m
        public short target_alt;                //目标高度 0.1m
        public short raw_lidar_alt;             //原始雷达高度 0.1m
        public short lidar_alt;                 //雷达高度 0.1m
        public short target_lidar_alt;          //目标雷达高度 0.1m
        public byte lidar_comp_state;          //雷达连接状态
        public short climb_rate;                //垂直速度 cm/s
        public short target_climb_rate;         //目标垂直速度 cm/s
        public short east_solved_speed;         //东西速度 cm/s
        public short north_solved_speed;        //南北速度 cm/s
        public short target_east_solved_speed;  //目标东西速度 cm/s
        public short target_north_solved_speed; //目标南北速度 cm/s
        public short total_wp_number;           //总航点数
        public short target_wp_number;          //目标航点
        public short picture_number;            //拍照数
        public short voltage_value;             //电压 0.1v
        public short dist_2_home;               //离家距离 m
        public short dist_2_target;             //目标距离 m
        public short dist_off_track;            //偏航距离 dm
        public short gps_alt;                   //GPS高度 dm
        public short gps_yaw;                   //GPS航向 deg
        public short gps_speed;                 //GPS速度 cm/s
        public byte gps_num;                    //GPS星数
        public byte gps_pdop;                   //GPSPDOP
        public sbyte pwmin1;                    //输入CH1
        public sbyte pwmin2;
        public sbyte pwmin3;
        public sbyte pwmin4;
        public sbyte pwmin5;
        public sbyte pwmin6;
        public sbyte pwmin7;
        public sbyte pwmin8;
        public sbyte pwmout1;           //输出CH1
        public sbyte pwmout2;
        public sbyte pwmout3;
        public sbyte pwmout4;
        public sbyte pwmout5;
        public sbyte pwmout6;
        public sbyte pwmout7;
        public sbyte pwmout8;
        public byte temperature;              //温度 度
        public byte rtk_flag;                 //rtk 标志位
        public byte ins_flag;                 //解算标志位
        public byte lock_flag;                //锁标志
        public byte pos_hold_flag;            //定点状态
        public byte alt_hold_flag;            //定高状态
        public byte lock_reason_flag;         //上锁原因
        public byte rth_reason_flag;          //返航原因
        public byte loiter_reason_flag;       //悬停原因
        public byte warn_flag;                //报警标志位
        public byte gps_status_flag;          //gps状态
        public byte barometer_status_flag;    //气压计状态
        public byte acc_gyro_status_flag;     //陀螺加计状态
        public byte mag_status_flag;          //磁状态
        public byte flight_mode;              //飞行模式
        public short pos_x_offset;            //纠偏 x
        public short pos_y_offset;            //纠偏 y
        public byte waterpump_state;          //水泵状态
        public short waterpump_value;         //水泵值
        public byte radar_quality;            //雷达质量
        public sbyte rec_stx;                 //计数累计
        public short data_rec_time;           //数据记录时间
        public short pid_r;                   //横滚pidout
        public short pid_p;                   //俯仰pidout
        public short pid_y;                   //航向pidout
        public short pid_t;                   //油门pidout
        public short x_gyro_t;                //俯仰目标角速度
        public short y_gyro_t;                //横滚目标角速度
        public short z_gyro_t;                //航向目标角速度
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PLANE_DOWN_LINK_MSG
    {
        public int flight_id;
        public short imu_hangxiangjiao;   // 0.1 deg
        public short imu_henggunjiao;     // 0.1 deg
        public short imu_fuyangjiao;        // 0.1 deg
        public int imu_jisuan_gaodu;    // dm
        public short imu_chuizhisudu;    // dm
        public short imu_shuipingsudu;   // dm
        public short imu_kongsu;            // m/s
        public int imu_jiesuan_lon;         // 1e-7 deg
        public int imu_jiesuan_lat;         // 1e-7 deg
        public int gps_lon;         // 1e-7 deg
        public int gps_lat;         // 1e-7 deg
        public int gps_alt;         // dm
        public short gps_track_angle;         // 0.1 deg
        public short gps_speed;         // 0.1 m/s
        public byte gps_num;
        public byte gps_pdop;           // 0.1m
        public byte rtk_status;
        public byte noise_kx;  // 0--200
        public short gps_year;
        public byte gps_month;
        public byte gps_day;
        public byte gps_hour;
        public byte gps_minute;
        public byte gps_second;
        public byte gps_mini_second;   // 100 ms
        public byte gps_num2;
        public byte rtk_ant2;
        public ushort dist_to_home;   // m
        public byte warnning_flag;
        public byte home_reason;
        public ushort flied_time;  // second
        public short cross_dist;    // dm
        public short target_wpt_dist;    // dm
        public short target_alt;    // dm
        public UInt32 total_wpt_dist;    // m
        public UInt32 wpt_flied_dist;    // m
        public ushort rest_circle_time;
        public short radar_alt;    // cm     -1----radar unavalable
        public short radar_front;    // cm
        public short radar_back;    // cm
        public byte fly_mode;
        public ushort total_wpt_count;
        public ushort target_wpt_index;
        public ushort total_pic_count;
        public ushort batter_volt;    //0.1 v
        public byte lock_status;
        public sbyte temperature;
        public UInt32 total_flied_time;   //minute
        public byte ins_flag;
        public byte motor_balance;
        public byte direction_filter;
        public byte in_forbidden_area_count;
        public byte mag_calibrate_status;   // 1---calibrate xy   2---calibrate xz    3---succuss    4---fail
        public byte plane_status;                   // 1---normal  2---mag calibrate   3---remoter calibrate    4---esc calibrate   5---imu update
        public short adc1_volt;
        public short adc2_volt;
        public byte controllerInput1;
        public byte controllerInput2;
        public byte controllerInput3;
        public byte controllerInput4;
        public byte controllerInput5;
        public byte controllerInput6;
        public byte controllerInput7;
        public byte controllerInput8;
        public byte ElectricMachineOutput1;
        public byte ElectricMachineOutput2;
        public byte ElectricMachineOutput3;
        public byte ElectricMachineOutput4;
        public byte ElectricMachineOutput5;
        public byte ElectricMachineOutput6;
        public byte ElectricMachineOutput7;
        public byte ElectricMachineOutput8;
        public ushort base_throttle;
        public byte gps_status;
        public byte baro_status;
        public byte gyro_acc_status;
        public byte mag_status;
        public short allign_ew_dist;
        public short allign_ns_dist;
        public short allign_up_dist;
        public int base_lon;    // 1e-7
        public int base_lat;     // 1e-7
        public int base_gps_alt;   // cm
        public short base_ew_vel;   // cm/s
        public short base_ns_vel;   // cm/s
        public short base_up_vel;   // cm/s
        public short base_heading;   // -180 --180 deg
        public byte base_ant1_num;
        public byte base_heading_type;   // 1-- available   0-- unavailable
        public byte base_ant2_num;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CHUIQI_DOWN_LINK_MSG
    {
        public short imu_hangxiangjiao;   // 0.01 deg    -180---180
        public short imu_henggunjiao;     // 0.01 deg     -180---180
        public short imu_fuyangjiao;        // 0.01 deg     -180---180

        public short x_gyro;        // 0.02 deg/s
        public short y_gyro;       // 0.02 deg/s
        public short z_gyro;       // 0.02 deg/s

        public short vel_e;        // cm/s
        public short vel_n;       // cm/s
        public short vel_d;       // cm/s

        public short x_acc;        // cm/s^2
        public short y_acc;       // cm/s^2
        public short z_acc;       // cm/s^2

        public int imu_jiesuan_lon;         // 1e-7 deg
        public int imu_jiesuan_lat;         // 1e-7 deg
        public int imu_jisuan_gaodu;    // cm

        public short target_pitch;   // 0.01 deg    -180---180
        public short target_roll;     // 0.01 deg     -180---180
        public short target_course;        // 0.01 deg     -180---180

        public int target_alt;    //  cm
        public short target_airspeed;   // dm/s

        public int gps_lon;         // 1e-7 deg
        public int gps_lat;         // 1e-7 deg
        public short gps_track_angle;         // 0.1 deg   0---360

        public short gps_alt;         // dm
        public short gps_speed;         // 0.1 m/s
        public byte gps_num;
        public byte gps_pdop;           //0.1

        public short gps_year;
        public byte gps_month;
        public byte gps_day;
        public byte gps_hour;
        public byte gps_minute;
        public byte gps_second;
        public byte gps_mini_second;   // 100 ms

        public byte gps_status;
        public byte baro_status;
        public byte gyro_acc_status;
        public byte mag_status;

        public byte noise_kx;  // 0--200
        public sbyte temperature;
        public byte ins_flag;
        public byte mag_calibrate_status;   // 1---calibrate xy   2---calibrate xz    3---succuss    4---fail
        public byte rtk_status;
        public byte direction_filter;

        public short cur_airspeed;  // dm/s
        public int dist_to_home;    //m
        public int warnning_flag;
        public byte home_reason;

        public int flied_time;  //s
        public short cross_dist;    // dm
        public int target_wpt_dist;    // m
        public byte fly_mode;

        public ushort total_wpt_count;
        public ushort target_wpt_index;
        public ushort total_pic_count;

        public short adc1_volt;
        public short adc2_volt;
        public short reserve_volt;

        public byte lock_status;
        public byte reserved1;
        public byte in_forbidden_area_count;

        public byte controllerInput1;
        public byte controllerInput2;
        public byte controllerInput3;
        public byte controllerInput4;
        public byte controllerInput5;
        public byte controllerInput6;
        public byte controllerInput7;
        public byte controllerInput8;

        public byte pwm_out1;       // 左副翼
        public byte pwm_out2;       // 升降
        public byte pwm_out3;       // 油门
        public byte pwm_out4;       // 方向
        public byte pwm_out5;       // 右副翼
        public byte pwm_out6;       //预留
        public byte pwm_out7;       // 预留
        public byte pwm_out8;       // 预留
        public byte pwm_out9;       // 旋翼电机1
        public byte pwm_out10;       // 旋翼电机2
        public byte pwm_out11;       // 旋翼电机3
        public byte pwm_out12;       // 旋翼电机4
        public byte pwm_out13;       // 预留
        public byte pwm_out14;       // 预留
        public byte pwm_out15;       // 预留
        public byte pwm_out16;       // 预留

        public byte signal_out1;        // 副翼控制信号
        public byte signal_out2;        // 升降控制信号
        public byte signal_out3;        // 油门控制信号
        public byte signal_out4;        // 方向控制信号
        public byte signal_out5;        // 旋翼横滚控制信号
        public byte signal_out6;        // 旋翼俯仰控制信号
        public byte signal_out7;        // 旋翼油门控制信号
        public byte signal_out8;        // 旋翼航向控制信号
        public byte signal_out9;

        public ushort engine_speed;
        public byte bian_gao;
        public byte power_type; // 0--旋翼   1--混合    2--固定翼
    }

    // 这个结构体是旋翼和固定翼综合的一个用来显示的结构体，这个结构体
    // 存在的意义仅仅是为了程序设计可以兼容旋翼和固定翼两种数据格式
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FLY_INFOR_DISPLAY
    {
        public int flight_id;
        public double imu_hangxiangjiao;   //  deg
        public double imu_henggunjiao;     //  deg
        public double imu_fuyangjiao;        //  deg

        public double imu_jisuan_gaodu;    // m
        public double imu_chuizhisudu;    // m
        public double imu_shuipingsudu;   // m/s
        public double imu_kongsu;            // m/s
        public double imu_jiesuan_lon;         // deg
        public double imu_jiesuan_lat;         // deg
        public double gps_lon;         //deg
        public double gps_lat;         // deg
        public double gps_alt;         // m
        public double gps_track_angle;         // deg
        public double gps_speed;         // m/s
        public byte gps_num;
        public double gps_pdop;
        public byte rtk_status;
        public double noise_kx;  // 0--200
        public short gps_year;
        public byte gps_month;
        public byte gps_day;
        public byte gps_hour;
        public byte gps_minute;
        public byte gps_second;
        public byte gps_mini_second;   // 100 ms
        public byte gps_num2;
        public byte rtk_ant2;
        public ushort dist_to_home;   // m
        public int warnning_flag;
        public byte home_reason;
        public int flied_time;  // second
        public double cross_dist;    // m
        public double target_wpt_dist;    // m
        public double target_alt;    // m
        public UInt32 total_wpt_dist;    // m
        public UInt32 wpt_flied_dist;    // m
        public ushort rest_circle_time;
        public double radar_alt;    // m     -1----radar unavalable
        public double radar_front;    // m
        public double radar_back;    // m
        public byte fly_mode;
        public ushort total_wpt_count;
        public ushort target_wpt_index;
        public ushort total_pic_count;
        public double batter_volt;    // v
        public byte lock_status;
        public sbyte temperature;
        public UInt32 total_flied_time;   //minute
        public byte ins_flag;
        public byte motor_balance;
        public byte direction_filter;
        public byte in_forbidden_area_count;
        public byte mag_calibrate_status;   // 1---calibrate xy   2---calibrate xz    3---succuss    4---fail
        public byte plane_status;                   // 1---normal  2---mag calibrate   3---remoter calibrate    4---esc calibrate   5---imu update
        public double adc1_volt;
        public double adc2_volt;

        public ushort base_throttle;
        public byte gps_status;
        public byte baro_status;
        public byte gyro_acc_status;
        public byte mag_status;

        public byte controllerInput1;
        public byte controllerInput2;
        public byte controllerInput3;
        public byte controllerInput4;
        public byte controllerInput5;
        public byte controllerInput6;
        public byte controllerInput7;
        public byte controllerInput8;

        public byte pwm_out1;       // 左副翼
        public byte pwm_out2;       // 升降
        public byte pwm_out3;       // 油门
        public byte pwm_out4;       // 方向
        public byte pwm_out5;       // 右副翼
        public byte pwm_out6;       //预留
        public byte pwm_out7;       // 预留
        public byte pwm_out8;       // 预留
        public byte pwm_out9;       // 旋翼电机1
        public byte pwm_out10;       // 旋翼电机2
        public byte pwm_out11;       // 旋翼电机3
        public byte pwm_out12;       // 旋翼电机4
        public byte pwm_out13;       // 预留
        public byte pwm_out14;       // 预留
        public byte pwm_out15;       // 预留
        public byte pwm_out16;       // 预留

        public byte signal_out1;        // 副翼控制信号
        public byte signal_out2;        // 升降控制信号
        public byte signal_out3;        // 油门控制信号
        public byte signal_out4;        // 方向控制信号
        public byte signal_out5;        // 旋翼横滚控制信号
        public byte signal_out6;        // 旋翼俯仰控制信号
        public byte signal_out7;        // 旋翼油门控制信号
        public byte signal_out8;        // 旋翼航向控制信号
        public byte signal_out9;

        public ushort engine_speed;
        public byte bian_gao;
        public byte power_type; // 0--旋翼   1--混合    2--固定翼

        public double target_Airspeed;

        public short allign_ew_dist;
        public short allign_ns_dist;
        public short allign_up_dist;

        public int base_lon;    // 1e-7
        public int base_lat;     // 1e-7
        public int base_gps_alt;   // cm
        public short base_ew_vel;   // cm/s
        public short base_ns_vel;   // cm/s
        public short base_up_vel;   // cm/s
        public short base_heading;   // -180 --180 deg
        public byte base_ant1_num;
        public byte base_heading_type;   // 1-- available   0-- unavailable
        public byte base_ant2_num;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FLY_POINT
    {
        public int pointLongitude;   // 1e-7 deg
        public int pointLattitude;    // 1e-7 deg
        public short pointAlt;          // m
        public short pointSpeed;    // dm/s
        public byte _point_mode;  // fly mode
        public ushort _circle_radius;    // dm
        public ushort _circle_speed;    // dm/s
        public byte _circle_direction;
        public short _circle_times;
    }

    public struct ACKid
    {
        public byte ackidnum;
        public short ackmsg;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PIC_POS
    {
        public ushort photoSequence; //照片序号
        public byte years;
        public byte month;
        public byte days;
        public byte hours;
        public byte min;
        public ushort min_seconds;  // 10 ms

        public int photoLongitude;//拍照点经度
        public int photoLattitude;//拍照点纬度
        public ushort gpsHeight;//GPS高度

        public short rollAngle; //横滚角
        public short pitchAngle;//俯仰角
        public short yawAngle;  //航向角

        public byte rtk;
        public ushort num_all;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PLAY_DATA_FROM_FC
    {
        public int data_id;
        public byte data_length;
        public int data_num_all;
        public byte[] data_;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FLY_LOG
    {
        public ushort log_all_id;
        public ushort log_id;
        public byte log_plane_type;
        public int log_gujianhao;
        public int log_jiesuo_jingdu;
        public int log_jiesuo_weidu;
        public byte log_jiesuo_year;
        public byte log_jiesuo_month;
        public byte log_jiesuo_day;
        public byte log_jiesuo_hour;
        public byte log_jiesuo_min;
        public byte log_jiesuo_second;

        public int log_luosuo_jingdu;
        public int log_luosuo_weidu;
        public ushort log_feixingshijian;
        public int log_all_feixingshijian;
        public ushort log_feixinglicheng;
        public int log_all_licheng;
        public ushort log_jiesuo_dianya;
        public ushort log_luosuo_dianya;
        public sbyte log_max_henggunjiao;
        public sbyte log_max_fuyangjiao;
        public short log_max_shuiping_speed;
        public byte log_max_chuizhi_shangsheng_speed;
        public byte log_max_chuizhi_xiajiang_speed;
        public sbyte log_max_GPS_num;
        public sbyte log_min_GPS_num;
        public ushort log_min_GPS_timer;
        public byte log_ci_yichang;
        public byte log_jiajituoluo_yichang;
        public byte log_qiya_yichang;
        public byte log_GPS_yichang;
        public byte log_leida_yichang;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct STRUCT_GPS_BIAS
    {
        public short _gpsA_x_bias;
        public short _gpsA_y_bias;
        public short _gpsA_z_bias;
        public short _gpsB_x_bias;
        public short _gpsB_y_bias;
        public short _gpsB_z_bias;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PLANE_SETTING
    {
        public byte _plane_type;
        public short _circle_r;
        public short _link_lost;
        public short _saft_volt_level1;
        public byte _saft_volt_level1_action;
        public short _saft_volt_level2;
        public byte _saft_volt_level2_action;
        public ushort _takeoff_alt;
        public ushort _return_alt;
        public sbyte _mag_bias;
        public byte _filter_level;
        public byte _daisu;
        public ushort _remoter_lost;
    }
    //sbus输出协议
    public struct SBus_jd
    {
        public byte sbus_type;          //通道类型
        public byte sbus_id;           //通道id1-8
        public short sbus_value;        //通道值
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PID_B
    {
        public ushort henggun_angle_P;
        public ushort henggun_gyro_P;
        public ushort fuyang_angle_P;
        public ushort fuyang_gyro_P;
        public ushort hangxiang_angle_P;
        public ushort hangxiang_gyro_P;
        public ushort dinggao_speed_P;

        public byte henggun_gyro_D;
        public byte fuyang_gyro_D;
        public byte hangxiang_gyro_D;

        public ushort dinggao_dist_P;
        public ushort dinggao_acc_P;
        public byte dinggao_acc_I;

        public ushort dingdian_dist_P;
        public ushort dingdian_speed_P;
        public ushort dingdian_acc_P;
        public byte dingdian_speed_I;

        public byte gyro_limit;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct STRUCT_VERSION
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] feikongname;
        public int xuliehao;
        public int imuhao;
        public int gujianhao;
        public byte reserve;
        public byte gps_type;
        public byte system_id;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FW_VERSION
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] feikongname;

        public int _serial_id;
        public int _hardware_id;
        public int _firmware_id;
        public int _total_power_time;    // min
        public int _total_flied_time;    // min
        public uint _engine_work_time;    // min
        public byte _software_version;    // 0---飞行   1---滑跑   2---仿真
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct STRUCT_WPT
    {
        public ushort wp_id;
        public int wp_lon;
        public int wp_lat;
        public int wp_alt;
        public ushort wp_speed;
        public byte wp_turn_mode;
        public short wp_turn_time;
        public byte wp_task;
        public short wp_pic_interval;
        public short wp_heading;
        public byte wp_alt_type;
        public short wp_allnum;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct STRUCT_PAR
    {
        public byte Max_Angle_GPS_Mode;
        public byte Max_Hori_Vel_GPS_Mode;
        public byte Max_Climb_Rate_GPS_Mode;
        public byte Max_Down_Rate_GPS_Mode;

        public UInt16 Base_Throttle;
        public UInt16 Limit_Alt1;
        public UInt16 Limit_Alt2;

        public byte Max_Yaw_Rate;
        public sbyte AD0_Bias;
        public sbyte AD1_Bias;
        public sbyte AD2_Bias;

        public byte Follow_Dist;
        public byte Max_Climb_Rate_Auto;
        public byte Max_Down_Rate_Auto;
        public byte Min_Down_Rate_Auto;
        public byte Max_Cruise_Vel_Auto;

        public short reserved1;
        public short reserved2;
        public short reserved3;

        public ushort Dist_limit;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FAN_HANG_REASON
    {
        public const byte REMOTER_INDICATION_HOME = 2;     // 遥控器指令返航
        public const byte GCS_INDICATION_HOME = 3;               // 地面站指令返航
        public const byte REMOTER_RRROR_HOME = 4;             // 遥控器错误返航
        public const byte LOW_VOLT_HOME = 5;                           // 低电压返航
        public const byte LINK_LOST_HOME = 6;                          // 电台丢失返航
        public const byte RTK_LOST_HOME = 7;                          // RTK丢失返航
        public const byte NO_PESTICIDE_HOME = 8;                  // 药量低返航
        public const byte ROCK_LOST_HOME = 9;                  // 摇杆丢失返航
        public const byte LIMIT_ALT_HOME = 10;                  // 高度限制返航
        public const byte INFRARED_INVALID_HOME = 11;     // 雷达失效返航
        public const byte HIGH_TEMPERATURE_HOME = 12;     // 温度过高返航
        public const byte REMOTER_LOST_HOME = 13;          // 遥控器断开返航
        public const byte REMOTER_FS_HOME = 14;
        public const byte FORBIDDEN_AREA_HOME = 15;
        public const byte FORBIDDEN_FIX_WING_ATTITUD_UNSTABLE = 16;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FOLLOW_GPS_POS
    {
        public int nLon_Follow;   // 1e-7
        public int nLat_Follow;   // 1e-7

        public int nGps_E_Follow;   // mm/s
        public int nGps_N_Follow;   // mm/s
        public int nGps_D_Follow;   // mm/s

        public int nAlt_Follow;     // mm
        public int nGroundSpeed_Follow;  // mm/s
        public short nHeading;    // 0.1度
        public byte StaNum;

        public byte pos_status;
        public byte heading_status;
        public byte base_mode;
        public byte StaNum_ant2;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FX_CHANNEL_CONFIG
    {
        public byte channel_id;
        public short min;
        public short mid;
        public short max;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FW_FLY_SETTINGS
    {
        public byte _fw_plane_type;
        public ushort _turn_dist;                     // m
        public short _max_roll;                     // 0.1 deg
        public short _max_pitch;                   // 0.1 deg
        public ushort _lost_airspeed;             // dm/s
        public ushort _cruise_airspeed;        // dm/s
        public ushort _max_climb_rate;        // dm/s
        public ushort _max_down_rate;        // dm/s
        public ushort _takeoff_speed;         // dm/s
        public short _takeoff_flap_angle;        // ±100%
        public short _break_speed;          // dm/s 
        public short _front_wheel_speed;          // dm/s 
        public short _land_flap_angle;          // 0.1 deg
        public byte _break_time;          // 0.1 
        public byte _break_intervel;          // 0.1 
        public byte _takeoff_angle;          // 0.1  deg
        public ushort _takeoff_speed_compensate_value;          // 0.1  m/s
        public ushort _takeoff_speed_compensate_kx;          // 0.01
        public ushort _cruise_speed_compensate_kx;          // 0.01
        public ushort _roll_compensate_kx;          // 1
        public ushort _start_break_dist;          // 0.1 m
        public ushort _stop_speed;          // 0.1 m/s
        public ushort _start_break_speed;          // 0.1 m/s
        public byte _throttle;
        public sbyte _max_speed_bias;    //0.1m
        public byte _lagan_compensate;    //0---100
        public ushort _fw_to_mm_dist;    //m
        public ushort _mm_to_fw_airspeed;    //dm/s
        public byte _mm_to_fw_time_excced;    //s
        public ushort _mm_daisi;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FW_SETTING2
    {
        public byte _reserved;
        public ushort _circle_r;        // m
        public ushort _link_lost;        //s
        public byte _saft_volt_level1_action;
        public ushort _saft_volt_level1;     //0.1v
        public byte _takeoff_alt;       //m
        public byte _return_alt;        //m
        public sbyte _mag_bias;     //deg
        public byte _zhuansu_protect;        //0---不开启   1---开启
        public ushort _zhuansu_limit;
        public byte _saft_volt_level2_action;
        public short _saft_volt_level2;
        public byte _action_after_take_off;
        public byte _circle_direction;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FW_MM_PID
    {
        public short _horizontal_dist_p;
        public short _horizontal_vel_p;
        public short _horizontal_vel_i;
        public short _horizontal_vel_d;

        public short _height_dist_p;
        public short _height_vel_p;
        public short _height_acc_p;
        public short _height_acc_i;

        public short _roll_angle_p;
        public short _pitch_angle_p;
        public short _yaw_angle_p;

        public short _roll_gyro_p;
        public short _pitch_gyro_p;
        public short _yaw_gyro_p;

        public short _roll_gyro_i;
        public short _pitch_gyro_i;
        public short _yaw_gyro_i;

        public short _roll_gyro_d;
        public short _pitch_gyro_d;
        public short _yaw_gyro_d;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FW_PID
    {
        public short _roll_p;
        public short _roll_i;
        public short _roll_d;
        public short _roll_imax;

        public short _pitch_p;
        public short _pitch_i;
        public short _pitch_d;
        public short _pitch_imax;

        public short _height_p;
        public short _up_vel_p;
        public short _up_vel_i;

        public short _airspeed_p;
        public short _airspeed_i;
        public short _crosss_p;
        public short _yaw_p;

        public short _L1_interval;
        public short _L1_d;
        public short _L1_i;
        public short _L1_dist;
    }

    public enum PARA_NUM
    {
        ParamNum_APType = 0,                      // 机型
        ParamNum_RadioLinkLostTime = 1,           // 电台失连时间 s
        ParamNum_LowVoltAction = 2,               // 低电压动作
        ParamNum_LowVoltValue = 3,                // 低电压阈值 0.1v
        ParamNum_APCircleRadius = 4,              // 环绕半径 m
        ParamNum_APRthAlt = 5,                    // 返航高度 m
        ParamNum_APTakeoffAlt = 6,                // 起飞高度 m
        ParamNum_MagDeclination = 7,              // 磁偏角 deg
        ParamNum_LidarSensibility = 8,            // 雷达灵敏度
        ParamNum_ImuFilterLever = 9,              // imu 滤波参数
        ParamNum_ImuAssembleDirection = 10,       // imu 安装方向
        ParamNum_APIdleSpeed = 11,                // 怠速等级
        ParamNum_GpsPosCalibX = 12,               // Gps 安装 X 补偿 cm
        ParamNum_GpsPosCalibY = 13,               // Gps 安装 Y 补偿 cm
        ParamNum_GpsPosCalibZ = 14,               // Gps 安装 Y 补偿 cm
        ParamNum_Port4Multiplexing = 15,          // 串口 4 功能复用
        ParamNum_DgpsAssembleDirection = 16,      // 双查分天线安装方向
        ParamNum_APMaxTilteAngle = 17,            // 旋翼最大目标倾斜角度 deg
        ParamNum_APMaxHorizonalSpeedGpsMode = 18, // gps 推杆最大目标水平速度 dm /s
        ParamNum_APMaxClimbSpeedGpsMode = 19, // gps 推杆最大目标爬升速度 dm/s
        ParamNum_APMaxDeclineSpeedGpsMode = 20, // gps 推杆最大目标下降速度 dm/s
        ParamNum_APHoverThrottle = 21,          // 旋翼悬停油门 1200~1800
        ParamNum_AltRestrictionA = 22,          // 一级高度限制 m
        ParamNum_AltRestrictionB = 23,          // 二级高度限制 m
        ParamNum_APMaxYawRate = 24,             // 旋翼最大锁尾角速度 deg/s
        ParamNum_VoltCalibKp0 = 25, // 电压校准比例系数0, 通道0(飞控供电通道)
        ParamNum_VoltCalibKp1 = 26, // 电压校准比例系数1, 通道 AD0
        ParamNum_VoltCalibKp2 = 27, // 电压校准比例系数2, 通道 AD1
        ParamNum_VoltCalibOffset0 = 28, // 电压校准偏移系数0, 通道0(飞控供电通道)
        ParamNum_VoltCalibOffset1 = 29,        // 电压校准偏移系数1
        ParamNum_VoltCalibOffset2 = 30,        // 电压校准偏移系数2
        ParamNum_FollowDist = 31,              // 跟随距离 m
        ParamNum_APMaxClimbSpeedAutoMode = 32, // 自动模式最大目标爬升速度 dm/s
        ParamNum_APMaxDeclineSpeedAutoMode = 33, // 自动模式最大目标下降速度 dm/s
        ParamNum_APMinLandingRateAutoMode = 34, // 自动模式最小降落速度 dm/s
        ParamNum_MaxHorizonalDistance = 35,     // 最远水平距离
        ParamNum_CameraSignalType = 36, // 拍照信号类型 0-低电平 1-高电平 2-pwm
        ParamNum_CameraSignalInterval = 37, // 拍照信号持续时间 ms
        ParamNum_CameraSignalPwmOn = 38,    // 拍照 pwm 高电平时间
        ParamNum_CameraSignalPwmOff = 39,   // 不拍照 PWM 高电平时间
        ParamNum_RollAngleKp = 40,          // 横滚姿态感度系数
        ParamNum_RollGyroKp = 41,           // 横滚基础感度系数
        ParamNum_RollGyroKd = 42,           // 横滚增稳系数
        ParamNum_PitchAngleKp = 43,         // 俯仰姿态感度系数
        ParamNum_PitchGyroKp = 44,          // 俯仰基础感度系数
        ParamNum_PitchGyroKd = 45,          // 俯仰增稳系数
        ParamNum_YawAngleKp = 46,           // 航向姿态感度系数
        ParamNum_YawGyroKp = 47,            // 航向基础感度系数
        ParamNum_YawGyroKd = 48,            // 航向增稳系数
        ParamNum_AltholdDistKp = 49,        // 定高位置系数
        ParamNum_AltholdSpeedKp = 50,       // 定高速度系数
        ParamNum_AltholdAccKp = 51,         // 定高加速度系数
        ParamNum_AltholdAccKi = 52,         // 定高积分补偿系数
        ParamNum_LoiterDistKp = 53,         // 水平位置系数
        ParamNum_LoiterSpeedKp = 54,        // 水平速度系数
        ParamNum_LoiterAccKp = 55,          // 水平加速度系数
        ParamNum_LoiterAccKi = 56,          // 水平积分补偿系数
        ParamNum_ParamNum_APMaxHorizonalSpeedAutoMode = 57 // 最大巡航水平速度
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BASE_INFOR
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] base_product_name;
        public int _serial_id;           // year + batch + number
        public int _firmwareVersion;     // yeaer + month + day
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct UDP_MSG
    {
        public ushort start_flag;
        public byte source_id;
        public byte plane_id;
        public byte data_len;
        public short yaw;
        public short roll;
        public short pitch;
        public int plane_lon;
        public int plane_lat;
        public short gps_alt;   // 0.1m
        public short gps_vel;  // 0.1m/s
        public short gps_year;
        public byte gps_month;
        public byte gps_day;
        public byte gps_hour;
        public byte gps_minute;
        public byte gps_second;
        public byte gps_minisecond; // 100ms
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct YOUDIAN_STRUCT
    {
        public ushort _header;  // 0xA55A
        public byte _length;
        public byte _version;
        public ushort _engine_speed;   // rpm
        public ushort _throttle;
        public ushort _engine_volt;  //0.1v
        public ushort _charge_current;  //0.1A
        public uint _total_time;    // min
        public ushort _work_time_rest;   // min
        public ushort _work_time_lock;   // min
        public byte _status;    //0--停止   1---等待  2---运行   3---锁机
        public ushort _emergency;
        public byte _rest_oil;    //%
        public ushort _cylinder1_temperature;   // 0---300℃
        public ushort _cylinder2_temperature;   // 0---300℃
        public byte _pcb_temperature;    // 0---255℃
        public ushort _crc_check;
    }
}
