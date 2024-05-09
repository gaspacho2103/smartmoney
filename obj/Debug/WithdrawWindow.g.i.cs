﻿#pragma checksum "..\..\WithdrawWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58268A312E41AF583B3AF6CA161EFA0C7BBEAA162B9194480E7205792E7230CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SmartMoney;
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


namespace SmartMoney {
    
    
    /// <summary>
    /// WithdrawWindow
    /// </summary>
    public partial class WithdrawWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\WithdrawWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button xMarkButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\WithdrawWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button collapseMarkButton;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\WithdrawWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CardTextBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\WithdrawWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MoneyTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\WithdrawWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button WithdrawButton;
        
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
            System.Uri resourceLocater = new System.Uri("/SmartMoney;component/withdrawwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WithdrawWindow.xaml"
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
            
            #line 16 "..\..\WithdrawWindow.xaml"
            ((MaterialDesignThemes.Wpf.Card)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Drag);
            
            #line default
            #line hidden
            return;
            case 2:
            this.xMarkButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\WithdrawWindow.xaml"
            this.xMarkButton.Click += new System.Windows.RoutedEventHandler(this.Button_Xmark_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.collapseMarkButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\WithdrawWindow.xaml"
            this.collapseMarkButton.Click += new System.Windows.RoutedEventHandler(this.Button_Collapse_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CardTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.MoneyTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.WithdrawButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\WithdrawWindow.xaml"
            this.WithdrawButton.Click += new System.Windows.RoutedEventHandler(this.WithdrawButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

