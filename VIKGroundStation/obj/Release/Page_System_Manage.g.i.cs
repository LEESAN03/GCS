﻿#pragma checksum "..\..\Page_System_Manage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F54415A509DBC2949EA1270B95CB16A2822DA1F7"
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
    /// Page_System_Manage
    /// </summary>
    public partial class Page_System_Manage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\Page_System_Manage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_SYSTEM_SET;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\Page_System_Manage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_VERSION_MANAGE;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Page_System_Manage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame Frm_System_Manage;
        
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
            System.Uri resourceLocater = new System.Uri("/VIKGroundStation;component/page_system_manage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Page_System_Manage.xaml"
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
            this.BTN_SYSTEM_SET = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Page_System_Manage.xaml"
            this.BTN_SYSTEM_SET.Click += new System.Windows.RoutedEventHandler(this.BTN_SYSTEM_SET_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BTN_VERSION_MANAGE = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\Page_System_Manage.xaml"
            this.BTN_VERSION_MANAGE.Click += new System.Windows.RoutedEventHandler(this.BTN_VERSION_MANAGE_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Frm_System_Manage = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
