#define IsChronPlus
//#undef IsChronPlus

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Chrones;

namespace ChronClient.GUI.OverlayThemes
{
    /// <summary>
    /// Interaction logic for Theme_Chronicel.xaml
    /// </summary>
    public partial class Theme_Chronicel : Page
    {
        DispatcherTimer rgbtimer { get; set; }
        TimeSpan rgbtimer_intervall { get; set; } = TimeSpan.FromMilliseconds(100);
        double rgbcounter { get; set; } = 0.0;
        double rgbcounterspeed { get; set; } = 10.0;

        public Theme_Chronicel()
        {
            InitializeComponent();

            rgbtimer = new DispatcherTimer();
            rgbtimer.Interval = rgbtimer_intervall;
            rgbtimer.Tick += rgbtimer_Tick;
            rgbtimer.Start();
        }

        ~Theme_Chronicel()
        {
            rgbtimer.Stop();
        }

        private void rgbtimer_Tick(object sender, EventArgs e)
        {
            rgbcounter += rgbcounterspeed;
            Math.Max(rgbcounter, 0);
            rgbcounter %= 1536;

            Color color = Cmr.Color.CounterToWPFColor(rgbcounter);
            SolidColorBrush colorbrush = new SolidColorBrush(color);

#if IsChronPlus
            Color color2 = Cmr.Color.CounterToWPFColor(rgbcounter + 100);
            Color color3 = Cmr.Color.CounterToWPFColor(rgbcounter + 200);

            LinearGradientBrush colorbrushtransitionH = new LinearGradientBrush();
            colorbrushtransitionH.StartPoint = new Point(0, 0);
            colorbrushtransitionH.EndPoint = new Point(1, 0);

            GradientStop GradientStop1 = new GradientStop();
            GradientStop1.Color = color;
            GradientStop1.Offset = 0.0;
            colorbrushtransitionH.GradientStops.Add(GradientStop1);

            GradientStop GradientStop2 = new GradientStop();
            GradientStop2.Color = color2;
            GradientStop2.Offset = 0.5;
            colorbrushtransitionH.GradientStops.Add(GradientStop2);

            GradientStop GradientStop3 = new GradientStop();
            GradientStop3.Color = color3;
            GradientStop3.Offset = 1.0;
            colorbrushtransitionH.GradientStops.Add(GradientStop3);

            LinearGradientBrush colorbrushtransitionV = new LinearGradientBrush();
            colorbrushtransitionV.StartPoint = new Point(0, 0);
            colorbrushtransitionV.EndPoint = new Point(0, 1);

            colorbrushtransitionV.GradientStops.Add(GradientStop1);
            colorbrushtransitionV.GradientStops.Add(GradientStop2);
            colorbrushtransitionV.GradientStops.Add(GradientStop3);

            UpdateGUIColor_ChronPlus(colorbrush, colorbrushtransitionH, colorbrushtransitionV);
#else
            UpdateGUIColor(colorbrush);
#endif
        }

        private void UpdateGUIColor_ChronPlus(SolidColorBrush colorbrush, LinearGradientBrush colorbrushtransitionH, LinearGradientBrush colorbrushtransitionV)
        {
            this.Border_Update_Color_9873.BorderBrush = colorbrushtransitionH;
            this.Border_Update_Color_9874.BorderBrush = colorbrushtransitionH;
            this.TextBlock_Update_Color_8983.Foreground = colorbrush;
            this.TextBlock_Update_Color_8985.Foreground = colorbrushtransitionV;
            this.ModuleList.Foreground = colorbrushtransitionH;
            this.Border_Update_Color_4567.BorderBrush = colorbrushtransitionV;
            this.TextBlock_Update_Color_8984.Foreground = colorbrushtransitionV;
        }

        private void UpdateGUIColor(SolidColorBrush colorbrush)
        {
            this.Border_Update_Color_9873.BorderBrush = colorbrush;
            this.Border_Update_Color_9874.BorderBrush = colorbrush;
            this.TextBlock_Update_Color_8983.Foreground = colorbrush;
            this.TextBlock_Update_Color_8985.Foreground = colorbrush;
            this.ModuleList.Foreground = colorbrush;
            this.Border_Update_Color_4567.BorderBrush = colorbrush;
            this.TextBlock_Update_Color_8984.Foreground = colorbrush;
        }
    }
}
