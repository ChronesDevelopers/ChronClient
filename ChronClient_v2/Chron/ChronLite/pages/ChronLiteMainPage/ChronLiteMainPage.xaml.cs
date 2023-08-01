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
using System.Windows.Threading;

namespace ChronClient.Lite.GUI.Pages
{
    /// <summary>
    /// Interaction logic for ChronLiteMainPage.xaml
    /// </summary>
    public partial class ChronLiteMainPage : Page
    {
        DispatcherTimer dispatcherTimer;
        bool AnimateModuleView = false;

        public ChronLiteMainPage()
        {
            AnimateModuleView = true;
            InitializeComponent();

            OnConstruct();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(30);
            dispatcherTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ModuleButton_AutoClicker.Refresh();
            ModuleButton_KnockbackModifier.Refresh();
            ModuleButton_Reach.Refresh();
        }
        private void OnConstruct()
        {
            ModuleButton_AutoClicker.ModuleName = "AutoClicker";
            ModuleButton_AutoClicker.SetToggleState = Module.AutoClicker.Events.SetToggleState;
            ModuleButton_AutoClicker.GetToggleState = Module.AutoClicker.Events.GetToggleState;
            ModuleButton_AutoClicker.ToggleState = false;

            ModuleButton_KnockbackModifier.ModuleName = "KnockbackModifier";
            ModuleButton_KnockbackModifier.SetToggleState = Module.KnockbackModifier.Events.SetToggleState;
            ModuleButton_KnockbackModifier.GetToggleState = Module.KnockbackModifier.Events.GetToggleState;
            ModuleButton_KnockbackModifier.ToggleState = false;

            ModuleButton_Reach.ModuleName = "Reach";
            ModuleButton_Reach.SetToggleState = Module.Reach.Events.SetToggleState;
            ModuleButton_Reach.GetToggleState = Module.Reach.Events.GetToggleState;
            ModuleButton_Reach.ToggleState = false;
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == CategoryButton0)
            {
                AnimateModuleView = true;
                ModuleView.SelectedIndex = 0;
            }

            if (sender == CategoryButton1)
            {
                AnimateModuleView = true;
                ModuleView.SelectedIndex = 1;
            }

            if (sender == CategoryButton2)
            {
                AnimateModuleView = true;
                ModuleView.SelectedIndex = 2;
            }

            if (sender == CategoryButton3)
            {
                AnimateModuleView = true;
                ModuleView.SelectedIndex = 3;
            }

            if (sender == CategoryButton4)
            {
                AnimateModuleView = true;
                ModuleView.SelectedIndex = 4;
            }
        }
        private void ModuleView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnimateModuleView)
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
                ModuleView.BeginAnimation(MarginProperty, ta);
                ModuleView.BeginAnimation(OpacityProperty, ta2);
                AnimateModuleView = false;
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender == this.ReachSlider)
            {
                string NewText = "Reach: ";
                try
                {
                    NewText += Convert.ToString(Math.Round(ReachSlider.Value / 100, 2));
                }
                catch
                {
                    NewText = "(err)";
                }
                ReachText.Text = NewText;
                return;
            }
            if (sender == this.KnockbackModifierHorizontalSlider)
            {
                string NewText = "Horizontal KB: ";
                try
                {
                    NewText += Convert.ToString(Math.Round(KnockbackModifierHorizontalSlider.Value / 100, 2));
                }
                catch
                {
                    NewText = "(err)";
                }
                KnockbackModifierHorizontalText.Text = NewText;
                return;
            }
            if (sender == this.KnockbackModifierVerticalSlider)
            {
                string NewText = "Vertical KB: ";
                try
                {
                    NewText += Convert.ToString(Math.Round(KnockbackModifierVerticalSlider.Value / 100, 2));
                }
                catch
                {
                    NewText = "(err)";
                }
                KnockbackModifierVerticalText.Text = NewText;
                return;
            }
            if (sender == this.AutoClickerCPSMinSlider)
            {
                if (this.AutoClickerCPSMinSlider != null && this.AutoClickerCPSMaxSlider != null)
                {
                    if (AutoClickerCPSMinSlider.Value > AutoClickerCPSMaxSlider.Value)
                    {
                        AutoClickerCPSMaxSlider.Value = AutoClickerCPSMinSlider.Value;
                    }
                    string NewText = "CPS Min: ";
                    try
                    {
                        NewText += Convert.ToString(Math.Round(AutoClickerCPSMinSlider.Value, 0));
                        Module.AutoClicker.CPS_L_Min = Convert.ToInt32(AutoClickerCPSMinSlider.Value);
                    }
                    catch
                    {
                        NewText = "(err)";
                    }
                    AutoClickerCPSMinText.Text = NewText;
                    return;
                }
            }
            if (sender == this.AutoClickerCPSMaxSlider)
            {
                if (this.AutoClickerCPSMinSlider != null && this.AutoClickerCPSMaxSlider != null)
                {
                    if (AutoClickerCPSMaxSlider.Value < AutoClickerCPSMinSlider.Value)
                    {
                        AutoClickerCPSMinSlider.Value = AutoClickerCPSMaxSlider.Value;
                    }
                    string NewText = "CPS Max: ";
                    try
                    {
                        NewText += Convert.ToString(Math.Round(AutoClickerCPSMaxSlider.Value, 0));
                        Module.AutoClicker.CPS_L_Max = Convert.ToInt32(AutoClickerCPSMaxSlider.Value);
                    }
                    catch
                    {
                        NewText = "(err)";
                    }
                    AutoClickerCPSMaxText.Text = NewText;
                    return;
                }
            }
        }

        private void KnockbackModifierComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (KnockbackModifier_Section_0 != null)
            {
                if (KnockbackModifierComboBox.SelectedIndex == 0)
                    KnockbackModifier_Section_0.Visibility = Visibility.Visible;
                if (KnockbackModifierComboBox.SelectedIndex == 1)
                    KnockbackModifier_Section_0.Visibility = Visibility.Collapsed;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (discordrpc != null)
            {
                if (discordrpc.IsChecked == true)
                {
                    ChronClient.Discord.DiscordRPC.StartAsync();
                }
                if (discordrpc.IsChecked == false)
                {
                    ChronClient.Discord.DiscordRPC.Close();
                }
            }
        }
    }
}
