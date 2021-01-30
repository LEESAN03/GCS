using System.Windows;

namespace VIKGroundStation
{
    /// <summary>
    /// Window_WPT_SHIFT.xaml 的交互逻辑
    /// </summary>
    public partial class Window_WPT_SHIFT : Window
    {
        // 实例化
        private static Window_WPT_SHIFT m_Window_WPT_SHIFT = new Window_WPT_SHIFT();
        public static Window_WPT_SHIFT getInstance()
        {
            if (m_Window_WPT_SHIFT == null)
                m_Window_WPT_SHIFT = new Window_WPT_SHIFT();
            return m_Window_WPT_SHIFT;
        }

        public static bool mb_wnd_initializaed = false;
        public static bool mb_wnd_visible = false;

        public static void Wnd_Show()
        {
            Window_WPT_SHIFT hWnd = getInstance();
            hWnd.Show();
            mb_wnd_visible = true;
            mb_wnd_initializaed = true;
        }

        public static void Wnd_Hide()
        {
            Window_WPT_SHIFT hWnd = getInstance();
            hWnd.Hide();
            mb_wnd_visible = false;
        }
        private Window_WPT_SHIFT()
        {
            InitializeComponent();
            Left = SystemParameters.PrimaryScreenWidth / 4;
            Top = SystemParameters.PrimaryScreenHeight / 8;

            Set_Font();
            Hide();
            Owner = MainWindow.getInstance();
        }

        /*************************************************************************
        * 函数功能：设置显示字体
        * **********************************************************************/
        public void Set_Font()
        {
            BTN_WPT_UP_SHIFT.FontSize = BTN_WPT_UP_SHIFT.FontSize * SystemParameters.PrimaryScreenHeight / 1080;
            BTN_WPT_LEFT_SHIFT.FontSize = BTN_WPT_LEFT_SHIFT.FontSize * SystemParameters.PrimaryScreenHeight / 1080;
            BTN_WPT_RIGHT_SHIFT.FontSize = BTN_WPT_RIGHT_SHIFT.FontSize * SystemParameters.PrimaryScreenHeight / 1080;
            BTN_WPT_DOWN_SHIFT.FontSize = BTN_WPT_DOWN_SHIFT.FontSize * SystemParameters.PrimaryScreenHeight / 1080;
            BTN_EXIT_WPT_SHIFT.FontSize = BTN_EXIT_WPT_SHIFT.FontSize * SystemParameters.PrimaryScreenHeight / 1080;
        }

        /*************************************************************************
        * 函数功能：向上整体移动航线
        * **********************************************************************/
        private void BTN_WPT_UP_SHIFT_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.Shift_All_Wpt(1);
        }

        /*************************************************************************
        * 函数功能：向左整体移动航线
        * **********************************************************************/
        private void BTN_WPT_LEFT_SHIFT_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.Shift_All_Wpt(3);
        }

        /*************************************************************************
        * 函数功能：退出
        * **********************************************************************/
        private void BTN_EXIT_WPT_SHIFT_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Page_2D_Map.addptbool = 0;
            Page_2D_Map.Wpt_Drag_Layer.Clear();
            Page_2D_Map.Drag_Area_Points.Clear();
            Page_2D_Map.isMouseInDragArea = false;
            Page_2D_Map.drag_area_exist = false;
        }

        /*************************************************************************
        * 函数功能：向右整体移动航线
        * **********************************************************************/
        private void BTN_WPT_RIGHT_SHIFT_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.Shift_All_Wpt(4);
        }

        /*************************************************************************
        * 函数功能：向下整体移动航线
        * **********************************************************************/
        private void BTN_WPT_DOWN_SHIFT_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.Shift_All_Wpt(2);
        }

        /*************************************************************************
        * 函数功能：选择需要平移的航点
        * **********************************************************************/
        private void BTN_WPT_SELECT_DRAG_START_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.addptbool = 2;

            Page_2D_Map.Wpt_Drag_Layer.Clear();
            Page_2D_Map.Drag_Area_Points.Clear();
            Page_2D_Map.drag_area_exist = false;
        }

        /*************************************************************************
        * 函数功能：结束选择航点
        * **********************************************************************/
        private void BTN_WPT_SELECT_DRAG_END_Click(object sender, RoutedEventArgs e)
        {
            Page_2D_Map.addptbool = 0;
        }
    }
}
