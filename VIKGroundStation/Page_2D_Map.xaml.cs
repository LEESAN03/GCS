using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MissionPlanner.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_2D_Map.xaml 的交互逻辑
    /// </summary>
    public partial class Page_2D_Map : Page
    {
        private static Page_2D_Map m_Page_2D_Map = new Page_2D_Map();
        public static Page_2D_Map getInstance()
        {
            if (m_Page_2D_Map == null)
                m_Page_2D_Map = new Page_2D_Map();

            return m_Page_2D_Map;
        }

        public MissionPlanner.Controls.myGMAP gMap_2D;
        System.Windows.Forms.Integration.WindowsFormsHost host;

        // ========================== 鼠标操作变量 ====================
        private PointLatLng MouseDownStart;

        private bool isLeftMouseDown = false;
        private bool isRightMouseDown = false;
        private bool isMouseDraging;

        internal PointLatLng MouseDownEnd;
        internal PointLatLng TouchDownEnd;

        private static List<PointLatLngAlt> MeasureDistListOnMap = new List<PointLatLngAlt>();
        private static List<PointLatLngAlt> boundPtListOnMap = new List<PointLatLngAlt>();

        private static List<PointLatLng> measurePoints = new List<PointLatLng>();
        public static List<PointLatLng> Drag_Area_Points = new List<PointLatLng>();  // 用来拖拽航点的矩形区域

        // =================== 地图上图层显示 ========================

        public static GMapRoute route_hangji;// = new GMapRoute("track");
        private static GMapRoute route_dist_measure;// = new GMapRoute("track");
        private static GMapRoute route_bound;// = new GMapRoute("bound track");

        public static GMapOverlay ZhiDian_Layer;// = new GMapOverlay("polygons"); // where the track is drawn
        public static GMapOverlay FollowGps_Layer;// = new GMapOverlay("polygons"); // where the track is drawn

        public static GMapOverlay PicPos_Layer;// = new GMapOverlay();     // 拍照点图层 

        public static List<PLANE_STRUCT> m_plane_list = new List<PLANE_STRUCT>();

        public static GMapOverlay Route_Layer;// = new GMapOverlay();
        public static GMapOverlay Wpt_Drag_Layer;// = new GMapOverlay();
        public static GMapOverlay KML_Layer;// = new GMapOverlay();

        private static GMapOverlay Dist_Measure_Layer;// = new GMapOverlay();  // 距离测量图层
        private static GMapOverlay Bound_Layer;// = new GMapOverlay();  // 自动规划航线的边界图层
        private static GMapOverlay No_Fly_Layer;// = new GMapOverlay();

        public static GMapOverlay Home_Pos_Layer;
        public static GMapOverlay Hot_Point_Layer;
        private GMapMarkerRect CurentRectMarker;

        private Page_2D_Map()
        {
            InitializeComponent();

            gMap_2D = new MissionPlanner.Controls.myGMAP();
            host = new System.Windows.Forms.Integration.WindowsFormsHost();
            host.Child = gMap_2D;
            host.Visibility = Visibility.Visible;

            Grid_2D_Map.Children.Add(host);
            gMap_2D.BackColor = Color.Black;

            gMap_2D.Bearing = 0F;
            gMap_2D.CanDragMap = true;

            gMap_2D.EmptyTileColor = Color.Gray;
            gMap_2D.GrayScaleMode = true;

            gMap_2D.HelperLineOption = HelperLineOptions.DontShow;
            gMap_2D.LevelsKeepInMemmory = 5;
            gMap_2D.MarkersEnabled = true;

            gMap_2D.MaxZoom = 19;
            gMap_2D.MinZoom = 3;

            gMap_2D.MapProvider = GMapProviders.TiandituCache;

            gMap_2D.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            gMap_2D.Name = "gMap_2D";

            gMap_2D.NegativeMode = false;
            gMap_2D.PolygonsEnabled = true;

            gMap_2D.RetryLoadTile = 0;
            gMap_2D.RoutesEnabled = true;
            gMap_2D.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Fractional;
            gMap_2D.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            gMap_2D.ShowTileGridLines = false;
            gMap_2D.Zoom = 10;

            gMap_2D.Manager.Mode = AccessMode.ServerAndCache;

            route_bound = new GMapRoute("bound track");
            ZhiDian_Layer = new GMapOverlay("polygons"); // where the track is drawn
            FollowGps_Layer = new GMapOverlay("polygons"); // where the track is drawn
            PicPos_Layer = new GMapOverlay();     // 拍照点图层 

            Route_Layer = new GMapOverlay();
            Wpt_Drag_Layer = new GMapOverlay();
            KML_Layer = new GMapOverlay();

            Dist_Measure_Layer = new GMapOverlay();  // 距离测量图层
            Bound_Layer = new GMapOverlay();  // 自动规划航线的边界图层
            No_Fly_Layer = new GMapOverlay();

            Home_Pos_Layer = new GMapOverlay();
            Hot_Point_Layer = new GMapOverlay();

            // 加载显示图层
            gMap_2D.Overlays.Add(ZhiDian_Layer);
            gMap_2D.Overlays.Add(FollowGps_Layer);

            gMap_2D.Overlays.Add(Wpt_Drag_Layer);
            gMap_2D.Overlays.Add(KML_Layer);
            gMap_2D.Overlays.Add(Dist_Measure_Layer);
            gMap_2D.Overlays.Add(Bound_Layer);
            gMap_2D.Overlays.Add(No_Fly_Layer);
            gMap_2D.Overlays.Add(Home_Pos_Layer);
            gMap_2D.Overlays.Add(Hot_Point_Layer);

            route_hangji = new GMapRoute("track");
            route_dist_measure = new GMapRoute("track");
            route_hangji.Stroke = new System.Drawing.Pen(System.Drawing.Color.DeepSkyBlue, 3);
            route_dist_measure.Stroke = new System.Drawing.Pen(System.Drawing.Color.Red, 3);

            gMap_2D.MouseMove += MainMap_MouseMove;
            gMap_2D.MouseDown += MainMap_MouseDown;
            gMap_2D.MouseUp += MainMap_MouseUp;
            gMap_2D.MouseDoubleClick += MainMap_doubleCLick;

            gMap_2D.OnMarkerEnter += MainMap_OnMarkerEnter;
            gMap_2D.OnMarkerLeave += MainMap_OnMarkerLeave;
        }

        private void Page_2D_Map_Loaded(object sender, RoutedEventArgs e)
        {
            byte i = 0;
            if (Window_Skyway.m_sky_way_list.Count == 0)
            {
                for (i = 0; i < 10; i++)
                {
                    SKY_WAY skyway_temp = new SKY_WAY();

                    skyway_temp.sky_way_no = (byte)(i + 1);
                    Window_Skyway.m_sky_way_list.Add(skyway_temp);

                    gMap_2D.Overlays.Add(skyway_temp.Wpt_Layer);
                }
            }

            gMap_2D.Overlays.Add(Route_Layer);
            gMap_2D.Overlays.Add(PicPos_Layer);
            for (i = 0; i < 21; i++)
            {
                PLANE_STRUCT plane_struct_temp = new PLANE_STRUCT();

                plane_struct_temp.plane_id = i;
                plane_struct_temp.plane_data_count = 0;
                plane_struct_temp.plane_exist = false;
                plane_struct_temp.Plane_Layer = new GMapOverlay();

                gMap_2D.Overlays.Add(plane_struct_temp.Plane_Layer);
                m_plane_list.Add(plane_struct_temp);
            }
        }

        public  void Set_Map_Type(int map_type)
        {
            switch (map_type)
            {
                case 0:
                    gMap_2D.MapProvider = GMapProviders.AMapHybird;
                    break;
                case 1:
                    gMap_2D.MapProvider = GMapProviders.TdtImage;
                    break;
                case 2:
                    gMap_2D.MapProvider = GMapProviders.TiandituCache;
                    break;
                case 3:
                    gMap_2D.MapProvider = GMapProviders.BingHybridMap;
                    break;
                default:
                    break;
            }
        }

        public static byte addptbool = 0;   // 0：无功能  1：添加航点   2：添加航线拖拽矩形  3:距离测量  4：添加禁飞区  5: 设置返航点  6:指点飞行
        public static bool isMouseInDragArea = false;
        public static bool drag_area_exist = false;
        private static double drag_left_lon = 0, drag_right_lon = 0, drag_top_lat = 0, drag_bottom_lat = 0;
        /*******************************************************************************
        * 功   能：响应鼠标放开动作
        * 参   数：
        * 返   回：
        * *****************************************************************************/
        void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (!isLeftMouseDown)
            {
                if (item is GMapMarkerRect)
                {
                    CurentRectMarker = null;
                }
            }
        }

        /*******************************************************************************
        * 功   能：响应鼠标移动的函数
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        void MainMap_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PointLatLng point_temp = gMap_2D.FromLocalToLatLng(e.X, e.Y);

            if (MouseDownStart == point_temp)
                return;

            if (addptbool == 0 || addptbool == 1)
            {
                //draging
                if (e.Button == MouseButtons.Left && isLeftMouseDown)
                {
                    // 拖拽航点或地图
                    if (isMouseInDragArea == false)
                    {
                        isMouseDraging = true;
                        // 如果鼠标左键点击上了航点，则拖动航点
                        if (CurentRectMarker != null) // left click pan
                        {
                            CurentRectMarker.InnerMarker.Position = point_temp;
                        }
                        // 如果鼠标左键没有点击有效的Maker，则拖动地图
                        else // left click pan
                        {
                            double latdif = MouseDownStart.Lat - point_temp.Lat;
                            double lngdif = MouseDownStart.Lng - point_temp.Lng;

                            gMap_2D.Position = new PointLatLng(gMap_2D.Position.Lat + latdif, gMap_2D.Position.Lng + lngdif);
                        }
                    }
                }
            }
        }

        /*******************************************************************************
        * 功   能：响应鼠标按下动作
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        void MainMap_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseDownStart = gMap_2D.FromLocalToLatLng(e.X, e.Y);

            if (addptbool == 0 || addptbool == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    isLeftMouseDown = true;
                    isMouseDraging = false;

                    // 判断鼠标是否点击在拖拽区域里
                    if (drag_area_exist == true)
                    {
                        if (MouseDownStart.Lng > drag_left_lon && MouseDownStart.Lng < drag_right_lon &&
                            MouseDownStart.Lat > drag_bottom_lat && MouseDownStart.Lat < drag_top_lat)
                        {
                            isMouseInDragArea = true;
                            Window_Skyway.wayPointSet_Copy = Window_Skyway.Get_Cur_SkyWay().wayPointSet;
                        }
                        else
                        {
                            isMouseInDragArea = false;
                        }
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    isRightMouseDown = true;
                }
            }
        }

        /*******************************************************************************
        * 功   能：响应鼠标弹起动作
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        public Int32 addWptIndex = 0;
        public static Int32 addPtMeasureIndex = 0;
        public static List<PointLatLng> Points_Forbid = new List<PointLatLng>();
        private void MainMap_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MouseDownEnd = gMap_2D.FromLocalToLatLng(e.X, e.Y);

            // ==================== add wpt ==================
            if (addptbool == 0 || addptbool == 1)
            {
                if (isLeftMouseDown)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        isLeftMouseDown = false;
                    }

                    // 记录下地图最后操作的点，方便下次程序打开时直接切换到该点
                    TouchDownEnd = gMap_2D.FromLocalToLatLng(e.X, e.Y);

                    // 如果不是在拖拽整个区域的航点
                    if (isMouseInDragArea == false)
                    {
                        // 如果不是在拖拽，则添加航点
                        if (!isMouseDraging)
                        {
                            // 如果是添加航线模式
                            if (addptbool == 1)
                            {
                                if (Window_Skyway.auto_wpt_enable == false)      // 手动添加，则直接添加航点
                                {
                                    Window_Skyway.getInstance().Add_Wpt_To_WptList(TouchDownEnd.Lat, TouchDownEnd.Lng, 0);
                                    Add_Skyway_On_Map(Window_Skyway.Get_Cur_SkyWay());
                                }
                                else                                                                              // 自动添加，则添加自动规划区域
                                {
                                    Window_Skyway.getInstance().AddPtToBoundList(TouchDownEnd.Lng, TouchDownEnd.Lat, 0);
                                    Window_Skyway.getInstance().Updatet_Bound_Skyway();
                                }
                            }
                        }
                        // 如果是在拖拽，则移动航点的位置
                        else
                        {
                            if (CurentRectMarker != null)
                            {
                                Change_Wpt_Pos(CurentRectMarker.InnerMarker.Tag.ToString(), CurentRectMarker.InnerMarker.Position.Lat,
                                    CurentRectMarker.InnerMarker.Position.Lng);

                                CurentRectMarker = null;
                            }
                        }
                        isMouseDraging = false;
                    }
                    else   // 如果是拖拽区域内的航点
                    {
                        isMouseInDragArea = false;

                        double drag_deltaLon, drag_deltaLat;
                        drag_deltaLon = MouseDownEnd.Lng - MouseDownStart.Lng;
                        drag_deltaLat = MouseDownEnd.Lat - MouseDownStart.Lat;

                        List<PointLatLng> Points_Temp = new List<PointLatLng>();
                        Points_Temp.Add(new PointLatLng(Drag_Area_Points[0].Lat + drag_deltaLat, Drag_Area_Points[0].Lng + drag_deltaLon));
                        Points_Temp.Add(new PointLatLng(Drag_Area_Points[1].Lat + drag_deltaLat, Drag_Area_Points[1].Lng + drag_deltaLon));
                        Points_Temp.Add(new PointLatLng(Drag_Area_Points[2].Lat + drag_deltaLat, Drag_Area_Points[2].Lng + drag_deltaLon));
                        Points_Temp.Add(new PointLatLng(Drag_Area_Points[3].Lat + drag_deltaLat, Drag_Area_Points[3].Lng + drag_deltaLon));

                        Add_Wpt_Drag_Area(Points_Temp);

                        // 检查被拖拽区域覆盖的航点
                        byte skyway_no = Window_Skyway.cur_skyway_no;
                        int count = Window_Skyway.Get_Cur_Skyway_Count();
                        for (int i = 0; i < count; i++)
                        {
                            if (Window_Skyway.m_sky_way_list[skyway_no].wayPointSet[i].drag_enable == true)
                            {
                                Window_Skyway.m_sky_way_list[skyway_no].wayPointSet[i].lon = Window_Skyway.wayPointSet_Copy[i].lon + drag_deltaLon;
                                Window_Skyway.m_sky_way_list[skyway_no].wayPointSet[i].lat = Window_Skyway.wayPointSet_Copy[i].lat + drag_deltaLat;
                            }
                        }

                        // 更新航线链表窗口的显示
                        Window_Skyway.getInstance().Update_Wpt_View_List();
                        // 将更新后的链表重新在地图上显示
                        Add_Skyway_On_Map(Window_Skyway.Get_Cur_SkyWay());
                    }
                }
                // 如果是鼠标右键，则弹出插入航点菜单
                else if (isRightMouseDown)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        isRightMouseDown = false;
                    }
                    // 在改航点的前后插入航点
                    if (CurentRectMarker != null)
                    {
                        if (CurentRectMarker.InnerMarker.ToolTipText.ToString() != null)
                        {
                            addWptIndex = Int32.Parse(CurentRectMarker.InnerMarker.Tag.ToString());
                            System.Windows.Forms.ContextMenu AddWpt_PopMenu = new System.Windows.Forms.ContextMenu();
                            System.Windows.Forms.MenuItem AddBeforeMenu = new System.Windows.Forms.MenuItem();
                            System.Windows.Forms.MenuItem AddAfterMenu = new System.Windows.Forms.MenuItem();
                            System.Windows.Forms.MenuItem AddExitMenu = new System.Windows.Forms.MenuItem();

                            AddBeforeMenu.Text = "前添加";
                            AddBeforeMenu.Click += btAdd_Before_Click;
                            AddWpt_PopMenu.MenuItems.Add(AddBeforeMenu);

                            AddAfterMenu.Text = "后添加";
                            AddAfterMenu.Click += btAdd_After_Click;
                            AddWpt_PopMenu.MenuItems.Add(AddAfterMenu);

                            AddExitMenu.Text = "取消";
                            AddExitMenu.Click += btAdd_Exit_Click;
                            AddWpt_PopMenu.MenuItems.Add(AddExitMenu);

                            gMap_2D.ContextMenu = AddWpt_PopMenu;
                        }
                        CurentRectMarker = null;
                    }
                }
            }
            // ================= add drag area ======================
            else if (addptbool == 2)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // 如果是添加第一个航点,记录下航点得位置
                    if (Drag_Area_Points.Count == 0 || Drag_Area_Points.Count == 4)
                    {
                        Drag_Area_Points.Clear();
                        Drag_Area_Points.Add(new PointLatLng(MouseDownEnd.Lat, MouseDownEnd.Lng));

                        Wpt_Drag_Layer.Clear();
                        drag_area_exist = false;
                    }
                    // 点击第2个航点的时候，将拖拽的四边形在地图上显示出来
                    else if (Drag_Area_Points.Count == 1)
                    {
                        Drag_Area_Points.Add(new PointLatLng(Drag_Area_Points[0].Lat, MouseDownEnd.Lng));
                        Drag_Area_Points.Add(new PointLatLng(MouseDownEnd.Lat, MouseDownEnd.Lng));
                        Drag_Area_Points.Add(new PointLatLng(MouseDownEnd.Lat, Drag_Area_Points[0].Lng));

                        Add_Wpt_Drag_Area(Drag_Area_Points);
                        drag_area_exist = true;

                        List<WAY_POINT> wptTemp = Window_Skyway.Get_Cur_SkyWay().wayPointSet;
                        // 检查有哪些航点在这个区域
                        for (int i = 0; i < wptTemp.Count; i++)
                        {
                            if (wptTemp[i].lon > drag_left_lon && wptTemp[i].lon < drag_right_lon && wptTemp[i].lat > drag_bottom_lat && wptTemp[i].lat < drag_top_lat)
                                wptTemp[i].drag_enable = true;
                            else
                                wptTemp[i].drag_enable = false;
                        }
                    }
                }
            }
            // ===================== add measure pt ======================
            else if (addptbool == 3)   // 添加距离测量
            {
                if (e.Button == MouseButtons.Left)
                {
                    AddMeasurePt(MouseDownEnd.Lat, MouseDownEnd.Lng, addPtMeasureIndex);
                    // 如果是第一个点
                    if (addPtMeasureIndex == 1)
                    {
                        addPtMeasureIndex = 2;
                    }
                    else if (addPtMeasureIndex == 2)
                    {
                        addPtMeasureIndex = 1;
                    }
                }
            }
            // ======================= add forbidden area ====================
            else if (addptbool == 4)   // add forbidden area
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (Points_Forbid.Count < 8)
                    {
                        Points_Forbid.Add(new PointLatLng(MouseDownEnd.Lat, MouseDownEnd.Lng));
                        Add_No_Fly_Area(Points_Forbid);
                    }
                    else
                    {
                        Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_FORBID_COUNT_ERROR").ToString());
                        return;
                    }
                }
            }
            // ===================== add home point =====================
            else if (addptbool == 5)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Add_Home_Marker("", MouseDownEnd.Lng, MouseDownEnd.Lat, 0);

                    Window_Set_Home.Update_Home_Pos_Text(MouseDownEnd.Lng, MouseDownEnd.Lat);
                }
            }
            // ===================== add head point  =====================
            else if (addptbool == 6)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Add_Hot_Point_Marker("", MouseDownEnd.Lng, MouseDownEnd.Lat, 0);
                    Window_Head_To_Pt.getInstance().Update_Home_Pos_Text(MouseDownEnd.Lng, MouseDownEnd.Lat);
                }
            }
            else if (addptbool == 7)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Add_ZhiDian_Pt(MouseDownEnd.Lat, MouseDownEnd.Lng, 0);
                    Window_Fly_Point.getInstance().Update_ZhiDian_Pos(MouseDownEnd.Lng, MouseDownEnd.Lat);
                }
            }
        }


        /***********************************************************************************
       * 功   能：在地图上双击一个航点的时候，删除该航点
       * 参   数：
       * 返   回：
       * *********************************************************************************/
        private void MainMap_doubleCLick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CurentRectMarker != null)
            {
                int num2;
                if (Int32.TryParse(CurentRectMarker.InnerMarker.ToolTipText.ToString(), out num2) == false)
                {
                    // 将航点从航线列表中删除
                    Window_Skyway.Delete_Cur_Skyway_Wpt(int.Parse(CurentRectMarker.InnerMarker.Tag.ToString()) - 1);
                    // 更新航线链表窗口的显示
                    Window_Skyway.getInstance().Update_Wpt_View_List();
                    // 将更新后的链表重新在地图上显示
                    Add_Skyway_On_Map(Window_Skyway.Get_Cur_SkyWay());
                }
                CurentRectMarker = null;
            }
        }

        /***********************************************************************************
        * 功   能：在地图上双击一个航点的时候，删除该航点
        * 参   数：
        * 返   回：
        * *********************************************************************************/
        void MainMap_OnMarkerEnter(GMapMarker item)
        {
            if ((addptbool == 0 || addptbool == 1) && (Window_Skyway.mb_wnd_visible == true))
            {
                if (!isLeftMouseDown && !isRightMouseDown)
                {
                    if (item is GMapMarkerRect)
                    {
                        GMapMarkerRect rc = item as GMapMarkerRect;
                        if (rc.InnerMarker.ToolTipText != null)
                        {
                            string strTemp = rc.InnerMarker.ToolTipText.ToString();

                            // 只有航点会添加ToolTipText，只有鼠标移动到航点的时候，才会获取Marker信息
                            if (strTemp != null)
                            {
                                CurentRectMarker = rc;
                            }
                        }
                    }
                }
            }
        }

        /******************************************************************
        * 函数名称：退出插入航点菜单
        * ***************************************************************/
        private void btAdd_Exit_Click(object sender, EventArgs e)
        {
            gMap_2D.ContextMenu = null;
        }

        /*******************************************************************************
        * 功   能：点击后添加命令
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        private void btAdd_After_Click(object sender, EventArgs e)
        {
            gMap_2D.ContextMenu = null;
            Window_Skyway.getInstance().Insert_Wpt(addWptIndex, 2);
            // 将更新后的链表重新在地图上显示
            Add_Skyway_On_Map(Window_Skyway.Get_Cur_SkyWay());
        }

        /*******************************************************************************
        * 功   能：更改航点的位置
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        private void Change_Wpt_Pos(string pointno, double lat, double lng)
        {
            if (pointno == "")
            {
                return;
            }
            try
            {
                Window_Skyway.getInstance().Change_Cur_Skyway_Wpt(lng, lat, int.Parse(pointno) - 1);
                Window_Skyway.getInstance().Update_Wpt_View_List();
                Add_Skyway_On_Map(Window_Skyway.Get_Cur_SkyWay());
            }
            catch
            {
            }
        }

        /*******************************************************************************
        * 功   能：响应鼠标弹起动作
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        private void btAdd_Before_Click(object sender, EventArgs e)
        {
            gMap_2D.ContextMenu = null;
            Window_Skyway.getInstance().Insert_Wpt(addWptIndex, 1);
            // 将更新后的链表重新在地图上显示
            Add_Skyway_On_Map(Window_Skyway.Get_Cur_SkyWay());
        }

        /*******************************************************************************
        * 功   能：添加航点marker
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        public static void addpolygonmarker_wpt(string tag, double lng, double lat, int alt)
        {
            SKY_WAY skyway_temp = Window_Skyway.Get_Cur_SkyWay();

            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarkerWP m;
            m = new GMapMarkerWP(point, tag, GMarkerGoogleType.red, 1);

            if (tag == "1")
            {
                m.ToolTipText = "NO." + skyway_temp.sky_way_no.ToString();
                m.ToolTipMode = MarkerTooltipMode.Always;
            }
            else
            {
                m.ToolTipText = " Alt: " + alt.ToString();
                m.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            }
            m.Tag = tag;

            GMapMarkerRect mBorders = new GMapMarkerRect(point);
            {
                mBorders.InnerMarker = m;
                mBorders.Tag = tag;
            }

            skyway_temp.Wpt_Layer.Markers.Add(m);
            skyway_temp.Wpt_Layer.Markers.Add(mBorders);
        }


        /*******************************************************************************
        * 功   能：添加测量的tag
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        private void Add_Measure_Tag(string tag, double lng, double lat, int alt)
        {
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarkerWP m;
            tag = tag + " " + "m";
            m = new GMapMarkerWP(point, tag, GMarkerGoogleType.green_small, 2);
            Dist_Measure_Layer.Markers.Add(m);
        }

        /*******************************************************************************
        * 功   能：添加航点之间的距离
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        private static void addpolygonmarker_wptDist(string tag, double lng, double lat, int alt)
        {
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarkerWP m;

            m = new GMapMarkerWP(point, tag, GMarkerGoogleType.green_small, 2);
            m.Tag = tag;

            GMapMarkerRect mBorders = new GMapMarkerRect(point);
            {
                mBorders.InnerMarker = m;
                mBorders.Tag = tag;
            }

            SKY_WAY skyway_temp = Window_Skyway.Get_Cur_SkyWay();
            skyway_temp.Wpt_Layer.Markers.Add(mBorders);
            skyway_temp.Wpt_Layer.Markers.Add(m);
        }

        /*******************************************************************************
        * 功   能：添加边界点之间的连接线
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        private void addpolygonmarker_boundDist(string tag, double lng, double lat, int alt)
        {
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarkerWP m;

            m = new GMapMarkerWP(point, tag, GMarkerGoogleType.green_small, 2);
            m.Tag = tag;

            GMapMarkerRect mBorders = new GMapMarkerRect(point);
            {
                mBorders.InnerMarker = m;
                mBorders.Tag = tag;
            }

            Bound_Layer.Markers.Add(mBorders);
            Bound_Layer.Markers.Add(m);
        }

        /*******************************************************************************
        * 功   能：添加航点之间的连线
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        public static void AddWptLineOnMap(List<PointLatLngAlt> wptListOnMap, UInt32 argLineType)
        {
            SKY_WAY skyway_temp = Window_Skyway.Get_Cur_SkyWay();

            skyway_temp.route_wptLine.Clear();
            skyway_temp.Wpt_Layer.Routes.Clear();

            if (wptListOnMap.Count < 1)
                return;

            for (int i = 0; i < wptListOnMap.Count; i++)
            {
                skyway_temp.route_wptLine.Points.Add(wptListOnMap[i]);
            }

            if (argLineType == 1)        // 实际航线连线
                skyway_temp.route_wptLine.Stroke = new System.Drawing.Pen(System.Drawing.Color.Yellow, 4);
            else if (argLineType == 2)   // 预览航线连线
                skyway_temp.route_wptLine.Stroke = new System.Drawing.Pen(System.Drawing.Color.Red, 2);

            skyway_temp.Wpt_Layer.Routes.Add(skyway_temp.route_wptLine);
            skyway_temp.route_wptLine.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
        }

        /*******************************************************************************
       * 功   能：添加边界点之间的连线
       * 参   数：
       * 返   回：
       * ******************************************************************************/
        private void AddBoundLineOnMap(List<PointLatLngAlt> boundPtListOnMap, UInt32 argLineType)
        {
            route_bound.Clear();
            Bound_Layer.Routes.Clear();

            for (int i = 0; i < boundPtListOnMap.Count; i++)
            {
                route_bound.Points.Add(boundPtListOnMap[i]);
            }
            route_bound.Points.Add(boundPtListOnMap[0]);
            route_bound.Stroke = new System.Drawing.Pen(System.Drawing.Color.RoyalBlue, 3);

            Bound_Layer.Routes.Add(route_bound);
            route_bound.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
        }

        /*******************************************************************************
        * 功   能：将航线添加到2D地图上
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        public static void Add_Skyway_On_Map(SKY_WAY sky_way)
        {
            List<WAY_POINT> wptList = sky_way.wayPointSet;
            int wptCountTemp = wptList.Count;

            if (wptCountTemp < 1)
                return;

            string strWptName;
            double wptLonTemp = 0, wptLatTemp = 0;
            double wptLonTemp_Next = 0, wptLatTemp_Nex = 0;
            int wptAltTemp = 0;

            sky_way.wptListOnMap.Clear();
            sky_way.Wpt_Layer.Markers.Clear();

            // 在地图上添加航点标记
            for (int i = 0; i < wptCountTemp; i++)
            {
                strWptName = (wptList[i].NumberId).ToString();
                wptLonTemp = wptList[i].lon;
                wptLatTemp = wptList[i].lat;
                wptAltTemp = (int)wptList[i].alt;

                addpolygonmarker_wpt(strWptName, wptLonTemp, wptLatTemp, wptAltTemp);
                PointLatLngAlt pointTemp = new PointLatLngAlt(wptLatTemp, wptLonTemp, wptAltTemp, strWptName);
                sky_way.wptListOnMap.Add(pointTemp);

                // 添加航点之间的距离标记
                if ((wptCountTemp > 1) && (i < wptCountTemp - 1))
                {
                    wptLonTemp_Next = wptList[i + 1].lon;
                    wptLatTemp_Nex = wptList[i + 1].lat;

                    addpolygonmarker_wptDist(((int)(Compute.dis_math(wptLonTemp, wptLonTemp_Next, wptLatTemp, wptLatTemp_Nex))).ToString(),
                        (wptLonTemp + wptLonTemp_Next) * 0.5, (wptLatTemp + wptLatTemp_Nex) * 0.5, wptAltTemp);
                }
            }

            if (wptCountTemp > 1)
            {
                // 添加两点之间的航线显示
                AddWptLineOnMap(sky_way.wptListOnMap, 1);
            }
        }

        /*******************************************************************************
       * 功   能：将边界点添加到2D地图
       * 参   数：
       * 返   回：
       * ******************************************************************************/
        public static void AddBoundListOnMap(List<BOUND_PT> bp_list)
        {
            int i = 0;
            boundPtListOnMap.Clear();
            Delete_Bound_Layer_2D();

            int boundCountTemp = bp_list.Count;

            // 小于两个点，则直接退出
            if (boundCountTemp < 2)
                return;

            // 将边界点添加到地图边界点的List中
            for (i = 0; i < boundCountTemp; i++)
            {
                PointLatLngAlt pointTemp = new PointLatLngAlt(bp_list[i].lat, bp_list[i].lon, 0);
                boundPtListOnMap.Add(pointTemp);
            }

            // 添加边界距离标记
            for (i = 0; i < boundCountTemp - 1; i++)
            {
                m_Page_2D_Map.addpolygonmarker_boundDist(((int)(Compute.dis_math(bp_list[i].lon, bp_list[i + 1].lon, bp_list[i].lat, bp_list[i + 1].lat))).ToString() + "m",
                    (bp_list[i].lon + bp_list[i + 1].lon) * 0.5, (bp_list[i].lat + bp_list[i + 1].lat) * 0.5, 10);
            }
            // 添加最后一个边界点到第一个航点之间的距离标记
            m_Page_2D_Map.addpolygonmarker_boundDist(((int)(Compute.dis_math(bp_list[boundCountTemp - 1].lon, bp_list[0].lon, bp_list[boundCountTemp - 1].lat, bp_list[0].lat))).ToString() + "m",
                (bp_list[boundCountTemp - 1].lon + bp_list[0].lon) * 0.5, (bp_list[boundCountTemp - 1].lat + bp_list[0].lat) * 0.5, 10);

            // 添加两个边界点之间的连线
            m_Page_2D_Map.AddBoundLineOnMap(boundPtListOnMap, 1);
        }


        /*******************************************************************************
        * 功   能：响应鼠标弹起动作
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        private static void Add_Wpt_Drag_Area(List<PointLatLng> dragAreaPoints)
        {
            Wpt_Drag_Layer.Clear();
            GMapPolygon polygon = new GMapPolygon(dragAreaPoints, "mypolygon");
            polygon.Fill = new SolidBrush(System.Drawing.Color.FromArgb(50, System.Drawing.Color.Blue));
            polygon.Stroke = new System.Drawing.Pen(System.Drawing.Color.Blue, 3);
            Wpt_Drag_Layer.Polygons.Add(polygon);

            // 检测在区域内的航点
            drag_left_lon = Compute.math_min(dragAreaPoints[0].Lng, dragAreaPoints[2].Lng);
            drag_right_lon = Compute.math_max(dragAreaPoints[0].Lng, dragAreaPoints[2].Lng);
            drag_bottom_lat = Compute.math_min(dragAreaPoints[0].Lat, dragAreaPoints[2].Lat);
            drag_top_lat = Compute.math_max(dragAreaPoints[0].Lat, dragAreaPoints[2].Lat);

            Drag_Area_Points = dragAreaPoints;
        }

        /*******************************************************************************
       * 功   能：添加禁飞区
       * 参   数：
       * 返   回：
       * ******************************************************************************/
        public static void Add_No_Fly_Area(List<PointLatLng> NoFlyPoints)
        {
            No_Fly_Layer.Clear();
            GMapPolygon polygon = new GMapPolygon(NoFlyPoints, "Forbidden Area");
            polygon.Fill = new SolidBrush(System.Drawing.Color.FromArgb(50, System.Drawing.Color.Red));
            polygon.Stroke = new System.Drawing.Pen(System.Drawing.Color.Red, 1);
            No_Fly_Layer.Polygons.Add(polygon);
        }

        /*******************************************************************************
        * 功   能：添加指点飞行位置
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        public static void Add_ZhiDian_Pt(double lat, double lng, int alt)
        {
            ZhiDian_Layer.Markers.Clear();

            GMapMarkerWP m;
            PointLatLng point = new PointLatLng(lat, lng);
            m = new GMapMarkerWP(point, GMarkerGoogleType.green_dot, 2);
            ZhiDian_Layer.Markers.Add(m);
        }

        /*******************************************************************************
        * 功   能：Show the follow gps position on map
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        public static void AddFollowGpsOnMap(byte satNum, double lat, double lng)
        {
            FollowGps_Layer.Markers.Clear();

            GMapMarkerWP m;
            PointLatLng point = new PointLatLng(lat, lng);

            m = new GMapMarkerWP(point, GMarkerGoogleType.green_big_go, 2);
            FollowGps_Layer.Markers.Add(m);
        }
        /*******************************************************************************
        * 功   能：清楚所有距离测量的标记
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        public static void Init_Measure_Dist_Mark()
        {
            Dist_Measure_Layer.Markers.Clear();
            Dist_Measure_Layer.Routes.Clear();
            route_dist_measure.Clear();
            measurePoints.Clear();
            MeasureDistListOnMap.Clear();
        }

        /*******************************************************************************
       * 功   能：添加距离测量
       * 参   数：
       * 返   回：
       * ******************************************************************************/
        private void AddMeasurePt(double lat, double lng, int index)
        {
            // 如果是添加第一个点，则将所有的清零
            if (index == 1)
            {
                Init_Measure_Dist_Mark();
            }
            PointLatLng point = new PointLatLng(lat, lng);
            measurePoints.Add(point);

            GMapMarkerWP m;
            m = new GMapMarkerWP(point, "", GMarkerGoogleType.red, 1);
            Dist_Measure_Layer.Markers.Add(m);

            PointLatLngAlt pointTemp = new PointLatLngAlt(lat, lng, 0, "");
            MeasureDistListOnMap.Add(pointTemp);

            // 如果是第二个点，则添加连接线以及两者之间的距离tag
            if (index == 2)
            {
                // 添加距离显示tag
                Add_Measure_Tag(((int)(Compute.dis_math(measurePoints[0].Lng, measurePoints[1].Lng, measurePoints[0].Lat, measurePoints[1].Lat))).ToString(),
                    (measurePoints[0].Lng + measurePoints[1].Lng) * 0.5, (measurePoints[0].Lat + measurePoints[1].Lat) * 0.5, 0);

                // 添加两者之间的连线
                for (int i = 0; i < MeasureDistListOnMap.Count; i++)
                {
                    route_dist_measure.Points.Add(MeasureDistListOnMap[i]);
                }
                Dist_Measure_Layer.Routes.Add(route_dist_measure);
                route_dist_measure.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            }
        }

        /*******************************************************************************
        * 功   能：整体移动航线
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        public static void Shift_All_Wpt(byte argShiftType)
        {
            MainWindow m_MainWnd = MainWindow.getInstance();
            double deltaLon = 0, deltaLat = 0;

            if (Drag_Area_Points.Count < 4)
            {
                Window_Operation_Indication.Set_Indication_Text(m_MainWnd.TryFindResource("TITLE_SELECT_DARG_AREA").ToString());
                return;
            }

            if (argShiftType == 1)   // 上移动
            {
                deltaLon = 0;
                deltaLat = 0.00001;
            }
            else if (argShiftType == 2)   // 下移动
            {
                deltaLon = 0;
                deltaLat = -0.00001;
            }
            else if (argShiftType == 3)   // 左移动
            {
                deltaLon = -0.00001;
                deltaLat = 0;
            }
            else if (argShiftType == 4)   // 右移动
            {
                deltaLon = 0.00001;
                deltaLat = 0;
            }

            byte cur_sky_index = Window_Skyway.cur_skyway_no;
            int cout = Window_Skyway.Get_Cur_Skyway_Count();

            for (int i = 0; i < cout; i++)
            {
                if (Window_Skyway.m_sky_way_list[cur_sky_index].wayPointSet[i].drag_enable == true)
                {
                    Window_Skyway.m_sky_way_list[cur_sky_index].wayPointSet[i].lon = Window_Skyway.m_sky_way_list[cur_sky_index].wayPointSet[i].lon + deltaLon;
                    Window_Skyway.m_sky_way_list[cur_sky_index].wayPointSet[i].lat = Window_Skyway.m_sky_way_list[cur_sky_index].wayPointSet[i].lat + deltaLat;
                }
            }

            // 将更新后的链表重新在地图上显示
            Add_Skyway_On_Map(Window_Skyway.Get_Cur_SkyWay());

            List<PointLatLng> Points_Temp = new List<PointLatLng>();
            Points_Temp.Add(new PointLatLng(Drag_Area_Points[0].Lat + deltaLat, Drag_Area_Points[0].Lng + deltaLon));
            Points_Temp.Add(new PointLatLng(Drag_Area_Points[1].Lat + deltaLat, Drag_Area_Points[1].Lng + deltaLon));
            Points_Temp.Add(new PointLatLng(Drag_Area_Points[2].Lat + deltaLat, Drag_Area_Points[2].Lng + deltaLon));
            Points_Temp.Add(new PointLatLng(Drag_Area_Points[3].Lat + deltaLat, Drag_Area_Points[3].Lng + deltaLon));

            Add_Wpt_Drag_Area(Points_Temp);
        }

        /***************************************************************
        * 功能：删除2D地图上的边界
        * 参数：
        * 返回：
        * *************************************************************/
        public static void Delete_Bound_Layer_2D()
        {
            Bound_Layer.Markers.Clear();
            route_bound.Clear();
            Bound_Layer.Routes.Clear();
        }

        /***************************************************************
        * 功能：删除2D地图上的航线
        * 参数：
        * 返回：
        * *************************************************************/
        public static void Delete_Wpt_Layer_2D()
        {
            SKY_WAY skyway_temp = Window_Skyway.Get_Cur_SkyWay();
            skyway_temp.Wpt_Layer.Markers.Clear();
            skyway_temp.route_wptLine.Clear();
            skyway_temp.Wpt_Layer.Routes.Clear();
            skyway_temp.wptListOnMap.Clear();
        }


        /*****************************************************************************
        * function:
        * para:
        * return:
        * ***************************************************************************/
        public static void Delete_Forbid_Area()
        {
            Points_Forbid.Clear();
            No_Fly_Layer.Clear();
        }

        /*****************************************************************************
        * function:
        * para:
        * return:
        * ***************************************************************************/
        public static void Upload_Forbid_Area(bool bUpload)
        {
            if (bUpload == true)
            {
                if (Points_Forbid.Count < 1)
                    return;

                DATA_LINK.Send_Forbid_Msg(1, 1, Points_Forbid);
            }
            else
            {
                DATA_LINK.Send_Forbid_Msg(0, 0, Points_Forbid);
            }
        }

        /*****************************************************************************
        * function:
        * para:
        * return:
        * ***************************************************************************/
        public static void Add_Home_Marker(string tag, double lng, double lat, int alt)
        {
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarkerWP m;
            m = new GMapMarkerWP(point, tag, GMarkerGoogleType.yellow_dot, 1);

            Home_Pos_Layer.Markers.Clear();
            Home_Pos_Layer.Markers.Add(m);
        }


        /*****************************************************************************
        * function: add hot point on map
        * para:
        * return:
        * ***************************************************************************/
        public static void Add_Hot_Point_Marker(string tag, double lng, double lat, int alt)
        {
            PointLatLng point = new PointLatLng(lat, lng);
            GMapMarkerWP m;
            m = new GMapMarkerWP(point, tag, GMarkerGoogleType.yellow_dot, 1);

            Hot_Point_Layer.Markers.Clear();
            Hot_Point_Layer.Markers.Add(m);
        }

        

        /*****************************************************************************
        * function:
        * para:
        * return:
        * ***************************************************************************/
        public static void Del_Home_Marker()
        {
            Home_Pos_Layer.Markers.Clear();
        }

        /*****************************************************************************
        * function:
        * para:
        * return:
        * ***************************************************************************/
        public static void Del_Hot_Point_Marker()
        {
            Hot_Point_Layer.Markers.Clear();
        }

        /****************************************************************************************
      * function: Show the planes on 2d map 
      * para:
      * return:
      * ***************************************************************************************/
        public static void Add_Plane_On_2D_Map(byte argNum, PointLatLng argPtLatLon, float argHeading, float argAlt, float argSpeed)
        {
            GMapMarkerPlane mm = new GMapMarkerPlane(argPtLatLon, argHeading, 0, 0, 0, 0);

            string str_id = "", str_alt = "", str_spd = "";
            if (App.language_type == 0)
            {
                str_id = "飞机 ID: ";
                str_alt = "高度: ";
                if (App.plane_type == 0)
                    str_spd = "速度: ";
                else
                    str_spd = "空速: ";
            }
            else if (App.language_type == 1)
            {
                str_id = "Plane ID: ";
                str_alt = "Alt: ";
                if (App.plane_type == 0)
                    str_spd = "Speed: ";
                else
                    str_spd = "Airspeed: ";
            }

            mm.ToolTipText = str_id + argNum.ToString() + "\n\r"
                        + str_alt + argAlt.ToString("0.0") + " m" + "\n\r"
                        + str_spd + argSpeed.ToString("0.0") + " m/s";

            mm.ToolTipMode = MarkerTooltipMode.Always;
            mm.icon = Properties.Resources.planetracker_link;

            m_plane_list[argNum].plane_id = argNum;
            m_plane_list[argNum].plane_data_count = 0;
            m_plane_list[argNum].plane_exist = true;
            m_plane_list[argNum].point_last = argPtLatLon;
            m_plane_list[argNum].alt_last = argAlt;
            m_plane_list[argNum].Plane_Layer.Markers.Clear();
            m_plane_list[argNum].Plane_Layer.Markers.Add(mm);

            // trajectory just be shown in single mode
            if (App.single_many_type == 0)
            {
                Route_Layer.Routes.Clear();
                route_hangji.Points.Add(argPtLatLon);
                Route_Layer.Routes.Add(route_hangji);
            }
        }

        /********************************************************************
         * function: check plane link status
         * para:
         * return:
         * *******************************************************************/
        public static void Check_Plane_Link_Status()
        {
            for (int i = 0; i < 21; i++)
            {
                if (m_plane_list[i].plane_exist == true)
                {
                    m_plane_list[i].plane_data_count++;
                    if (m_plane_list[i].plane_data_count > 30)
                    {
                        GMapMarkerPlane mm = new GMapMarkerPlane(m_plane_list[i].point_last, 0, 0, 0, 0, 0);

                        string str_id = "", str_alt = "", str_spd = "";
                        if (App.language_type == 0)
                        {
                            str_id = "飞机 ID: ";
                            str_alt = "高度: ";
                            if (App.plane_type == 0)
                                str_spd = "速度: ";
                            else
                                str_spd = "空速: ";
                        }
                        else if (App.language_type == 1)
                        {
                            str_id = "Plane ID: ";
                            str_alt = "Alt: ";
                            if (App.plane_type == 0)
                                str_spd = "Speed: ";
                            else
                                str_spd = "Airspeed: ";
                        }

                        mm.ToolTipText = str_id + i.ToString() + "\n\r"
                                    + str_alt + m_plane_list[i].alt_last.ToString("0.0") + " m" + "\n\r"
                                    + str_spd + " m/s";

                        mm.ToolTipMode = MarkerTooltipMode.Always;
                        mm.icon = Properties.Resources.planetracker_lost;

                        m_plane_list[i].Plane_Layer.Markers.Clear();
                        m_plane_list[i].Plane_Layer.Markers.Add(mm);
                    }
                }
            }
        }
    }
}
