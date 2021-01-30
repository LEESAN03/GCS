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
using System.Windows.Shapes;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_ChuiQi_Fly_Infor.xaml 的交互逻辑
    /// </summary>
    public partial class Window_ChuiQi_Fly_Infor : Window
    {
        public Window_ChuiQi_Fly_Infor()
        {
            InitializeComponent();
            Top = SystemParameters.PrimaryScreenHeight * 8.5 / 208;
            Left = SystemParameters.PrimaryScreenWidth * 0.027;
        }


        /*************************************************************
    * 功   能：显示垂直起降的IMU信息
    * 参   数：
    * 返   回：
    * ***********************************************************/
        public void Show_Imu_Type1(FLY_INFOR_DISPLAY mFly_Infor_Display)
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
            ATTITUDE_PANEL.PitchAngle = pitchTemp;

            ATTITUDE_PANEL.FlyHeight = (double)mFly_Infor_Display.imu_jisuan_gaodu;

            TextBlock_Attitude.Text = TryFindResource("TITLE_ATTITUDE") + ":  " + strYaw + yawTemp.ToString("0.0") + "   " +
                                     strRoll + Math.Abs(rollTemp).ToString("0.0") + "   " +
                                     strPitch + Math.Abs(pitchTemp).ToString("0.0");

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

            // 温度
            TextBlock_Temperature.Text = TryFindResource("TITLE_TEMPERATURE") + " " + mFly_Infor_Display.temperature.ToString() + "°C";

            // 空速
            TextBlock_Target_Air_Speed.Text = "目标空速: " + mFly_Infor_Display.target_Airspeed.ToString("0.0") + " m/s";
            ATTITUDE_PANEL.AirSpeed = mFly_Infor_Display.imu_kongsu * 3.6;

            // 地速
            TextBlock_Ground_Speed.Text = "地速: " +  (mFly_Infor_Display.gps_speed).ToString("0.0") + " m/s";

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
            lon_temp = mFly_Infor_Display.imu_jiesuan_lon;
            lat_temp = mFly_Infor_Display.imu_jiesuan_lat;

            TextBlock_Plane_Lon.Text = "Lon: " + lon_temp.ToString("0.0000000");
            TextBlock_Plane_Lat.Text = "Lat: " + lat_temp.ToString("0.0000000");

            // GPS高度
            TextBlock_GPS_Alt.Text = TryFindResource("TITLE_GPS_ALT") + " " + (mFly_Infor_Display.gps_alt).ToString("0.0") + " m";

            // 磁航向类型
            if ((byte)(mFly_Infor_Display.mag_status & 0x40) == (byte)0x40)     // GPS双天线定型
            {
                TextBlock_Head_Type.Text = TryFindResource("TITLE_HEAD_TYPE") + " " + TryFindResource("TITLE_DOUBLE_ANTENA");
            }
            else
            {
                TextBlock_Head_Type.Text = TryFindResource("TITLE_HEAD_TYPE") + " " + TryFindResource("TITLE_COMPASS");
            }

            // =============================== 发动机信息 ==============================   
            TextBlock_Engine_Speed.Text = "转速: " + mFly_Infor_Display.engine_speed.ToString() + "rpm";

            if (mFly_Infor_Display.power_type == 0)
                TextBlock_Power_Type.Text = "动力类型: " + "旋翼";
            else if (mFly_Infor_Display.power_type == 1)
                TextBlock_Power_Type.Text = "动力类型: " + "混合";
            if (mFly_Infor_Display.power_type == 2)
                TextBlock_Power_Type.Text = "动力类型: " + "固定翼";
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
    }
}
