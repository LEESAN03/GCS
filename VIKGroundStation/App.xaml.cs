using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VIKGroundStation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    ///  
    public partial class App : Application
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static winSplash win = null;

        public static int plane_type = 0, single_many_type = 0;
        public static bool main_wnd_load_finished = false;
        public static string str_plane_type, str_single_multi;

        public static System.Threading.ManualResetEvent mre = new System.Threading.ManualResetEvent(false);

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            SetCulture();
        }
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]

        public static void Main()
        {
            win = new winSplash();
            win.ShowDialog();
        }

        public static bool init_finish = false;
        public static void System_Init()
        {
            log4net.Config.XmlConfigurator.Configure();
            Thread main_thread = new Thread(ShowSplashScreenThenMainWindow);
            main_thread.SetApartmentState(ApartmentState.STA);
            main_thread.Start();

            init_finish = true;
        }

        /// <summary>
        /// 创建启动屏幕对象，显示系统初始化信息，最后显示主窗体
        /// </summary>
        static void ShowSplashScreenThenMainWindow()
        {
            //显示主窗体
            App myApp = new App();
            AddCulture();
            myApp.Run(new MainWindow());
        }

        public static string Culture { get; set; }
        private static void SetCulture()
        {
            try
            {
                VIKGroundStation.Properties.Settings.Default.Culture = Culture;
                VIKGroundStation.Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
            }
        }

        public static byte language_type = 0;
        public static void AddCulture()
        {
            string str_path = Directory.GetCurrentDirectory();
            if (int.Parse(ReadConfigFile.ReadIniData("IP_SET", "language", "", str_path + "\\Start_Up.ini")) == 1) 
            {
                App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Resources/StringResource.zh-CN.xaml", UriKind.RelativeOrAbsolute) });
                language_type = 0;
            }
            else if (int.Parse(ReadConfigFile.ReadIniData("IP_SET", "language", "", str_path + "\\Start_Up.ini")) == 2)
            {
                App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Resources/StringResource.en-US.xaml", UriKind.RelativeOrAbsolute) });
                language_type = 1;
            }
            else if (int.Parse(ReadConfigFile.ReadIniData("IP_SET", "language", "", str_path + "\\Start_Up.ini")) == 3)
            {
                App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/Resources/StringResource.tr-TR.xaml", UriKind.RelativeOrAbsolute) });
                language_type = 2;
            }
        }
    }
}
