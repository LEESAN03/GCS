﻿#pragma checksum "..\..\Window_Function_Indication.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E20ED9DAED2528892F0BAD5897B96BF5D9A213AA"
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


namespace VIKGroundStation {
    
    
    /// <summary>
    /// Window_Function_Indication
    /// </summary>
    public partial class Window_Function_Indication : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\Window_Function_Indication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Target_Wpt;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Window_Function_Indication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Target_Wpt;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Window_Function_Indication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_SET_TARGET_WPT;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Window_Function_Indication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Target_Alt;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Window_Function_Indication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Target_Alt;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Window_Function_Indication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_SET_TARGET_ALT;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\Window_Function_Indication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Pic_Num;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\Window_Function_Indication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Pic_Num_Show;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\Window_Function_Indication.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_TAKE_PIC;
        
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
            System.Uri resourceLocater = new System.Uri("/VIKGroundStation;component/window_function_indication.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_Function_Indication.xaml"
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
            
            #line 8 "..\..\Window_Function_Indication.xaml"
            ((VIKGroundStation.Window_Function_Indication)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBlock_Target_Wpt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TextBox_Target_Wpt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.BTN_SET_TARGET_WPT = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\Window_Function_Indication.xaml"
            this.BTN_SET_TARGET_WPT.Click += new System.Windows.RoutedEventHandler(this.BTN_SET_TARGET_WPT_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBlock_Target_Alt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TextBox_Target_Alt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.BTN_SET_TARGET_ALT = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\Window_Function_Indication.xaml"
            this.BTN_SET_TARGET_ALT.Click += new System.Windows.RoutedEventHandler(this.BTN_SET_TARGET_ALT_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TextBlock_Pic_Num = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.TextBlock_Pic_Num_Show = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.BTN_TAKE_PIC = ((System.Windows.Controls.Button)(target));
            
            #line 111 "..\..\Window_Function_Indication.xaml"
            this.BTN_TAKE_PIC.Click += new System.Windows.RoutedEventHandler(this.BTN_TAKE_PIC_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
