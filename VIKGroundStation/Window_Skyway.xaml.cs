using GMap.NET;
using GMap.NET.WindowsForms;
using Ionic.Zip;
using MissionPlanner.Utilities;
using SharpKml.Base;
using SharpKml.Dom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_Skyway.xaml 的交互逻辑
    /// </summary>
    public partial class Window_Skyway : Window
    {
        private static Window_Skyway m_wnd_skyway = new Window_Skyway();
        public static Window_Skyway getInstance()
        {
            if (m_wnd_skyway == null)
                m_wnd_skyway = new Window_Skyway();

            mb_wnd_initializaed = true;
            return m_wnd_skyway;
        }

        public void Show_Wnd()
        {
            Show();
            mb_wnd_visible = true;
        }
        public void Hide_Wnd()
        {
            Hide();
            mb_wnd_visible = false;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;

        public static List<BOUND_PT> boudPt_Mianji = new List<BOUND_PT>();    // 用来计算面积
        public static List<WAY_POINT> wayPointSet_Copy = new List<WAY_POINT>();
        public static List<BOUND_PT> bound_pt_list = new List<BOUND_PT>();      // 边界集
        public static List<SKY_WAY> m_sky_way_list = new List<SKY_WAY>();

        private DispatcherTimer timer_upload_wpt;
        public static ushort Req_Wpt_Index = 1;         // 读取航线时请求航点的索引
        public static ushort Req_Wpt_Count = 0;        // 读取航点时的发送的请求次数
        public Window_Skyway()
        {
            InitializeComponent();
            Owner = MainWindow.getInstance();
            Hide();

            Top = (SystemParameters.PrimaryScreenHeight) * 0.05;
            Left = (SystemParameters.PrimaryScreenWidth - this.Width);

            timer_upload_wpt = new DispatcherTimer();
            timer_upload_wpt.Interval = System.TimeSpan.FromMilliseconds(100);
            timer_upload_wpt.Tick += timer_upload_wpt_Tick;

            Btn_Shift_Wpt.Visibility = Visibility.Visible;

            if (App.plane_type == 0)
            {
                combox_turn_mode.Items.Add(TryFindResource("TITLE_AUTO_TURN"));
                combox_turn_mode.Items.Add(TryFindResource("TITLE_HOVER"));
                combox_turn_mode.Items.Add(TryFindResource("TITLE_LOCK_HEAD_TURN"));
                combox_turn_mode.Items.Add(TryFindResource("TITLE_THROW"));
                combox_turn_mode.Items.Add(TryFindResource("TITLE_LANDING"));
                combox_turn_mode.Items.Add(TryFindResource("TITLE_HORIZON_CIRCLE"));
            }
            else
            {
                combox_turn_mode.Items.Add(TryFindResource("TITLE_AUTO_TURN"));
                combox_turn_mode.Items.Add(TryFindResource("TITLE_HORIZON_CIRCLE"));
                combox_turn_mode.Items.Add(TryFindResource("TITLE_BACK_HOME"));
                combox_turn_mode.Items.Add(TryFindResource("TITLE_REPEAT_WPT"));
                combox_turn_mode.Items.Add(TryFindResource("TITLE_LANDING"));
            }
            combox_turn_mode.SelectedIndex = 0;

            combox_task.Items.Add(TryFindResource("TITLE_NO_TASK"));
            combox_task.Items.Add(TryFindResource("TITLE_PIC_BY_DIST"));
            combox_task.Items.Add(TryFindResource("TITLE_PIC_BY_TIME"));
            combox_task.SelectedIndex = 0;

            combox_alt_type.Items.Add(TryFindResource("TITLE_RELATIVE_ALT"));
            combox_alt_type.Items.Add(TryFindResource("TITLE_ABSOLUTE_ALT"));
            combox_alt_type.SelectedIndex = 0;

            for (int i = 0; i < 10; i++)
            {
                combox_skyway_no.Items.Add((i + 1).ToString());
            }

            combox_skyway_no.SelectedIndex = 0;

            System.Diagnostics.Debug.WriteLine("Skyway window initialize successfully");
        }

        public static SKY_WAY Get_Cur_SkyWay()
        {
            if (m_sky_way_list.Count < 1)
                return null;
            else
                return m_sky_way_list[cur_skyway_no];
        }

        /******************************************************************************
        * 功   能：上传航点到飞控
        * 参   数：
        * 返   回：
        * ***************************************************************************/
        private int curPackSendTimes = 0;
        private void timer_upload_wpt_Tick(object sender, EventArgs e)
        {
            int count = m_sky_way_list[cur_skyway_no].wayPointSet.Count;
            if (!curWaypointTransferSucceed && curWaypointSeq < count)
            {
                Upload_Wpt(MsgDef.MSG_WP, curWaypointSeq);
                string strTemp = TryFindResource("TITLE_WPT_IS_UPLOADING").ToString() + (curWaypointSeq + 1).ToString() + "/" + count.ToString();
                MessageTimerWindow.Update_Data(strTemp);

                curPackSendTimes++;
                if (curPackSendTimes >= 100)
                {
                    timer_upload_wpt.Stop();
                    Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_WPT_UPLOAD_FAIL").ToString());

                    return;
                }
            }
            else
            {
                curPackSendTimes = 0;
                curWaypointSeq++;
                curWaypointTransferSucceed = false;
            }
            // 所有航点上传完成，则提示
            if (curWaypointSeq >= count && count != 0)
            {
                MessageTimerWindow.Update_Data("");
                curWaypointSeq = 0;
                timer_upload_wpt.Stop();

                Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_WPT_UPLOAD_SUCCESS").ToString());
            }
        }

        /**********************************************************************
         * 功   能：上传航点，固定翼和多选翼航点格式一致
         * 参   数：
         * 返   回：
         * *******************************************************************/
        private void Upload_Wpt(byte msg_id, int msg_id2)
        {
            byte[] buf_msg_wp = new byte[255];
            byte index = 0;
            byte system_id = DATA_LINK.Get_System_Set_Id();

            buf_msg_wp[index++] = (byte)0xfe;
            buf_msg_wp[index++] = (byte)26;
            buf_msg_wp[index++] = (byte)0;
            buf_msg_wp[index++] = (byte)system_id;
            buf_msg_wp[index++] = (byte)0;
            buf_msg_wp[index++] = (byte)msg_id;

            buf_msg_wp[index++] = BitConverter.GetBytes(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].NumberId)[0];
            buf_msg_wp[index++] = BitConverter.GetBytes(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].NumberId)[1];

            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].lon * Math.Pow(10, 7)))[0];
            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].lon * Math.Pow(10, 7)))[1];
            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].lon * Math.Pow(10, 7)))[2];
            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].lon * Math.Pow(10, 7)))[3];

            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].lat * Math.Pow(10, 7)))[0];
            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].lat * Math.Pow(10, 7)))[1];
            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].lat * Math.Pow(10, 7)))[2];
            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].lat * Math.Pow(10, 7)))[3];

            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].alt * 100))[0];
            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].alt * 100))[1];
            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].alt * 100))[2];
            buf_msg_wp[index++] = BitConverter.GetBytes((int)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].alt * 100))[3];

            buf_msg_wp[index++] = BitConverter.GetBytes((short)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].speed * 100))[0];
            buf_msg_wp[index++] = BitConverter.GetBytes((short)(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].speed * 100))[1];

            buf_msg_wp[index++] = m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].byte_turn_mode;

            buf_msg_wp[index++] = BitConverter.GetBytes(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].turn_time)[0];
            buf_msg_wp[index++] = BitConverter.GetBytes(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].turn_time)[1];

            if (m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].str_renwu == TryFindResource("TITLE_NO_TASK").ToString())
            {
                buf_msg_wp[index++] = 1;
            }
            else if (m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].str_renwu == TryFindResource("TITLE_PIC_BY_DIST").ToString())
            {
                buf_msg_wp[index++] = 2;
            }
            else if (m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].str_renwu == TryFindResource("TITLE_PIC_BY_TIME").ToString())
            {
                buf_msg_wp[index++] = 3;
            }
            else
            {
                buf_msg_wp[index++] = 1;
            }
            buf_msg_wp[index++] = BitConverter.GetBytes(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].pic_interval)[0];
            buf_msg_wp[index++] = BitConverter.GetBytes(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].pic_interval)[1];

            buf_msg_wp[index++] = BitConverter.GetBytes(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].wpt_heading)[0];
            buf_msg_wp[index++] = BitConverter.GetBytes(m_sky_way_list[cur_skyway_no].wayPointSet[msg_id2].wpt_heading)[1];

            buf_msg_wp[index++] = wpt_alt_type;

            buf_msg_wp[index++] = BitConverter.GetBytes((short)m_sky_way_list[cur_skyway_no].wayPointSet.Count)[0];
            buf_msg_wp[index++] = BitConverter.GetBytes((short)m_sky_way_list[cur_skyway_no].wayPointSet.Count)[1];

            buf_msg_wp[1] = (byte)(index - 6);

            buf_msg_wp[index] = CRC.Get_Crc16(buf_msg_wp, 0, (short)(index))[0];
            buf_msg_wp[index + 1] = CRC.Get_Crc16(buf_msg_wp, 0, (short)(index))[1];

            DATA_LINK.Send_Buf(buf_msg_wp, index + 2);
        }

        /************************************************************************************
        功   能：更新航线属性的显示
        参   数：
        返   回：
        * **********************************************************************************/
        private void UpdateWptPara()
        {
            int index = wpt_list_box.SelectedIndex;
            if (index >= 0)
            {
                TextBlock_Wpt_Num.Text = (index + 1).ToString();
                TextBox_WptLon.Text = Math.Round(m_sky_way_list[cur_skyway_no].wayPointSet[index].lon, 7).ToString();
                TextBox_WptLat.Text = Math.Round(m_sky_way_list[cur_skyway_no].wayPointSet[index].lat, 7).ToString();

                TextBox_WptAlt.Text = m_sky_way_list[cur_skyway_no].wayPointSet[index].alt.ToString();
                TextBox_WptSpeed.Text = m_sky_way_list[cur_skyway_no].wayPointSet[index].speed.ToString();

                if (App.plane_type == 0)
                {
                    combox_turn_mode.SelectedIndex = m_sky_way_list[cur_skyway_no].wayPointSet[index].byte_turn_mode - 1;
                }
                else
                {
                    if (m_sky_way_list[cur_skyway_no].wayPointSet[index].byte_turn_mode == 1)
                        combox_turn_mode.SelectedIndex = m_sky_way_list[cur_skyway_no].wayPointSet[index].byte_turn_mode - 1;
                    else
                        combox_turn_mode.SelectedIndex = m_sky_way_list[cur_skyway_no].wayPointSet[index].byte_turn_mode - 3;
                }
                TextBox_Turn_Time.Text = m_sky_way_list[cur_skyway_no].wayPointSet[index].turn_time.ToString();

                combox_task.SelectedIndex = m_sky_way_list[cur_skyway_no].wayPointSet[index].byte_renwunum - 1;
                TextBox_Task_Time.Text = m_sky_way_list[cur_skyway_no].wayPointSet[index].pic_interval.ToString();

                TextBox_Turn_Heading.Text = m_sky_way_list[cur_skyway_no].wayPointSet[index].wpt_heading.ToString();
            }
        }

        private void lvwOverallViewWayPointInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateWptPara();
        }

        /*******************************************************************************
       * 功   能：在2D地图上添加航点
       * 参   数：
       * 返   回：
       * ******************************************************************************/
        public void Add_Wpt_To_WptList(double lat, double lng, int alt)
        {
            var wptTemp = new WAY_POINT
            {
                NumberId = (short)(m_sky_way_list[cur_skyway_no].wayPointSet.Count + 1),
                lon = lng,
                lat = lat,

                speed = double.Parse(TextBox_WptSpeed.Text),
                alt = double.Parse(TextBox_WptAlt.Text),

                byte_turn_mode = m_wpt_turn_mode,

                turn_time = short.Parse(TextBox_Turn_Time.Text),
                alt_level = 0,

                byte_renwunum = (byte)(combox_task.SelectedIndex + 1),
                pic_interval = short.Parse(TextBox_Task_Time.Text),
            };

            wptTemp.str_turn_mode = combox_turn_mode.Text;
            wptTemp.str_renwu = combox_task.Text;

            m_sky_way_list[cur_skyway_no].wayPointSet.Add(wptTemp);
            Update_Wpt_View_List();
        }


        /*****************************************************************
         * 功   能：更新航线显示列表
         * 参   数：
         * 返   回：
         * **************************************************************/
        public void Update_Wpt_View_List(/*List<WAY_POINT> wayPointSet*/)//更新列表
        {
            List<WAY_POINT> wayPointSet = m_sky_way_list[cur_skyway_no].wayPointSet;
            wpt_list_box.Items.Clear();

            int count = wayPointSet.Count;
            int i = 0, all_dis = 0, all_time = 0;
            float all_dist_km = 0;

            if (count == 0)
            {
                all_dis = 0;
                all_time = 0;
                return;
            }

            for (i = 0; i < count; i++)
            {
                System.Windows.Controls.ListViewItem item = new System.Windows.Controls.ListViewItem();
                wayPointSet[i].NumberId = (short)(i + 1);
                item.Content = wayPointSet[i];
                wpt_list_box.Items.Add(item);

                // 计算航线总长度和总的飞行时间
                if (i > 0)
                {
                    all_dis = all_dis + (int)(Compute.dis_math(wayPointSet[i].lon, wayPointSet[i - 1].lon, wayPointSet[i].lat, wayPointSet[i - 1].lat));
                    all_dist_km = (float)all_dis / 1000;
                    if ((wayPointSet[0].speed) == 0)
                    {
                        all_time = 0;
                    }
                    else
                    {
                        all_time = (int)(all_dis / wayPointSet[0].speed);
                    }
                }
            }

            int minuntes = (int)all_time / 60;

            if (all_dis < 1000)
                Text_Total_Wpt_Dist.Text = TryFindResource("TITLE_WPT_TOTAL_DIST").ToString() + " " + all_dis.ToString() + "m";
            else
                Text_Total_Wpt_Dist.Text = TryFindResource("TITLE_WPT_TOTAL_DIST").ToString() + " " + all_dist_km.ToString() + "km";

            Text_Total_Wpt_Time.Text = TryFindResource("TITLE_WPT_TOTAL_TIME").ToString() + " " + minuntes.ToString() + "min";
        }


        /************************************************************************
         * 功   能：确认航点属性的修改
         * 参   数：
         * 返   回：
         * *********************************************************************/
        private void Btn_Wpt_Change_OK_Click(object sender, RoutedEventArgs e)
        {
            if (m_sky_way_list[cur_skyway_no].wayPointSet.Count < 1)
                return;

            MainWindow m_MainWnd = MainWindow.getInstance();
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();

            // 如果是单独修改某个航点
            if (TextBlock_Wpt_Num.Text != "All")
            {
                int m = int.Parse(TextBlock_Wpt_Num.Text) - 1;
                if (m < 0)
                    return;

                m_sky_way_list[cur_skyway_no].wayPointSet[m].lon = double.Parse(TextBox_WptLon.Text);
                m_sky_way_list[cur_skyway_no].wayPointSet[m].lat = double.Parse(TextBox_WptLat.Text);
                m_sky_way_list[cur_skyway_no].wayPointSet[m].alt = double.Parse(TextBox_WptAlt.Text);
                m_sky_way_list[cur_skyway_no].wayPointSet[m].speed = double.Parse(TextBox_WptSpeed.Text);

                m_sky_way_list[cur_skyway_no].wayPointSet[m].byte_turn_mode = m_wpt_turn_mode;
                m_sky_way_list[cur_skyway_no].wayPointSet[m].str_turn_mode = combox_turn_mode.Text;

                m_sky_way_list[cur_skyway_no].wayPointSet[m].turn_time = (short)(double.Parse(TextBox_Turn_Time.Text));

                m_sky_way_list[cur_skyway_no].wayPointSet[m].byte_renwunum = (byte)(combox_task.SelectedIndex + 1);
                m_sky_way_list[cur_skyway_no].wayPointSet[m].str_renwu = combox_task.Text;

                m_sky_way_list[cur_skyway_no].wayPointSet[m].pic_interval = (short)(double.Parse(TextBox_Task_Time.Text));
                m_sky_way_list[cur_skyway_no].wayPointSet[m].wpt_heading = (short)(double.Parse(TextBox_Turn_Heading.Text));

                Update_Wpt_View_List();

                if (MainWindow.map_show_type == 2)
                    Page_2D_Map.Add_Skyway_On_Map(m_sky_way_list[cur_skyway_no]);
                else if (MainWindow.map_show_type == 3)
                {
                    m_PageGoogleMap.webBrowser_google_earth.InvokeScript("setWayPointAlt", new object[] { double.Parse(TextBox_WptAlt.Text), m });
                }
            }
            // 如果是修改所有航点属性
            else
            {
                for (int i = 0; i < m_sky_way_list[cur_skyway_no].wayPointSet.Count; i++)
                {
                    m_sky_way_list[cur_skyway_no].wayPointSet[i].alt = double.Parse(TextBox_WptAlt.Text);
                    m_sky_way_list[cur_skyway_no].wayPointSet[i].speed = double.Parse(TextBox_WptSpeed.Text);

                    m_sky_way_list[cur_skyway_no].wayPointSet[i].byte_turn_mode = m_wpt_turn_mode;
                    m_sky_way_list[cur_skyway_no].wayPointSet[i].str_turn_mode = combox_turn_mode.Text;

                    m_sky_way_list[cur_skyway_no].wayPointSet[i].turn_time = (short)(double.Parse(TextBox_Turn_Time.Text));

                    m_sky_way_list[cur_skyway_no].wayPointSet[i].byte_renwunum = (byte)(combox_task.SelectedIndex + 1);
                    m_sky_way_list[cur_skyway_no].wayPointSet[i].str_renwu = combox_task.Text;

                    m_sky_way_list[cur_skyway_no].wayPointSet[i].pic_interval = (short)(double.Parse(TextBox_Task_Time.Text));
                    m_sky_way_list[cur_skyway_no].wayPointSet[i].wpt_heading = (short)(double.Parse(TextBox_Turn_Heading.Text));
                    m_sky_way_list[cur_skyway_no].wayPointSet[i].wpt_alt_type = wpt_alt_type;
                }
                Update_Wpt_View_List();

                if (MainWindow.map_show_type == 2)
                    Page_2D_Map.Add_Skyway_On_Map(m_sky_way_list[cur_skyway_no]);
                else if (MainWindow.map_show_type == 3)
                {
                    m_PageGoogleMap.webBrowser_google_earth.InvokeScript("setWayPointAlt", new object[] { double.Parse(TextBox_WptAlt.Text), -1 });
                }
            }
        }

        private void Btn_All_Wpt_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_Wpt_Num.Text = "All";
        }

        /************************************************************************
         * 功   能：保存航线，默认按照时间来命名文件名称
         * 参   数：
         * 返   回：
         * *********************************************************************/
        private void Btn_Save_Wpt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog ofd = new Microsoft.Win32.SaveFileDialog();
            ofd.FileName = DateTime.Now.ToLongDateString().ToString();
            ofd.DefaultExt = ".XML";
            ofd.Filter = "XML file|*.XML";

            if (ofd.ShowDialog() == true)
            {
                FileStream afile = new FileStream(ofd.FileName, FileMode.Create);
                XmlTextWriter writer = new XmlTextWriter(afile, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();

                writer.WriteStartElement("Root");
                writer.WriteStartElement("Item");
                writer.WriteElementString("SkywayNo", cur_skyway_no.ToString());
                writer.WriteElementString("IdAllNum", m_sky_way_list[cur_skyway_no].wayPointSet.Count.ToString());
                writer.WriteElementString("CreatTimer", DateTime.Now.ToLocalTime().ToString());
                writer.WriteEndElement(); // 关闭元素

                //向先前创建的元素中添加一个属性
                for (int i = 0; i < m_sky_way_list[cur_skyway_no].wayPointSet.Count; i++)
                {
                    writer.WriteStartElement("Item" + m_sky_way_list[cur_skyway_no].wayPointSet[i].NumberId.ToString());
                    writer.WriteAttributeString("id", m_sky_way_list[cur_skyway_no].wayPointSet[i].NumberId.ToString());                  //航点编号
                    writer.WriteElementString("Longitude", m_sky_way_list[cur_skyway_no].wayPointSet[i].lon.ToString());                  //航点经度
                    writer.WriteElementString("Latitude", m_sky_way_list[cur_skyway_no].wayPointSet[i].lat.ToString());                   //航点纬度
                    writer.WriteElementString("Altitude", m_sky_way_list[cur_skyway_no].wayPointSet[i].alt.ToString());                   //航点高度
                    writer.WriteElementString("Speed", m_sky_way_list[cur_skyway_no].wayPointSet[i].speed.ToString());                    //航点速度     
                    writer.WriteElementString("WaypointModel", m_sky_way_list[cur_skyway_no].wayPointSet[i].byte_turn_mode.ToString());      //航点模式
                    writer.WriteElementString("WaypointModelName", m_sky_way_list[cur_skyway_no].wayPointSet[i].str_turn_mode.ToString());      //航点模式
                    writer.WriteElementString("WaypointModelTimer", m_sky_way_list[cur_skyway_no].wayPointSet[i].turn_time.ToString());  //航点模式时间
                    writer.WriteElementString("WaypointTask", m_sky_way_list[cur_skyway_no].wayPointSet[i].byte_renwunum.ToString());
                    writer.WriteElementString("WaypointTaskName", m_sky_way_list[cur_skyway_no].wayPointSet[i].str_renwu.ToString());//航点任务
                    writer.WriteElementString("WaypointTaskTimer", m_sky_way_list[cur_skyway_no].wayPointSet[i].pic_interval.ToString());  //航点任务时间
                    writer.WriteElementString("LevelAltitude", m_sky_way_list[cur_skyway_no].wayPointSet[i].alt_level.ToString());        //航点海拔
                    writer.WriteElementString("WptHeading", m_sky_way_list[cur_skyway_no].wayPointSet[i].wpt_heading.ToString());        //航点指向
                    writer.WriteElementString("AltType", m_sky_way_list[cur_skyway_no].wayPointSet[i].wpt_alt_type.ToString());        //航点指向
                    writer.WriteEndElement(); // 关闭元素
                }
                writer.WriteEndElement(); // 关闭元素
                writer.Close();
                afile.Close();

                Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_SAVE_FILE_SUCCESS").ToString());
            }
        }

        /************************************************************************
        * 功   能：打开航线文件并加载
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void Btn_Open_Wpt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".XML";
            ofd.Filter = "xml file|*.XML";

            if (ofd.ShowDialog() == true)
            {
                FileStream afile = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                XmlDocument doc = new XmlDocument();
                doc.Load(afile);

                XmlNode xn = doc.SelectSingleNode("Root");
                XmlNode xn1 = xn.SelectSingleNode("Item");

                XmlNode xn_Skyway_No = xn1.SelectSingleNode("SkywayNo");
                cur_skyway_no = byte.Parse(xn_Skyway_No.InnerText);
                m_sky_way_list[cur_skyway_no].wayPointSet.Clear();

                XmlNode xn_IdAllNum = xn1.SelectSingleNode("IdAllNum");
                int count_way = int.Parse(xn_IdAllNum.InnerText);

                for (int i = 0; i < count_way; i++)
                {
                    XmlNode xn_item = xn.SelectSingleNode("Item" + (i + 1).ToString());
                    XmlNode xn_Longitude = xn_item.SelectSingleNode("Longitude");
                    XmlNode xn_Latitude = xn_item.SelectSingleNode("Latitude");
                    XmlNode xn_Altitude = xn_item.SelectSingleNode("Altitude");
                    XmlNode xn_Speed = xn_item.SelectSingleNode("Speed");
                    XmlNode xn_WaypointModel = xn_item.SelectSingleNode("WaypointModel");
                    XmlNode xn_WaypointModelName = xn_item.SelectSingleNode("WaypointModelName");
                    XmlNode xn_WaypointModelTimer = xn_item.SelectSingleNode("WaypointModelTimer");
                    XmlNode xn_WaypointTask = xn_item.SelectSingleNode("WaypointTask");
                    XmlNode xn_WaypointTaskName = xn_item.SelectSingleNode("WaypointTaskName");
                    XmlNode xn_WaypointTaskTimer = xn_item.SelectSingleNode("WaypointTaskTimer");
                    XmlNode xn_LevelAltitude = xn_item.SelectSingleNode("LevelAltitude");
                    XmlNode xn_WptHeading = xn_item.SelectSingleNode("WptHeading");
                    XmlNode xn_AltType = xn_item.SelectSingleNode("AltType");

                    var wptTemp = new WAY_POINT
                    {
                        NumberId = (short)(i + 1),
                        lon = double.Parse(xn_Longitude.InnerText),
                        lat = double.Parse(xn_Latitude.InnerText),
                        speed = double.Parse(xn_Speed.InnerText),
                        alt = double.Parse(xn_Altitude.InnerText),

                        str_turn_mode = xn_WaypointModelName.InnerText,
                        byte_turn_mode = byte.Parse(xn_WaypointModel.InnerText),
                        turn_time = short.Parse(xn_WaypointModelTimer.InnerText),

                        str_renwu = xn_WaypointTaskName.InnerText,
                        byte_renwunum = byte.Parse(xn_WaypointTask.InnerText),
                        pic_interval = short.Parse(xn_WaypointTaskTimer.InnerText),

                        alt_level = double.Parse(xn_LevelAltitude.InnerText),
                        wpt_heading = short.Parse(xn_WptHeading.InnerText),
                        wpt_alt_type = byte.Parse(xn_AltType.InnerText)
                    };
                    m_sky_way_list[cur_skyway_no].wayPointSet.Add(wptTemp);
                }
                afile.Close();

                Update_Wpt_View_List();
                // 打开航线时，将之前地图上所有的航线清除
                Show_All_Wpt_On_Map();

                combox_skyway_no.SelectedIndex = cur_skyway_no;
            }
        }

        /************************************************************************
        * 功   能：将航线在地图上显示
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void Show_All_Wpt_On_Map()
        {
            MainWindow m_MainWnd = MainWindow.getInstance();
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();
            Page_2D_Map mPage2DMap = Page_2D_Map.getInstance();

            if (MainWindow.map_show_type == 2)
            {
                Page_2D_Map.Add_Skyway_On_Map(m_sky_way_list[cur_skyway_no]);
                PointLatLng currentloc = new PointLatLng(m_sky_way_list[cur_skyway_no].wayPointSet[0].lat, m_sky_way_list[cur_skyway_no].wayPointSet[0].lon);
                mPage2DMap.gMap_2D.Position = currentloc;
                mPage2DMap.gMap_2D.Zoom = 18;
            }
            else if (MainWindow.map_show_type == 3 && Page_Google_Map.initmap == true)
            {
                Page_Google_Map.Delete_All_Wpt_3D();
                for (int i = 0; i < m_sky_way_list[cur_skyway_no].wayPointSet.Count; i++)
                {
                    m_PageGoogleMap.webBrowser_google_earth.InvokeScript("AddSkyWay", new object[] {
                            m_sky_way_list[cur_skyway_no].wayPointSet[i].lon, m_sky_way_list[cur_skyway_no].wayPointSet[i].lat, m_sky_way_list[cur_skyway_no].wayPointSet[i].alt,m_sky_way_list[cur_skyway_no].wayPointSet[i].alt_level, i});
                }

                // 将视角切换到添加航线处
                m_PageGoogleMap.webBrowser_google_earth.InvokeScript("updataLookat", new object[] {
                            m_sky_way_list[cur_skyway_no].wayPointSet[0].lon, m_sky_way_list[cur_skyway_no].wayPointSet[0].lat, m_sky_way_list[cur_skyway_no].wayPointSet[0].alt,1000});
            }
        }

        /************************************************************************
         * 功   能：
         * 参   数：
         * 返   回：
         * *********************************************************************/
        public static int curWaypointSeq = -1;
        public static bool curWaypointTransferSucceed = false;
        private void Btn_Upload_Wpt_Click(object sender, RoutedEventArgs e)
        {
            if (DATA_LINK.data_suc_com == false)
                return;

            Page_2D_Map m_Page2DMap = Page_2D_Map.getInstance();
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();

            curWaypointSeq = 0;
            curPackSendTimes = 0;
            curWaypointTransferSucceed = false;
            // 开启航线上传功能
            if (m_sky_way_list[cur_skyway_no].wayPointSet.Count > 0)
            {
                timer_upload_wpt.Start();
            }
            else
            {
                Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_NO_WPT_TO_UPLOAD").ToString());
            }
        }

        /************************************************************************
        * 功   能：从飞控上下载航线
        * 参   数：
        * 返   回：
        * *********************************************************************/
        private void Btn_Download_Wpt_Click(object sender, RoutedEventArgs e)
        {
            if (DATA_LINK.data_suc_com == false)
                return;

            // 首先清除地图上所有的航点
            m_sky_way_list[cur_skyway_no].Wpt_Layer.Clear();

            if (MainWindow.map_show_type == 3 && Page_Google_Map.initmap == true)
                Page_Google_Map.Delete_All_Wpt_3D();

            // 清除航线列表
            m_sky_way_list[cur_skyway_no].wayPointSet.Clear();
            wpt_list_box.Items.Clear();

            // 初始化操作参数
            Page_Version_Update.Read_Data_Type = 3;
            Req_Wpt_Index = 1;         // 读取航线时请求航点的索引
            Req_Wpt_Count = 0;        // 读取航点时的发送的请求次数

            // 打开发送请求时钟
            Page_Version_Update.timer_read_log_pos.Start();
        }

        /*******************************************************************
        * 功   能：删除航点
        * 参   数：
        * 返   回：
        * ****************************************************************/
        private void Btn_Delete_Wpt_Click(object sender, RoutedEventArgs e)
        {
            if (m_sky_way_list[cur_skyway_no].wayPointSet.Count < 1)
                return;

            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();

            // 如果是单独修改某个航点
            if (TextBlock_Wpt_Num.Text != "All" && TextBlock_Wpt_Num.Text != "0")
            {
                int m = int.Parse(TextBlock_Wpt_Num.Text) - 1;

                // 如果航点的序号大于航线的长度，则
                if (m >= m_sky_way_list[cur_skyway_no].wayPointSet.Count)
                    return;

                m_sky_way_list[cur_skyway_no].wayPointSet.RemoveAt(m);
                Update_Wpt_View_List();
                // 更改2D地图上的显示
                Page_2D_Map.Add_Skyway_On_Map(m_sky_way_list[cur_skyway_no]);

                if (Page_Google_Map.initmap == true)
                {
                    // 更改googleearth上的航点显示
                    m_PageGoogleMap.webBrowser_google_earth.InvokeScript("DelPt", new object[] { m });
                }
            }
            // 如果是修改所有航点属性
            else
            {
                Delete_All_Wpt();
            }
        }

        /*******************************************************************
        * 功   能：删除所有航点
        * 参   数：
        * 返   回：
        * ****************************************************************/
        private void Delete_All_Wpt()
        {
            m_sky_way_list[cur_skyway_no].Wpt_Layer.Clear();

            if (Page_Google_Map.initmap == true)
            {
                Page_Google_Map.Delete_All_Wpt_3D();
            }

            m_sky_way_list[cur_skyway_no].wayPointSet.Clear();
            wpt_list_box.Items.Clear();
        }

        /*******************************************************************
         * 功   能：结束航点编辑
         * 参   数：
         * 返   回：
         * ****************************************************************/
        private void Btn_End_Wpt_Click(object sender, RoutedEventArgs e)
        {
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();

            Page_2D_Map.addptbool = 0;
            Page_Google_Map.wptEditType = 0;

            if (Page_Google_Map.initmap == true && MainWindow.map_show_type == 3)
                m_PageGoogleMap.webBrowser_google_earth.InvokeScript("setUAVLineState", new object[] { 0, 0 });

            if (auto_wpt_enable == true)
            {
                auto_wpt_enable = false;
                Window_Auto_Wpt.getInstance().Hide();

                bound_pt_list.Clear();

                // 将地图上所有的边界标记去掉
                if (MainWindow.map_show_type == 2)
                {
                    Page_2D_Map.Delete_Bound_Layer_2D();
                    Page_2D_Map.Delete_Wpt_Layer_2D();
                }
                else if (MainWindow.map_show_type == 3)
                {
                    m_PageGoogleMap.webBrowser_google_earth.InvokeScript("DelAllBoundPt", new object[] { 0, 0 });
                    m_PageGoogleMap.webBrowser_google_earth.InvokeScript("DelAllPrePt", new object[] { 0, 0 });
                }

                // 更新
                Update_Wpt_View_List();

                if (MainWindow.map_show_type == 2)
                {
                    Page_2D_Map.Add_Skyway_On_Map(m_sky_way_list[cur_skyway_no]);
                }
                else if (MainWindow.map_show_type == 3)
                {
                    for (int i = 0; i < m_sky_way_list[cur_skyway_no].wayPointSet.Count; i++)
                    {
                        m_PageGoogleMap.webBrowser_google_earth.InvokeScript("AddSkyWay", new object[] {
                            m_sky_way_list[cur_skyway_no].wayPointSet[i].lon, m_sky_way_list[cur_skyway_no].wayPointSet[i].lat, m_sky_way_list[cur_skyway_no].wayPointSet[i].alt, Page_Google_Map.level_alt, i});
                    }
                }
            }

            Window_Fan_Hang_Reason.getInstance().TextBlock_Fan_Hang_Reason.Text = "";
        }

        /*******************************************************************
        * 功   能：将航点添加到航线列表
        * 参   数：
        * 返   回：
        * ****************************************************************/
        private void AddPtToWptList(short argIndex, double argLon, double argLat, bool isAutoWpt)
        {
            MainWindow m_MainWnd = MainWindow.getInstance();
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();

            var wptTemp = new WAY_POINT
            {
                NumberId = (short)(argIndex + 1),
                lon = argLon,
                lat = argLat,
                speed = double.Parse(TextBox_WptSpeed.Text),
                alt = double.Parse(TextBox_WptAlt.Text),

                byte_turn_mode = m_wpt_turn_mode,
                turn_time = short.Parse(TextBox_Turn_Time.Text),

                pic_interval = short.Parse(TextBox_Task_Time.Text),
                alt_level = Page_Google_Map.level_alt,

                wpt_heading = short.Parse(TextBox_Turn_Heading.Text),
            };

            wptTemp.str_turn_mode = combox_turn_mode.Text;

            // 如果是自动规划
            if (isAutoWpt == true)
            {
                // 奇数航点不拍照
                if (argIndex % 2 == 1)
                {
                    wptTemp.str_renwu = TryFindResource("TITLE_NO_TASK").ToString();
                    wptTemp.byte_renwunum = 1;
                }
                else
                {
                    wptTemp.byte_renwunum = (byte)(combox_task.SelectedIndex + 1);
                    wptTemp.str_renwu = combox_task.Text;
                }
            }
            else                  // 如果是手动规划
            {
                wptTemp.byte_renwunum = (byte)(combox_task.SelectedIndex + 1);
                wptTemp.str_renwu = combox_task.Text;
            }
            m_sky_way_list[cur_skyway_no].wayPointSet.Add(wptTemp);
        }

        private void Btn_Shift_Wpt_Click(object sender, RoutedEventArgs e)
        {
            Window_WPT_SHIFT.Wnd_Show();
        }

        private void Btn_Add_Wpt_Click(object sender, RoutedEventArgs e)
        {
            Pop_Add_Wpt.IsOpen = true;
        }

        /***************************************************************************
         * 功   能：手动添加航线
         * 参   数：
         * 返   回：
         * ************************************************************************/
        private void Btn_Add_Manual_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m_MainWnd = MainWindow.getInstance();

            Pop_Add_Wpt.IsOpen = false;

            // 在二维地图上添加
            if (MainWindow.map_show_type == 2)
            {
                Page_2D_Map mPage2DMapTemp = Page_2D_Map.getInstance();
                if (Page_2D_Map.addptbool == 0)
                {
                    Page_2D_Map.addptbool = 1;
                }
                else
                {
                    Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString());

                    return;
                }
            }
            // 在三维地图上添加
            else if (MainWindow.map_show_type == 3)
            {
                Page_Google_Map m_GoogleMap = Page_Google_Map.getInstance();
                if (Page_Google_Map.wptEditType == 0)
                {
                    Page_Google_Map.SetWptEditType(1, -1);

                    int altTemp = int.Parse(TextBox_WptAlt.Text);
                    m_GoogleMap.webBrowser_google_earth.InvokeScript("SetWptAltPara", new object[] { altTemp });
                }
                else
                {
                    Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString());

                    return;
                }
            }
            auto_wpt_enable = false;

            Window_Fan_Hang_Reason.getInstance().TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString();
        }

        /***************************************************************************
        * 功   能：自动添加航线
        * 参   数：
        * 返   回：
        * ************************************************************************/
        public static bool auto_wpt_enable = false;
        private void Btn_Add_Auto_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m_MainWnd = MainWindow.getInstance();
            Page_Google_Map m_GoogleMap = Page_Google_Map.getInstance();

            Pop_Add_Wpt.IsOpen = false;

            if (MainWindow.map_show_type == 2)
            {
                if (Page_2D_Map.addptbool == 0)
                {
                    Page_2D_Map.addptbool = 1;
                }
                else
                {
                    Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString());

                    return;
                }
            }
            else if (MainWindow.map_show_type == 3)
            {
                if (Page_Google_Map.wptEditType == 0)
                {
                    m_GoogleMap.webBrowser_google_earth.InvokeScript("setUAVLineState", new object[] { 6, -1 });

                    int altTemp = int.Parse(TextBox_WptAlt.Text);
                    m_GoogleMap.webBrowser_google_earth.InvokeScript("SetWptAltPara", new object[] { altTemp });
                }
                else
                {
                    Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString());

                    return;
                }
            }

            auto_wpt_enable = true;
            Window_Auto_Wpt.getInstance().Show();

            Window_Fan_Hang_Reason.getInstance().TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString();
        }

        /*********************************************************************************
        * function:
        * para:
        * return:
        * *******************************************************************************/
        private void Btn_Add_Forbid_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m_MainWnd = MainWindow.getInstance();

            Pop_Add_Wpt.IsOpen = false;

            // 在二维地图上添加
            if (MainWindow.map_show_type == 2)
            {
                Page_2D_Map mPage2DMapTemp = Page_2D_Map.getInstance();
                if (Page_2D_Map.addptbool == 0)
                {
                    Page_2D_Map.addptbool = 4;
                }
                else
                {
                    Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString());

                    return;
                }
            }
            auto_wpt_enable = false;

            Window_Fan_Hang_Reason.getInstance().TextBlock_Fan_Hang_Reason.Text = TryFindResource("TITLE_END_WPT_PLAN_INSTRUCTION").ToString();
        }

        /*****************************************************************************
         * 功   能：地图上点击的航点，添加在航线列表上
         * 参   数：
         * 返   回：
         * ***************************************************************************/
        public void Add_Wpt_From_GoogleMap(double argLon, double argLat, int argIndex, double argLevelAlt)
        {
            var wptTemp = new WAY_POINT
            {
                NumberId = (short)(argIndex + 1),
                lon = argLon,
                lat = argLat,
                speed = float.Parse(TextBox_WptSpeed.Text),
                alt = int.Parse(TextBox_WptAlt.Text),

                byte_turn_mode = m_wpt_turn_mode,
                turn_time = short.Parse(TextBox_Turn_Time.Text),

                byte_renwunum = (byte)(combox_task.SelectedIndex + 1),
                pic_interval = short.Parse(TextBox_Task_Time.Text),

                alt_level = argLevelAlt,
                wpt_heading = short.Parse(TextBox_Turn_Heading.Text)
            };

            wptTemp.str_turn_mode = combox_turn_mode.Text;
            wptTemp.str_renwu = combox_task.Text;

            m_sky_way_list[cur_skyway_no].wayPointSet.Insert(argIndex, wptTemp);
            Update_Wpt_View_List();
        }

        /*******************************************************************************
      * 功   能：添加边界点
      * 参   数：
      * 返   回：
      * ******************************************************************************/
        public void AddPtToBoundList(double argLon, double argLat, int argIndex)
        {
            // 构造一个边界点
            var boundPtTemp = new BOUND_PT
            {
                lon = argLon,
                lat = argLat,
                alt = double.Parse(TextBox_WptAlt.Text)
            };

            bound_pt_list.Add(boundPtTemp);
        }

        /*******************************************************************************
        * 功   能：更新边界以及预览航线
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        public void Updatet_Bound_Skyway()
        {
            int i = 0;
            MainWindow m_MainWnd = MainWindow.getInstance();

            // =============== 计算自动规划区域的面积 ================
            boudPt_Mianji.Clear();
            for (i = 0; i < bound_pt_list.Count; i++)
            {
                boudPt_Mianji.Add(bound_pt_list[i]);
            }

            // 计算整个规划区域的面积
            double mianJi = Compute.calcpolygonarea(boudPt_Mianji);
            if (mianJi < 10000)
            {
                Text_Total_Wpt_Acreage.Text = m_MainWnd.TryFindResource("TITLE_WPT_TOTAL_ACREAGE").ToString() + " " + Math.Round(mianJi, 0).ToString() + "m^2";
            }
            else
            {
                Text_Total_Wpt_Acreage.Text = m_MainWnd.TryFindResource("TITLE_WPT_TOTAL_ACREAGE").ToString() + " " + Math.Round(mianJi / 1000000, 2).ToString() + "km^2";
            }

            // 将边界添加到地图上
            if (MainWindow.map_show_type == 2)
            {
                Page_2D_Map.AddBoundListOnMap(bound_pt_list);
            }
            else if (MainWindow.map_show_type == 3)
            {
                Page_Google_Map.Add_BoundList_3D(bound_pt_list);
            }

            // 当航点超过3个的时候，则显示预计规划的航迹
            double rotate_temp = Window_Auto_Wpt.getInstance().skyline_rotate;
            double space_temp = Window_Auto_Wpt.getInstance().skyline_space;
            Generate_PreWpt(bound_pt_list, Compute.wrap_360(rotate_temp - 90), space_temp);
        }

        /*******************************************************************************
        * 功   能：由边界、行间距、航线方向来生成预览航线
        * 参   数：
        * 返   回：
        * ******************************************************************************/
        private static List<Points> boudList_utm = new List<Points>();
        private static List<Points> preWpt_utm = new List<Points>();
        public void Generate_PreWpt(List<BOUND_PT> boundList, double rotate, double space)
        {
            MainWindow m_MainWnd = MainWindow.getInstance();
            Wayline_math wayLineMath = Wayline_math.getInstance();
            Page_Google_Map mPageGoogleMap = Page_Google_Map.getInstance();

            // 删除地图上的航线标记
            if (MainWindow.map_show_type == 2)
                Page_2D_Map.Delete_Wpt_Layer_2D();
            else if (MainWindow.map_show_type == 3)
                mPageGoogleMap.webBrowser_google_earth.InvokeScript("DelAllPrePt", new object[] { });

            if (boundList.Count < 3)
                return;

            int boundListCount = boundList.Count;
            double coord_x, coord_y, longitude, lattitude;
            UTMProjection utmProjectionObj = new UTMProjection();
            Boolean result = false;
            int i = 0;

            boudList_utm.Clear();
            preWpt_utm.Clear();

            // 将边界点的坐标转换为平面坐标系下的坐标
            for (i = 0; i < boundListCount; i++)
            {
                result = utmProjectionObj.utm_projection_caculate(boundList[i].lon, boundList[i].lat, out coord_x, out coord_y);
                if (result)
                {
                    boudList_utm.Add(new Points(coord_y, coord_x, 0));
                }
            }

            // 根据行间距和航线方向生成预览航线
            preWpt_utm = wayLineMath.setPointsss(boudList_utm, rotate, space);
            // 如果航点大于2000个，则直接退出
            if (preWpt_utm.Count > 2000)
            {
                boundList.Clear();
                if (MainWindow.map_show_type == 2)
                    Page_2D_Map.Delete_Bound_Layer_2D();
                else if (MainWindow.map_show_type == 3)
                    mPageGoogleMap.webBrowser_google_earth.InvokeScript("DelAllBoundPt", new object[] { });

                Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_WPT_OUTOF_RANGE").ToString());

                return;
            }

            m_sky_way_list[cur_skyway_no].wayPointSet.Clear();       // 将航线列表清除
            for (i = 0; i < preWpt_utm.Count; i++)
            {
                result = utmProjectionObj.utm_projection_inverse_caculate(preWpt_utm[i].y, preWpt_utm[i].x, out longitude, out lattitude);
                PointLatLngAlt pointTemp = new PointLatLngAlt(lattitude, longitude, 0, (i + 1).ToString());

                AddPtToWptList((short)i, longitude, lattitude, true);

                // 显示整个航线的开始和结尾
                if (MainWindow.map_show_type == 2)
                {
                    if (i == 0)
                        Page_2D_Map.addpolygonmarker_wpt("S", longitude, lattitude, 0);
                    else if (i == (preWpt_utm.Count - 1))
                        Page_2D_Map.addpolygonmarker_wpt("E", longitude, lattitude, 0);

                    m_sky_way_list[cur_skyway_no].wptListOnMap.Add(pointTemp);
                }
            }

            // 添加智能规划预览航线
            if (MainWindow.map_show_type == 2)
            {
                Page_2D_Map.AddWptLineOnMap(m_sky_way_list[cur_skyway_no].wptListOnMap, 2);
            }
            else if (MainWindow.map_show_type == 3)
            {
                for (i = 0; i < m_sky_way_list[cur_skyway_no].wayPointSet.Count; i++)
                    mPageGoogleMap.webBrowser_google_earth.InvokeScript("AddPreSkyWay", new object[] {
                            m_sky_way_list[cur_skyway_no].wayPointSet[i].lon, m_sky_way_list[cur_skyway_no].wayPointSet[i].lat, m_sky_way_list[cur_skyway_no].wayPointSet[i].alt, m_sky_way_list[cur_skyway_no].wayPointSet[i].alt_level, i, m_sky_way_list[cur_skyway_no].wayPointSet.Count});
            }
        }

        /*********************************************************************
         * 功   能：加载KMZ/KML文件
         * ******************************************************************/
        private void Btn_Open_Kmz_Click(object sender, RoutedEventArgs e)
        {
            POP_KMZ_TYPE.IsOpen = true;
        }

        private void Decode_Kmz()
        {
            Page_2D_Map mPage2DMapTemp = Page_2D_Map.getInstance();
            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.Filter = "Google Earth KML |*.kml;*.kmz";
                DialogResult result = fd.ShowDialog();
                string file = fd.FileName;

                if (file != "")
                {
                    try
                    {
                        string kml = "";
                        string tempdir = "";
                        if (file.ToLower().EndsWith("kmz"))
                        {
                            ZipFile input = new ZipFile(file);

                            tempdir = System.IO.Path.GetTempPath() + System.IO.Path.DirectorySeparatorChar + System.IO.Path.GetRandomFileName();
                            input.ExtractAll(tempdir, ExtractExistingFileAction.OverwriteSilently);

                            string[] kmls = Directory.GetFiles(tempdir, "*.kml");

                            if (kmls.Length > 0)
                            {
                                file = kmls[0];
                                input.Dispose();
                            }
                            else
                            {
                                input.Dispose();
                                return;
                            }
                        }

                        var sr = new StreamReader(File.OpenRead(file));
                        kml = sr.ReadToEnd();
                        sr.Close();

                        // cleanup after out
                        if (tempdir != "")
                            Directory.Delete(tempdir, true);

                        kml = kml.Replace("<Snippet/>", "");

                        var parser = new Parser();

                        parser.ElementAdded += parser_ElementAdded;
                        parser.ParseString(kml, false);
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show("Bad KML File :" + ex);
                    }
                }
            }
        }
        private void parser_ElementAdded(object sender, ElementEventArgs e)
        {
            if (kmz_type == 1)
                ProcessKML_Wpt(e.Element);
            else if (kmz_type == 2)
                ProcessKML_Bound(e.Element);
        }

        /************************************************************************
        * 函数功能：处理KML字符串
        * **********************************************************************/
        private void ProcessKML_Bound(Element Element)
        {
            Page_Google_Map mPageGoogleMap = Page_Google_Map.getInstance();
            Page_2D_Map mPage2DMap = Page_2D_Map.getInstance();

            Document doc = Element as Document;
            SharpKml.Dom.Placemark pm = Element as SharpKml.Dom.Placemark;
            Folder folder = Element as Folder;
            SharpKml.Dom.Polygon polygon = Element as SharpKml.Dom.Polygon;
            LineString ls = Element as LineString;

            double lat_temp = 0, lon_temp = 0;
            ushort ptIndexTemp = 0;

            if (doc != null)
            {
                foreach (var feat in doc.Features)
                {
                }
            }
            else if (folder != null)
            {
                foreach (Feature feat in folder.Features)
                {
                }
            }
            else if (pm != null)
            {
            }
            else if (polygon != null)        // 如果KML里面的坐标不为空
            {
                if (MainWindow.map_show_type == 2)     // 如果是二维地图
                {
                    GMapRoute route_kml = new GMapRoute("kmlroute");
                    foreach (var loc in polygon.OuterBoundary.LinearRing.Coordinates)
                    {
                        if (ptIndexTemp == 0)
                        {
                            lat_temp = loc.Latitude;
                            lon_temp = loc.Longitude;
                        }
                        route_kml.Points.Add(new PointLatLng(loc.Latitude, loc.Longitude));
                        ptIndexTemp++;
                    }

                    //再次添加第一个点，形成一个封闭的多边形
                    route_kml.Points.Add(new PointLatLng(lat_temp, lon_temp));
                    route_kml.Stroke = new System.Drawing.Pen(System.Drawing.Color.GreenYellow, 2);
                    Page_2D_Map.KML_Layer.Routes.Add(route_kml);

                    // 将视角直接切换到该KML位置
                    PointLatLng currentloc = new PointLatLng(lat_temp, lon_temp);
                    mPage2DMap.gMap_2D.Position = currentloc;
                    mPage2DMap.gMap_2D.Zoom = 13;
                }
                else if (MainWindow.map_show_type == 3)      // 如果是三维地图
                {
                    foreach (var loc in polygon.OuterBoundary.LinearRing.Coordinates)
                    {
                        if (ptIndexTemp == 0)
                        {
                            lat_temp = loc.Latitude;
                            lon_temp = loc.Longitude;
                        }
                        mPageGoogleMap.webBrowser_google_earth.InvokeScript("AddKmz", new object[] { loc.Longitude, loc.Latitude, ptIndexTemp });
                        ptIndexTemp++;
                    }
                    mPageGoogleMap.webBrowser_google_earth.InvokeScript("AddKmz", new object[] { lon_temp, lat_temp, ptIndexTemp });
                    // 将视角切换到KMZ区域
                    mPageGoogleMap.webBrowser_google_earth.InvokeScript("updataLookat", new object[] { lon_temp, lat_temp, 10, 1000 });
                }
            }
            else if (ls != null)
            {
                if (MainWindow.map_show_type == 2)     // 如果是二维地图
                {
                    // 添加KML文件里面每个点的坐标
                    GMapRoute route_kml = new GMapRoute("kmlroute");
                    foreach (var loc in ls.Coordinates)
                    {
                        if (ptIndexTemp == 0)
                        {
                            lat_temp = loc.Latitude;
                            lon_temp = loc.Longitude;
                        }
                        route_kml.Points.Add(new PointLatLng(loc.Latitude, loc.Longitude));
                        ptIndexTemp++;
                    }
                    //再次添加第一个点，形成一个封闭的多边形
                    route_kml.Points.Add(new PointLatLng(lat_temp, lon_temp));
                    route_kml.Stroke = new System.Drawing.Pen(System.Drawing.Color.GreenYellow, 2);
                    Page_2D_Map.KML_Layer.Routes.Add(route_kml);

                    // 将视角直接切换到该KML位置
                    PointLatLng currentloc = new PointLatLng(lat_temp, lon_temp);
                    mPage2DMap.gMap_2D.Position = currentloc;
                    mPage2DMap.gMap_2D.Zoom = 13;
                }
                else if (MainWindow.map_show_type == 3)      // 如果是三维地图
                {
                    foreach (var loc in ls.Coordinates)
                    {
                        if (ptIndexTemp == 0)
                        {
                            lat_temp = loc.Latitude;
                            lon_temp = loc.Longitude;
                        }
                        mPageGoogleMap.webBrowser_google_earth.InvokeScript("AddKmz", new object[] { loc.Longitude, loc.Latitude, ptIndexTemp });
                        ptIndexTemp++;
                    }
                    mPageGoogleMap.webBrowser_google_earth.InvokeScript("AddKmz", new object[] { lon_temp, lat_temp, ptIndexTemp });

                    // 将视角切换到KMZ区域
                    mPageGoogleMap.webBrowser_google_earth.InvokeScript("updataLookat", new object[] { lon_temp, lat_temp, 10, 1000 });
                }
            }
        }

        private void ProcessKML_Wpt(Element Element)
        {
            Page_2D_Map mPage2DMapTemp = Page_2D_Map.getInstance();

            Document doc = Element as Document;
            SharpKml.Dom.Placemark pm = Element as SharpKml.Dom.Placemark;
            Folder folder = Element as Folder;
            SharpKml.Dom.Polygon polygon = Element as SharpKml.Dom.Polygon;
            LineString ls = Element as LineString;

            double lat_temp = 0, lon_temp = 0;
            ushort ptIndexTemp = 0;

            if (doc != null)
            {
                foreach (var feat in doc.Features)
                {
                }
            }
            else if (folder != null)
            {
                foreach (Feature feat in folder.Features)
                {
                }
            }
            else if (pm != null)
            {
            }
            else if (polygon != null)
            {
                Delete_All_Wpt();
                foreach (var loc in polygon.OuterBoundary.LinearRing.Coordinates)
                {
                    if (ptIndexTemp == 0)
                    {
                        lat_temp = loc.Latitude;
                        lon_temp = loc.Longitude;
                    }
                    ptIndexTemp++;

                    // 将KMZ里面的标记添加到航线里
                    WAY_POINT wptTemp = new WAY_POINT();
                    wptTemp.lon = loc.Longitude;
                    wptTemp.lat = loc.Latitude;
                    wptTemp.alt = 50;
                    wptTemp.alt_level = 0;
                    wptTemp.byte_renwunum = 1;
                    wptTemp.byte_turn_mode = 1;
                    m_sky_way_list[cur_skyway_no].wayPointSet.Add(wptTemp);
                }
            }
            else if (ls != null)
            {
                Delete_All_Wpt();

                // 添加KML文件里面每个点的坐标
                //GMapRoute route_kml = new GMapRoute("kmlroute");
                foreach (var loc in ls.Coordinates)
                {
                    if (ptIndexTemp == 0)
                    {
                        lat_temp = loc.Latitude;
                        lon_temp = loc.Longitude;
                    }
                    //route_kml.Points.Add(new PointLatLng(loc.Latitude, loc.Longitude));
                    ptIndexTemp++;

                    // 将KMZ里面的标记添加到航线里
                    WAY_POINT wptTemp = new WAY_POINT();
                    wptTemp.lon = loc.Longitude;
                    wptTemp.lat = loc.Latitude;
                    wptTemp.alt = 50;
                    wptTemp.alt_level = 0;
                    wptTemp.byte_renwunum = 1;
                    wptTemp.byte_turn_mode = 1;
                    m_sky_way_list[cur_skyway_no].wayPointSet.Add(wptTemp);
                }
            }

            // 将航点添加到航线列表和地图上面去
            if (polygon != null || ls != null)
            {
                if (m_sky_way_list[cur_skyway_no].wayPointSet.Count > 0)
                {
                    Update_Wpt_View_List();
                    Show_All_Wpt_On_Map();
                }
            }
        }

        /*******************************************************************************
       * 功   能：在argIndex之前还是之后添加航点
       * 参   数：
       * 返   回：
       * ******************************************************************************/
        public void Insert_Wpt(Int32 argIndex, UInt16 argPos)
        {
            WAY_POINT wpt_temp = new WAY_POINT();
            if (argIndex < 1)
                return;

            wpt_temp.lon = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].lon + 0.0001;
            wpt_temp.lat = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].lat + 0.0001;
            wpt_temp.alt = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].alt;

            wpt_temp.byte_turn_mode = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].byte_turn_mode;
            wpt_temp.str_turn_mode = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].str_turn_mode;
            wpt_temp.turn_time = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].turn_time;

            wpt_temp.byte_renwunum = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].byte_renwunum;
            wpt_temp.str_renwu = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].str_renwu;
            wpt_temp.pic_interval = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].pic_interval;
            wpt_temp.alt_level = m_sky_way_list[cur_skyway_no].wayPointSet[argIndex - 1].alt_level;


            // 如果在点击航点之前插入
            if (argPos == 1)
                m_sky_way_list[cur_skyway_no].wayPointSet.Insert(argIndex - 1, wpt_temp);
            else if (argPos == 2)
                m_sky_way_list[cur_skyway_no].wayPointSet.Insert(argIndex, wpt_temp);

            // 更新航线链表窗口的显示
            Update_Wpt_View_List();
        }

        private byte kmz_type = 1;    // 默认为航线模式
        private void BTN_BOUND_TYPE_Click(object sender, RoutedEventArgs e)
        {
            kmz_type = 2;
            POP_KMZ_TYPE.IsOpen = false;
            Decode_Kmz();
        }

        private void BTN_WPT_TYPE_Click(object sender, RoutedEventArgs e)
        {
            kmz_type = 1;
            POP_KMZ_TYPE.IsOpen = false;
            Decode_Kmz();
        }

        /*****************************************************************************
         * function:
         * para:
         * return:
         * ***************************************************************************/
        private void Btn_Upload_Forbidden_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.Upload_Forbid_Area(true);
        }

        /*****************************************************************************
        * function:
        * para:
        * return:
        * ***************************************************************************/
        private void Btn_Delete_Forbidden_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.Delete_Forbid_Area();
            Page_2D_Map.Upload_Forbid_Area(false);
        }

        private void Btn_Download_Forbidden_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.Delete_Forbid_Area();
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, MsgDef.MSG_FORBID_AREA, 1);
        }

        public static byte m_wpt_turn_mode = 1;
        private void combox_turn_mode_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (App.plane_type == 0)
            {
                switch (combox_turn_mode.SelectedIndex)
                {
                    case 0:
                    case 3:
                    case 4:
                        TextBox_Turn_Time.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Time.Visibility = Visibility.Hidden;
                        TextBox_Turn_Heading.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Heading.Visibility = Visibility.Hidden;
                        break;
                    case 1:
                        TextBlock_Turn_Time.Text = "s";
                        TextBox_Turn_Time.Visibility = Visibility.Visible;
                        TextBlock_Turn_Time.Visibility = Visibility.Visible;
                        TextBox_Turn_Heading.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Heading.Visibility = Visibility.Hidden;
                        break;
                    case 2:
                        TextBox_Turn_Time.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Time.Visibility = Visibility.Hidden;
                        TextBox_Turn_Heading.Visibility = Visibility.Visible;
                        TextBlock_Turn_Heading.Visibility = Visibility.Visible;
                        TextBlock_Turn_Heading.Text = "°";
                        break;
                    case 5:
                        TextBox_Turn_Time.Visibility = Visibility.Visible;
                        TextBlock_Turn_Time.Visibility = Visibility.Visible;
                        TextBox_Turn_Heading.Visibility = Visibility.Visible;
                        TextBlock_Turn_Heading.Visibility = Visibility.Visible;
                        TextBlock_Turn_Time.Text = "cir";
                        TextBlock_Turn_Heading.Text = "m/s";
                        break;
                    default:
                        break;
                }
                m_wpt_turn_mode = (byte)(combox_turn_mode.SelectedIndex + 1);
            }
            else
            {
                switch (combox_turn_mode.SelectedIndex)
                {
                    case 0:
                        m_wpt_turn_mode = 1;
                        TextBox_Turn_Time.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Time.Visibility = Visibility.Hidden;
                        TextBox_Turn_Heading.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Heading.Visibility = Visibility.Hidden;
                        break;
                    case 1:
                        m_wpt_turn_mode = 4;
                        TextBlock_Turn_Time.Text = "s";
                        TextBlock_Turn_Heading.Text = "m/s";
                        TextBox_Turn_Time.Visibility = Visibility.Visible;
                        TextBlock_Turn_Time.Visibility = Visibility.Visible;
                        TextBox_Turn_Heading.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Heading.Visibility = Visibility.Hidden;
                        break;
                    case 2:
                        m_wpt_turn_mode = 5;
                        TextBox_Turn_Time.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Time.Visibility = Visibility.Hidden;
                        TextBox_Turn_Heading.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Heading.Visibility = Visibility.Hidden;
                        break;
                    case 3:
                        m_wpt_turn_mode = 6;
                        TextBox_Turn_Time.Visibility = Visibility.Visible;
                        TextBlock_Turn_Time.Visibility = Visibility.Hidden;
                        TextBox_Turn_Heading.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Heading.Visibility = Visibility.Hidden;
                        break;
                    case 4:
                        m_wpt_turn_mode = 10;
                        TextBlock_Turn_Time.Text = "dm";
                        TextBox_Turn_Time.Visibility = Visibility.Visible;
                        TextBlock_Turn_Time.Visibility = Visibility.Visible;
                        TextBox_Turn_Heading.Visibility = Visibility.Hidden;
                        TextBlock_Turn_Heading.Visibility = Visibility.Hidden;
                        break;

                    default:
                        break;
                }
            }
        }

        private void combox_task_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (combox_task.SelectedIndex == 1)
                TextBlock_Task_Interval.Text = "m";
            else if (combox_task.SelectedIndex == 2)
                TextBlock_Task_Interval.Text = "s";
        }


        private byte wpt_alt_type = 0;
        private void combox_alt_type_Changed(object sender, SelectionChangedEventArgs e)
        {
            wpt_alt_type = (byte)combox_alt_type.SelectedIndex;
        }

        /*************************************************************************************
        函数名称：   OnExternalMouseUp( double x, double y,double pointIndex )
        功能：       地图鼠标点击相应函数
        ************************************************************************************/
        public void Change_Cur_Skyway_Wpt(double x, double y, int pointIndex)
        {
            if (pointIndex >= 0 && pointIndex < m_sky_way_list[cur_skyway_no].wayPointSet.Count)
            {
                m_sky_way_list[cur_skyway_no].wayPointSet[pointIndex].lon = x;
                m_sky_way_list[cur_skyway_no].wayPointSet[pointIndex].lat = y;

                Update_Wpt_View_List();
            }
        }

        /***************************************************************************
         * 功   能：
         * 参   数：
         * 返   回：
         * **************************************************************************/
        public static byte cur_skyway_no = 0;
        private void combox_skyway_no_Changed(object sender, SelectionChangedEventArgs e)
        {
            Page_2D_Map mPage2DMap = Page_2D_Map.getInstance();
            cur_skyway_no = (byte)combox_skyway_no.SelectedIndex;

            if (m_sky_way_list == null || m_sky_way_list.Count == 0)
                return;
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    if (m_sky_way_list[i].wayPointSet.Count > 0)
                    {
                        if (i != cur_skyway_no)
                            m_sky_way_list[i].route_wptLine.Stroke = new System.Drawing.Pen(System.Drawing.Color.Yellow, 4);
                        else
                        {
                            m_sky_way_list[i].route_wptLine.Stroke = new System.Drawing.Pen(System.Drawing.Color.Red, 4);
                            Update_Wpt_View_List();
                        }

                        mPage2DMap.gMap_2D.Refresh();
                    }
                }
            }
        }

        public static int Get_Cur_Skyway_Count()
        {
            return m_sky_way_list[cur_skyway_no].wayPointSet.Count;
        }

        public static void Delete_Cur_Skyway_Wpt(int index)
        {
            m_sky_way_list[cur_skyway_no].wayPointSet.RemoveAt(index);
        }

        /*******************************************************************
        * 功   能：从飞控上下载航线，并在地图上显示
        * 参   数：
        * 返   回：
        * ****************************************************************/
        public void Down_Wpt_From_Plane()
        {
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();
            STRUCT_WPT mStruct_Wpt = DataProcess_JD.Get_WPT();

            // 如果当前航点序号收到，则请求下一个航点
            if ((Req_Wpt_Index == mStruct_Wpt.wp_id) && (mStruct_Wpt.wp_id > Get_Cur_Skyway_Count()))
            {
                WAY_POINT wptPtTemp = new WAY_POINT();
                wptPtTemp.NumberId = (short)(mStruct_Wpt.wp_id);
                wptPtTemp.lon = (double)mStruct_Wpt.wp_lon * Math.Pow(10, -7);
                wptPtTemp.lat = (double)mStruct_Wpt.wp_lat * Math.Pow(10, -7);

                wptPtTemp.alt = (double)mStruct_Wpt.wp_alt / 100;
                wptPtTemp.speed = (double)mStruct_Wpt.wp_speed / 100;

                wptPtTemp.byte_turn_mode = mStruct_Wpt.wp_turn_mode;

                if (App.plane_type == 0)
                {
                    if (wptPtTemp.byte_turn_mode == 1)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_AUTO_TURN").ToString();
                    else if (wptPtTemp.byte_turn_mode == 2)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_HOVER").ToString();
                    else if (wptPtTemp.byte_turn_mode == 3)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_LOCK_HEAD_TURN").ToString();
                    else if (wptPtTemp.byte_turn_mode == 4)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_THROW").ToString();
                    else if (wptPtTemp.byte_turn_mode == 5)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_LANDING").ToString();
                    else if (wptPtTemp.byte_turn_mode == 6)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_HORIZON_CIRCLE").ToString();
                }
                else
                {
                    if (wptPtTemp.byte_turn_mode == 1)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_AUTO_TURN").ToString();
                    else if (wptPtTemp.byte_turn_mode == 4)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_HORIZON_CIRCLE").ToString();
                    else if (wptPtTemp.byte_turn_mode == 5)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_EXIT_WPT").ToString();
                    else if (wptPtTemp.byte_turn_mode == 6)
                        wptPtTemp.str_turn_mode = TryFindResource("TITLE_REPEAT_WPT").ToString();
                }

                wptPtTemp.turn_time = mStruct_Wpt.wp_turn_time;

                wptPtTemp.byte_renwunum = mStruct_Wpt.wp_task;
                if (wptPtTemp.byte_renwunum == 1)
                    wptPtTemp.str_renwu = TryFindResource("TITLE_NO_TASK").ToString();
                else if (wptPtTemp.byte_renwunum == 2)
                    wptPtTemp.str_renwu = TryFindResource("TITLE_PIC_BY_DIST").ToString();
                else if (wptPtTemp.byte_renwunum == 3)
                    wptPtTemp.str_renwu = TryFindResource("TITLE_PIC_BY_TIME").ToString();

                wptPtTemp.pic_interval = mStruct_Wpt.wp_pic_interval;
                wptPtTemp.alt_level = Page_Google_Map.level_alt;
                wptPtTemp.wpt_heading = mStruct_Wpt.wp_heading;

                wptPtTemp.wpt_alt_type = mStruct_Wpt.wp_alt_type;

                // 将收到的航点插入到航线列表
                m_sky_way_list[cur_skyway_no].wayPointSet.Insert(wptPtTemp.NumberId - 1, wptPtTemp);
                // 更新航线链表窗口的显示
                Update_Wpt_View_List();

                // 将更新后的链表重新在地图上显示
                if (MainWindow.map_show_type == 2)
                {
                    Page_2D_Map.Add_Skyway_On_Map(Get_Cur_SkyWay());
                }
                else if (MainWindow.map_show_type == 3)
                {
                    m_PageGoogleMap.webBrowser_google_earth.InvokeScript("AddSkyWay", new object[] {
                            wptPtTemp.lon, wptPtTemp.lat, wptPtTemp.alt, wptPtTemp.alt_level, wptPtTemp.NumberId - 1});
                }
                string srtTemp = TryFindResource("TITLE_WPT_IS_DOWN_LOADING").ToString() + (wptPtTemp.NumberId).ToString() + "/" + mStruct_Wpt.wp_allnum.ToString();
                MessageTimerWindow.Update_Data(srtTemp);
                // 如果收到最后一个航点
                if (mStruct_Wpt.wp_id == mStruct_Wpt.wp_allnum)
                {
                    Page_Version_Update.Read_Data_Type = 0;
                    Page_Version_Update.timer_read_log_pos.Stop();

                    Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_WPT_DOWN_LOAD_SUCC").ToString());

                    MessageTimerWindow.Update_Data("");
                }
                else
                {
                    Req_Wpt_Index++;
                    Req_Wpt_Count = 0;
                }
            }
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
