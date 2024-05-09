﻿#pragma checksum "..\..\ProfilePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "879880F46BC01C1F5373D241AD3F3D95FB6E14F766D1FC534AE6DAD7556FA4F2"
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
    /// ProfilePage
    /// </summary>
    public partial class ProfilePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SurnameProfileBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NameProfileBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TelephoneProfileBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ReplenishProfileBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WithdrawProfileBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock StocksBuyCount;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Replenish;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Withdraw;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\ProfilePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock BalanceProfileBox;
        
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
            System.Uri resourceLocater = new System.Uri("/SmartMoney;component/profilepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProfilePage.xaml"
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
            this.SurnameProfileBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.NameProfileBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TelephoneProfileBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.ReplenishProfileBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.WithdrawProfileBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.StocksBuyCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Replenish = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\ProfilePage.xaml"
            this.Replenish.Click += new System.Windows.RoutedEventHandler(this.Replenish_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Withdraw = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\ProfilePage.xaml"
            this.Withdraw.Click += new System.Windows.RoutedEventHandler(this.Withdraw_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BalanceProfileBox = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

