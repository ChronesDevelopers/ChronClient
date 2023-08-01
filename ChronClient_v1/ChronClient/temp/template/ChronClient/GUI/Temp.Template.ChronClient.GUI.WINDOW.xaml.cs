using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class Template_Window : Window
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

        public Template_Window()
        {
            InitializeComponent();

            #region MaximizingFix
            SourceInitialized += (s, e) =>
            {
                WindowCompositionTarget = PresentationSource.FromVisual(this).CompositionTarget;
                HwndSource.FromHwnd(new WindowInteropHelper(this).Handle).AddHook(WindowProc);
            };
            #endregion
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
    }
}
