﻿#pragma checksum "..\..\Window_Area_Route.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FAF05C4BD0C96B1C19E361EAE4F3EA651B3E798F"
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
    /// Window_Area_Route
    /// </summary>
    public partial class Window_Area_Route : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\Window_Area_Route.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pt;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Window_Area_Route.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CLose;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\Window_Area_Route.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button gaoduSet;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\Window_Area_Route.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Name;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\Window_Area_Route.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kaishiSet;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\Window_Area_Route.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button jiesuSet;
        
        #line default
        #line hidden
        
        
        #line 230 "..\..\Window_Area_Route.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button qingpingSet;
        
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
            System.Uri resourceLocater = new System.Uri("/VIKGroundStation;component/window_area_route.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_Area_Route.xaml"
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
            this.pt = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.CLose = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\Window_Area_Route.xaml"
            this.CLose.Click += new System.Windows.RoutedEventHandler(this.CLose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.gaoduSet = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.kaishiSet = ((System.Windows.Controls.Button)(target));
            
            #line 156 "..\..\Window_Area_Route.xaml"
            this.kaishiSet.Click += new System.Windows.RoutedEventHandler(this.kaishiSet_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.jiesuSet = ((System.Windows.Controls.Button)(target));
            
            #line 189 "..\..\Window_Area_Route.xaml"
            this.jiesuSet.Click += new System.Windows.RoutedEventHandler(this.jiesuSet_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.qingpingSet = ((System.Windows.Controls.Button)(target));
            
            #line 230 "..\..\Window_Area_Route.xaml"
            this.qingpingSet.Click += new System.Windows.RoutedEventHandler(this.qingpingSet_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

