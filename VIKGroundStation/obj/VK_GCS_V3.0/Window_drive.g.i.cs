﻿#pragma checksum "..\..\Window_drive.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "935403827FBA9277CC01BE8612B87E98ABE09C3E"
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
    /// Window_drive
    /// </summary>
    public partial class Window_drive : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\Window_drive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox drive_namelist;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\Window_drive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button connect;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Window_drive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button get;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Window_drive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_text;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Window_drive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button get_Copy;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\Window_drive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button get_Copy1;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\Window_drive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_text_Copy;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\Window_drive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tb_text_Copy1;
        
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
            System.Uri resourceLocater = new System.Uri("/VK_GCS;component/window_drive.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_drive.xaml"
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
            
            #line 5 "..\..\Window_drive.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.drive_namelist = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.connect = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\Window_drive.xaml"
            this.connect.Click += new System.Windows.RoutedEventHandler(this.connect_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.get = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Window_drive.xaml"
            this.get.Click += new System.Windows.RoutedEventHandler(this.get_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tb_text = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.get_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\Window_drive.xaml"
            this.get_Copy.Click += new System.Windows.RoutedEventHandler(this.get_Copy_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.get_Copy1 = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\Window_drive.xaml"
            this.get_Copy1.Click += new System.Windows.RoutedEventHandler(this.get_Copy1_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.tb_text_Copy = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.tb_text_Copy1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

