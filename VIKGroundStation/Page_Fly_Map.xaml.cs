using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMapDownload;
using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Fly_Map.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Fly_Map : Page
    {
        private static Page_Fly_Map m_Page_Fly_Map = new Page_Fly_Map();
        public static Page_Fly_Map getInstance()
        {
            if (m_Page_Fly_Map == null)
                m_Page_Fly_Map = new Page_Fly_Map();

            return m_Page_Fly_Map;
        }
        private Page_Fly_Map()
        {
            InitializeComponent();

            // 选择串口时钟
            timer_link = new DispatcherTimer();
            timer_link.Interval = TimeSpan.FromMilliseconds(5000);
            timer_link.Tick += timer_link_Tick;

            timer_link.Start();

            Show_Forbidden_Area();

            if (App.plane_type == 1 || App.plane_type == 2)
                BTN_HEAD_TO_POINT.ToolTip = TryFindResource("TITLE_RETURN_CIRCLE_PT");
        }

        public DispatcherTimer timer_link;        //用来判断信号强弱
        // 定时器用来检测遥测信号
        public short reciveImuCount = 0;
        private void timer_link_Tick(object sender, EventArgs e)
        {
            // 如果是回放数据，则直接退出
            if (Window_Replay.playback_data_type != 0)
                return;

            if (reciveImuCount == 0)
            {
                image_link_signal.Source = new BitmapImage(new Uri(@"Images\信号0.png", UriKind.Relative));
            }
            else if ((reciveImuCount > 0) && (reciveImuCount < 3))
            {
                image_link_signal.Source = new BitmapImage(new Uri(@"Images\信号1.png", UriKind.Relative));
            }
            else if ((reciveImuCount >= 3) && (reciveImuCount < 6))
            {
                image_link_signal.Source = new BitmapImage(new Uri(@"Images\信号2.png", UriKind.Relative));
            }
            else if (reciveImuCount >= 6)
            {
                image_link_signal.Source = new BitmapImage(new Uri(@"Images\信号3.png", UriKind.Relative));
            }

            reciveImuCount = 0;
        }

        /*******************************************************************
        * 功   能：加载航线编辑/飞行信息/地图显示信息
        * 参   数：argShowMode    1：显示航线编辑  2：显示飞行信息
        * 返   回：
        * ****************************************************************/
        public void SetMode(byte argShowMode)
        {
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();
            Page_2D_Map m_Page2DMap = Page_2D_Map.getInstance();

            if (argShowMode == 2)
            {
                // 添加2D地图
                Frm_Map_Show2.Navigate(m_Page2DMap);
            }
            else if (argShowMode == 3)
            {
                // 添加谷歌地图
                Frm_Map_Show2.Navigate(m_PageGoogleMap);
            }
        }

        /*************************************************************************
        * 功   能：显示飞行信息
        * 参   数：
        * 返   回：
        * **********************************************************************/
        public void Init_view_pos(double argLon, double argLat)
        {
            Page_2D_Map mPage2DMap = Page_2D_Map.getInstance();
            Page_Google_Map mPageGoogle = Page_Google_Map.getInstance();

            if (MainWindow.map_show_type == 2)
            {
                PointLatLng currentloc = new PointLatLng(argLat, argLon);
                mPage2DMap.gMap_2D.Position = currentloc;
                mPage2DMap.gMap_2D.Zoom = 18;
            }
            else if (MainWindow.map_show_type == 3)
            {
                if (Page_Google_Map.initmap == true)
                {
                    // 将视角切换到添加航线处
                    mPageGoogle.webBrowser_google_earth.InvokeScript("updataLookat", new object[] {
                            argLon, argLat, 0,1000});
                }
            }
        }

        /*************************************************************************
         * 功   能：显示飞行信息
         * 参   数：
         * 返   回：
         * **********************************************************************/
        public static bool fly_infor_wnd_show = false;
        private void BTN_Show_FLy_Info_Click(object sender, RoutedEventArgs e)
        {
            if (App.plane_type == 0)
                Imu_Type0_Wnd_Show();
            else if (App.plane_type == 1)
                Imu_Type1_Wnd_Show();
        }

        /*************************************************************************
        * 功   能：显示多旋翼IMU信息
        * 参   数：
        * 返   回：
        * **********************************************************************/
        private void Imu_Type0_Wnd_Show()
        {
            if (MainWindow.m_WndFlyInfor == null)
            {
                MainWindow.m_WndFlyInfor = new Window_Fly_Infor();
                MainWindow.m_WndFlyInfor.Owner = MainWindow.getInstance();

                MainWindow.m_WndFlyInfor.Show();

                GRID_Show_FLy_Info.Background = System.Windows.Media.Brushes.Orange;
                fly_infor_wnd_show = true;
            }
            else
            {
                if (MainWindow.m_WndFlyInfor.IsVisible == false)
                {
                    MainWindow.m_WndFlyInfor.Show();
                    GRID_Show_FLy_Info.Background = System.Windows.Media.Brushes.Orange;
                    fly_infor_wnd_show = true;
                }
                else
                {
                    MainWindow.m_WndFlyInfor.Hide();
                    GRID_Show_FLy_Info.Background = System.Windows.Media.Brushes.Black;
                    fly_infor_wnd_show = false;
                }
            }
        }


        /*************************************************************************
      * 功   能：显示垂起IMU信息
      * 参   数：
      * 返   回：
      * **********************************************************************/
        private void Imu_Type1_Wnd_Show()
        {
            if (MainWindow.m_WndChuiQi == null)
            {
                MainWindow.m_WndChuiQi = new Window_ChuiQi_Fly_Infor();
                MainWindow.m_WndChuiQi.Owner = MainWindow.getInstance();

                MainWindow.m_WndChuiQi.Show();

                GRID_Show_FLy_Info.Background = System.Windows.Media.Brushes.Orange;
                fly_infor_wnd_show = true;
            }
            else
            {
                if (MainWindow.m_WndChuiQi.IsVisible == false)
                {
                    MainWindow.m_WndChuiQi.Show();
                    GRID_Show_FLy_Info.Background = System.Windows.Media.Brushes.Orange;
                    fly_infor_wnd_show = true;
                }
                else
                {
                    MainWindow.m_WndChuiQi.Hide();
                    GRID_Show_FLy_Info.Background = System.Windows.Media.Brushes.Black;
                    fly_infor_wnd_show = false;
                }
            }
        }

        /*************************************************************************
        * 功   能：显示指点弹出窗口
        * 参   数：
        * 返   回：
        * **********************************************************************/
        public static bool fly_point_wnd_show = false;
        private void BTN_Show_FLy_Point_Click(object sender, RoutedEventArgs e)
        {
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();

            Window_Fly_Point m_wnd_fly_point = Window_Fly_Point.getInstance();
            m_wnd_fly_point.Show();

            Window_Fly_Point.mb_wnd_initializaed = true;
            Window_Fly_Point.mb_wnd_visible = true;

            if (MainWindow.map_show_type == 2)
            {
                Page_2D_Map.addptbool = 7;
            }
            else if (MainWindow.map_show_type == 3)
            {
                m_PageGoogleMap.webBrowser_google_earth.InvokeScript("setUAVLineState", new object[] { 5, 0 });
            }
        }

        /***********************************************************************************
        * 功   能：拍照Pos点信息下传
        * 参   数：
        * 返   回：
        * *********************************************************************************/
        public void Show_Pos_Information()
        {
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();
            Page_Version_Update m_PageVersionUpdate = Page_Version_Update.getInstance();

            PIC_POS mPic_Pos = DataProcess_JD.Get_Pic_Pos();

            double picPosLon = (double)(mPic_Pos.photoLongitude) * Math.Pow(10, -7);
            double picPosLat = (double)(mPic_Pos.photoLattitude) * Math.Pow(10, -7);
            double picPosAlt = mPic_Pos.gpsHeight * 0.1;
            ushort picPosSeq = mPic_Pos.photoSequence;

            byte years = mPic_Pos.years;
            byte month = mPic_Pos.month;
            byte days = mPic_Pos.days;
            byte hours = mPic_Pos.hours;
            byte min = mPic_Pos.min;
            ushort seconds = mPic_Pos.min_seconds;

            // 如果是拍照的时候，不是pos下载，则将拍照点添加在地图上
            if (Page_Version_Update.Read_Data_Type == 0)
            {
                if (MainWindow.map_show_type == 2)
                    AddPicPosOnMap(picPosSeq, picPosLon, picPosLat);
                else if (MainWindow.map_show_type == 3)
                {
                    m_PageGoogleMap.webBrowser_google_earth.InvokeScript("AddPicPos", new object[] { picPosLon, picPosLat, picPosAlt });
                }
            }
            // 如果是在下载pos点，则将POS点写入文件
            else if ((Page_Version_Update.Read_Data_Type == 2) && (Page_Version_Update.Req_Pic_Pos_Index == picPosSeq))//读取POS
            {
                Page_Version_Update.swrite_pos.WriteLine("{0,4}  {1,16}  {2,12}  {3,12}  {4,8}  {5,8}  {6,8}  {7,8} {8,4} ",
                                                picPosSeq,
                                                years.ToString() + "/" + month.ToString() + "/" + days.ToString() + " " + hours.ToString() + ":" + min.ToString() + ":" + seconds.ToString(),
                                                picPosLon,
                                                picPosLat,
                                                (double)mPic_Pos.gpsHeight * 0.1,
                                                (double)mPic_Pos.rollAngle * 0.1,
                                                (double)mPic_Pos.pitchAngle * 0.1,
                                                (double)mPic_Pos.yawAngle * 0.1,
                                                mPic_Pos.rtk);
                // 有POS数据达到，则将请求索引+1，同时将请求次数清零
                Page_Version_Update.Req_Pic_Pos_Index = (ushort)(picPosSeq + 1);
                Page_Version_Update.Req_Pic_Pos_Count = 0;

                // 显示POS读取进度
                m_PageVersionUpdate.ProgressBar_Download_Pos.Value = (double)picPosSeq / mPic_Pos.num_all;
                m_PageVersionUpdate.TextBlock_Pos_Percent.Text = (picPosSeq * 100 / mPic_Pos.num_all).ToString() + "%";

                // 如果收到的索引等于POS总数，则说明下载完成，关闭写文件，关闭时钟
                if (picPosSeq == mPic_Pos.num_all)
                {
                    Page_Version_Update.swrite_pos.Close();
                    Page_Version_Update.Read_Data_Type = 0;
                    Page_Version_Update.timer_read_log_pos.Stop();
                }
            }
        }

        /***********************************************************************************
        * 功   能：将拍照点添加在地图上
        * 
        * ********************************************************************************/
        private void AddPicPosOnMap(ushort argPicPosIndex, double argPicPosLon, double argPicPosLat)
        {
            PointLatLng point = new PointLatLng(argPicPosLat, argPicPosLon);
            GMapMarkerWP m;

            m = new GMapMarkerWP(point, argPicPosIndex.ToString(), GMarkerGoogleType.yellow_small, 3);
            m.Tag = argPicPosIndex.ToString();

            GMapMarkerRect mBorders = new GMapMarkerRect(point);
            {
                mBorders.InnerMarker = m;
                mBorders.Tag = argPicPosIndex.ToString();
            }

            Page_2D_Map.PicPos_Layer.Markers.Add(mBorders);
            Page_2D_Map.PicPos_Layer.Markers.Add(m);
        }

        /***********************************************************************************
        * 功   能：显示禁飞区
        * 参   数：
        * 返   回：
        * *********************************************************************************/
        private void Show_Forbidden_Area()
        {
            No_FLy_Zone mNoFlyZone = No_FLy_Zone.getInstance();

            for (int i = 0; i < 192; i++)
            {
                List<PointLatLng> Points_Temp = new List<PointLatLng>();
                Points_Temp.Add(new PointLatLng((double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 0, 1]) / 10000000, (double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 0, 0]) / 10000000));
                Points_Temp.Add(new PointLatLng((double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 1, 1]) / 10000000, (double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 1, 0]) / 10000000));
                Points_Temp.Add(new PointLatLng((double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 2, 1]) / 10000000, (double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 2, 0]) / 10000000));
                Points_Temp.Add(new PointLatLng((double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 3, 1]) / 10000000, (double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 3, 0]) / 10000000));
                Points_Temp.Add(new PointLatLng((double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 4, 1]) / 10000000, (double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 4, 0]) / 10000000));
                Points_Temp.Add(new PointLatLng((double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 5, 1]) / 10000000, (double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 5, 0]) / 10000000));
                Points_Temp.Add(new PointLatLng((double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 6, 1]) / 10000000, (double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 6, 0]) / 10000000));
                Points_Temp.Add(new PointLatLng((double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 7, 1]) / 10000000, (double)(mNoFlyZone.NO_FLY_ZONE_OCTANGON[i, 7, 0]) / 10000000));

                Page_2D_Map.Add_No_Fly_Area(Points_Temp);
            }
        }

        /***********************************************************************************
        * 功   能：显示IMU姿态信息
        * 参   数：
        * 返   回：
        * *********************************************************************************/
        public static bool b_plane_exist = false;
        double[] lon_buf = new double[3];
        double[] lat_buf = new double[3];
        public double lon_average = 0, lat_average = 0;
        public void Show_Imu_Type0()
        {
            byte sys_id_set = DATA_LINK.Get_System_Set_Id();
            byte sys_id_recv = DATA_LINK.Get_System_Recv_Id();

            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();
            FLY_INFOR_DISPLAY mFly_Infor_Display = DataProcess_JD.Get_Fly_Display(sys_id_recv);

            double lonTemp = 0, latTemp = 0;
            double lonTemp1 = 0, latTemp1 = 0, lonTemp2 = 0, latTemp2 = 0;
            double ldistOwnToProject = 0, ldistOwnToProject2 = 0;
            double preWptLon_Temp, preWptLat_Temp, preWptLon_Temp2, preWptLat_Temp2;
            double tarWptLon_Temp, tarWptLat_Temp, tarWptLon_Temp2, tarWptLat_Temp2;

            b_plane_exist = true;
            reciveImuCount++;

            List<WAY_POINT> wpt_list = null;
            if (Window_Skyway.Get_Cur_SkyWay() != null)
                wpt_list = Window_Skyway.Get_Cur_SkyWay().wayPointSet;

            // ====================== show all planes' position on the map =====================
            if (App.single_many_type == 0)
            {
                // 如果进入了解算，则使用解算位置
                if ((mFly_Infor_Display.ins_flag & 0x0f) == (byte)1 || (mFly_Infor_Display.ins_flag & 0x0f) == (byte)2)
                {
                    if (mFly_Infor_Display.fly_mode == 15 && wpt_list != null && wpt_list.Count >= mFly_Infor_Display.target_wpt_index && mFly_Infor_Display.target_wpt_index > 1)
                    {
                        int tarWptIndex_Temp = mFly_Infor_Display.target_wpt_index;

                        // 计算飞机在当前航线的投影
                        preWptLon_Temp = wpt_list[tarWptIndex_Temp - 2].lon;
                        preWptLat_Temp = wpt_list[tarWptIndex_Temp - 2].lat;

                        tarWptLon_Temp = wpt_list[tarWptIndex_Temp - 1].lon;
                        tarWptLat_Temp = wpt_list[tarWptIndex_Temp - 1].lat;

                        // 计算飞机在航线上的投影
                        double kx = (tarWptLat_Temp - preWptLat_Temp) / (tarWptLon_Temp - preWptLon_Temp);
                        lonTemp1 = (kx * preWptLon_Temp + mFly_Infor_Display.imu_jiesuan_lon / kx + mFly_Infor_Display.imu_jiesuan_lat - preWptLat_Temp) / (kx + 1 / kx);
                        latTemp1 = (mFly_Infor_Display.imu_jiesuan_lat) - 1 / kx * (lonTemp1 - mFly_Infor_Display.imu_jiesuan_lon);

                        // 计算投影点和飞机实际之间的距离
                        ldistOwnToProject = Math.Sqrt((lonTemp1 - mFly_Infor_Display.imu_jiesuan_lon) * (lonTemp1 - mFly_Infor_Display.imu_jiesuan_lon)
                                                                        + (latTemp1 - mFly_Infor_Display.imu_jiesuan_lat) * (latTemp1 - mFly_Infor_Display.imu_jiesuan_lat)) * 10000000;

                        // 计算飞机在上一条航线的投影，这里主要是为了在转弯处的显示
                        if (tarWptIndex_Temp >= 3)
                        {
                            // 计算飞机在上一条航线
                            preWptLon_Temp2 = wpt_list[tarWptIndex_Temp - 3].lon;
                            preWptLat_Temp2 = wpt_list[tarWptIndex_Temp - 3].lat;

                            tarWptLon_Temp2 = wpt_list[tarWptIndex_Temp - 2].lon;
                            tarWptLat_Temp2 = wpt_list[tarWptIndex_Temp - 2].lat;

                            // 计算飞机在航线上的投影
                            double kx2 = (tarWptLat_Temp2 - preWptLat_Temp2) / (tarWptLon_Temp2 - preWptLon_Temp2);
                            lonTemp2 = (kx2 * preWptLon_Temp2 + (mFly_Infor_Display.imu_jiesuan_lon) / kx2 + (mFly_Infor_Display.imu_jiesuan_lat) - preWptLat_Temp2) / (kx2 + 1 / kx2);
                            latTemp2 = (mFly_Infor_Display.imu_jiesuan_lat) - 1 / kx2 * (lonTemp2 - mFly_Infor_Display.imu_jiesuan_lon);

                            // 计算投影点和飞机实际之间的距离
                            ldistOwnToProject2 = Math.Sqrt((lonTemp2 - mFly_Infor_Display.imu_jiesuan_lon) * (lonTemp2 - mFly_Infor_Display.imu_jiesuan_lon)
                                                                            + (latTemp2 - mFly_Infor_Display.imu_jiesuan_lat) * (latTemp2 - mFly_Infor_Display.imu_jiesuan_lat)) * 10000000;

                            // 在哪条航线上的投影距离短，则选择哪个投影点显示
                            if (ldistOwnToProject < ldistOwnToProject2)
                            {
                                lonTemp = lonTemp1;
                                latTemp = latTemp1;
                            }
                            else
                            {
                                lonTemp = lonTemp2;
                                latTemp = latTemp2;
                            }
                        }
                        else
                        {
                            lonTemp = lonTemp1;
                            latTemp = latTemp1;
                        }

                        // 如果距离 < 5米，则将飞机投影到航线上
                        if (ldistOwnToProject < 500)
                        {
                            // 如果飞机在航点的附近，并且速度小于1.5m/s， 说明是定点悬停模式
                            if (mFly_Infor_Display.imu_shuipingsudu < 2)
                            {
                                double distToTarWpt = Math.Sqrt((lonTemp1 - tarWptLon_Temp) * (lonTemp1 - tarWptLon_Temp) + (latTemp1 - tarWptLat_Temp) * (latTemp1 - tarWptLat_Temp)) * 10000000;
                                double distToPreTarWpt = Math.Sqrt((lonTemp1 - preWptLon_Temp) * (lonTemp1 - preWptLon_Temp) + (latTemp1 - preWptLat_Temp) * (latTemp1 - preWptLat_Temp)) * 10000000;
                                if (distToTarWpt < 200)
                                {
                                    lonTemp = tarWptLon_Temp;
                                    latTemp = tarWptLat_Temp;
                                }
                                else if (distToPreTarWpt < 200)
                                {
                                    lonTemp = preWptLon_Temp;
                                    latTemp = preWptLat_Temp;
                                }
                            }
                        }
                        else    // 否则，将飞机的实际位置进行显示
                        {
                            lonTemp = mFly_Infor_Display.imu_jiesuan_lon;
                            latTemp = mFly_Infor_Display.imu_jiesuan_lat;
                        }
                    }
                    else
                    {
                        lonTemp = mFly_Infor_Display.imu_jiesuan_lon;
                        latTemp = mFly_Infor_Display.imu_jiesuan_lat;
                    }
                }
                // 初始化上电时，显示原始GPS的数值
                else if (mFly_Infor_Display.gps_num > 5)
                {
                    lonTemp = mFly_Infor_Display.gps_lon;
                    latTemp = mFly_Infor_Display.gps_lat;
                }

                //对位置进行平均
                int i = 0;
                for (i = 0; i < 2; i++)
                {
                    lon_buf[i] = lon_buf[i + 1];
                    lat_buf[i] = lat_buf[i + 1];
                }
                lon_buf[2] = lonTemp;
                lat_buf[2] = latTemp;

                if ((lon_buf[0] != 0) && (lat_buf[0] != 0))
                {
                    lon_average = (lon_buf[0] + lon_buf[1] + lon_buf[2]) / 3;
                    lat_average = (lat_buf[0] + lat_buf[1] + lat_buf[2]) / 3;
                }
                else
                {
                    lon_average = lonTemp;
                    lat_average = latTemp;
                }
            }
            else
            {
                lon_average = mFly_Infor_Display.imu_jiesuan_lon;
                lat_average = mFly_Infor_Display.imu_jiesuan_lat;
            }

            // 地图上显示位置
            double yawTemp = mFly_Infor_Display.imu_hangxiangjiao;
            double rollTemp = mFly_Infor_Display.imu_henggunjiao;
            double pitchTemp = mFly_Infor_Display.imu_fuyangjiao;

            if (mFly_Infor_Display.gps_num >= 8 && Math.Abs(lon_average) > 0.0000001 && Math.Abs(lat_average) > 0.0000001)
            {
                if (MainWindow.map_show_type == 2)
                {
                    PointLatLng portlocation = new PointLatLng();
                    portlocation.Lat = lat_average;
                    portlocation.Lng = lon_average;

                    Page_2D_Map.Add_Plane_On_2D_Map(sys_id_recv, portlocation, (float)yawTemp, (float)mFly_Infor_Display.imu_jisuan_gaodu, (float)mFly_Infor_Display.imu_shuipingsudu);
                }
                else if (MainWindow.map_show_type == 3)
                {
                    if (Page_Google_Map.initmap == true)
                    {
                        yawTemp = yawTemp + 180;
                        if (yawTemp > 180)
                            yawTemp = yawTemp - 360;
                        else if (yawTemp <= -180)
                            yawTemp = yawTemp + 360;
                        m_PageGoogleMap.webBrowser_google_earth.InvokeScript("updataCraftLocation", new object[] {
                            lon_average, lat_average, Math.Round(mFly_Infor_Display.imu_jisuan_gaodu,1), yawTemp, pitchTemp, rollTemp, 0, 1});
                    }
                }
            }

            mFly_Infor_Display = DataProcess_JD.Get_Fly_Display(sys_id_set);
            TextBlock_Alt.Text = TryFindResource("TITLE_ALTITUDE") + ": " + mFly_Infor_Display.imu_jisuan_gaodu.ToString("0.0") + " " + "m ";
            // 速度显示
            TextBlock_Speed.Text = TryFindResource("TITLE_HORIZONTAL_VEL_STATIC") + " " + mFly_Infor_Display.imu_shuipingsudu.ToString("0.0") + " m/s";
            // 爬升速度 
            TextBlock_Climb_Rate.Text = TryFindResource("TITLE_VERTICAL_VEL_STATIC") + " " + mFly_Infor_Display.imu_chuizhisudu.ToString("0.0") + " m/s";
            // 目标航点
            TextBlock_Target_Wpt.Text = TryFindResource("TITLE_TARGET_WPT_NUM") + " " + mFly_Infor_Display.target_wpt_index.ToString() + "/" + mFly_Infor_Display.total_wpt_count.ToString();
            // 航点距离
            TextBlock_Target_Wpt_Dist.Text = TryFindResource("TITLE_TARGET_WPT_DIST") + " " + (mFly_Infor_Display.target_wpt_dist).ToString("0.0") + " m";
        }


        /***********************************************************************************
     * 功   能：显示垂起IMU姿态
     * 参   数：
     * 返   回：
     * *********************************************************************************/
        public void Show_Imu_Type1()
        {
            byte sys_id_set = DATA_LINK.Get_System_Set_Id();
            byte sys_id_recv = DATA_LINK.Get_System_Recv_Id();

            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();
            FLY_INFOR_DISPLAY mFly_Infor_Display = DataProcess_JD.Get_Fly_Display(sys_id_recv);

            double lonTemp = 0, latTemp = 0;

            b_plane_exist = true;
            reciveImuCount++;

            // 如果进入了解算，则使用解算位置
            if ((mFly_Infor_Display.ins_flag & 0x0f) == (byte)1 || (mFly_Infor_Display.ins_flag & 0x0f) == (byte)2)
            {
                lonTemp = mFly_Infor_Display.imu_jiesuan_lon;
                latTemp = mFly_Infor_Display.imu_jiesuan_lat;
            }
            // 初始化上电时，显示原始GPS的数值
            else if (mFly_Infor_Display.gps_num > 5)
            {
                lonTemp = mFly_Infor_Display.gps_lon;
                latTemp = mFly_Infor_Display.gps_lat;
            }

            // 地图上显示位置
            double yawTemp = mFly_Infor_Display.imu_hangxiangjiao;
            double rollTemp = mFly_Infor_Display.imu_henggunjiao;
            double pitchTemp = mFly_Infor_Display.imu_fuyangjiao;

            if (mFly_Infor_Display.gps_num > 5 && Math.Abs(lonTemp) > 0.0000001 && Math.Abs(latTemp) > 0.0000001)
            {
                if (MainWindow.map_show_type == 2)
                {
                    PointLatLng portlocation = new PointLatLng();
                    portlocation.Lat = latTemp;
                    portlocation.Lng = lonTemp;

                    Page_2D_Map.Add_Plane_On_2D_Map(sys_id_recv, portlocation, (float)yawTemp, (float)mFly_Infor_Display.imu_jisuan_gaodu, (float)mFly_Infor_Display.imu_kongsu);
                }
                else if (MainWindow.map_show_type == 3)
                {
                    if (Page_Google_Map.initmap == true)
                    {
                        yawTemp = yawTemp + 180;
                        if (yawTemp > 180)
                            yawTemp = yawTemp - 360;
                        else if (yawTemp <= -180)
                            yawTemp = yawTemp + 360;
                        m_PageGoogleMap.webBrowser_google_earth.InvokeScript("updataCraftLocation", new object[] {
                            lon_average, lat_average, Math.Round(mFly_Infor_Display.imu_jisuan_gaodu,1), yawTemp, pitchTemp, rollTemp, 0, 1});
                    }
                }
            }

            mFly_Infor_Display = DataProcess_JD.Get_Fly_Display(sys_id_set);

            TextBlock_Alt.Text = TryFindResource("TITLE_ALTITUDE") + ": " + mFly_Infor_Display.imu_jisuan_gaodu.ToString("0.0") + " " + "m ";
            // 速度显示
            TextBlock_Speed.Text = "空速:" + " " + (mFly_Infor_Display.imu_kongsu).ToString("0.0") + " m/s";
            // 爬升速度 
            TextBlock_Climb_Rate.Text = TryFindResource("TITLE_VERTICAL_VEL_STATIC") + " " + mFly_Infor_Display.imu_chuizhisudu.ToString("0.0") + " m/s";
            // 目标航点
            TextBlock_Target_Wpt.Text = TryFindResource("TITLE_TARGET_WPT_NUM") + " " + mFly_Infor_Display.target_wpt_index.ToString() + "/" + mFly_Infor_Display.total_wpt_count.ToString();
            // 航点距离
            TextBlock_Target_Wpt_Dist.Text = TryFindResource("TITLE_TARGET_WPT_DIST") + " " + mFly_Infor_Display.target_wpt_dist.ToString("0.0") + " m";
        }
        /***********************************************************************************
        function:   show gps information
        para:
        return:
         * ********************************************************************************/
        public void Show_Gps_Information(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            string str_temp;
            // 如果使用主GPS或者差分GPS，则显示白色
            if ((byte)(mFly_Infor_Display.gps_status & 0x04) == (byte)0x04)
                str_temp = "GPS-B: ";
            else
                str_temp = "GPS-A: ";

            // GPS状态信息
            if (mFly_Infor_Display.rtk_status == 1)
            {
                TextBlock_Gps.Text = str_temp + "RTK " + mFly_Infor_Display.gps_num.ToString();
            }
            else
            {
                TextBlock_Gps.Text = str_temp + mFly_Infor_Display.gps_num.ToString();
            }
            // show ant1/ant2/m8n gps num
            Window_Gps_Num.getInstance().UpdateInfor();
        }

        /***********************************************************************************
        * 功   能：显示多旋翼飞行状态
        * 参   数：
        * 返   回：
        * *********************************************************************************/
        private void Show_MM_FlyMode(byte fly_mode)
        {
            switch (fly_mode)
            {
                case 3:            // 遥控器姿态模式
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  姿态";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Attitude";
                    break;
                case 4:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  GPS位置";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  GPS";
                    break;
                case 5:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  智能机头";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Headless";
                    break;
                case 6:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  环绕";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Circle";
                    break;
                case 7:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  返航";
                    if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Return";
                    break;
                case 8:            // 摇杆姿态模式
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  摇杆姿态";
                    if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Rocker Attitude";
                    break;
                case 9:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  摇杆GPS";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Rocker GPS";
                    break;
                case 10:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  自动起飞";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Take Off";
                    break;
                case 11:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  GCS悬停";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  GCS Hover";
                    break;
                case 12:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  GCS返航";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  GCS Return";
                    break;
                case 13:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  自动航线";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Wpt Cruise";
                    break;
                case 14:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  断点续飞";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Break-Go";
                    break;
                case 15:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  自动航线";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Wpt Cruise";
                    break;
                case 16:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  继续航线";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Resume Wpt";
                    break;
                case 17:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  指点飞行";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  FLy to Point";
                    break;
                case 18:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  指点飞行";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  FLy to Point";
                    break;
                case 19:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  一键降落";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Auto Landing";
                    break;
                case 20:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  紧急迫降";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Emergent Landing";
                    break;
                case 21:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  跟随飞行";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Follow Fly";
                    break;
                case 22:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  抛物";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Throwing";
                    break;
                case 23:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  环绕";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Circle";
                    break;
                default:
                    break;
            }
        }

        /***********************************************************************************
        * 功   能：显示固定翼飞行模式
        * 参   数：
        * 返   回：
        * *********************************************************************************/
        private void Show_FW_FlyMode(byte fly_mode)
        {
            switch (fly_mode)
            {
                case 3:            // 遥控器姿态模式
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  旋翼姿态";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Multi-M Attitude";
                    break;
                case 4:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  旋翼GPS位置";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Multi-M GPS";
                    break;
                case 10:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  自动起飞";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Auto Take Off";
                    break;
                case 11:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  悬停";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Hover";
                    break;
                case 12:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  返航";
                    if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Return";
                    break;
                case 40:            // 摇杆姿态模式
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  待命";
                    if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Default";
                    break;
                case 41:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  固定翼手动";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  FW Manual";
                    break;
                case 42:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式: 固定翼半自动";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  FW Semi-Auto";
                    break;
                case 43:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  巡航";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Cruise";
                    break;
                case 44:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  盘旋";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Circle";
                    break;
                case 45:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  降落航线";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Landing Wpt";
                    break;
                case 46:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  指点飞行";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Fly to Point";
                    break;
                case 47:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  降落";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Landing";
                    break;
                case 48:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  丢星";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  GPS Lost";
                    break;
                case 49:
                    if (App.language_type == 0)
                        TextBlock_Fly_Mode.Text = "飞行模式:  去往应急点";
                    else if (App.language_type == 1)
                        TextBlock_Fly_Mode.Text = "Fly Mode:  Emergency";
                    break;
                default:
                    break;
            }
        }


        /***********************************************************************************
        * 功   能：显示飞行状态
        * 参   数：
        * 返   回：
        * *********************************************************************************/
        private byte fly_mode_last = 0;
        private byte status_infor_arrive_count = 10;
        public void Show_Fly_Status(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            if (App.plane_type == 0)
                Show_MM_FlyMode(mFly_Infor_Display.fly_mode);
            else
                Show_FW_FlyMode(mFly_Infor_Display.fly_mode);

            // voice to indicate the fly mode
            if (mFly_Infor_Display.fly_mode != fly_mode_last && MainWindow.enable_voice == true)
            {
                MainWindow.Speaker.SpeakAsyncCancelAll();
                MainWindow.Speaker.SpeakAsync(TextBlock_Fly_Mode.Text);
            }
            fly_mode_last = mFly_Infor_Display.fly_mode;

            // show adc0 and adc1
            if(show_volt_index == 0)
                TextBlock_Battery_Volt.Text = TryFindResource("TITLE_VOLT_STATIC") + " " + mFly_Infor_Display.batter_volt.ToString("0.0") + " V";
            else
                TextBlock_Battery_Volt.Text = "ADC2:" + " " + mFly_Infor_Display.adc1_volt.ToString("0.0") + " V";

            status_infor_arrive_count++;
            if (status_infor_arrive_count >= 100)
            {
                status_infor_arrive_count = 0;
                if (MainWindow.enable_voice == true)
                {
                    string str_speek = "";
                    if (App.plane_type == 0)
                    {
                        str_speek = "电压" + (mFly_Infor_Display.batter_volt).ToString("0.0") + "伏" + "    高度" + mFly_Infor_Display.imu_jisuan_gaodu.ToString("0.0") + "米"
                                                        + "    速度" + ((double)mFly_Infor_Display.imu_shuipingsudu).ToString("0.0") + " 米每秒";
                    }
                    else if (App.plane_type == 1)
                    {
                        str_speek = "电压" + (mFly_Infor_Display.batter_volt).ToString("0.0") + "伏" + "    高度" + mFly_Infor_Display.imu_jisuan_gaodu.ToString("0.0") + "米"
                                + "    空速" + ((double)mFly_Infor_Display.imu_kongsu).ToString("0.0") + " 米每秒";
                    }

                    MainWindow.Speaker.SpeakAsync(str_speek);
                }
            }
        }

        /*****************************************************************
        * 功   能：显示云台控制窗口
        * 参   数：
        * 返   回：
        * **************************************************************/
        public static bool chart_wnd_show = false;
        private void BTN_Show_Wnd_Chat_Click(object sender, RoutedEventArgs e)
        {
            if (Window_Chart.mb_wnd_visible == false)
            {
                Window_Chart.getInstance().Show_Wnd();
                GRID_Show_Wnd_Chat.Background = System.Windows.Media.Brushes.Orange;
            }
            else
            {
                Window_Chart.getInstance().Hide_Wnd();
                GRID_Show_Wnd_Chat.Background = System.Windows.Media.Brushes.Black;
            }
        }

        /*****************************************************************
        * 功   能：打开数据回放窗口
        * 参   数：
        * 返   回：
        * **************************************************************/
        private void BTN_REPLAY_Click(object sender, RoutedEventArgs e)
        {
            Window_Replay.getInstance().Show_Wnd();
        }


        private void BTN_DOWNLOAD_MAP_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map m_Page2DMap = Page_2D_Map.getInstance();

            PointLatLng LeftTop = m_Page2DMap.gMap_2D.FromLocalToLatLng((int)(-SystemParameters.PrimaryScreenWidth + SystemParameters.PrimaryScreenWidth), (int)(-SystemParameters.PrimaryScreenHeight + SystemParameters.PrimaryScreenHeight));
            PointLatLng RightTop = m_Page2DMap.gMap_2D.FromLocalToLatLng((int)(2 * SystemParameters.PrimaryScreenWidth - SystemParameters.PrimaryScreenWidth), (int)(-SystemParameters.PrimaryScreenHeight + SystemParameters.PrimaryScreenHeight));
            PointLatLng RightBottom = m_Page2DMap.gMap_2D.FromLocalToLatLng((int)(2 * SystemParameters.PrimaryScreenWidth - SystemParameters.PrimaryScreenWidth), (int)(2 * SystemParameters.PrimaryScreenHeight - SystemParameters.PrimaryScreenHeight));
            PointLatLng LeftBottom = m_Page2DMap.gMap_2D.FromLocalToLatLng((int)(-SystemParameters.PrimaryScreenWidth + SystemParameters.PrimaryScreenWidth), (int)(2 * SystemParameters.PrimaryScreenHeight - SystemParameters.PrimaryScreenHeight));

            //Path.DirectorySeparatorChar;
            RectLatLng area = new RectLatLng(LeftTop.Lat, LeftTop.Lng, Math.Abs(RightBottom.Lng - LeftTop.Lng), Math.Abs(RightBottom.Lat - LeftTop.Lat));

            if (!area.IsEmpty)
            {
                DownloadMap(area);
                /*for (int i = (int)m_Page2DMap.gMap_2D.Zoom; i <= 20; i++)
                {
                    MessageBoxResult res = System.Windows.MessageBox.Show(TryFindResource("TITLE_PREPARE_DOWN_LOAD").ToString() + i + TryFindResource("TITLE_GRADE").ToString(), TryFindResource("TITLE_OFF_LINE_DOWN_LOAD").ToString(), MessageBoxButton.YesNoCancel);

                    if (res == MessageBoxResult.Yes)
                    {
                        TilePrefetcher obj = new TilePrefetcher();
                        obj.ShowCompleteMessage = true;
                        obj.Start(area, i, m_Page2DMap.gMap_2D.MapProvider, 100, 100);
                    }
                    else if (res == MessageBoxResult.No)
                    {
                        continue;
                    }
                    else if (res == MessageBoxResult.Cancel)
                    {
                        break;
                    }
                }*/
            }
            else
            {
                System.Windows.MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private TileDownloader tileDownloader = new TileDownloader(5);
        private string tilePath = "D:\\GisMap";
        private int retryNum = 3;
        private void DownloadMap(RectLatLng area)
        {
            if (area != null)
            {
                if (!tileDownloader.IsComplete)
                {
                    //CommonTools.MessageBox.ShowWarningMessage("正在下载地图，等待下载完成！");
                }
                else
                {

                    try
                    {
                        Page_2D_Map m_Page2DMap = Page_2D_Map.getInstance();
                        DownloadCfgForm downloadCfgForm = new DownloadCfgForm(area, m_Page2DMap.gMap_2D.MapProvider);

                        if (downloadCfgForm.ShowDialog() == DialogResult.OK)
                        {
                            TileDownloaderArgs downloaderArgs = downloadCfgForm.GetDownloadTileGPoints();
                            // ResetToServerAndCacheMode();


                            tileDownloader.TilePath = this.tilePath;

                            tileDownloader.Retry = retryNum;
                            tileDownloader.PrefetchTileStart += new EventHandler<TileDownloadEventArgs>(tileDownloader_PrefetchTileStart);
                            tileDownloader.PrefetchTileProgress += new EventHandler<TileDownloadEventArgs>(tileDownloader_PrefetchTileProgress);
                            tileDownloader.PrefetchTileComplete += new EventHandler<TileDownloadEventArgs>(tileDownloader_PrefetchTileComplete);
                            tileDownloader.StartDownload(downloaderArgs);
                        }
                    }
                    catch (Exception r)
                    {
                        // MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // log.Error(ex);
                    }
                }
            }
            else
            {
                // CommonTools.MessageBox.ShowTipMessage("请先用画图工具画下载的区域多边形或选择省市区域！");
            }
        }
        void tileDownloader_PrefetchTileComplete(object sender, TileDownloadEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("地图下载完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            // ShowDownloadTip(false);
        }

        private delegate void UpdateDownloadProress(int completedCount, int totalCount);

        private void UpdateDownloadBar(int completedCount, int totalCount)
        {
            //if (this.toolStripProgressBarDownload.Visible)
            {
                int value = completedCount * 100 / totalCount;
                string srtTemp = string.Format("下载进度：{0}/{1}", completedCount, totalCount);
                MessageTimerWindow.Update_Data(srtTemp);
                //this.toolStripProgressBarDownload.Value = value;
            }
        }

        void tileDownloader_PrefetchTileProgress(object sender, TileDownloadEventArgs e)
        {
            if (e != null)
            {
                // if (this.IsDisposed || !this.IsHandleCreated) return;
                Dispatcher.Invoke(new UpdateDownloadProress(UpdateDownloadBar), e.TileCompleteNum, e.TileAllNum);
            }
        }

        void tileDownloader_PrefetchTileStart(object sender, TileDownloadEventArgs e)
        {
            // ShowDownloadTip(true);
        }

        /*****************************************************************
        * 功   能：打开视频显示窗口
        * 参   数：
        * 返   回：
        * **************************************************************/
        public static Form1 formWnd;
        private void BTN_Show_Vedio_Click(object sender, RoutedEventArgs e)
        {
            if (formWnd == null)
            {
                formWnd = new Form1();
                System.Windows.Interop.WindowInteropHelper helper = new System.Windows.Interop.WindowInteropHelper(MainWindow.getInstance());
                formWnd.Show();

                Window_Video_Control.getInstance().Show_Wnd();
            }
        }

        /*****************************************************************
        * 功   能：删除POS点
        * 参   数：
        * 返   回：
        * **************************************************************/
        private void BTN_GPS_FOLLOW_Click(object sender, RoutedEventArgs e)
        {
            Window_Gps_Follow.Wnd_Show();

            string[] portsName = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(portsName);
            Window_Gps_Follow.getInstance().combox_follow.ItemsSource = portsName;

            Window_Gps_Follow.get_dist_status = 3;
        }

        /*************************************************************************
        * function: open the keyboard control window
        * para:
        * return:
        * ***********************************************************************/
        private void BTN_KEYBOARD_SHIFT_Click(object sender, RoutedEventArgs e)
        {
            Window_Confirm mWndConfirm = Window_Confirm.getInstance();
            mWndConfirm.ShowDialog();

            if (mWndConfirm.Yes_No == false)
            {
                return;
            }

            Window_Hover_Shift m_wnd_hover_shift = Window_Hover_Shift.getInstance();

            Window_Hover_Shift.timer_keyboard.Start();
            Window_Hover_Shift.keyboard_control_count = 0;
            Window_Hover_Shift.Init_rock();

            m_wnd_hover_shift.ShowDialog();
        }

        private void BTN_SET_HOME_Click(object sender, RoutedEventArgs e)
        {
            Window_Set_Home.Wnd_Show();

            Page_2D_Map.addptbool = 5;
        }

        /*****************************************************************
        * 功   能：机头指向兴趣点
        * 参   数：
        * 返   回：
        * **************************************************************/
        private void BTN_HEAD_TO_POINT_Click(object sender, RoutedEventArgs e)
        {
            Window_Head_To_Pt.Wnd_Show();

            Page_2D_Map.addptbool = 6;
        }

        private void TextBlock_Gps_LMouse_Down(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Window_Gps_Num.mb_wnd_initializaed == false)
            {
                Window_Gps_Num.Wnd_Show();
            }
            else
            {
                if (Window_Gps_Num.mb_wnd_visible == true)
                {
                    Window_Gps_Num.getInstance().Hide();
                    Window_Gps_Num.mb_wnd_visible = false;
                }
                else
                {
                    Window_Gps_Num.getInstance().Show();
                    Window_Gps_Num.mb_wnd_visible = true;
                }
            }
        }

        public static byte change_target_type = 0;
        private void TextBlock_Alt_LMouse_Down(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window_Target m_wnd_target = Window_Target.getInstance();
            m_wnd_target.Show();

            m_wnd_target.TextBlock_Target_Value.Text = TryFindResource("TITLE_CHANGE_ALT").ToString();
            m_wnd_target.TextBlock_Target_Unit.Text = "m";
            m_wnd_target.BTN_TARGET_CANCEL.Content = TryFindResource("TITLE_CANCEL_CHANGE_ALT").ToString();
            change_target_type = 1;
        }

        private void TextBlock_Speed_LMouse_Down(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window_Target m_wnd_target = Window_Target.getInstance();
            m_wnd_target.Show();

            m_wnd_target.TextBlock_Target_Value.Text = TryFindResource("TITLE_CHANGE_SPEED").ToString();
            m_wnd_target.TextBlock_Target_Unit.Text = "m/s";
            m_wnd_target.BTN_TARGET_CANCEL.Content = TryFindResource("TITLE_CANCEL_CHANGE_SPEED").ToString();
            change_target_type = 2;
        }

        private void TextBlock_Target_Wpt_LMouse_Down(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window_Target m_wnd_target = Window_Target.getInstance();
            m_wnd_target.Show();

            m_wnd_target.TextBlock_Target_Value.Text = TryFindResource("TITLE_CHANGE_WPT").ToString();
            m_wnd_target.TextBlock_Target_Unit.Text = "";
            m_wnd_target.BTN_TARGET_CANCEL.Visibility = Visibility.Hidden;
            change_target_type = 3;
        }

        private void BTN_ENGINE_INFOR_Click(object sender, RoutedEventArgs e)
        {
            if (Window_Engine.mb_wnd_visible == false)
            {
                Window_Engine.Wnd_Show();
                GRID_ENGINE_INFOR.Background = System.Windows.Media.Brushes.Orange;
            }
            else
            {
                Window_Engine.Wnd_Hide();
                GRID_ENGINE_INFOR.Background = System.Windows.Media.Brushes.Black;
            }
        }

        private byte show_volt_index = 0;
        private void TextBlock_Battery_Volt_Down(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (show_volt_index == 0)
                show_volt_index = 1;
            else
                show_volt_index = 0;
        }

        private void TextBlock_Target_Wpt_Dist_LMouse_Down(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window_Target m_wnd_target = Window_Target.getInstance();
            m_wnd_target.Show();

            m_wnd_target.TextBlock_Target_Value.Text = TryFindResource("TITLE_WPT_CIRCLE_TIMES").ToString();
            m_wnd_target.TextBlock_Target_Unit.Text = "Circles";
            m_wnd_target.BTN_TARGET_CANCEL.Visibility = Visibility.Hidden;
            change_target_type = 4;
        }
    }
}
