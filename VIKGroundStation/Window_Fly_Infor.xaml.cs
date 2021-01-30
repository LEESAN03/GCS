using System;
using System.Windows;
using System.Windows.Input;


namespace VIKGroundStation
{
    /// <summary>
    /// Window_Fly_Infor.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Fly_Infor : Window
    {
        public Window_Fly_Infor()
        {
            InitializeComponent();

            Top = SystemParameters.PrimaryScreenHeight * 8.5 / 208;
            Left = SystemParameters.PrimaryScreenWidth * 0.027;
            Hide();
        }


        /******************************************************************
         * 功  能：使该窗口可拖动
         * 参  数：
         * 返  回：
         * ***************************************************************/
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

        /*************************************************************
        * 功   能：显示多旋翼IMU信息
        * 参   数：
        * 返   回：
        * ***********************************************************/
        public void Show_Imu_Type0(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            //  ========================== 姿态 =============================
            String strRoll = "";
            if (mFly_Infor_Display.imu_henggunjiao >= 0)
                strRoll = TryFindResource("TITLE_RIGHT").ToString();
            else
                strRoll = TryFindResource("TITLE_LEFT").ToString();

            String strPitch = "";
            if (mFly_Infor_Display.imu_fuyangjiao >= 0)
                strPitch = TryFindResource("TITLE_YANG").ToString();
            else
                strPitch = TryFindResource("TITLE_FU").ToString();

            String strYaw = TryFindResource("TITLE_YAW").ToString();

            double yawTemp = mFly_Infor_Display.imu_hangxiangjiao;
            double rollTemp = mFly_Infor_Display.imu_henggunjiao;
            double pitchTemp = mFly_Infor_Display.imu_fuyangjiao;
            pitchTemp = Compute.Math_Constrain_float(pitchTemp, -89, 89);

            // 仪表盘的姿态角度
            ATTITUDE_PANEL.YawAngle = yawTemp;
            ATTITUDE_PANEL.RollAngle = rollTemp;
            ATTITUDE_PANEL.PitchAngle =  pitchTemp;

            ATTITUDE_PANEL.FlyHeight = mFly_Infor_Display.imu_jisuan_gaodu;

            TextBlock_Attitude.Text = TryFindResource("TITLE_ATTITUDE") + ":  " + strYaw + yawTemp.ToString() + "   " +
                                     strRoll + Math.Abs(rollTemp).ToString() + "   " +
                                     strPitch + Math.Abs(pitchTemp).ToString();

            // 飞行时间
            int hours = 0;
            int minuntes = 0;
            int seconds = 0;
            seconds = (mFly_Infor_Display.flied_time) % 60;
            minuntes = (mFly_Infor_Display.flied_time) / 60;
            hours = minuntes / 60;
            minuntes = minuntes % 60;
            string str = hours.ToString() + ":" + minuntes.ToString() + ":" + seconds.ToString();
            if (str == "" || str == null)
            {
                TextBlock_Flied_Time.Text = "00:00:00";
            }
            else
            {
                TextBlock_Flied_Time.Text = TryFindResource("TITLE_FLIED_TIME") + str;
            }

            // 已飞距离   
            double wpt_dist_temp = 0.0f;
            if (mFly_Infor_Display.wpt_flied_dist < 1000)
            {
                TextBlock_Flied_Dist.Text = TryFindResource("TITLE_FLIED_DIST") + " " + (mFly_Infor_Display.wpt_flied_dist).ToString() + " m";
            }
            else
            {
                wpt_dist_temp = (double)mFly_Infor_Display.wpt_flied_dist / 1000;
                TextBlock_Flied_Dist.Text = TryFindResource("TITLE_FLIED_DIST") + " " + Math.Round(wpt_dist_temp, 1).ToString() + " km";
            }

            // 航线总距离
            if (mFly_Infor_Display.total_wpt_dist < 1000)
            {
                TextBlock_Total_Dist.Text = TryFindResource("TITLE_WPT_TOTAL_DIST") + " " + (mFly_Infor_Display.total_wpt_dist).ToString() + " m";
            }
            else
            {
                wpt_dist_temp = (double)mFly_Infor_Display.total_wpt_dist / 1000;
                TextBlock_Total_Dist.Text = TryFindResource("TITLE_WPT_TOTAL_DIST") + " " + Math.Round(wpt_dist_temp, 1).ToString() + " km";
            }

            //回家距离
            if (mFly_Infor_Display.dist_to_home < (short)1000)
                TextBlock_Dist_Home.Text = TryFindResource("TITLE_DIST_HOME_STATIC") + " " + mFly_Infor_Display.dist_to_home.ToString() + " m";
            else
                TextBlock_Dist_Home.Text = TryFindResource("TITLE_DIST_HOME_STATIC") + " " + Math.Round((double)(mFly_Infor_Display.dist_to_home) / 1000, 2).ToString() + " km";

            // 定高状态
            if (mFly_Infor_Display.rtk_status == 1 || mFly_Infor_Display.rtk_status == 2)
            {
                TextBlock_Alt_Control_Status.Text = TryFindResource("TITLE_ALT_CONTROL_STATIC") + " " + TryFindResource("TITLE_STATUS_GOOD");
                TextBlock_Alt_Control_Status.Foreground = System.Windows.Media.Brushes.White;
            }
            else if (mFly_Infor_Display.rtk_status == 0)
            {
                TextBlock_Alt_Control_Status.Text = TryFindResource("TITLE_ALT_CONTROL_STATIC") + " " + TryFindResource("TITLE_STATUS_BAD");
                TextBlock_Alt_Control_Status.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }

            // 震动系数
            TextBlock_Noise_Kx.Text = TryFindResource("TITLE_ZHEN_DONG_STATIC") + " " + mFly_Infor_Display.noise_kx.ToString("0.00");

            // 显示电机的平衡性
            if (mFly_Infor_Display.motor_balance == 1)
            {
                TextBlock_Motor_Balance.Text = TryFindResource("TITLE_MOTOR_BALANCE_STATIC").ToString() + " " + TryFindResource("TITLE_STATUS_BAD");
                TextBlock_Motor_Balance.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }
            else
            {
                TextBlock_Motor_Balance.Text = TryFindResource("TITLE_MOTOR_BALANCE_STATIC").ToString() + " " + TryFindResource("TITLE_STATUS_GOOD");
                TextBlock_Motor_Balance.Foreground = System.Windows.Media.Brushes.White;
            }

            // 油门总输出
            int throttlePercent = (int)((mFly_Infor_Display.base_throttle - 1000) / 10);
            if (throttlePercent < 0)
                throttlePercent = 0;
            TextBlock_Basic_Throttle.Text = TryFindResource("TITLE_BASIC_STATIC").ToString() + " " + throttlePercent.ToString() + "%";

            // 温度
            TextBlock_Temperature.Text = TryFindResource("TITLE_TEMPERATURE") + " " + mFly_Infor_Display.temperature.ToString() + "°C";

            // =================== GPS信息显示 =====================
            // GPS_A的状态
            if ((byte)(mFly_Infor_Display.gps_status & 0x01) == (byte)0x01)     // 主GPS断开
            {
                TextBlock_Zhu_Gps_Status.Text = "GPS-A: " + TryFindResource("TITLE_GPS_LOST_WARNNING");
                TextBlock_Zhu_Gps_Status.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }
            else if ((byte)(mFly_Infor_Display.gps_status & 0x08) == (byte)0x08)     // 主GPS数据不变
            {
                TextBlock_Zhu_Gps_Status.Text = "GPS-A: " + TryFindResource("TITLE_GPS_ERROR_WARNNING");
                TextBlock_Zhu_Gps_Status.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }
            else
            {
                TextBlock_Zhu_Gps_Status.Text = "GPS-A: " + TryFindResource("TITLE_STATUS_OK");
                TextBlock_Zhu_Gps_Status.Foreground = System.Windows.Media.Brushes.White;
            }
            // GPS_B的状态
            if ((byte)(mFly_Infor_Display.gps_status & 0x02) == (byte)0x02)     // 从GPS断开
            {
                TextBlock_Cong_Gps_Status.Text = "GPS-B: " + TryFindResource("TITLE_GPS_LOST_WARNNING");
                TextBlock_Cong_Gps_Status.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }
            else if ((byte)(mFly_Infor_Display.gps_status & 0x10) == (byte)0x10)     // 从GPS数据不变
            {
                TextBlock_Cong_Gps_Status.Text = "GPS-B: " + TryFindResource("TITLE_GPS_ERROR_WARNNING");
                TextBlock_Cong_Gps_Status.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }
            else
            {
                TextBlock_Cong_Gps_Status.Text = "GPS-B: " + TryFindResource("TITLE_STATUS_OK");
                TextBlock_Cong_Gps_Status.Foreground = System.Windows.Media.Brushes.White;
            }

            // 磁传感器报错, GPS连接正产的情况下才进行磁传感器报错
            // 主磁力计状态
            if ((byte)(mFly_Infor_Display.mag_status & 0x08) == (byte)0x08)     // 主磁力计断开
            {
                TextBlock_MagA_Status.Text = "MAG-A: " + TryFindResource("TITLE_GPS_LOST_WARNNING");
                TextBlock_MagA_Status.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }
            else if ((byte)(mFly_Infor_Display.mag_status & 0x01) == (byte)0x01)      //  主磁力计干扰
            {
                TextBlock_MagA_Status.Text = "MAG-A: " + TryFindResource("TITLE_MAG_WARNNING");
                TextBlock_MagA_Status.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }
            else
            {
                TextBlock_MagA_Status.Text = "MAG-A: " + TryFindResource("TITLE_STATUS_OK");
                TextBlock_MagA_Status.Foreground = System.Windows.Media.Brushes.White;
            }
            // 从磁力计状态
            if ((byte)(mFly_Infor_Display.mag_status & 0x10) == (byte)0x10)     // 从磁力计断开
            {
                TextBlock_MagB_Status.Text = "MAG-B: " + TryFindResource("TITLE_GPS_LOST_WARNNING");
                TextBlock_MagB_Status.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }
            else if ((byte)(mFly_Infor_Display.mag_status & 0x02) == (byte)0x02)      //  从磁力计干扰
            {
                TextBlock_MagB_Status.Text = "MAG-B: " + TryFindResource("TITLE_MAG_WARNNING");
                TextBlock_MagB_Status.Foreground = System.Windows.Media.Brushes.OrangeRed;
            }
            else
            {
                TextBlock_MagB_Status.Text = "MAG-B: " + TryFindResource("TITLE_STATUS_OK");
                TextBlock_MagB_Status.Foreground = System.Windows.Media.Brushes.White;
            }

            // 飞机经纬度
            double lon_temp, lat_temp;
            lon_temp =mFly_Infor_Display.imu_jiesuan_lon;
            lat_temp = mFly_Infor_Display.imu_jiesuan_lat;

            TextBlock_Plane_Lon.Text = "Lon: " + lon_temp.ToString("0.0000000");
            TextBlock_Plane_Lat.Text = "Lat: " + lat_temp.ToString("0.0000000");

            // GPS高度
            TextBlock_GPS_Alt.Text = TryFindResource("TITLE_GPS_ALT") + " " + (mFly_Infor_Display.gps_alt).ToString("0.0") + " m";

            // GPS跟随距离
            int follow_dist;
            if (DATA_LINK.follow_gps_exist == true)
            {
                FOLLOW_GPS_POS m_FollowGps = DataProcess_JD.Get_Follow_Gps_Struct();

                follow_dist = Compute.point_to_point_distance((int)(mFly_Infor_Display.imu_jiesuan_lon*10000000), (int)(mFly_Infor_Display.imu_jiesuan_lat*10000000),
                    m_FollowGps.nLon_Follow, m_FollowGps.nLat_Follow);
            }
            else
            {
                follow_dist = 0;
            }

            TextBlock_Follow_Dist.Text = TryFindResource("TITLE_FOLLOW_DIST") + " " + (follow_dist / 100).ToString("0.0") + " m";

            // 磁航向类型
            if ((byte)(mFly_Infor_Display.mag_status & 0x40) == (byte)0x40)     // GPS双天线定型
            {
                TextBlock_Head_Type.Text = TryFindResource("TITLE_HEAD_TYPE") + " " + TryFindResource("TITLE_DOUBLE_ANTENA");
            }
            else
            {
                TextBlock_Head_Type.Text = TryFindResource("TITLE_HEAD_TYPE") + " " + TryFindResource("TITLE_COMPASS");
            }

            // 高度雷达
            if (mFly_Infor_Display.radar_alt < 0)
            {
                TextBlock_Alt_Radar_Dist.Text = TryFindResource("TITLE_ALT_RADAR_DIST") + " " + TryFindResource("TITLE_INVALID");
            }
            else
            {
                TextBlock_Alt_Radar_Dist.Text = TryFindResource("TITLE_ALT_RADAR_DIST") + " " + (mFly_Infor_Display.radar_alt).ToString("0.0") + " m";
            }
            // front radar dist
            if (mFly_Infor_Display.radar_front < 0)
            {
                TextBlock_Front_Radar_Dist.Text = TryFindResource("TITLE_FRONT_RADAR_DIST") + " " + TryFindResource("TITLE_INVALID");
            }
            else
            {
                TextBlock_Front_Radar_Dist.Text = TryFindResource("TITLE_FRONT_RADAR_DIST") + " " + (mFly_Infor_Display.radar_front).ToString("0.0") + " m";
            }
            // back radar dist
            if (mFly_Infor_Display.radar_back < 0)
            {
                TextBlock_Back_Radar_Dist.Text = TryFindResource("TITLE_BACK_RADAR_DIST") + " " + TryFindResource("TITLE_INVALID");
            }
            else
            {
                TextBlock_Back_Radar_Dist.Text = TryFindResource("TITLE_BACK_RADAR_DIST") + " " + (mFly_Infor_Display.radar_back).ToString("0.0") + " m";
            }
        }
    }
}
