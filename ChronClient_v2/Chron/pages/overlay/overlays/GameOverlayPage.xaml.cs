using ChronClient.Data;
using ChronClient.GUI.Themes;
using Chrones.Cmr.Color;
using MaterialDesignThemes.Wpf;
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

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaction logic for GameOverlayPage.xaml
    /// </summary>
    public partial class GameOverlayPage : Page
    {
        DispatcherTimer RefreshTimer;

        public GameOverlayPage()
        {
            InitializeComponent();

            #region RefreshTimer
            RefreshTimer = new DispatcherTimer();
            RefreshTimer.Interval = TimeSpan.FromMilliseconds(GlobalData.OverlayWindow.RefreshRate);
            RefreshTimer.Tick += new EventHandler(Refresh);
            RefreshTimer.Start();
            #endregion
        }

        public void Refresh(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Visible;
            if (theme.GetType() == typeof(Theme_Darki))
            {
                theme.Refresh();
            } else
            if (theme.GetType() == typeof(Theme_Matrix))
            {
                theme.Refresh();
            } else
            if (theme.GetType() == typeof(Theme_Clear))
            {
                theme.Refresh();
            }
            /* */
        }
    }
}
