using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaktionslogik für ChronClient.xaml
    /// </summary>
    public partial class MainWindow_DashboardPage : Page
    {
        public bool NavigateWithAnimationBool = true;

        public MainWindow_DashboardPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Thread t1 = new Thread(Open100BrowserTabs);
            //t1.Start();
            Data.CommunicationData.MainWindow.WindowObject.NavigateWithAnimationBool = true;
            this.NavigationService.Navigate(new MainWindow_WelcomePage());
        }

        private void Open100BrowserTabs()
        {
            for (int i = 0; i < 50; i++)
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCf37yIqWXfiXspKivc1X_Ow");
            }
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
                ta.From = new Thickness(0, 300, 0, 0);
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                ta.From = new Thickness(0, 0, 0, 300);
            }

            var ta2 = new DoubleAnimation();
            ta2.To = 1;
            ta2.From = 0;
            QuadraticEase EasingFunction2 = new QuadraticEase();
            EasingFunction2.EasingMode = EasingMode.EaseOut;
            ta.EasingFunction = EasingFunction2;
            //(e.Content as Page).BeginAnimation(MarginProperty, ta);
            ContentShowerNavigationFrame.BeginAnimation(OpacityProperty, ta2);

            if (NavigateWithAnimationBool)
            {
                ContentShowerNavigationFrame.BeginAnimation(MarginProperty, ta);
            }

            NavigateWithAnimationBool = true;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ContentShowerNavigationFrame.Navigate(new MainWindow_DashboardPage_SettingsPage());
        }

        private void ModuleButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateWithAnimationBool = false;
            ContentShowerNavigationFrame.Navigate(new MainWindow_DashboardPage_ModulePage());
        }
    }
}
