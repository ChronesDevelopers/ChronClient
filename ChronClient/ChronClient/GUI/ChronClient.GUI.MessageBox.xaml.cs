using Chrones.Cmr;
using Chrones.Cmr.Imports;
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
    public partial class C_MessageBox : Window
    {
        #region MaximizingFix
        CompositionTarget WindowCompositionTarget { get; set; }

        double CachedMinWidth { get; set; }

        double CachedMinHeight { get; set; }

        Import.POINT CachedMinTrackSize { get; set; }

        IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    Import.MINMAXINFO mmi = (Import.MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(Import.MINMAXINFO));
                    IntPtr monitor = Import.MonitorFromWindow(hwnd, 0x00000002 /*MONITOR_DEFAULTTONEAREST*/);
                    if (monitor != IntPtr.Zero)
                    {
                        Import.MONITORINFO monitorInfo = new Import.MONITORINFO { };
                        Import.GetMonitorInfo(monitor, monitorInfo);
                        Import.RECT rcWorkArea = monitorInfo.rcWork;
                        Import.RECT rcMonitorArea = monitorInfo.rcMonitor;
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

        public C_MessageBox(string TextMessageA, string TitleA, string Option1, string Option2, RoutedEventHandler Option1OnClick, RoutedEventHandler Option2OnClick)
        {
            InitializeComponent();
            if (TextMessageA != null)
            {
                this.TEXT.Text = TextMessageA;
            } else
            {
                this.TEXT.Text = "";
            }

            if (TitleA != null)
            {
                this.Title = TitleA;
                this.TitleBlock.Text = TitleA;
            } else
            {
                this.Title = "";
                this.TitleBlock.Text = "";
            }

            if (Option1 != null)
            {
                this.Option1.Content = Option1;
            } else
            {
                this.Option1.Content = "";
            }

            if (Option2 != null)
            {
                this.Option2.Content = Option2;
            } else
            {
                this.Option2.Content = "";
            }

            if (Option1OnClick != null)
            {
                this.Option1.Click += Option1OnClick;
            }

            if (Option2OnClick != null)
            {
                this.Option1.Click += Option2OnClick;
            }

            #region MaximizingFix
            SourceInitialized += (s, e) =>
            {
                WindowCompositionTarget = PresentationSource.FromVisual(this).CompositionTarget;
                HwndSource.FromHwnd(new WindowInteropHelper(this).Handle).AddHook(WindowProc);
            };
            #endregion

            this.Show();
        }

        public string TextMessage
        {
            get { return TEXT.Text; }
            set { TEXT.Text = TextMessage; }
        }

        private void Control_Close_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
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
        
        public void _CLOSE()
        {
            this.Close();
        }
    }
}
