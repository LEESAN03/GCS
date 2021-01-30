using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace VIKGroundStation
{
    public partial class MainWindow : Window
    {
        private static MainWindow m_MainWindow;
        public static MainWindow getInstance()
        {
            if (m_MainWindow == null)
                m_MainWindow = new MainWindow();

            return m_MainWindow;
        }

        // ========================== 初始化窗口 =============================
        private static Page_2D_Map m_Page2DMap = Page_2D_Map.getInstance();
        private static Page_Fly_Map m_PageFlyMap = Page_Fly_Map.getInstance();

        private static Page_Plane_Settings m_PagePlaneSettings = Page_Plane_Settings.getInstance();
        private static Page_Pid_Para m_PagePidPara = Page_Pid_Para.getInstance();
        private static Page_Par_Setting m_ParSetting = Page_Par_Setting.getInstance();

        public static Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();
        private static Page_Fix_Direction m_PageFixDirection = Page_Fix_Direction.getInstance();
        private static Page_Task_Function m_PageTaskFunction = Page_Task_Function.getInstance();

        private static Page_Remoter_Calibrate m_page_remoter_calibrate = Page_Remoter_Calibrate.getInstance();
        private Page_Motor_Test m_PageMotorTest = Page_Motor_Test.getInstance();
        private Page_ChuiQi_Pwm_Out m_Page_ChuiQi_Pwm = Page_ChuiQi_Pwm_Out.getInstance();
        private static Page_ChuiQi_Settings2 m_chuiqi_settings2 = Page_ChuiQi_Settings2.getInstance();

        public static Window_ctrl mWndCtrl = new Window_ctrl();
        public static Window_Fly_Infor m_WndFlyInfor = null;
        public static Window_ChuiQi_Fly_Infor m_WndChuiQi = null;

        private bool bMain_Wnd_Init = false;

        public static StreamWriter stream_gcs_log = null;
        public static SpeechSynthesizer Speaker = new SpeechSynthesizer();
        public static bool enable_voice = false;
        /***********************************************************************************
        * 功  能：初始化2D、3D地图属性
        * 参  数：
        * 返  回：
        * *********************************************************************************/
        public MainWindow()
        {
            m_MainWindow = this;
            InitializeComponent();

            combox_language.Items.Add("Chinese");
            combox_language.Items.Add("English");
            //combox_language.Items.Add("Turkic");
            combox_map_type.Items.Add("高德地图");
            combox_map_type.Items.Add("天地图");
            combox_map_type.Items.Add("天地图离线");
            combox_map_type.Items.Add("Bing Map");
            combox_map_type.SelectedIndex = 0;

            // open the file to log gcs operation
            if (stream_gcs_log == null)
            {
                string str_path = Directory.GetCurrentDirectory() + "\\GCS_LOG\\" + DateTime.Now.ToLongDateString()
                                                + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + ".log";

                stream_gcs_log = new StreamWriter(str_path, true, System.Text.Encoding.Default);
            }

            TextBlock_Version.Text = App.str_plane_type + "(" + App.str_single_multi + ")" + "   " + "V3.1";
        }

        /***********************************************************************************
        * 功  能：初始化主界面窗口
        * 参  数：
        * 返  回：
        * *********************************************************************************/
        private void Main_Window_Loaded(object sender, RoutedEventArgs e)
        {
            mWndCtrl.Owner = this;
            mWndCtrl.Show();

            Single_Many_Show();

            string str_path = Directory.GetCurrentDirectory();

            if (int.Parse(ReadConfigFile.ReadIniData("IP_SET", "language", "", str_path + "\\Start_Up.ini")) == 1)  // Chinese
            {
                combox_language.SelectedIndex = 0;
            }
            else if (int.Parse(ReadConfigFile.ReadIniData("IP_SET", "language", "", str_path + "\\Start_Up.ini")) == 2)   //English
            {
                combox_language.SelectedIndex = 1;
            }
            else if (int.Parse(ReadConfigFile.ReadIniData("IP_SET", "language", "", str_path + "\\Start_Up.ini")) == 3)
            {
                combox_language.SelectedIndex = 2;
            }

            double init_lon, init_lat;
            init_lon = double.Parse(ReadConfigFile.ReadIniData("IP_SET", "init_lon", "", str_path + "\\Start_Up.ini"));
            init_lat = double.Parse(ReadConfigFile.ReadIniData("IP_SET", "init_lat", "", str_path + "\\Start_Up.ini"));

            // 初始化程序的时候，直接切换到飞行监视页面
            page_Index = 2;

            frmMainShow.Navigate(m_PageFlyMap);
            m_PageFlyMap.SetMode(2);
            m_PageFlyMap.Init_view_pos(init_lon, init_lat);

            bMain_Wnd_Init = true;

            string str_time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "  ";
            stream_gcs_log.WriteLine(str_time + "Main Window init success");
            stream_gcs_log.Flush();
        }


        /*******************************************************************************
         * 函数功能：数据回放
         * ****************************************************************************/
        public void Show_PlayBack_Info(byte dataType)
        {
            FLY_INFOR_DISPLAY mFlyInforDisplay = DataProcess_JD.Get_Fly_Display(0);
            this.Dispatcher.Invoke(new Action(delegate
             {
                 if (App.plane_type == 0)
                 {
                     m_PageFlyMap.Show_Imu_Type0();

                     if (m_WndFlyInfor != null)
                         m_WndFlyInfor.Show_Imu_Type0(mFlyInforDisplay);

                     m_PageFlyMap.Show_Gps_Information(mFlyInforDisplay);
                     m_PageFlyMap.Show_Fly_Status(mFlyInforDisplay);

                     m_page_remoter_calibrate.Show_Pwm_In_Information(mFlyInforDisplay);

                     if (App.plane_type == 0)
                     {
                         m_PageMotorTest.Update_Pwm_Out(mFlyInforDisplay);
                     }
                     else
                     {
                         m_Page_ChuiQi_Pwm.Update_Pwm_Out(mFlyInforDisplay);
                     }
                     Show_Emergency_Infor(mFlyInforDisplay);

                     Window_Fan_Hang_Reason.getInstance().Update_Infor_Pro(mFlyInforDisplay);

                     if (Window_Chart.mb_wnd_initialized == true && Window_Chart.mb_wnd_visible == true)
                         Window_Chart.getInstance().Update_Chart();
                 }
             }));
        }


        /******************************************************************************
        * function: show the multiple motors imu information
        * para:
        * return:
        * ****************************************************************************/
        private void Fly_Display()
        {
            byte sys_id_set = DATA_LINK.Get_System_Set_Id();
            FLY_INFOR_DISPLAY mFlyInforDisplay = DataProcess_JD.Get_Fly_Display(sys_id_set);

            if (App.plane_type == 0)
            {
                m_PageFlyMap.Show_Imu_Type0();

                if (m_WndFlyInfor != null)
                    m_WndFlyInfor.Show_Imu_Type0(mFlyInforDisplay);

                m_PageFixDirection.ShowFixInfor(mFlyInforDisplay);

                Window_Radar.getInstance().Radar_Display(mFlyInforDisplay.radar_front, mFlyInforDisplay.radar_back);

                mWndCtrl.Update_Infor(mFlyInforDisplay);

                if (Window_Gps_Follow.mb_wnd_initializaed == true && Window_Gps_Follow.mb_wnd_visible == true)
                    Window_Gps_Follow.getInstance().Follow_Infor_Display();
            }
            else
            {
                m_PageFlyMap.Show_Imu_Type1();

                if (m_WndChuiQi != null)
                    m_WndChuiQi.Show_Imu_Type1(mFlyInforDisplay);

                m_chuiqi_settings2.ShowFixInfor(mFlyInforDisplay);
            }

            Show_Emergency_Infor(mFlyInforDisplay);
            m_PageFlyMap.Show_Gps_Information(mFlyInforDisplay);

            Window_Fan_Hang_Reason.getInstance().Update_Infor_Pro(mFlyInforDisplay);

            m_PageFlyMap.Show_Fly_Status(mFlyInforDisplay);

            m_page_remoter_calibrate.Show_Pwm_In_Information(mFlyInforDisplay);
            if (App.plane_type == 0)
            {
                m_PageMotorTest.Update_Pwm_Out(mFlyInforDisplay);
            }
            else
            {
                m_Page_ChuiQi_Pwm.Update_Pwm_Out(mFlyInforDisplay);
            }

            Show_Mag_Calibrate_Status(mFlyInforDisplay);
        }

        /******************************************************************************
        * function: show mag calibrate status
        * para:
        * return:
        * ****************************************************************************/
        private void Show_Mag_Calibrate_Status(FLY_INFOR_DISPLAY mFlyInforDisplay)
        {
            string strTemp;
            if (mFlyInforDisplay.mag_calibrate_status == 1)
            {
                strTemp = TryFindResource("TITLE_MAG_CALIBRATE_XY").ToString();
                MessageTimerWindow.Update_Data(strTemp);
            }
            else if (mFlyInforDisplay.mag_calibrate_status == 2)
            {
                strTemp = TryFindResource("TITLE_MAG_CALIBRATE_XZ").ToString();
                MessageTimerWindow.Update_Data(strTemp);
            }
            else if (mFlyInforDisplay.mag_calibrate_status == 3)
            {
                strTemp = TryFindResource("TITLE_MAG_CALIBRATE_SUCCESS").ToString();
                MessageTimerWindow.Update_Data(strTemp);
            }
            else if (mFlyInforDisplay.mag_calibrate_status == 4)
            {
                strTemp = TryFindResource("TITLE_MAG_CALIBRATE_FAIL").ToString();
                MessageTimerWindow.Update_Data(strTemp);
            }
            else if (mFlyInforDisplay.mag_calibrate_status == 0 && mag_calibrate_status_last != 0)
            {
                strTemp = "";
                MessageTimerWindow.Update_Data(strTemp);
            }
            mag_calibrate_status_last = mFlyInforDisplay.mag_calibrate_status;
        }

        /***********************************************************************************
        * 函数功能：将飞控下传的信息分类显示
        * ********************************************************************************/
        private byte mag_calibrate_status_last = 0;
        public void Fly_Info_Display(byte dataType)
        {
            this.Dispatcher.Invoke(new Action(delegate
            {
                switch (dataType)
                {
                    case MsgDef.MSG_IMU:                                         //  imu msg
                        Fly_Display();
                        break;
                    case MsgDef.MSG_PO:                                           // pos msg
                        m_PageFlyMap.Show_Pos_Information();
                        break;
                    case MsgDef.MSG_LPID:                                       // pid para
                        if (App.plane_type == 0)
                            m_PagePidPara.Show_Multi_Motor_Basic_Pid();
                        else
                            m_PagePlaneSettings.Show_FX_Channel_Config();
                        break;
                    case MsgDef.MSG_FW_MM_PID:                        // fixwing plane multi pid
                        if (App.plane_type == 1 || App.plane_type == 2)
                            m_PagePlaneSettings.Update_FW_MM_Pid();
                        break;
                    case MsgDef.MSG_FW_PID:                                  // fix wing pid
                        if (App.plane_type == 1 || App.plane_type == 2)
                            m_PagePlaneSettings.Update_FW_Pid();
                        break;
                    case MsgDef.MSG_APTYPE:                                    // plane type msg
                        if (App.plane_type == 0)
                            m_PagePlaneSettings.Show_Plane_Settings();
                        else
                            m_PagePlaneSettings.Update_Fw_Settings2();
                        break;
                    case MsgDef.MSG_WP:                                            // wpt msg
                        Window_Skyway.getInstance().Down_Wpt_From_Plane();
                        break;
                    case MsgDef.MSG_VER:                                            // firmware version
                        m_PageTaskFunction.Show_Version();
                        break;
                    case MsgDef.MSG_GPS_BIAS:                                  // gps bias
                        m_PageFixDirection.Update_Gps_Bias();
                        break;
                    case MsgDef.MSG_PAR:                                             // fly para
                        m_ParSetting.Update_Para_Setting();
                        break;
                    case MsgDef.MSG_SINGLE_CONFIG:                       // single msg configration
                        Update_Single_Msg();
                        break;
                    case MsgDef.PICTURE_TRIGGER_MODE:
                        if (App.plane_type == 1 || App.plane_type == 2)
                        {
                            m_PagePlaneSettings.Update_Fw_Settings();
                        }
                        break;
                    case MsgDef.MSG_FORBID_AREA:
                        Page_2D_Map.Add_No_Fly_Area(Page_2D_Map.Points_Forbid);
                        break;
                    case MsgDef.MSG_TRANSPARENT:
                        Window_Engine.getInstance().Show_Engine_Infor();
                        break;
                    case 199:                                                                           // firmware update warnning
                        WarningMsg.Update_Warnning_Msg(DATA_LINK.str_update_warnning);
                        break;
                    default:
                        break;
                }
            }));
        }

        /******************************************************************************
        * 功   能：单一参数回馈信息
        * 参   数：
        * 返   回：
        * ****************************************************************************/
        private void Update_Single_Msg()
        {
            switch (DataProcess_JD.m_Msg_Single_Para.single_msg_id)
            {
                case SINGLE_MSG_DEFINE.Single_Msg_Gps_Heading:
                    if (App.plane_type == 0)
                        m_PageFixDirection.Combox_Gps_Heading.SelectedIndex = DataProcess_JD.m_Msg_Single_Para.msg_value;
                    else
                        m_chuiqi_settings2.Combox_Gps_Heading.SelectedIndex = DataProcess_JD.m_Msg_Single_Para.msg_value;
                    break;
                case 65:
                    Window_Gps_Follow.getInstance().TextBox_Right_Dist.Text = ((double)DataProcess_JD.m_Msg_Single_Para.msg_value / 100).ToString("0.0");
                    break;
                case 66:
                    Window_Gps_Follow.getInstance().TextBox_Front_Dist.Text = ((double)DataProcess_JD.m_Msg_Single_Para.msg_value / 100).ToString("0.0");
                    break;
                case 67:
                    Window_Gps_Follow.getInstance().TextBox_Yaw_Error.Text = ((double)DataProcess_JD.m_Msg_Single_Para.msg_value).ToString("0");
                    break;
                default:
                    break;
            }
        }

        /********************************************************************************
         * function: show emergency information of multiple motors
         * para:
         * return:
         * *******************************************************************************/
        private void Show_Emergency_Infor(FLY_INFOR_DISPLAY mFly_Infor_Display)
        {
            // 每次更新状态前先将状态设置为正常
            WarningMsg.Update_Warnning_Msg("");

            bool warnning_txt_exist = false;

            // 陀螺加速度计报错
            if ((byte)(mFly_Infor_Display.gyro_acc_status & 0xFF) != (byte)0x00)
            {
                if (warnning_txt_exist == false)
                {
                    if ((byte)(mFly_Infor_Display.gyro_acc_status & 0xFF) == (byte)0x01)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_GYRO1_WARNNING").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.gyro_acc_status & 0xFF) == (byte)0x02)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_GYRO2_WARNNING").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.gyro_acc_status & 0xFF) == (byte)0x04)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_ACC1_WARNNING").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.gyro_acc_status & 0xFF) == (byte)0x08)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_ACC2_WARNNING").ToString());
                    }
                    warnning_txt_exist = true;
                }
            }

            // 禁飞区提醒
            if (App.plane_type == 0)
            {
                if (mFly_Infor_Display.in_forbidden_area_count != 0)
                {
                    if (warnning_txt_exist == false)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_IN_FORBIDDEN_AREA").ToString());
                        warnning_txt_exist = true;
                    }
                }
            }

            if (warnning_txt_exist == false)
            {
                if (App.plane_type == 0)        // multiple motors
                {
                    // 更新报警信息，此类报警主要是因为传感器错误，遥控器错误，解算错误等
                    if (mFly_Infor_Display.warnning_flag != 1)
                    {
                        switch (mFly_Infor_Display.warnning_flag)
                        {
                            case 2:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_NO_IMU").ToString());
                                break;
                            case 3:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_DMA_ERROR").ToString());
                                break;
                            case 4:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_REMOTOR_BTN_ERROR").ToString());
                                break;
                            case 5:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_LOW_BATTERY").ToString());
                                break;
                            case 6:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_REDIO_LOST").ToString());
                                break;
                            case 8:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_GPS_LOST").ToString());
                                break;
                            case 9:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_ACC_ERROR").ToString());
                                break;
                            case 10:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_SPEED_ERROR").ToString());
                                break;
                            case 15:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_NOISE_ERROR").ToString());
                                break;
                            case 21:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_HIGH_TEMPERATURE").ToString());
                                break;
                            case 22:
                                WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_VERSION_ERROR").ToString());
                                break;
                            default:
                                break;
                        }
                    }
                }
                else if (App.plane_type == 1)       // fix wing
                {
                    if ((byte)(mFly_Infor_Display.warnning_flag & 0x01) == (byte)0x01)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_NO_IMU").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.warnning_flag & 0x02) == (byte)0x02)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_DMA_ERROR").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.warnning_flag & 0x04) == (byte)0x04)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_REMOTOR_BTN_ERROR").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.warnning_flag & 0x08) == (byte)0x08)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_LOW_BATTERY").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.warnning_flag & 0x10) == (byte)0x10)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_REDIO_LOST").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.warnning_flag & 0x20) == (byte)0x20)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_GPS_LOST").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.warnning_flag & 0x40) == (byte)0x40)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_ACC_ERROR").ToString());
                    }
                    else if ((byte)(mFly_Infor_Display.warnning_flag & 0x80) == (byte)0x80)
                    {
                        WarningMsg.Update_Warnning_Msg(TryFindResource("TITLE_WARNNING_SPEED_ERROR").ToString());
                    }
                }
            }
        }

        /********************************************************************************
         * function:
         * para:
         * return:
         * *******************************************************************************/
        private void Set_Menue_Btn_White()
        {
            MENUE_BTN_PLANE_SETTINGS.Background = System.Windows.Media.Brushes.Black;
            MENUE_BTN_WPT_PLAN.Background = System.Windows.Media.Brushes.Black;
            MENUE_BTN_FLY_INFO.Background = System.Windows.Media.Brushes.Black;
            MENUE_BTN_TASK_SETTING.Background = System.Windows.Media.Brushes.Black;
            MENUE_BTN_2D_3D.Background = System.Windows.Media.Brushes.Black;
        }

        /********************************************************************************
         * function:
         * para:
         * return:
         * *******************************************************************************/
        private void MENUE_BTN_PLANE_SETTINGS_Click(object sender, RoutedEventArgs e)
        {
            page_Index = 1;
            frmMainShow.Navigate(m_PagePlaneSettings);

            Set_Menue_Btn_White();
            MENUE_BTN_PLANE_SETTINGS.Background = System.Windows.Media.Brushes.Orange;
            Hide_All_Window();
        }

        /*******************************************************************************
        * 功   能：进入航线编辑页
        * 参   数：
        * 返   回：
        * *****************************************************************************/
        private void MENUE_BTN_WPT_PLAN_Click(object sender, RoutedEventArgs e)
        {
            if (Page_2D_Map.addptbool == 1 || Page_2D_Map.addptbool == 2 || Page_2D_Map.addptbool == 4)
            {
                Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString());
                return;
            }

            if (Window_Skyway.mb_wnd_visible == false)
            {
                Window_Skyway.getInstance().Show_Wnd();
            }
            else
            {
                Window_Skyway.getInstance().Hide_Wnd();
            }
        }

        /*******************************************************************************
        * 功   能：进入飞行信息显示页
        * 参   数：
        * 返   回：
        * *****************************************************************************/
        private void MENUE_BTN_FLY_INFO_Click(object sender, RoutedEventArgs e)
        {
            page_Index = 2;

            frmMainShow.Navigate(m_PageFlyMap);
            m_PageFlyMap.SetMode(map_show_type);

            Set_Menue_Btn_White();
            MENUE_BTN_FLY_INFO.Background = System.Windows.Media.Brushes.Orange;

            Show_All_Wnd();
        }

        /*******************************************************************************
        * 功   能：任务功能设置显示页
        * 参   数：
        * 返   回：
        * *****************************************************************************/
        private void MENUE_BTN_TASK_SETTING_Click(object sender, RoutedEventArgs e)
        {
            page_Index = 3;
            frmMainShow.Navigate(m_PageTaskFunction);

            Set_Menue_Btn_White();
            MENUE_BTN_TASK_SETTING.Background = System.Windows.Media.Brushes.Orange;

            Hide_All_Window();

            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_VER, 0);
        }

        /*********************************************************************
         * 功   能：切换2D/3D地图
         * 参   数：
         * 返   回：
         * *******************************************************************/
        public static byte page_Index = 0;
        public static byte map_show_type = 2;   // 默认三维地图
        private void MENUE_BTN_2D_3D_Click(object sender, RoutedEventArgs e)
        {
            SKY_WAY skyway_temp = Window_Skyway.Get_Cur_SkyWay();
            List<WAY_POINT> wptTemp = null;

            if (skyway_temp != null)
                wptTemp = skyway_temp.wayPointSet;

            // 由2D地图切换到3D地图
            if (map_show_type == 2)
            {
                if (Page_2D_Map.addptbool != 0)
                {
                    Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString());
                    return;
                }

                map_show_type = 3;
                MENUE_BTN_2D_3D.Content = "3D";
                Window_Skyway.getInstance().Btn_Shift_Wpt.Visibility = Visibility.Hidden;

                // 将视角切换到同一个地点
                if (Page_Google_Map.initmap == true)
                {
                    m_PageGoogleMap.webBrowser_google_earth.InvokeScript("updataLookat", new object[] {
                                m_Page2DMap.TouchDownEnd.Lng, m_Page2DMap.TouchDownEnd.Lat, 0, 1000});

                    // 将二维地图上的航线移到googleearth上
                    if (wptTemp != null && wptTemp.Count > 0)
                    {
                        Page_Google_Map.Delete_All_Wpt_3D();
                        for (int i = 0; i < wptTemp.Count; i++)
                        {
                            m_PageGoogleMap.webBrowser_google_earth.InvokeScript("AddSkyWay", new object[] {
                            wptTemp[i].lon, wptTemp[i].lat, wptTemp[i].alt, wptTemp[i].alt_level, i});
                        }
                    }
                }

                // 如果是在飞行信息显示页面
                if (page_Index == 2)
                {
                    m_PageFlyMap.Frm_Map_Show2.Navigate(m_PageGoogleMap);
                }

                Window_Skyway.getInstance().combox_skyway_no.IsEnabled = false;
            }
            // 由3D地图切换到2D地图
            else if (map_show_type == 3)
            {
                if (Page_Google_Map.wptEditType != 0)
                {
                    Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString());
                    return;
                }
                map_show_type = 2;
                MENUE_BTN_2D_3D.Content = "2D";
                Window_Skyway.getInstance().Btn_Shift_Wpt.Visibility = Visibility.Visible;

                PointLatLng currentloc = new PointLatLng(m_Page2DMap.TouchDownEnd.Lat, m_Page2DMap.TouchDownEnd.Lng);
                m_Page2DMap.gMap_2D.Position = currentloc;
                m_Page2DMap.gMap_2D.Zoom = 18;

                // 将googleearth上的航线信息添加到二维地图上
                if (wptTemp != null && wptTemp.Count > 0)
                {
                    Page_2D_Map.Add_Skyway_On_Map(Window_Skyway.Get_Cur_SkyWay());
                }

                // 如果是在飞行信息显示页面
                if (page_Index == 2)
                {
                    m_PageFlyMap.Frm_Map_Show2.Navigate(m_Page2DMap);
                }

                Window_Skyway.getInstance().combox_skyway_no.IsEnabled = true;
            }
        }

        /*************************************************************************
        function: hide all display window when menu is not in FLY_INFOR
        para:
        return:
        * **********************************************************************/
        void Hide_All_Window()
        {
            if (Window_Fly_Point.mb_wnd_initializaed == true)
                Window_Fly_Point.getInstance().Hide();

            if (mWndCtrl != null)
                mWndCtrl.Hide();

            if (m_WndFlyInfor != null)
                m_WndFlyInfor.Hide();

            if (Window_Chart.mb_wnd_initialized == true)
                Window_Chart.getInstance().Hide();

            if (Window_Replay.mb_wnd_initialized == true)
                Window_Replay.getInstance().Hide();

            if (Window_Hover_Shift.mb_wnd_initializaed == true)
                Window_Hover_Shift.getInstance().Hide();

            if (Window_Gps_Follow.mb_wnd_initializaed == true)
                Window_Gps_Follow.getInstance().Hide();

            if (Window_Video_Control.mb_wnd_initializaed == true)
            {
                Page_Fly_Map.formWnd.Hide();
                Window_Video_Control.getInstance().Hide();
            }

            if (m_WndChuiQi != null)
                m_WndChuiQi.Hide();

            if (Window_WPT_SHIFT.mb_wnd_initializaed == true)
                Window_WPT_SHIFT.getInstance().Hide();

            if (Window_Skyway.mb_wnd_initializaed == true)
                Window_Skyway.getInstance().Hide();

            if (Window_Head_To_Pt.mb_wnd_initializaed == true)
                Window_Head_To_Pt.getInstance().Hide();

            if (Window_Set_Home.mb_wnd_initializaed == true)
                Window_Set_Home.getInstance().Hide();

            if (Window_Engine.mb_wnd_initializaed == true)
                Window_Engine.getInstance().Hide();
        }

        /*****************************************************************
      * 功   能：记录飞行检测页面的窗口打开状态
      * 参   数：
      * 返   回：
      * **************************************************************/
        public void Show_All_Wnd()
        {
            if (m_WndFlyInfor != null)
            {
                if (Page_Fly_Map.fly_infor_wnd_show == true)
                    m_WndFlyInfor.Show();
            }

            if (m_WndChuiQi != null)
            {
                if (Page_Fly_Map.fly_infor_wnd_show == true)
                    m_WndChuiQi.Show();
            }

            if (mWndCtrl != null)
            {
                mWndCtrl.Show();
            }

            if (Window_Fly_Point.mb_wnd_visible == true)
            {
                Window_Fly_Point.getInstance().Show();
            }

            if (Window_Replay.mb_wnd_visible == true)
            {
                Window_Replay.getInstance().Show_Wnd();
            }

            if (Window_Chart.mb_wnd_visible == true)
                Window_Chart.getInstance().Show_Wnd();

            if (Window_Gps_Follow.mb_wnd_visible == true)
                Window_Gps_Follow.getInstance().Show();

            if (Window_Video_Control.mb_wnd_visible == true)
            {
                Page_Fly_Map.formWnd.Show();
                Window_Video_Control.getInstance().Show_Wnd();
            }

            if (Window_Skyway.mb_wnd_visible == true)
                Window_Skyway.getInstance().Show_Wnd();

            if (Window_WPT_SHIFT.mb_wnd_visible == true)
                Window_WPT_SHIFT.getInstance().Show();

            if (Window_Head_To_Pt.mb_wnd_visible == true)
                Window_Head_To_Pt.getInstance().Show();

            if (Window_Set_Home.mb_wnd_visible == true)
                Window_Set_Home.getInstance().Show();

            if (Window_Engine.mb_wnd_visible == true)
                Window_Engine.getInstance().Show();
        }

        /*************************************************************************
        * 功   能：选择使用语言
        * 参   数：
        * 返   回：
        * **********************************************************************/
        private void combox_language_Changed(object sender, SelectionChangedEventArgs e)
        {
            Page_Remoter_Calibrate_Instruction mPageRemoterCalibrateInstruction = Page_Remoter_Calibrate_Instruction.getInstance();

            string str_path = Directory.GetCurrentDirectory();
            if (bMain_Wnd_Init == true && combox_language.SelectedIndex >= 0)
            {
                App.Current.Resources.MergedDictionaries.RemoveAt(0);
                App.language_type = (byte)(combox_language.SelectedIndex);

                if (App.language_type == 0)
                {
                    App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Resources/StringResource.zh-CN.xaml", UriKind.RelativeOrAbsolute) });
                }
                else if (App.language_type == 1)
                {
                    App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Resources/StringResource.en-US.xaml", UriKind.RelativeOrAbsolute) });
                }
                else if (App.language_type == 2)
                {
                    App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Resources/StringResource.tr-TR.xaml", UriKind.RelativeOrAbsolute) });
                }

                ReadConfigFile.WritePrivateProfileString("IP_SET", "language", (combox_language.SelectedIndex + 1).ToString(), str_path + "\\Start_Up.ini");

                // set the instruction to english
                mPageRemoterCalibrateInstruction.Show_Remoter_Instruction();
            }
        }

        /*******************************************************************************
         * function:
         * para:
         * return:
         * *****************************************************************************/
        private void MENUE_BTN_LINK_SET_Click(object sender, RoutedEventArgs e)
        {
            Window_Port.getInstance().ShowDialog();

            string[] portsName = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(portsName);

            Window_Port.getInstance().combox_serial_array.ItemsSource = portsName;
        }

        /***********************************************************************
        * function:
        * para:
        * return:
        * *********************************************************************/
        private bool m_WndStateMax = true;
        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)//Esc键  
            {
                if (m_WndStateMax == true)
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    m_WndStateMax = false;
                }
                else
                {
                    WindowStyle = WindowStyle.None;
                    WindowState = WindowState.Maximized;
                    m_WndStateMax = true;
                }
            }
            else if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right
                        || e.Key == Key.A || e.Key == Key.S || e.Key == Key.W || e.Key == Key.D)
            {
                if (Window_Hover_Shift.mb_wnd_visible == true)
                    Window_Hover_Shift.getInstance().Activate();
            }
        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Close_Application();
            e.Cancel = true;
        }

        /**********************************************************************************************
         * function:
         * para:
         * return:
         * ********************************************************************************************/
        public static void Close_Application()
        {
            Page_2D_Map m_Page2DMap = Page_2D_Map.getInstance();

            string str_path = Directory.GetCurrentDirectory();
            ReadConfigFile.WritePrivateProfileString("IP_SET", "init_lon", m_Page2DMap.TouchDownEnd.Lng.ToString(), str_path + "\\Start_Up.ini");
            ReadConfigFile.WritePrivateProfileString("IP_SET", "init_lat", m_Page2DMap.TouchDownEnd.Lat.ToString(), str_path + "\\Start_Up.ini");

            if (DATA_LINK.sw_save_downlink_data != null)
                DATA_LINK.sw_save_downlink_data.Close();

            if (stream_gcs_log != null)
            {
                stream_gcs_log.Close();
            }

            // 如果有googleearth的进程，则先结束该进程
            System.Diagnostics.Process[] processArr = System.Diagnostics.Process.GetProcesses();
            for (int i = 0; i < processArr.Length; i++)
            {
                if (processArr[i].ProcessName.ToString() == "geplugin")
                {
                    processArr[i].Kill();
                    break;
                }
            }
            try
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                Application.Current.Shutdown();
                Environment.Exit(0);
            }
            catch
            {
            }
        }

        /*********************************************************************************
         * function: set the system single or multi
         * para:
         * return:
         * ********************************************************************************/
        private void Single_Many_Show()
        {
            GRID_SHOW_PLANE.ColumnDefinitions.Clear();

            ColumnDefinition c1 = new ColumnDefinition();
            ColumnDefinition c2 = new ColumnDefinition();

            if (App.single_many_type == 0)
            {
                c1.Width = new GridLength(103, GridUnitType.Star);
                c2.Width = new GridLength(0, GridUnitType.Star);

                DATA_LINK.Set_System_All_Id(0);
                DATA_LINK.Set_System_Id(0);
            }
            else if (App.single_many_type == 1)
            {
                c1.Width = new GridLength(100, GridUnitType.Star);
                c2.Width = new GridLength(3, GridUnitType.Star);

                DATA_LINK.Set_System_All_Id(1);
                DATA_LINK.Set_System_Id(1);
            }

            GRID_SHOW_PLANE.ColumnDefinitions.Add(c1);
            GRID_SHOW_PLANE.ColumnDefinitions.Add(c2);
        }

        private void BTN_SELECT_PLANE_ONE_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_ONE.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(1);
            DATA_LINK.Set_System_All_Id(1);
        }

        private void BTN_SELECT_PLANE_TWO_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_TWO.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(2);
            DATA_LINK.Set_System_All_Id(2);
        }

        private void BTN_SELECT_PLANE_THREE_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_THREE.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(3);
            DATA_LINK.Set_System_All_Id(3);
        }

        private void BTN_SELECT_PLANE_FOUR_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_FOUR.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(4);
            DATA_LINK.Set_System_All_Id(4);
        }

        private void BTN_SELECT_PLANE_FIVE_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_FIVE.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(5);
            DATA_LINK.Set_System_All_Id(5);
        }
        private void BTN_SELECT_PLANE_SIX_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_SIX.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(6);
            DATA_LINK.Set_System_All_Id(6);
        }
        private void BTN_SELECT_PLANE_SEVEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_SEVEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(7);
            DATA_LINK.Set_System_All_Id(7);
        }
        private void BTN_SELECT_PLANE_EIGHT_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_EIGHT.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(8);
            DATA_LINK.Set_System_All_Id(8);
        }
        private void BTN_SELECT_PLANE_NINE_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_NINE.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(9);
            DATA_LINK.Set_System_All_Id(9);
        }
        private void BTN_SELECT_PLANE_TEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_TEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(10);
            DATA_LINK.Set_System_All_Id(10);
        }
        private void BTN_SELECT_PLANE_ELEVEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_ELEVEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(11);
            DATA_LINK.Set_System_All_Id(11);
        }
        private void BTN_SELECT_PLANE_TWELVE_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_TWELVE.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(12);
            DATA_LINK.Set_System_All_Id(12);
        }
        private void BTN_SELECT_PLANE_THIRTEEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_THIRTEEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(13);
            DATA_LINK.Set_System_All_Id(13);
        }
        private void BTN_SELECT_PLANE_FOURTEEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_FOURTEEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(14);
            DATA_LINK.Set_System_All_Id(14);
        }
        private void BTN_SELECT_PLANE_FIFTEEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_FIFTEEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(15);
            DATA_LINK.Set_System_All_Id(15);
        }
        private void BTN_SELECT_PLANE_SIXTEEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_SIXTEEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(16);
            DATA_LINK.Set_System_All_Id(16);
        }
        private void BTN_SELECT_PLANE_SEVENTEEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_SEVENTEEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(17);
            DATA_LINK.Set_System_All_Id(17);
        }
        private void BTN_SELECT_PLANE_EIGHTEEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_EIGHTEEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(18);
            DATA_LINK.Set_System_All_Id(18);
        }
        private void BTN_SELECT_PLANE_NINETEEN_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_NINETEEN.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(19);
            DATA_LINK.Set_System_All_Id(19);
        }
        private void BTN_SELECT_PLANE_TWENTY_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_TWENTY.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_Id(20);
            DATA_LINK.Set_System_All_Id(20);
        }
        private void BTN_SELECT_PLANE_ALL_Click(object sender, RoutedEventArgs e)
        {
            Set_All_Plane_Default();
            BTN_SELECT_PLANE_ALL.BorderBrush = System.Windows.Media.Brushes.Orange;
            DATA_LINK.Set_System_All_Id(0xFF);
        }

        private void Set_All_Plane_Default()
        {
            BTN_SELECT_PLANE_ONE.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_TWO.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_THREE.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_FOUR.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_FIVE.BorderBrush = System.Windows.Media.Brushes.Black;

            BTN_SELECT_PLANE_SIX.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_SEVEN.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_EIGHT.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_NINE.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_TEN.BorderBrush = System.Windows.Media.Brushes.Black;

            BTN_SELECT_PLANE_ELEVEN.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_TWELVE.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_THIRTEEN.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_FOURTEEN.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_FIFTEEN.BorderBrush = System.Windows.Media.Brushes.Black;

            BTN_SELECT_PLANE_SIXTEEN.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_SEVENTEEN.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_EIGHTEEN.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_NINETEEN.BorderBrush = System.Windows.Media.Brushes.Black;
            BTN_SELECT_PLANE_TWENTY.BorderBrush = System.Windows.Media.Brushes.Black;

            BTN_SELECT_PLANE_ALL.BorderBrush = System.Windows.Media.Brushes.Black;
        }

        private void BTN_WND_NORMAL_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
        }

        private void BTN_WND_MAX_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void BTN_WND_EXIT_Click(object sender, RoutedEventArgs e)
        {
            Close_Application();
        }
        private void BTN_WND_MIN_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
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

        private void combox_map_type_Changed(object sender, SelectionChangedEventArgs e)
        {
            m_Page2DMap.Set_Map_Type(combox_map_type.SelectedIndex);
        }
    }
}
