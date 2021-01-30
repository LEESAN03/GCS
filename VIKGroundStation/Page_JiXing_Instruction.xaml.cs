using System;
using System.IO;
using System.Windows.Controls;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_JiXing_Instruction.xaml 的交互逻辑
    /// </summary>
    public partial class Page_JiXing_Instruction : Page
    {

        private static Page_JiXing_Instruction m_Page_JiXing_Instruction = new Page_JiXing_Instruction();
        public static Page_JiXing_Instruction getInstance()
        {
            if (m_Page_JiXing_Instruction == null)
                m_Page_JiXing_Instruction = new Page_JiXing_Instruction();

            return m_Page_JiXing_Instruction;
        }
        public Page_JiXing_Instruction()
        {
            InitializeComponent();
            Show_JiXing_Instruction();
        }

        private void Show_JiXing_Instruction()
        {
            var filename = "";

            if (App.language_type == 1)
            {
                filename = "jixing_settings_en";
            }
            else if (App.language_type == 0)
            {
                filename = "jixing_settings_ch";
            }
            // 判断文件是否存在
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    try
                    {
                        HelpText_JiXing.Text = sr.ReadToEnd();
                    }
                    catch (Exception ex)
                    { throw ex; }
                    finally
                    {
                        sr.Close();
                        sr.Dispose();
                    }
                }
            }
        }
    }
}
