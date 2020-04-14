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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Chrones.Cmr.Color;

namespace ChronClient.GUI.Controls.Forms
{
    /// <summary>
    /// Interaktionslogik für ChronClient.xaml
    /// </summary>
    public partial class OverlayUserControl : UserControl
    {
        DispatcherTimer ColorRGBTimer;

        public OverlayUserControl()
        {
            InitializeComponent();

            ModuleList.Text = Modules.ModuleManagment.ModuleGUI.GetFullModuleString();
            if (ModuleList.Text.Length > 0)
            {
                if (ModuleList.Text[ModuleList.Text.Length - 1] == '\n')
                {
                    string ret = "";
                    for (int i = 0; i < (ModuleList.Text.Length - 1); i++)
                    {
                        ret += ModuleList.Text[i];
                    }
                    ModuleList.Text = ret;
                }
            }

            #region ColorRGBTimer
            ColorRGBTimer = new DispatcherTimer();
            ColorRGBTimer.Interval = TimeSpan.FromMilliseconds(10);
            ColorRGBTimer.Tick += new EventHandler(ColorRGBTimer_Tick);
            ColorRGBTimer.Start();
            #endregion
        }

        private void ColorRGBTimer_Tick(object sender, EventArgs e)
        {
            ModuleList.Text = Modules.ModuleManagment.ModuleGUI.GetFullModuleString();
            if (ModuleList.Text.Length > 0) 
            {
                if (ModuleList.Text[ModuleList.Text.Length - 1] == '\n')
                {
                    string ret = "";
                    for (int i = 0; i < (ModuleList.Text.Length - 1); i++)
                    {
                        ret += ModuleList.Text[i];
                    }
                    ModuleList.Text = ret;
                } 
            }

            Color color = cmr_color.WindowsCounterToColor(Data.CommunicationData.GUI.ColorRGBCounter);
            SolidColorBrush colorbrush = new SolidColorBrush(color);

            UpdateGUIColor(color, colorbrush);
        }

        public void UpdateGUIColor(Color color, SolidColorBrush colorbrush)
        {
            this.Border_Update_Color_9873.BorderBrush = colorbrush;
            this.TextBlock_Update_Color_8983.Foreground = colorbrush;
            this.ModuleList.Foreground = colorbrush;
            this.Border_Update_Color_4567.BorderBrush = colorbrush;
        }
    }
}
