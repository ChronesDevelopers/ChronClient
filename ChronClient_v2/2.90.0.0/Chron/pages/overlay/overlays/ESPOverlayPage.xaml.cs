using ChronClient.Data;
using Chrones.Cmr.Color;
using GlmNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaction logic for ESPOverlayPage.xaml
    /// </summary>
    public partial class ESPOverlayPage : Page
    {
        public DispatcherTimer timer;

        public ESPOverlayPage()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(GlobalData.OverlayWindow.DrawRefreshRate);
            timer.Tick += new EventHandler(ONRENDERTICK);
            //timer.Start();
        }

        public void ONRENDERTICK_V()
        {
            this.InvalidateVisual();
        }
        public void ONRENDERTICK(object sender, EventArgs e)
        {
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            //return;

            double width = this.ActualWidth;
            double height = this.ActualHeight;

            SolidColorBrush brush1 = new SolidColorBrush();
            brush1.Color = cmr_color.WindowsCounterToColor(Threads.ColorRGBUpdate.ColorRGBCounter);
            Pen p;

            p = new Pen(brush1, 1);
            dc.DrawLine(p, new Point { X = width / 2 - 100, Y = height / 2 - 300 }, new Point { X = width / 2, Y = height / 2 });

            mat4 viewmatrix = glm.perspective(100f, (float)(width / height), 0.1f, 100f);
            //dc.
        }
    }
}
