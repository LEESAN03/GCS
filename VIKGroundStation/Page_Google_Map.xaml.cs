using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
namespace VIKGroundStation
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    /// <summary>
    /// Page_Google_Map.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Google_Map : Page
    {
        private static Page_Google_Map m_Page_Google_Map = new Page_Google_Map();
        public static Page_Google_Map getInstance()
        {
            if (m_Page_Google_Map == null)
                m_Page_Google_Map = new Page_Google_Map();
            return m_Page_Google_Map;
        }

        // 0---无动作， 1---添加航点， 2---编辑航点， 3---删除航点
        public static byte wptEditType = 0;
        public static int wptEditIndex = 0;     // 需要编辑航点的序号

        public Page_Google_Map()
        {
            InitializeComponent();

            // 添加谷歌地图
            this.webBrowser_google_earth.Visibility = Visibility.Visible;

            ObjectForScriptingHelper_Google helper;
            helper = new ObjectForScriptingHelper_Google();
            this.webBrowser_google_earth.ObjectForScripting = helper;

            string htmlStrpath;
            htmlStrpath = "http://127.0.0.1:" + onusergetHttp() + "/Main_V81.html";
            webBrowser_google_earth.Navigate(new Uri(htmlStrpath));
        }
        [DllImport("web.dll")]
        public static extern int onusergetHttp();

        /********************************************************************
         * 功   能：googleearth初始化响应函数
         * 参   数：
         * 返   回：
         * ******************************************************************/
        public static bool initmap = false;
        public static double level_alt = 0;  // 
        public void OnExternalInitOver()//初始化视角；
        {
            initmap = true;
        }

        /*******************************************************************
         * 功   能：设置编辑航点类型和编辑航线序号
         * 参   数：
         * 返   回：
         * *****************************************************************/
        public static void SetWptEditType(int argEditType, int argEditNum)
        {
            m_Page_Google_Map.webBrowser_google_earth.InvokeScript("setUAVLineState", new object[] { argEditType, argEditNum });
        }

        /*******************************************************************
         * 功   能：删除当前所有航点
         * 参   数：
         * 返   回：
         * *****************************************************************/
        public static void Delete_All_Wpt_3D()
        {
            m_Page_Google_Map.webBrowser_google_earth.InvokeScript("DelAllPt", new object[] {  });
        }

        /*******************************************************************
        * 功   能：添加边界点
        * 参   数：
        * 返   回：
        * *****************************************************************/
        public static void Add_BoundList_3D( List<BOUND_PT> bound_list)
        {
            int i = 0;
            m_Page_Google_Map.webBrowser_google_earth.InvokeScript("DelAllBoundPt", new object[] { });

            for (i = 0; i < bound_list.Count; i++)
            {
                m_Page_Google_Map.webBrowser_google_earth.InvokeScript("AddBoundPt", new object[] {
                    bound_list[i].lon, bound_list[i].lat, bound_list[i].alt, level_alt, i});
            }
        }
    }
}
