using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Camera_Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Camera_Setting : Page
    {
        // 实例化
        private static Page_Camera_Setting m_Page_Camera_Setting = new Page_Camera_Setting();
        public static Page_Camera_Setting getInstance()
        {
            if (m_Page_Camera_Setting == null)
                m_Page_Camera_Setting = new Page_Camera_Setting();
            return m_Page_Camera_Setting;
        }

        public List<CAMERA_PARA> m_Camera_List = new List<CAMERA_PARA>();

        private Page_Camera_Setting()
        {
            InitializeComponent();
            Load_Camera_List();
            Paizhao_Mode_Combox.Items.Add("L-Level");
            Paizhao_Mode_Combox.Items.Add("H-Level");
            Paizhao_Mode_Combox.Items.Add("PWM");
            Paizhao_Mode_Combox.SelectedIndex = 0;
        }

        /****************************************************************
         * 功   能：加载相机列表
         * 参   数：
         * 返   回：
         * *************************************************************/
        private void Load_Camera_List()
        {
            string str_path = Directory.GetCurrentDirectory() + "\\Camera_List.XML";

            FileStream afile = new FileStream(str_path, FileMode.Open, FileAccess.Read);

            if (afile.Length < 50)
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(afile);

            XmlNode xn = doc.SelectSingleNode("Root");
            XmlNode xn1 = xn.SelectSingleNode("Item");
            XmlNode xn_IdAllNum = xn1.SelectSingleNode("IdAllNum");

            int count_way = int.Parse(xn_IdAllNum.InnerText);           //获取航点总数

            if (count_way < 1)
                return;

            for (int i = 0; i < count_way; i++)
            {
                XmlNode xn_item = xn.SelectSingleNode("Item" + (i + 1).ToString());
                XmlNode xn_Name = xn_item.SelectSingleNode("Name_ID");
                XmlNode xn_PangXiangCCDNum = xn_item.SelectSingleNode("Pang_CCD_Num");
                XmlNode xn_HangXiangCCDNum = xn_item.SelectSingleNode("Hang_CCD_Num");
                XmlNode xn_CCD_Size = xn_item.SelectSingleNode("Xiang_Yuan_Size");
                XmlNode xn_Jiao_Ju = xn_item.SelectSingleNode("Jiao_Ju");

                XmlNode pic_mode = xn_item.SelectSingleNode("Pic_Mode");
                XmlNode trigger_time = xn_item.SelectSingleNode("Trigger_Time");
                XmlNode pwm_on_time = xn_item.SelectSingleNode("Pwm_On_Time");
                XmlNode pwm_off_time = xn_item.SelectSingleNode("Pwm_Off_Time");

                CAMERA_PARA Camera_Temp = new CAMERA_PARA();
                Camera_Temp.nameId = xn_Name.InnerText;
                Camera_Temp.Pang_CCD_Num = uint.Parse(xn_PangXiangCCDNum.InnerText);
                Camera_Temp.Hang_CCD_Num = uint.Parse(xn_HangXiangCCDNum.InnerText);
                Camera_Temp.Xiang_Yuan_Size = float.Parse(xn_CCD_Size.InnerText);
                Camera_Temp.Jiao_Ju = float.Parse(xn_Jiao_Ju.InnerText);

                Camera_Temp.Pic_Mode = byte.Parse(pic_mode.InnerText);
                Camera_Temp.Trigger_Time = short.Parse(trigger_time.InnerText);
                Camera_Temp.Pwm_On = short.Parse(pwm_on_time.InnerText);
                Camera_Temp.Pwm_Off = short.Parse(pwm_off_time.InnerText);

                m_Camera_List.Add(Camera_Temp);
                // 默认将第一个相机的参数显示出来
                Camera_Select_Combox.Items.Add(Camera_Temp.nameId);
            }
            Camera_Select_Combox.SelectedIndex = 0;

            TextBox_Camera_ID.Text = m_Camera_List[0].nameId;
            TextBox_Pang_Xiang_Num.Text = m_Camera_List[0].Pang_CCD_Num.ToString();
            TextBox_Hang_Xiang_Num.Text = m_Camera_List[0].Hang_CCD_Num.ToString();

            TextBox_Xiang_Yuan_Size.Text = m_Camera_List[0].Xiang_Yuan_Size.ToString();
            TextBox_Focuses.Text = m_Camera_List[0].Jiao_Ju.ToString();

            Paizhao_Mode_Combox.SelectedIndex = (int)m_Camera_List[0].Pic_Mode;
            TextBox_Pic_Trigger_Time_On.Text = m_Camera_List[0].Trigger_Time.ToString();
            TextBox_Pic_Pwm_On_Time.Text = m_Camera_List[0].Pwm_On.ToString();
            TextBox_Pic_Pwm_Off_Time.Text = m_Camera_List[0].Pwm_Off.ToString();

            afile.Close();
        }

        /*****************************************************************
         * 功   能：添加相机设置
         * 参   数：
         * 返   回：
         * **************************************************************/
        private void BTN_ADD_CAMERA_Click(object sender, RoutedEventArgs e)
        {
            CAMERA_PARA Camera_Temp = new CAMERA_PARA();

            Camera_Temp.nameId = TextBox_Camera_ID.Text;
            Camera_Temp.Pang_CCD_Num = uint.Parse(TextBox_Pang_Xiang_Num.Text);
            Camera_Temp.Hang_CCD_Num = uint.Parse(TextBox_Hang_Xiang_Num.Text);

            Camera_Temp.Xiang_Yuan_Size = float.Parse(TextBox_Xiang_Yuan_Size.Text);
            Camera_Temp.Jiao_Ju = float.Parse(TextBox_Focuses.Text);

            Camera_Temp.Pic_Mode = (byte)Paizhao_Mode_Combox.SelectedIndex;
            Camera_Temp.Trigger_Time = short.Parse(TextBox_Pic_Trigger_Time_On.Text);

            Camera_Temp.Pwm_On = short.Parse(TextBox_Pic_Pwm_On_Time.Text);
            Camera_Temp.Pwm_Off = short.Parse(TextBox_Pic_Pwm_Off_Time.Text);

            m_Camera_List.Add(Camera_Temp);

            // 更新相机设置文件
            Save_Camera_List();
            Camera_Select_Combox.Items.Add(Camera_Temp.nameId);
        }

        /*****************************************************************
        * 功   能：保存相机设置
        * 参   数：
        * 返   回：
        * **************************************************************/
        private void Save_Camera_List()
        {
            string str_path = Directory.GetCurrentDirectory() + "\\Camera_List.XML";

            FileStream afile = new FileStream(str_path, FileMode.Create);
            XmlTextWriter writer = new XmlTextWriter(afile, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();

            writer.WriteStartElement("Root");
            writer.WriteStartElement("Item");
            writer.WriteElementString("IdAllNum", m_Camera_List.Count.ToString());
            writer.WriteEndElement(); // 关闭元素

            //向先前创建的元素中添加一个属性
            for (int i = 0; i < m_Camera_List.Count; i++)
            {
                writer.WriteStartElement("Item" + (i+1).ToString());
                writer.WriteElementString("Name_ID", m_Camera_List[i].nameId);                                //航点编号
                writer.WriteElementString("Pang_CCD_Num", m_Camera_List[i].Pang_CCD_Num.ToString());       //航点经度
                writer.WriteElementString("Hang_CCD_Num", m_Camera_List[i].Hang_CCD_Num.ToString());       //航点纬度
                writer.WriteElementString("Xiang_Yuan_Size", m_Camera_List[i].Xiang_Yuan_Size.ToString()); //航点高度
                writer.WriteElementString("Jiao_Ju", m_Camera_List[i].Jiao_Ju.ToString());                 //航点海拔
                writer.WriteElementString("Pic_Mode", m_Camera_List[i].Pic_Mode.ToString());               //拍照模式
                writer.WriteElementString("Trigger_Time", m_Camera_List[i].Trigger_Time.ToString());       //拍照时间
                writer.WriteElementString("Pwm_On_Time", m_Camera_List[i].Pwm_On.ToString());              //PWM拍照触发值
                writer.WriteElementString("Pwm_Off_Time", m_Camera_List[i].Pwm_Off.ToString());             //PWM不拍照的值
                writer.WriteEndElement(); // 关闭元素
            }
            writer.Close();
            afile.Close();

            Window_Operation_Indication.Set_Indication_Text(TryFindResource("TITLE_SAVE_FILE_SUCCESS").ToString());
        }

        /*******************************************************************
         * 功   能：删除指定的相机
         * 参   数：
         * 返   回：
         * ****************************************************************/
        private void BTN_DELETE_CAMERA_Click(object sender, RoutedEventArgs e)
        {
            int indexTemp = Camera_Select_Combox.SelectedIndex;
            Camera_Select_Combox.Items.RemoveAt(indexTemp);

            m_Camera_List.RemoveAt(indexTemp);
            Save_Camera_List();
        }

        /*****************************************************************
        * 功   能：计算航线参数
        * 参   数：
        * 返   回：
        * **************************************************************/
        public double wpt_alt_calculated = 0;
        uint wpt_pic_interval_dist = 0, hang_jian_ju_calculated = 0;
        private void BTN_Camera_Caculate_Click(object sender, RoutedEventArgs e)
        {
            int pangxiang_ccd_num = int.Parse(TextBox_Pang_Xiang_Num.Text);
            int hangxiang_ccd_num = int.Parse(TextBox_Hang_Xiang_Num.Text);
            double xiang_yuan_size = double.Parse(TextBox_Xiang_Yuan_Size.Text) / 1000000;

            double pangxiang_cover = double.Parse(TextBox_Pang_Xiang_Cover_Rate.Text) / 100;
            double hangxiang_cover = double.Parse(TextBox_Hang_Xiang_Cover_Rate.Text) / 100;
            double res = double.Parse(TextBox_CCD_Resolution.Text) / 100;

            double cam_focus = double.Parse(TextBox_Focuses.Text) / 1000;

            // 计算航线高度
            wpt_alt_calculated = cam_focus * res / xiang_yuan_size;
            TextBox_Wpt_Alt.Text = Math.Round(wpt_alt_calculated, 1).ToString();

            // 计算行间距
            hang_jian_ju_calculated = (uint)((1 - pangxiang_cover) * pangxiang_ccd_num * res);
            TextBox_Hang_Jian_Ju.Text = hang_jian_ju_calculated.ToString();

            // 计算拍照间隔
            wpt_pic_interval_dist = (uint)((1 - hangxiang_cover) * hangxiang_ccd_num * res);
            TextBox_Pic_Interval_Dist.Text = wpt_pic_interval_dist.ToString();
        }

        /*****************************************************************
        * 功   能：将计算的参数复制到航线编辑中
        * 参   数：
        * 返   回：
        * **************************************************************/
        private void BTN_Camera_Setting_Ok_Click(object sender, RoutedEventArgs e)
        {
            Window_Skyway.getInstance().TextBox_WptAlt.Text = TextBox_Wpt_Alt.Text;
            Window_Skyway.getInstance().TextBox_Task_Time.Text = TextBox_Pic_Interval_Dist.Text;
        }

        /*****************************************************************
        * 功   能：拍照方式选择
        * 参   数：
        * 返   回：
        * **************************************************************/
        private void BTN_PAI_ZHAO_MODE_Click(object sender, RoutedEventArgs e)
        {
            short triggerTime = short.Parse(TextBox_Pic_Trigger_Time_On.Text);
            short pwmOnTime = short.Parse(TextBox_Pic_Pwm_On_Time.Text);
            short pwmOffTime = short.Parse(TextBox_Pic_Pwm_Off_Time.Text);

            DATA_LINK.Send_Picture_Trigger_Mode(MsgDef.PICTURE_TRIGGER_MODE, (byte)paizhao_mode, triggerTime, pwmOnTime, pwmOffTime);
        }

        private int paizhao_mode = 0;   // 默认低电平拍照
        private void Paizhao_Mode_Combox_Changed(object sender, SelectionChangedEventArgs e)
        {
            paizhao_mode = Paizhao_Mode_Combox.SelectedIndex;
            if (paizhao_mode == 2)
            {
                TextBlock_Pwm_On.Visibility = Visibility.Visible;
                TextBlock_Pwm_Off.Visibility = Visibility.Visible;
                TextBox_Pic_Pwm_On_Time.Visibility = Visibility.Visible;
                TextBox_Pic_Pwm_Off_Time.Visibility = Visibility.Visible;
            }
            else
            {
                TextBlock_Pwm_On.Visibility = Visibility.Hidden;
                TextBlock_Pwm_Off.Visibility = Visibility.Hidden;
                TextBox_Pic_Pwm_On_Time.Visibility = Visibility.Hidden;
                TextBox_Pic_Pwm_Off_Time.Visibility = Visibility.Hidden;
            }
        }

        /*****************************************************************
        * 功   能：获取MC_COM的配置
        * 参   数：
        * 返   回：
        * **************************************************************/
        private void BTN_MC_COM_FETCH_Click(object sender, RoutedEventArgs e)
        {
            DATA_LINK.Send_Req_Ctl_Cal_Msg(MsgDef.MSG_REQ, 24, 15);
        }

        /*****************************************************************
        * 功   能：相机列表选择变化时
        * 参   数：
        * 返   回：
        * **************************************************************/
        private void Camera_Select_Combox_Changed(object sender, SelectionChangedEventArgs e)
        {
            int indexTemp = Camera_Select_Combox.SelectedIndex;

            if (indexTemp >= 0)
            {
                TextBox_Camera_ID.Text = m_Camera_List[indexTemp].nameId;
                TextBox_Pang_Xiang_Num.Text = m_Camera_List[indexTemp].Pang_CCD_Num.ToString();
                TextBox_Hang_Xiang_Num.Text = m_Camera_List[indexTemp].Hang_CCD_Num.ToString();

                TextBox_Xiang_Yuan_Size.Text = m_Camera_List[indexTemp].Xiang_Yuan_Size.ToString();
                TextBox_Focuses.Text = m_Camera_List[indexTemp].Jiao_Ju.ToString();

                Paizhao_Mode_Combox.SelectedIndex = (int)(m_Camera_List[indexTemp].Pic_Mode);
                TextBox_Pic_Trigger_Time_On.Text = m_Camera_List[indexTemp].Trigger_Time.ToString();
                TextBox_Pic_Pwm_On_Time.Text = m_Camera_List[indexTemp].Pwm_On.ToString();
                TextBox_Pic_Pwm_Off_Time.Text = m_Camera_List[indexTemp].Pwm_Off.ToString();
            }
        }
    }
}
