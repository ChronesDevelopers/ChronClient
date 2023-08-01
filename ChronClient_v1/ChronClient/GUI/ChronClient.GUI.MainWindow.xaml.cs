using Chrones.Cmr;
using System;
using System.Windows;
using System.Windows.Threading;
using ChronClient.Data;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using Chrones.Cmr.Win32API;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using Chrones.Cmr.Color;
using System.Reflection;

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

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

        public bool NavigateWithAnimationBool = true;

        public MainWindow()
        {
            InitializeComponent();

            CommunicationData.MainWindow.WindowObject = this;
            CommunicationData.MainWindow.WindowHandle = new WindowInteropHelper(this).Handle; ;

            #region MaximizingFix
            SourceInitialized += (s, e) =>
            {
                WindowCompositionTarget = PresentationSource.FromVisual(this).CompositionTarget;
                HwndSource.FromHwnd(new WindowInteropHelper(this).Handle).AddHook(WindowProc);
            };
            #endregion

            WelcomeScreen();     
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
            } else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Control_Minimize_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    
        public void WelcomeScreen()
        {
            DoubleAnimation db = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(2500)));
            this.Content.BeginAnimation(UIElement.OpacityProperty, db);
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
            } else 
            if (NavigateWithAnimationBool)
            {
                if (e.NavigationMode == NavigationMode.New)
                {
                    ta.From = new Thickness(0, 500, 0, 0);
                }
                else if (e.NavigationMode == NavigationMode.Back)
                {
                    ta.From = new Thickness(0, 0, 500, 0);
                }
            }

            var ta2 = new DoubleAnimation();
            ta2.To = 1;
            ta2.From = 0;
            QuadraticEase EasingFunction2 = new QuadraticEase();
            EasingFunction2.EasingMode = EasingMode.EaseOut;
            ta.EasingFunction = EasingFunction2;
            NavigateWithAnimationBool = false;
            //(e.Content as Page).BeginAnimation(MarginProperty, ta);
            NavigationFrame.BeginAnimation(MarginProperty, ta);
            NavigationFrame.BeginAnimation(OpacityProperty, ta2);
        }
    
        public void NavigateWithUpAnimation(object content)
        {
            NavigateWithAnimationBool = true;
            this.NavigationFrame.Navigate(content);
        }

        public void InvokeShow()
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => { this.Show(); }));
        }
    }
}
