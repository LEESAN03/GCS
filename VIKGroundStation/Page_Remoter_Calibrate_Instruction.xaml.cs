using System;
using System.IO;
using System.Windows.Controls;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Remoter_Calibrate_Instruction.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Remoter_Calibrate_Instruction : Page
    {
        private static Page_Remoter_Calibrate_Instruction m_PageRemoterInstruction = new Page_Remoter_Calibrate_Instruction();
        public static Page_Remoter_Calibrate_Instruction getInstance()
        {
            if (m_PageRemoterInstruction == null)
                m_PageRemoterInstruction = new Page_Remoter_Calibrate_Instruction();
            return m_PageRemoterInstruction;
        }

        public Page_Remoter_Calibrate_Instruction()
        {
            InitializeComponent();
            Show_Remoter_Instruction();
        }

        public void Show_Remoter_Instruction()
        {
            var filename = "";

            if (VIKGroundStation.App.language_type == 1)
            {
                filename = "remoter_calibration_en";
            }
            else if (VIKGroundStation.App.language_type == 0)
            {
                filename = "remoter_calibration_ch";
            }
            // 判断文件是否存在
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    try
                    {
                        HelpText_Remoter.Text = sr.ReadToEnd();
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
