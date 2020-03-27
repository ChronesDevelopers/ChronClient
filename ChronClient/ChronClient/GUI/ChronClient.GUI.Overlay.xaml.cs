using ChronClient.Data;
using ChronClient.Input;
using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for COverlay.xaml
    /// </summary>
    public partial class Overlay : Window
    {
        Win32.SimpleRECT rect = new Win32.SimpleRECT();
        DispatcherTimer SnapToWindowTimer;

        IntPtr Handle;

        public Overlay()
        {
            InitializeComponent();

            #region SnapToWindowTimer
            SnapToWindowTimer = new DispatcherTimer();
            SnapToWindowTimer.Interval = TimeSpan.FromMilliseconds(10);
            SnapToWindowTimer.Tick += new EventHandler(SnapToWindowTimer_Tick);
            SnapToWindowTimer.Start();
            #endregion
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
            CommunicationData.Overlay.TargetWindowHandle = Win32.FindWindow(null, C_Data.TargetWindowName);
            Win32.GetWindowRect(CommunicationData.Overlay.TargetWindowHandle, out rect);
            Win32.GetWindowRect(CommunicationData.Overlay.TargetWindowHandle, out rect);
            this.Width = rect.right - rect.left;
            this.Height = rect.bottom - rect.top;
            this.Top = rect.top;
            this.Left = rect.left;

            IntPtr ForegroundWindowHandle = Win32.GetForegroundWindow();

            if (ForegroundWindowHandle == this.Handle)
            {
                Win32.SetForegroundWindow(CommunicationData.Overlay.TargetWindowHandle);
                this.Show();
            }
            else if (ForegroundWindowHandle == CommunicationData.Overlay.TargetWindowHandle)
            {  
                this.Show();
                if (CInput.GetKeyStateRightShiftPressed())
                {
                    if (cmr_input.GetKeyStateDown(Win32.VirtualKeys.Control))
                    {
                        Win32.SetForegroundWindow(CommunicationData.Console.Handle);
                    } else
                    {
                        Win32.SetForegroundWindow(Data.CommunicationData.MainWindow.WindowHandle);
                    }
                }
            }
            else if (ForegroundWindowHandle == CommunicationData.Console.Handle && CInput.GetKeyStateRightShiftPressed() && !cmr_input.GetKeyStateDown(Win32.VirtualKeys.Control))
            {
                Win32.SetForegroundWindow(CommunicationData.Overlay.TargetWindowHandle);
                this.Hide();
            }
            else
            {
                this.Hide();
            }
        }
    }
}
