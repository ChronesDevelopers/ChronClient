using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Chrones;

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaction logic for ChronDialog.xaml
    /// </summary>
    public partial class ChronDialog : Window
    {
        #region WINDOW
        bool IsClosing = false;
        bool CanClose = false;
        private void Window_StateChanged(object sender, EventArgs e)
        {
            this.WindowControlButton_Maximize_Refresh();
        }
        private void WindowControlButton_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void WindowControlButton_Maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void WindowControlButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void WindowControlButton_Maximize_Refresh()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                WindowBorderBorder.Visibility = Visibility.Hidden;
                this.WindowControlButton_Maximize.Visibility = Visibility.Collapsed;
                this.WindowControlButton_MaximizeRestore.Visibility = Visibility.Visible;
            }
            else
            {
                WindowBorderBorder.Visibility = Visibility.Visible;
                this.WindowControlButton_Maximize.Visibility = Visibility.Visible;
                this.WindowControlButton_MaximizeRestore.Visibility = Visibility.Collapsed;
            }
        }
        private void CONSTRUCT()
        {
            WindowControlButton_Maximize_Refresh();

            #region MaximizingFix
            SourceInitialized += (s, e) =>
            {
                WindowCompositionTarget = PresentationSource.FromVisual(this).CompositionTarget;
                System.Windows.Interop.HwndSource.FromHwnd(new System.Windows.Interop.WindowInteropHelper(this).Handle).AddHook(WindowProc);
            };
            #endregion
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CanClose == true)
            {
                return;
            }
            if (IsClosing == false)
            {
                var ta = new DoubleAnimation();
                ta.Duration = TimeSpan.FromSeconds(0.2);
                QuadraticEase EasingFunction = new QuadraticEase();
                EasingFunction.EasingMode = EasingMode.EaseOut;
                ta.EasingFunction = EasingFunction;
                ta.To = 0;
                ta.Completed += (object sender, EventArgs e) => { CanClose = true; this.Close(); };
                this.BeginAnimation(OpacityProperty, ta);
                IsClosing = true;
                e.Cancel = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #region MaximizingFix
        CompositionTarget WindowCompositionTarget { get; set; }

        double CachedMinWidth { get; set; }

        double CachedMinHeight { get; set; }

        Cmr.Win32.POINT CachedMinTrackSize { get; set; }

        IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    Cmr.Win32.MINMAXINFO mmi = (Cmr.Win32.MINMAXINFO)System.Runtime.InteropServices.Marshal.PtrToStructure(lParam, typeof(Cmr.Win32.MINMAXINFO));
                    IntPtr monitor = Cmr.Win32.MonitorFromWindow(hwnd, 0x00000002 /*MONITOR_DEFAULTTONEAREST*/);
                    if (monitor != IntPtr.Zero)
                    {
                        Cmr.Win32.MONITORINFO monitorInfo = new Cmr.Win32.MONITORINFO { };
                        Cmr.Win32.GetMonitorInfo(monitor, monitorInfo);
                        Cmr.Win32.RECT rcWorkArea = monitorInfo.rcWork;
                        Cmr.Win32.RECT rcMonitorArea = monitorInfo.rcMonitor;
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
                    System.Runtime.InteropServices.Marshal.StructureToPtr(mmi, lParam, true);
                    handled = true;
                    break;
            }
            return IntPtr.Zero;
        }
        #endregion

        #endregion WINDOW
        public ChronDialog()
        {
            InitializeComponent();
            CONSTRUCT();
        }
    }
}
