using ChronClient.Data;
using ChronClient.File;
using ChronClient.Instance;
using ChronClient.Modules;
using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChronClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool NavigateWithAnimationBool = true;

        #region MaximizingFix
        CompositionTarget WindowCompositionTarget { get; set; }

        double CachedMinWidth { get; set; }

        double CachedMinHeight { get; set; }

        Win32.POINT CachedMinTrackSize { get; set; }

        IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    Win32.MINMAXINFO mmi = (Win32.MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(Win32.MINMAXINFO));
                    IntPtr monitor = Win32.MonitorFromWindow(hwnd, 0x00000002 /*MONITOR_DEFAULTTONEAREST*/);
                    if (monitor != IntPtr.Zero)
                    {
                        Win32.MONITORINFO monitorInfo = new Win32.MONITORINFO { };
                        Win32.GetMonitorInfo(monitor, monitorInfo);
                        Win32.RECT rcWorkArea = monitorInfo.rcWork;
                        Win32.RECT rcMonitorArea = monitorInfo.rcMonitor;
                        mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                        mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                        mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                        mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
                        if (!CachedMinTrackSize.Equals(mmi.ptMinTrackSize) || CachedMinHeight != MinHeight && CachedMinWidth != MinWidth)
                        {
                            mmi.ptMinTrackSize.x = (int)((CachedMinWidth = MinWidth) * WindowCompositionTarget.TransformToDevice.M11);
                            mmi.ptMinTrackSize.y = (int)((CachedMinHeight = MinHeight) * WindowCompositionTarget.TransformToDevice.M22);
                            CachedMinTrackSize = mmi.ptMinTrackSize;
                        }
                    }
                    Marshal.StructureToPtr(mmi, lParam, true);
                    handled = true;
                    break;
            }
            return IntPtr.Zero;
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            if (GlobalData.ApplicationData.IsChronLite && GlobalData.ApplicationData.UseDefaultIcon)
            {
                this.Icon = null;
            }

            #region MaximizingFix
            SourceInitialized += (s, e) =>
            {
                WindowCompositionTarget = PresentationSource.FromVisual(this).CompositionTarget;
                HwndSource.FromHwnd(new WindowInteropHelper(this).Handle).AddHook(WindowProc);
            };
            #endregion

            if (!GlobalData.ApplicationData.IsChronLite)
            {
                #region Chron
                Data.GlobalData.MainWindow.window = this;

                if (GlobalData.ApplicationData.IsPlusVersion)
                {
                    this.Title = "ChronClient⧫ v2";
                    this.TITLE.Text = @$"ChronClient⧫ v{GlobalData.ApplicationData.VERSION}";
                }
                else
                {
                    this.Title = "ChronClient v2";
                    this.TITLE.Text = @$"ChronClient v{GlobalData.ApplicationData.VERSION}";
                }

                if (GlobalData.ApplicationData.LaunchMinecraftWhenLoading)
                {
                    Process.Start("minecraft://");
                }

                OnLoad.Start();
                Threads.Threads.Start();

                Data.GlobalData.OverlayWindow.overlay = new GUI.OverlayWindow();
                Data.GlobalData.OverlayWindow.overlay.Show();
                #endregion

                return;
            }
            else
            {
                #region ChronLite
                Data.GlobalData.MainWindow.window = this;

                GlobalData.ChronLiteData.LoadingPage = new ChronClient.Lite.GUI.Pages.LoadingPage();
                this.NavigationFrame.Navigate(GlobalData.ChronLiteData.LoadingPage);

                if (GlobalData.ApplicationData.IsPlusVersion)
                {
                    this.Title = "ChronClient⧫ Lite";
                    this.TITLE.Text = @$"ChronClient⧫ Lite v{GlobalData.ChronLiteData.VERSION}";
                }
                else
                {
                    this.Title = "ChronClient Lite";
                    this.TITLE.Text = @$"ChronClient Lite v{GlobalData.ApplicationData.VERSION}";
                }

                if (GlobalData.ApplicationData.LaunchMinecraftWhenLoading)
                {
                    Process.Start("minecraft://");
                }

                ChronClient.Lite.Modules.OnLoad.Start();
                Threads.Threads.StartLite();
                #endregion

                return;
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
            base.OnClosing(e);
        }
        private void Control_Close_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
            cmr.ExitApplication();
        }
        private void Control_Maximize_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void Control_Minimize_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void NavigationFrame_Navigated(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(1);
            QuadraticEase EasingFunction = new QuadraticEase();
            EasingFunction.EasingMode = EasingMode.EaseOut;
            ta.EasingFunction = EasingFunction;
            ta.DecelerationRatio = 0.7;
            ta.To = new Thickness(0, 0, 0, 0);

            if (NavigateWithAnimationBool)
            {
                if (e.NavigationMode == NavigationMode.New)
                {
                    ta.From = new Thickness(0, 200, 0, -200);
                }
                else if (e.NavigationMode == NavigationMode.Back)
                {
                    ta.From = new Thickness(-200, 0, 200, 0);
                }
            }
            else
            if (!NavigateWithAnimationBool)
            {
                if (e.NavigationMode == NavigationMode.New)
                {
                    ta.From = new Thickness(0, 0, 0, 0);
                }
                else if (e.NavigationMode == NavigationMode.Back)
                {
                    ta.From = new Thickness(0, 0, 0, 0);
                }
            }

            var ta2 = new DoubleAnimation();
            ta2.To = 1;
            ta2.From = 0;
            ta2.Duration = ta.Duration;
            QuadraticEase EasingFunction2 = new QuadraticEase();
            EasingFunction2.EasingMode = EasingMode.EaseOut;
            ta.EasingFunction = EasingFunction2;
            NavigateWithAnimationBool = true;
            //(e.Content as Page).BeginAnimation(MarginProperty, ta);
            NavigationFrame.BeginAnimation(MarginProperty, ta);
            NavigationFrame.BeginAnimation(OpacityProperty, ta2);
        }
        public void NavigateWithUpAnimation(object content)
        {
            NavigateWithAnimationBool = true;
            this.NavigationFrame.Navigate(content);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GlobalData.MainWindow.windowHandle = Process.GetCurrentProcess().MainWindowHandle;
        }
    }
}
