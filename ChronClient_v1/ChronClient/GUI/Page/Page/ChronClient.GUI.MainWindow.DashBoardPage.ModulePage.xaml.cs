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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaction logic for ChronClient.xaml
    /// </summary>
    public partial class MainWindow_DashboardPage_ModulePage : Page
    {
        public MainWindow_DashboardPage_ModulePage()
        {
            InitializeComponent();
        }

        private void ContentShowerNavigationFrame_Navigated(object sender, NavigatingCancelEventArgs e)
        {
            var ta = new ThicknessAnimation();
            ta.Duration = TimeSpan.FromSeconds(1);
            QuadraticEase EasingFunction = new QuadraticEase();
            EasingFunction.EasingMode = EasingMode.EaseOut;
            ta.EasingFunction = EasingFunction;
            ta.DecelerationRatio = 0.7;
            ta.To = new Thickness(0, 0, 0, 0);
            if (e.NavigationMode == NavigationMode.New)
            {
                ta.From = new Thickness(0, 200, 0, 0);
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                ta.From = new Thickness(0, 0, 0, 200);
            }

            var ta2 = new DoubleAnimation();
            ta2.To = 1;
            ta2.From = 0;
            QuadraticEase EasingFunction2 = new QuadraticEase();
            EasingFunction2.EasingMode = EasingMode.EaseOut;
            ta.EasingFunction = EasingFunction2;
            //(e.Content as Page).BeginAnimation(MarginProperty, ta);
            ContentShowerNavigationFrame.BeginAnimation(MarginProperty, ta);
            ContentShowerNavigationFrame.BeginAnimation(OpacityProperty, ta2);
        }
    
        private void NavigateToMovement(object sender, EventArgs e)
        {
            ContentShowerNavigationFrame.Navigate(new ModulePages.ModulePage_MovementPage());
        }

        private void NavigateToCombat(object sender, EventArgs e)
        {
            ContentShowerNavigationFrame.Navigate(new ModulePages.ModulePage_CombatPage());
        }

        private void NavigateToPlayer(object sender, EventArgs e)
        {
            ContentShowerNavigationFrame.Navigate(new ModulePages.ModulePage_PlayerPage());
        }

        private void NavigateToWorld(object sender, EventArgs e)
        {
            ContentShowerNavigationFrame.Navigate(new ModulePages.ModulePage_WorldPage());
        }

        private void NavigateToTeleport(object sender, EventArgs e)
        {
            ContentShowerNavigationFrame.Navigate(new ModulePages.ModulePage_TeleportPage());
        }

        private void NavigateToOther(object sender, EventArgs e)
        {
            ContentShowerNavigationFrame.Navigate(new ModulePages.ModulePage_OtherPage());
        }
    }
}
