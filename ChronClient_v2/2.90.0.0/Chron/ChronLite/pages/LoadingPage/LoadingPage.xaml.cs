using ChronClient.Data;
using ChronClient.File;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace ChronClient.Lite.GUI.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoadingPage : Page
    {
        public LoadingPage()
        {
            InitializeComponent();
            GlobalData.OverlayWindow.ShowOverlay = false;
            if (!GlobalData.LoginPage.HasLoaded)
            {
                if (GlobalData.ChronLiteData.VERSIONTAGS != "stable")
                {
                    TextBlockVersion.Text += $" {GlobalData.ChronLiteData.VERSION} {GlobalData.ChronLiteData.VERSIONTAGS}";
                }
                else
                {
                    TextBlockVersion.Text += $" {GlobalData.ChronLiteData.VERSION}";
                }
            }
            if (GlobalData.ApplicationData.IsPackageMode)
            {
                RunAsAdminButton.Visibility = Visibility.Visible;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
            if (!GlobalData.LoginPage.HasLoaded)
            {
                LoadingAnimationGrid.Visibility = Visibility.Visible;
                OnCheckDataAccess();
            }
        }

        private async Task OnCheckDataAccess()
        {
            LoadingAnimationGrid_AnimationIn();
            await Task.Delay(500);
            await Task.Delay(300);
            LoadingAnimationGrid_AnimationOut();
            await Task.Delay(TimeSpan.FromSeconds(1));
            // Success
            GlobalData.ChronLiteData.MainPage = new ChronClient.Lite.GUI.Pages.ChronLiteMainPage();
            this.NavigationService.Navigate(GlobalData.ChronLiteData.MainPage);
        }

        private void LoadingAnimationGrid_AnimationIn()
        {
            if (LoadingAnimationGrid.Visibility == Visibility.Visible)
            {
                var ta = new ThicknessAnimation();
                ta.Duration = TimeSpan.FromSeconds(2);
                QuadraticEase EasingFunction = new QuadraticEase();
                EasingFunction.EasingMode = EasingMode.EaseOut;
                ta.EasingFunction = EasingFunction;
                ta.DecelerationRatio = 0.7;
                ta.To = new Thickness(0, 0, 0, 0);

                ta.From = new Thickness(0, 100, 0, -100);

                var ta2 = new DoubleAnimation();
                ta2.To = 1;
                ta2.From = 0;
                ta2.Duration = ta.Duration;
                QuadraticEase EasingFunction2 = new QuadraticEase();
                EasingFunction2.EasingMode = EasingMode.EaseOut;
                ta.EasingFunction = EasingFunction2;
                LoadingAnimationGrid.BeginAnimation(MarginProperty, ta);
                LoadingAnimationGrid.BeginAnimation(OpacityProperty, ta2);
            }
        }
        private void LoadingAnimationGrid_AnimationOut()
        {
            if (LoadingAnimationGrid.Visibility == Visibility.Visible)
            {
                var ta2 = new DoubleAnimation();
                ta2.To = 0;
                ta2.Duration = TimeSpan.FromSeconds(1);
                ta2.Completed += LoadingAnimationGrid_AnimationOut_Completed;
                LoadingAnimationGrid.BeginAnimation(OpacityProperty, ta2);
            }
        }
        private void LoadingAnimationGrid_AnimationOut_Completed(object sender, EventArgs e)
        {
            //LoadingAnimationGrid.Visibility = Visibility.Hidden;
            // Load new Page
        }
        private void ThereWasAnErrorGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ThereWasAnErrorGrid.Visibility == Visibility.Visible)
            {
                var ta = new ThicknessAnimation();
                ta.Duration = TimeSpan.FromSeconds(1);
                QuadraticEase EasingFunction = new QuadraticEase();
                EasingFunction.EasingMode = EasingMode.EaseOut;
                ta.EasingFunction = EasingFunction;
                ta.DecelerationRatio = 0.7;
                ta.To = new Thickness(0, 0, 0, 0);

                ta.From = new Thickness(0, 100, 0, -100);

                var ta2 = new DoubleAnimation();
                ta2.To = 1;
                ta2.From = 0;
                ta2.Duration = ta.Duration;
                QuadraticEase EasingFunction2 = new QuadraticEase();
                EasingFunction2.EasingMode = EasingMode.EaseOut;
                ta.EasingFunction = EasingFunction2;
                ThereWasAnErrorGrid.BeginAnimation(MarginProperty, ta);
                ThereWasAnErrorGrid.BeginAnimation(OpacityProperty, ta2);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void RunAsAdminButton_Click(object sender, RoutedEventArgs e)
        {
            //if (!GlobalData.ApplicationData.IsPackageMode)
            //{
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.FileName = System.Reflection.Assembly.GetEntryAssembly().Location;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.Verb = "runas";
            try
            {
                Process.Start(proc);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                if (ex.HResult == -2147467259)
                {
                    return;
                }
                else
                {
                    try
                    {
                        Environment.Exit(0);
                        GlobalData.MainWindow.window.Close();
                    }
                    catch
                    {
                        Environment.Exit(0);
                    }
                }
                return;
            }
            Environment.Exit(0);
            //Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location);
            //}
        }
    }
}
