#pragma checksum "..\..\Page_Log_Pos_Data.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7EBC1105EDC1944E0B68CC61D88A686183102281"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using VIKGroundStation;


namespace VIKGroundStation
{


    /// <summary>
    /// Page_Log_Pos_Data
    /// </summary>
    public partial class Page_Log_Pos_Data : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VK_GCS;component/page_log_pos_data.xaml", System.UriKind.Relative);

#line 1 "..\..\Page_Log_Pos_Data.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.Btn_Download_Pos = ((System.Windows.Controls.Button)(target));

#line 64 "..\..\Page_Log_Pos_Data.xaml"
                    this.Btn_Download_Pos.Click += new System.Windows.RoutedEventHandler(this.Btn_Download_Pos_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.ProgressBar_Download_Pos = ((System.Windows.Controls.ProgressBar)(target));
                    return;
                case 3:
                    this.TextBlock_Pos_Percent = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 4:
                    this.Btn_Download_Fly_Data = ((System.Windows.Controls.Button)(target));

#line 103 "..\..\Page_Log_Pos_Data.xaml"
                    this.Btn_Download_Fly_Data.Click += new System.Windows.RoutedEventHandler(this.Btn_Download_Fly_Data_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.ProgressBar_Download_FLy_Data = ((System.Windows.Controls.ProgressBar)(target));
                    return;
                case 6:
                    this.TextBlock_Fly_Data_Percent = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 7:
                    this.TextBlock_Jiaci = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 8:
                    this.Combox_Jiaci = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 9:
                    this.Btn_Download_Fly_Log = ((System.Windows.Controls.Button)(target));

#line 149 "..\..\Page_Log_Pos_Data.xaml"
                    this.Btn_Download_Fly_Log.Click += new System.Windows.RoutedEventHandler(this.Btn_Download_Fly_Log_Click);

#line default
#line hidden
                    return;
                case 10:
                    this.ProgressBar_Download_FLy_Log = ((System.Windows.Controls.ProgressBar)(target));
                    return;
                case 11:
                    this.TextBlock_Fly_Log_Percent = ((System.Windows.Controls.TextBlock)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}
