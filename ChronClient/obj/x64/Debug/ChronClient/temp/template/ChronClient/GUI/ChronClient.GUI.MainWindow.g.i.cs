﻿#pragma checksum "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2A5EA665FA95A32E68029B119A231CB90AFBD80273CFBCCD4CF8419C3A0F0486"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using ChronClient.GUI;
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


namespace ChronClient.GUI {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Chrome;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TitleBlock;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Controls;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Control_Minimize;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Control_Maximize;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse Control_Close;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Content;
        
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
            System.Uri resourceLocater = new System.Uri("/ChronClient;component/chronclient/temp/template/chronclient/gui/chronclient.gui." +
                    "mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
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
            this.Chrome = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.TitleBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Controls = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.Control_Minimize = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 19 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
            this.Control_Minimize.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Control_Minimize_MouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Control_Maximize = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 20 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
            this.Control_Maximize.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Control_Maximize_MouseUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Control_Close = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 21 "..\..\..\..\..\..\..\..\ChronClient\temp\template\ChronClient\GUI\ChronClient.GUI.MainWindow.xaml"
            this.Control_Close.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Control_Close_MouseUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Content = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

