
using System.Collections.Generic;

namespace VIKGroundStation
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class ObjectForScriptingHelper_Google
    {
        public ObjectForScriptingHelper_Google()
        {
        }
        public void OnExternalInitOver()
        {
            Page_Google_Map m_PageGoogleMap = Page_Google_Map.getInstance();
            m_PageGoogleMap.OnExternalInitOver();
        }
        /********************************************************************************************
         * 功   能：谷歌地球鼠标点击响应函数
         * 参   数：
         * 返   回：
         * ******************************************************************************************/
        public void OnExternalMouseClick(double x, double y, double editType, int g_iLineEditParam, double level_Alt)
        {
            Page_2D_Map m_Page2DMap = Page_2D_Map.getInstance();

            m_Page2DMap.TouchDownEnd.Lng = x;
            m_Page2DMap.TouchDownEnd.Lat = y;
            Page_Google_Map.wptEditType = (byte)editType;

            // 如果是添加航点
            if (editType == 1)
            {
                // 获取航线的海拔
                Page_Google_Map.level_alt = level_Alt;
                int wptIndex_Temp = 0;
                // 如果直接从航线尾部添加
                if (g_iLineEditParam == -1)
                    wptIndex_Temp = Window_Skyway.Get_Cur_Skyway_Count();
                else
                    wptIndex_Temp = g_iLineEditParam;

                Window_Skyway.getInstance().Add_Wpt_From_GoogleMap(x, y, wptIndex_Temp, level_Alt);
            }
            else if (editType == 5)     // 添加指点
            {
                Window_Fly_Point.getInstance().Update_ZhiDian_Pos(x, y);
            }
            else if (editType == 6)       // 添加边界点
            {
                // 获取航线的海拔
                Page_Google_Map.level_alt = level_Alt;
                int boundIndex_Temp = 0;
                // 如果直接从航线尾部添加
                if (g_iLineEditParam == -1)
                    boundIndex_Temp = Window_Skyway.bound_pt_list.Count;
                else
                    boundIndex_Temp = g_iLineEditParam;

                Window_Skyway.getInstance().AddPtToBoundList(x, y, boundIndex_Temp);
                Window_Skyway.getInstance().Updatet_Bound_Skyway();
            }
        }

        /*************************************************************************************
        函数名称：   OnExternalMouseUp( double x, double y,double pointIndex )
        功能：       地图鼠标点击相应函数
        ************************************************************************************/
        public void OnExternalMouseUp(double x, double y, int pointIndex)
        {
            Window_Skyway.getInstance().Change_Cur_Skyway_Wpt(x, y, pointIndex);
        }
    }
}
