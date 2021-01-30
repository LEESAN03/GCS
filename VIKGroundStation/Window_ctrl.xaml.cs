using GMap.NET;
using System;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace VIKGroundStation
{
    /// <summary>
    /// Interaction logic for Window_ctrl.xaml
    /// </summary>
    public partial class Window_ctrl : Window
    {
        public Window_ctrl()
        {
            InitializeComponent();

            this.Top = (SystemParameters.PrimaryScreenHeight - this.Height) * 0.95;
            this.Left = (SystemParameters.PrimaryScreenWidth - this.Width) * 0.5;
        }

        /*************************************************************************
         * 函数功能：一键解锁
         * **********************************************************************/
        private void THR_UN_LOCK_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Unlock, 0);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Unlock indication send out");
                MainWindow.stream_gcs_log.Flush();
            }
        }
        /*************************************************************************
        * 函数功能：自动起飞
        * **********************************************************************/
        private void AUTO_TAKE_OFF_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Auto_TakeOff, 0);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Auto take off indication  send out");
                MainWindow.stream_gcs_log.Flush();
            }
        }

        /*************************************************************************
        * 函数功能：开始航线
        * **********************************************************************/
        private void START_WPT_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_XunHang, 0);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Start wpt indication  send out");
                MainWindow.stream_gcs_log.Flush();
            }
        }


        /*************************************************************************
        * 函数功能：暂停航线/ 复用固定翼的盘旋
        * **********************************************************************/
        private void INTERRUPUT_WPT_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_ZanTing, 0);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Stop wpt indication  send out");
                MainWindow.stream_gcs_log.Flush();
            }
        }


        /*************************************************************************
        * 函数功能：断点续飞
        * **********************************************************************/
        private void DUAN_DIAN_WPT_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                if(App.plane_type == 0)
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Xufei, 0);
                else
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_JiXu, 0);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Break go indication  send out");
                MainWindow.stream_gcs_log.Flush();
            }
        }
        
        /*************************************************************************
        * 函数功能：一键返航
        * **********************************************************************/
        private void BACK_HOME_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_FanHang, 0);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Return Indication  send out");
                MainWindow.stream_gcs_log.Flush();
            }
        }

        private void LAND_NOW_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_JiangLuo, 0);

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Still land indication  send out");
                MainWindow.stream_gcs_log.Flush();
            }
        }

        private void BTN_TAKE_PIC_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Take_Photo, 0);
        }

        private void BTN_OPEN_PARACHUTE_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == true)
            {
                if (App.plane_type == 0)
                {
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, 100, 0);
                }
                else if (App.plane_type == 0)
                {
                    DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_CTL, Ctrl_ID.Ctrl_Open_Parachute, 0);
                }

                string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
                MainWindow.stream_gcs_log.WriteLine(str_time + "Open parachute indication  send out");
                MainWindow.stream_gcs_log.Flush();
            }
        }

        private void BTN_CENTEL_VIEWS_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map mPage2DMap = Page_2D_Map.getInstance();
            byte sys_id_set = DATA_LINK.Get_System_Set_Id();
            FLY_INFOR_DISPLAY mFly_Infor_Display = DataProcess_JD.Get_Fly_Display(sys_id_set);

            if (mFly_Infor_Display.gps_num < 8)
                return;

            // 如果飞行器连接正常，一键居中有效，否则无效
            if (Page_Fly_Map.b_plane_exist == true)
            {
                double lonTemp = 0, latTemp = 0;

                // 如果进入了解算，则使用解算位置
                if ((mFly_Infor_Display.ins_flag & 0x0f) == (byte)1 || (mFly_Infor_Display.ins_flag & 0x0f) == (byte)2)
                {
                    lonTemp = mFly_Infor_Display.imu_jiesuan_lon;
                    latTemp = mFly_Infor_Display.imu_jiesuan_lat;
                }
                // 初始化上电时，显示原始GPS的数值
                else if ((mFly_Infor_Display.ins_flag & 0x0f) == (byte)0)
                {
                    lonTemp = mFly_Infor_Display.gps_lon;
                    latTemp = mFly_Infor_Display.gps_lat;
                }

                if (MainWindow.map_show_type == 2)
                {
                    PointLatLng currentloc = new PointLatLng(latTemp, lonTemp);
                    mPage2DMap.gMap_2D.Position = currentloc;
                    mPage2DMap.gMap_2D.Zoom = 18;
                }
                else if (MainWindow.map_show_type == 3)
                {
                    if (Page_Google_Map.initmap == true)
                    {
                        // 将视角切换到添加航线处
                        MainWindow.m_PageGoogleMap.webBrowser_google_earth.InvokeScript("updataLookat", new object[] {
                            lonTemp, latTemp, mFly_Infor_Display.imu_jisuan_gaodu,1000});
                    }
                }
            }
        }

        bool Dist_Measure_Enable = false;
        private void BTN_MESURE_Click(object sender, RoutedEventArgs e)
        {
            Page_Google_Map mPageGoogleMap = Page_Google_Map.getInstance();

            if (Dist_Measure_Enable == false)
            {
                Dist_Measure_Enable = true;
                if (MainWindow.map_show_type == 2)
                {
                    Page_2D_Map.addptbool = 3;
                    Page_2D_Map.addPtMeasureIndex = 1;
                }
                else if (MainWindow.map_show_type == 3)
                {
                    mPageGoogleMap.webBrowser_google_earth.InvokeScript("MeasureDist", new object[] { 1 });
                }
            }
            else
            {
                Dist_Measure_Enable = false;

                if (MainWindow.map_show_type == 2)
                {
                    Page_2D_Map.addptbool = 0;
                    Page_2D_Map.addPtMeasureIndex = 0;

                    Page_2D_Map.Init_Measure_Dist_Mark();
                }
                else if (MainWindow.map_show_type == 3)
                {
                    mPageGoogleMap.webBrowser_google_earth.InvokeScript("MeasureDist", new object[] { 0 });
                }
            }
        }

        private void BTN_DELETE_POS_Click(object sender, RoutedEventArgs e)
        {
            Page_Google_Map mPageGoogleMap = Page_Google_Map.getInstance();

            if (MainWindow.map_show_type == 2)
            {
                Page_2D_Map.PicPos_Layer.Markers.Clear();
            }
            else if (MainWindow.map_show_type == 3)
            {
                mPageGoogleMap.webBrowser_google_earth.InvokeScript("DelPicPos", new object[] { });
            }
        }

        private void BTN_DELETE_FLY_WAY_Click(object sender, RoutedEventArgs e)
        {
            Page_Google_Map mPageGoogle = Page_Google_Map.getInstance();

            // 删除2D地图上的航迹
            Page_2D_Map.Route_Layer.Routes.Clear();
            Page_2D_Map.route_hangji.Clear();

            // 删除3D地图上的航迹
            if (Page_Google_Map.initmap == true)
            {
                mPageGoogle.webBrowser_google_earth.InvokeScript("Del_Fly_Way", new object[] { });
            }
        }

        /*******************************************************************
         * function:    update the information
         * para:    the downlink data struct
         * return:  none
         * ******************************************************************/
        public void Update_Infor(FLY_INFOR_DISPLAY mFlyInfor)
        {
            if (mFlyInfor.lock_status == 2 || mFlyInfor.lock_status == 3)
            {
                image_lock_status.Source = new BitmapImage(new Uri(@"Images\dev_unlock.png", UriKind.Relative));
            }
            else
            {
                image_lock_status.Source = new BitmapImage(new Uri(@"Images\dev_lock.png", UriKind.Relative));
            }

            TextBlock_Pic_Num.Text = mFlyInfor.total_pic_count.ToString();
            TextBlock_Rest_Circle.Text = mFlyInfor.rest_circle_time.ToString();
        }

        private void BTN_VOICE_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.enable_voice == false)
            {
                MainWindow.enable_voice = true;
                image_voice.Source = new BitmapImage(new Uri(@"Images\voice.png", UriKind.Relative));
            }
            else if (MainWindow.enable_voice == true)
            {
                MainWindow.enable_voice = false;
                image_voice.Source = new BitmapImage(new Uri(@"Images\no_voice.png", UriKind.Relative));
                MainWindow.Speaker.SpeakAsyncCancelAll();
            }
        }

        private bool m_bEnable_ob_radar = true;
        private void BTN_OB_RADAR_Click(object sender, RoutedEventArgs e)
        {
            if (m_bEnable_ob_radar == false)
            {
                m_bEnable_ob_radar = true;
                image_ob_radar.Source = new BitmapImage(new Uri(@"Images\ob_radar_on.png", UriKind.Relative));
                DATA_LINK.Send_Single_Para(59, 1);
            }
            else if (m_bEnable_ob_radar == true)
            {
                m_bEnable_ob_radar = false;
                image_ob_radar.Source = new BitmapImage(new Uri(@"Images\ob_radar_off.png", UriKind.Relative));
                DATA_LINK.Send_Single_Para(59, 0);
            }
        }
    }
}
