using Chrones.Cmr;
using System;
using System.Windows;
using System.Windows.Threading;
using ChronClient.Data;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Threading;
using System.Windows.Controls;

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer SlowUpdateGUI;


        public MainWindow()
        {
            InitializeComponent();

            #region Timer
            SlowUpdateGUI = new DispatcherTimer();
            SlowUpdateGUI.Interval = new TimeSpan(100);
            SlowUpdateGUI.Tick += SlowUpdateGUI_Tick;
            SlowUpdateGUI.Start();
            #endregion
        }

        private void Control_Close_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
            cmr.ExitApplication();
        }

        private void Control_Maximize_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            } else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Control_Minimize_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    
        private void SlowUpdateGUI_Tick(object sender, EventArgs e)
        {
            if (CommunicationData.MainWindow.WelcomeScreenAllowed)
            {
                DoubleAnimation db = new DoubleAnimation(1, new Duration(new TimeSpan(0, 0, 1)));
                this.Content.BeginAnimation(UIElement.OpacityProperty, db);
            }
        }

        private void NavigationFrame_Navigated(object sender, NavigatingCancelEventArgs e)
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
                ta.From = new Thickness(500, 0, 0, 0);
            }
            else if (e.NavigationMode == NavigationMode.Back)
            {
                ta.From = new Thickness(0, 0, 500, 0);
            }

            var ta2 = new DoubleAnimation();
            ta2.To = 1;
            ta2.From = 0;
            QuadraticEase EasingFunction2 = new QuadraticEase();
            EasingFunction2.EasingMode = EasingMode.EaseOut;
            ta.EasingFunction = EasingFunction2;
            //(e.Content as Page).BeginAnimation(MarginProperty, ta);
            NavigationFrame.BeginAnimation(MarginProperty, ta);
            NavigationFrame.BeginAnimation(OpacityProperty, ta2);
        }
    }
}
