﻿#pragma checksum "..\..\Date_Back.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4587E888E909D37585F0DF9A42A18AFB16F0BAD3"
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


namespace VIKGroundStation {
    
    
    /// <summary>
    /// Date_Back
    /// </summary>
    public partial class Date_Back : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_OPEN_REPLAY_DATA;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CHECK_BOX_PRO;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CHECK_BOX_AG;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Replay_Data_Path;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Replay_Progress;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Slider_Replay_Progress;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Replay_Speed;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider Slider_Replay_Rate;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_REPLAY_CONTINUE;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_REPLAY_PAUSE;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\Date_Back.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_REPLAY_EXIT;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VIKGroundStation;component/date_back.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Date_Back.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\Date_Back.xaml"
            ((VIKGroundStation.Date_Back)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BTN_OPEN_REPLAY_DATA = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Date_Back.xaml"
            this.BTN_OPEN_REPLAY_DATA.Click += new System.Windows.RoutedEventHandler(this.BTN_OPEN_REPLAY_DATA_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CHECK_BOX_PRO = ((System.Windows.Controls.CheckBox)(target));
            
            #line 28 "..\..\Date_Back.xaml"
            this.CHECK_BOX_PRO.Click += new System.Windows.RoutedEventHandler(this.CHECK_BOX_PRO_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CHECK_BOX_AG = ((System.Windows.Controls.CheckBox)(target));
            
            #line 32 "..\..\Date_Back.xaml"
            this.CHECK_BOX_AG.Click += new System.Windows.RoutedEventHandler(this.CHECK_BOX_AG_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBlock_Replay_Data_Path = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TextBlock_Replay_Progress = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Slider_Replay_Progress = ((System.Windows.Controls.Slider)(target));
            return;
            case 8:
            this.TextBlock_Replay_Speed = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.Slider_Replay_Rate = ((System.Windows.Controls.Slider)(target));
            return;
            case 10:
            this.BTN_REPLAY_CONTINUE = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\Date_Back.xaml"
            this.BTN_REPLAY_CONTINUE.Click += new System.Windows.RoutedEventHandler(this.BTN_REPLAY_CONTINUE_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.BTN_REPLAY_PAUSE = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\Date_Back.xaml"
            this.BTN_REPLAY_PAUSE.Click += new System.Windows.RoutedEventHandler(this.BTN_REPLAY_PAUSE_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.BTN_REPLAY_EXIT = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\Date_Back.xaml"
            this.BTN_REPLAY_EXIT.Click += new System.Windows.RoutedEventHandler(this.BTN_REPLAY_EXIT_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
