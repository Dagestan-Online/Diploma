﻿#pragma checksum "..\..\..\..\Pages\Material\MaterialPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "20965AA592921BAD8A15D57177B472787DA22B4F1E654F01A37F7B5A90635AA5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DiplomaProject.Pages.Material;
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


namespace DiplomaProject.Pages.Material {
    
    
    /// <summary>
    /// MaterialPage
    /// </summary>
    public partial class MaterialPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 31 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbFindText;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSort;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvInfo;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSelectedPage;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbCurrentEntries;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbTotalEntries;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnFirstPage;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPreviousPage;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbPages;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNextPage;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\..\Pages\Material\MaterialPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLastPage;
        
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
            System.Uri resourceLocater = new System.Uri("/DiplomaProject;component/pages/material/materialpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Material\MaterialPage.xaml"
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
            this.tbFindText = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            this.tbFindText.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbFindText_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbSort = ((System.Windows.Controls.ComboBox)(target));
            
            #line 45 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            this.cmbSort.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbSort_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 56 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddInfo_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lvInfo = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.tbSelectedPage = ((System.Windows.Controls.TextBox)(target));
            
            #line 107 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            this.tbSelectedPage.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.tbSelectedPage_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 113 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChangePage_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.tbCurrentEntries = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.tbTotalEntries = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.BtnFirstPage = ((System.Windows.Controls.Button)(target));
            
            #line 151 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            this.BtnFirstPage.Click += new System.Windows.RoutedEventHandler(this.BtnFirstPage_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.BtnPreviousPage = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            this.BtnPreviousPage.Click += new System.Windows.RoutedEventHandler(this.BtnPreviousPage_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.tbPages = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.BtnNextPage = ((System.Windows.Controls.Button)(target));
            
            #line 170 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            this.BtnNextPage.Click += new System.Windows.RoutedEventHandler(this.BtnNextPage_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.BtnLastPage = ((System.Windows.Controls.Button)(target));
            
            #line 176 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            this.BtnLastPage.Click += new System.Windows.RoutedEventHandler(this.BtnLastPage_Click);
            
            #line default
            #line hidden
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
            case 5:
            
            #line 81 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteInfo_Click);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 86 "..\..\..\..\Pages\Material\MaterialPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditInfo_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

