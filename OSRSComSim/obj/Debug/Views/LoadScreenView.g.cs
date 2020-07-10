﻿#pragma checksum "..\..\..\Views\LoadScreenView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72337D9497D4B845084C2C5D3871633F33A5403C90F23812348E17F5C0F7A235"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using OSRSComSim.ViewModels;
using OSRSComSim.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace OSRSComSim.Views {
    
    
    /// <summary>
    /// LoadScreenView
    /// </summary>
    public partial class LoadScreenView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 21 "..\..\..\Views\LoadScreenView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas LoadScreeenCanvas;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Views\LoadScreenView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelectedPlayer;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\LoadScreenView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_select;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Views\LoadScreenView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_cancel;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\LoadScreenView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_create_new;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\LoadScreenView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_import_new;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\LoadScreenView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox players_viewer;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Views\LoadScreenView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PlayerSkills;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Views\LoadScreenView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl show_create_player;
        
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
            System.Uri resourceLocater = new System.Uri("/OSRSComSim;component/views/loadscreenview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\LoadScreenView.xaml"
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
            this.LoadScreeenCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.SelectedPlayer = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.button_select = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Views\LoadScreenView.xaml"
            this.button_select.Click += new System.Windows.RoutedEventHandler(this.button_select_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Views\LoadScreenView.xaml"
            this.button_cancel.Click += new System.Windows.RoutedEventHandler(this.button_cancel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_create_new = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Views\LoadScreenView.xaml"
            this.btn_create_new.Click += new System.Windows.RoutedEventHandler(this.Btn_create_new_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_import_new = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.players_viewer = ((System.Windows.Controls.ListBox)(target));
            return;
            case 11:
            this.PlayerSkills = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.show_create_player = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            
            #line 38 "..\..\..\Views\LoadScreenView.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.PlayerBorder_Click);
            
            #line default
            #line hidden
            break;
            case 9:
            
            #line 43 "..\..\..\Views\LoadScreenView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_btn_Click);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 47 "..\..\..\Views\LoadScreenView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete_btn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

