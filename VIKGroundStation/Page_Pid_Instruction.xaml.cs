using System;
using System.IO;
using System.Windows.Controls;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Pid_Instruction.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Pid_Instruction : Page
    {
        private static Page_Pid_Instruction m_Page_Pid_Instruction = new Page_Pid_Instruction();
        public static Page_Pid_Instruction getInstance()
        {
            if (m_Page_Pid_Instruction == null)
                m_Page_Pid_Instruction = new Page_Pid_Instruction();

            return m_Page_Pid_Instruction;
        }

        public Page_Pid_Instruction()
        {
            InitializeComponent();
            Show_Pid_Instruction();
        }

        private void Show_Pid_Instruction()
        {
            var filename = "";

            if (VIKGroundStation.App.language_type == 1)
            {
                filename = "pid_en";
            }
            else if (VIKGroundStation.App.language_type == 0)
            {
                filename = "pid_ch";
            }
            // 判断文件是否存在
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    try
                    {
                        HelpText_Pid.Text = sr.ReadToEnd();
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
