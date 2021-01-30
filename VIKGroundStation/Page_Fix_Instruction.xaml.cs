using System;
using System.IO;
using System.Windows.Controls;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Fix_Instruction.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Fix_Instruction : Page
    {
        private static Page_Fix_Instruction m_Page_Fix_Instruction = new Page_Fix_Instruction();
        public static Page_Fix_Instruction getInstance()
        {
            if (m_Page_Fix_Instruction == null)
                m_Page_Fix_Instruction = new Page_Fix_Instruction();

            return m_Page_Fix_Instruction;
        }

        public Page_Fix_Instruction()
        {
            InitializeComponent();
            Set_Instruction();
        }

        public void Set_Instruction()
        {
            Show_Imu_Calibrate_Instruction();
        }


        private void Show_Imu_Calibrate_Instruction()
        {
            var filename = "";

            if (App.language_type == 1)
            {
                filename = "imu_calibration_en";
            }
            else if (App.language_type == 0)
            {
                filename = "imu_calibration_ch";
            }
            // 判断文件是否存在
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    try
                    {
                        HelpText.Text = sr.ReadToEnd();
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
