using ChronClient.Data;
using Chrones.Cmr.Imports;
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
        Import.SimpleRECT rect = new Import.SimpleRECT();
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

            int extendedSyle = Import.GetWindowLong(this.Handle, GWL_EXSTYLE);
            Import.SetWindowLong(this.Handle, GWL_EXSTYLE, extendedSyle | WS_EX_TRANSPARENT);
        }

        public void SnapToWindowTimer_Tick(object sender, EventArgs e)
        {
            CommunicationData.Overlay.TargetWindowHandle = Import.FindWindow(null, C_Data.TargetWindowName);
            Import.GetWindowRect(CommunicationData.Overlay.TargetWindowHandle, out rect);
            Import.GetWindowRect(CommunicationData.Overlay.TargetWindowHandle, out rect);
            this.Width = rect.right - rect.left;
            this.Height = rect.bottom - rect.top;
            this.Top = rect.top;
            this.Left = rect.left;

            IntPtr ForegroundWindowHandle = Import.GetForegroundWindow();
            if (ForegroundWindowHandle == this.Handle)
            {
                Import.SetForegroundWindow(CommunicationData.Overlay.TargetWindowHandle);
                this.Show();
            }
            else if (ForegroundWindowHandle == CommunicationData.Overlay.TargetWindowHandle)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }
    }
}
