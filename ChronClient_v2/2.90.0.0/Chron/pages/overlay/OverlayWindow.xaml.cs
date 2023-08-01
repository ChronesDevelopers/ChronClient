using ChronClient.Data;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaction logic for OverlayWindow.xaml
    /// </summary>
    public partial class OverlayWindow : Window
    {
        Win32.SimpleRECT rect = new Win32.SimpleRECT();
        DispatcherTimer SnapToWindowTimer;
        IntPtr Handle;

        public OverlayWindow()
        {
            InitializeComponent();

            #region SnapToWindowTimer
            SnapToWindowTimer = new DispatcherTimer();
            SnapToWindowTimer.Interval = TimeSpan.FromMilliseconds(20);
            SnapToWindowTimer.Tick += new EventHandler(SnapToWindowTimer_Tick);
            SnapToWindowTimer.Start();
            #endregion
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //Environment.Exit(0);
            e.Cancel = true;
            base.OnClosing(e);
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            this.Handle = new WindowInteropHelper(this).Handle;

            const int WS_EX_TRANSPARENT = 0x00000020;
            const int GWL_EXSTYLE = -20;

            int extendedSyle = Win32.GetWindowLong(this.Handle, GWL_EXSTYLE);
            Win32.SetWindowLong(this.Handle, GWL_EXSTYLE, extendedSyle | WS_EX_TRANSPARENT);
        }

        public void SnapToWindowTimer_Tick(object sender, EventArgs e)
        {
            if (GlobalData.OverlayWindow.ShowOverlay == true)
            {
                IntPtr targethandle = Win32.FindWindow(null, "Minecraft");
                Win32.GetWindowRect(targethandle, out rect);
                Win32.GetWindowRect(targethandle, out rect);
                this.Width = rect.right - rect.left;
                this.Height = rect.bottom - rect.top;
                this.Top = rect.top;
                this.Left = rect.left;

                IntPtr ForegroundWindowHandle = Win32.GetForegroundWindow();

                if (ForegroundWindowHandle == this.Handle)
                {
                    Win32.SetForegroundWindow(targethandle);
                    this.Show();
                    if (this.WindowState != WindowState.Normal)
                    {
                        this.WindowState = WindowState.Normal;
                    }
                }
                else if (ForegroundWindowHandle == targethandle)
                {
                    this.Show();
                    if (this.WindowState != WindowState.Normal)
                    {
                        this.WindowState = WindowState.Normal;
                    }
                }
                else
                {
                    if (this.WindowState != WindowState.Minimized)
                    {
                        this.WindowState = WindowState.Minimized;
                    }
                    this.Hide();
                }
            } else
            {
                this.Hide();
                if (this.WindowState != WindowState.Minimized)
                {
                    this.WindowState = WindowState.Minimized;
                }
            }
        }
    }
}
