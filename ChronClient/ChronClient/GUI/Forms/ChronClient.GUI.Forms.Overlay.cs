using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chrones.Cmr.Imports;
using ChronClient.Data;
using System.Drawing.Drawing2D;
using System.Windows.Forms.Integration;

namespace ChronClient.GUI.Forms
{
    public partial class OldOverlay : Form
    {
        int InitialStyle;
        Import.SimpleRECT rect = new Import.SimpleRECT();

        Graphics g;

        

        public OldOverlay()
        {
            InitializeComponent();

            CommunicationData.Overlay.TargetWindowHandle = Import.FindWindow(null, C_Data.TargetWindowName);
            /*this.BackColor = Color.FromArgb(113, 20, 153);
            this.TransparencyKey = Color.FromArgb(113, 20, 153);*/
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            this.Update();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = true;
            this.TopMost = true;

            this.InitialStyle = Import.GetWindowLong(this.Handle, -20);
            Import.SetWindowLong(this.Handle, -20, InitialStyle | 0x80000 | 0x20);

            elementHost.Dock = DockStyle.Fill;
            GUI.Controls.Forms.OverlayUserControl overlayUserControl = new GUI.Controls.Forms.OverlayUserControl();
            overlayUserControl.InitializeComponent();
            elementHost.Child = overlayUserControl;

            this.Focus();
        }

        private void Timer_SnapToWindow_Tick(object sender, EventArgs e)
        {
            CommunicationData.Overlay.TargetWindowHandle = Import.FindWindow(null, C_Data.TargetWindowName);
            Import.GetWindowRect(CommunicationData.Overlay.TargetWindowHandle, out rect);
            this.Size = new Size(rect.right - rect.left, rect.bottom - rect.top);
            this.Top = rect.top;
            this.Left = rect.left;
            this.TopLevel = true;
            this.TopMost = true;

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

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            /*g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            Pen p;
            Brush b;
            StringFormat sf;
            SizeF sizef;
            Font f;

            f = new Font("Consolas", 30, FontStyle.Bold);   
            sf = new StringFormat();

            sizef = g.MeasureString("ChronClient", f);

            b = new SolidBrush(Color.FromArgb(0, 76, 152, 237));
            g.FillRectangle(b, 100, 100, sizef.Width, sizef.Height);

            p = new Pen(Color.FromArgb(30, 57, 87));
            p.Width = 5f;
            g.DrawRectangle(p, 100, 100, sizef.Width, sizef.Height);

            b = new SolidBrush(Color.FromArgb(0, 0, 0));
            g.DrawString("ChronClient", f, b, 100, 100);*/
        }
    }
}
