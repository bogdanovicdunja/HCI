﻿#pragma checksum "..\..\..\..\Pages\UpdateSurgery.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7F76BAE938EDB1A44E98902EAB7A11D852E995BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using bolnica.Pages;


namespace bolnica.Pages {
    
    
    /// <summary>
    /// UpdateSurgery
    /// </summary>
    public partial class UpdateSurgery : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 106 "..\..\..\..\Pages\UpdateSurgery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DP1;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\Pages\UpdateSurgery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboTP;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\..\Pages\UpdateSurgery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Rooms;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\..\Pages\UpdateSurgery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Patients;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\Pages\UpdateSurgery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Doctors;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\Pages\UpdateSurgery.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame NewSur;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/bolnica;component/pages/updatesurgery.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\UpdateSurgery.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DP1 = ((System.Windows.Controls.DatePicker)(target));
            
            #line 106 "..\..\..\..\Pages\UpdateSurgery.xaml"
            this.DP1.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DP1_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cboTP = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.Rooms = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.Patients = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Doctors = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            
            #line 154 "..\..\..\..\Pages\UpdateSurgery.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NewSur = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

