﻿#pragma checksum "..\..\winSplash.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4B4C2B0CF471A825FE77EBFECBE8C2774720386F"
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
    /// winSplash
    /// </summary>
    public partial class winSplash : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\winSplash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBlock_Wait;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\winSplash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combox_plane_type;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\winSplash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combox_single_many;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\winSplash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_START_UP;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\winSplash.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_SHUT_DOWN;
        
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
            System.Uri resourceLocater = new System.Uri("/VK_GCS;component/winsplash.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\winSplash.xaml"
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
            
            #line 5 "..\..\winSplash.xaml"
            ((VIKGroundStation.winSplash)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBlock_Wait = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.combox_plane_type = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\winSplash.xaml"
            this.combox_plane_type.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.combox_plane_type_Changed);
            
            #line default
            #line hidden
            return;
            case 4:
            this.combox_single_many = ((System.Windows.Controls.ComboBox)(target));
            
            #line 32 "..\..\winSplash.xaml"
            this.combox_single_many.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.combox_single_many_Changed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BTN_START_UP = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\winSplash.xaml"
            this.BTN_START_UP.Click += new System.Windows.RoutedEventHandler(this.BTN_START_UP_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BTN_SHUT_DOWN = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\winSplash.xaml"
            this.BTN_SHUT_DOWN.Click += new System.Windows.RoutedEventHandler(this.BTN_SHUT_DOWN_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
