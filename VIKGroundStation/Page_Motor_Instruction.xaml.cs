using System.Windows.Controls;

namespace VIKGroundStation
{
    /// <summary>
    /// Page_Motor_Instruction.xaml 的交互逻辑
    /// </summary>
    public partial class Page_Motor_Instruction : Page
    {
        private static Page_Motor_Instruction m_PageMotorInstruction = new Page_Motor_Instruction();
        public static Page_Motor_Instruction getInstance()
        {
            if (m_PageMotorInstruction == null)
                m_PageMotorInstruction = new Page_Motor_Instruction();

            return m_PageMotorInstruction;
        }

        public Page_Motor_Instruction()
        {
            InitializeComponent();
            Show_Motor_Instruction();
        }

        private void Show_Motor_Instruction()
        {
            HelpText_Motor.Text = "";
        }
    }
}
