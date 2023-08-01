using ChronClient.Data;
using ChronClient.File;
using ChronClient.Instance;
using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChronClient.GUI.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        DispatcherTimer dispatcherTimer;
        public bool SettingsViewAnimate = false;

        public MainPage()
        {
            InitializeComponent();
            GlobalData.OverlayWindow.ShowOverlay = true;
            OnConstruct();
            OnConstruct2();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(30);
            dispatcherTimer.Start();
            Timer_Tick2(null, null);
            _Module.OnLoad();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ModuleButton_Airjump.Refresh();
            ModuleButton_AirWalk.Refresh();
            ModuleButton_Antivoid.Refresh();
            ModuleButton_BlockReach.Refresh();
            ModuleButton_ClickTp.Refresh();
            ModuleButton_CubecraftFly.Refresh();
            ModuleButton_CustomTime.Refresh();
            ModuleButton_DirectionalBoost.Refresh();
            ModuleButton_Fly.Refresh();
            ModuleButton_FreeView.Refresh();
            ModuleButton_Fullbright.Refresh();
            ModuleButton_Glide.Refresh();
            ModuleButton_Highjump.Refresh();
            ModuleButton_Hitbox.Refresh();
            ModuleButton_Instabreak.Refresh();
            ModuleButton_Jetpack.Refresh();
            ModuleButton_Killaura.Refresh();
            ModuleButton_LongJump.Refresh();
            ModuleButton_NoFall.Refresh();
            ModuleButton_NoHungerSlowDown.Refresh();
            ModuleButton_NoJumpDelay.Refresh();
            ModuleButton_NoKnockBack.Refresh();
            ModuleButton_NoSwing.Refresh();
            ModuleButton_NoWater.Refresh();
            ModuleButton_NoWeb.Refresh();
            ModuleButton_RapidHit.Refresh();
            ModuleButton_Reach.Refresh();
            ModuleButton_Reverse.Refresh();
            ModuleButton_Scaffold.Refresh();
            ModuleButton_Speed.Refresh();
            ModuleButton_SpeedFall.Refresh();
            ModuleButton_Step.Refresh();
            ModuleButton_TpAura.Refresh();
        }
        private void Timer_Tick2(object sender, EventArgs e)
        {
            Button_Toggle_OnTop.Refresh();
            Button_Toggle_AllowHideWindow.Refresh();
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            FullSettingsGrid.Visibility = Visibility.Visible;
        }
        private void WindowControl_Minimize_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FullSettingsGrid.Visibility = Visibility.Hidden;
        }
        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == CategoryButton0)
            {
                ModuleView.SelectedIndex = 0;
            }

            if (sender == CategoryButton1)
            {
                ModuleView.SelectedIndex = 1;
            }

            if (sender == CategoryButton2)
            {
                ModuleView.SelectedIndex = 2;
            }

            if (sender == CategoryButton3)
            {
                ModuleView.SelectedIndex = 3;
            }

            if (sender == CategoryButton4)
            {
                ModuleView.SelectedIndex = 4;
            }

            if (sender == CategoryButton5)
            {
                ModuleView.SelectedIndex = 5;
            }
        }
        private void CategoryButton_Settings_Click(object sender, RoutedEventArgs e)
        {
            MainPage_GUIEvents.CategoryButton_Settings_Click(sender, e, this);
        }
        private void ModuleButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage_GUIEvents.ModuleButton_Click(sender, e, this);
        }
        private void OnConstruct()
        {
            ModuleButton_Airjump.ModuleName = "Airjump";
            ModuleButton_Airjump.SetToggleState = Module.Airjump.Events.SetToggleState;
            ModuleButton_Airjump.GetToggleState = Module.Airjump.Events.GetToggleState;
            ModuleButton_Airjump.ToggleState = false;

            ModuleButton_AirWalk.ModuleName = "AirWalk";
            ModuleButton_AirWalk.SetToggleState = Module.AirWalk.Events.SetToggleState;
            ModuleButton_AirWalk.GetToggleState = Module.AirWalk.Events.GetToggleState;
            ModuleButton_AirWalk.ToggleState = false;

            ModuleButton_Antivoid.ModuleName = "Antivoid";
            ModuleButton_Antivoid.SetToggleState = Module.Antivoid.Events.SetToggleState;
            ModuleButton_Antivoid.GetToggleState = Module.Antivoid.Events.GetToggleState;
            ModuleButton_Antivoid.ToggleState = false;

            ModuleButton_BlockReach.ModuleName = "BlockReach";
            ModuleButton_BlockReach.SetToggleState = Module.BlockReach.Events.SetToggleState;
            ModuleButton_BlockReach.GetToggleState = Module.BlockReach.Events.GetToggleState;
            ModuleButton_BlockReach.ToggleState = false;

            ModuleButton_ClickTp.ModuleName = "ClickTp";
            ModuleButton_ClickTp.SetToggleState = Module.ClickTp.Events.SetToggleState;
            ModuleButton_ClickTp.GetToggleState = Module.ClickTp.Events.GetToggleState;
            ModuleButton_ClickTp.ToggleState = false;

            ModuleButton_CubecraftFly.ModuleName = "CubecraftFly";
            ModuleButton_CubecraftFly.SetToggleState = Module.CubecraftFly.Events.SetToggleState;
            ModuleButton_CubecraftFly.GetToggleState = Module.CubecraftFly.Events.GetToggleState;
            ModuleButton_CubecraftFly.ToggleState = false;
            
            ModuleButton_CustomTime.ModuleName = "CustomTime";
            ModuleButton_CustomTime.SetToggleState = Module.CustomTime.Events.SetToggleState;
            ModuleButton_CustomTime.GetToggleState = Module.CustomTime.Events.GetToggleState;
            ModuleButton_CustomTime.ToggleState = false;
            
            ModuleButton_DirectionalBoost.ModuleName = "DirectionalBoost";
            ModuleButton_DirectionalBoost.SetToggleState = Module.DirectionalBoost.Events.SetToggleState;
            ModuleButton_DirectionalBoost.GetToggleState = Module.DirectionalBoost.Events.GetToggleState;
            ModuleButton_DirectionalBoost.ToggleState = false;
           
            ModuleButton_Fly.ModuleName = "Fly";
            ModuleButton_Fly.SetToggleState = Module.Fly.Events.SetToggleState;
            ModuleButton_Fly.GetToggleState = Module.Fly.Events.GetToggleState;
            ModuleButton_Fly.ToggleState = false;

            ModuleButton_FreeView.ModuleName = "FreeView";
            ModuleButton_FreeView.SetToggleState = Module.FreeView.Events.SetToggleState;
            ModuleButton_FreeView.GetToggleState = Module.FreeView.Events.GetToggleState;
            ModuleButton_FreeView.ToggleState = false;

            ModuleButton_Fullbright.ModuleName = "Fullbright";
            ModuleButton_Fullbright.SetToggleState = Module.Fullbright.Events.SetToggleState;
            ModuleButton_Fullbright.GetToggleState = Module.Fullbright.Events.GetToggleState;
            ModuleButton_Fullbright.ToggleState = false;

            ModuleButton_Glide.ModuleName = "Glide";
            ModuleButton_Glide.SetToggleState = Module.Glide.Events.SetToggleState;
            ModuleButton_Glide.GetToggleState = Module.Glide.Events.GetToggleState;
            ModuleButton_Glide.ToggleState = false;

            ModuleButton_Highjump.ModuleName = "Highjump";
            ModuleButton_Highjump.SetToggleState = Module.Highjump.Events.SetToggleState;
            ModuleButton_Highjump.GetToggleState = Module.Highjump.Events.GetToggleState;
            ModuleButton_Highjump.ToggleState = false;

            ModuleButton_Hitbox.ModuleName = "Hitbox";
            ModuleButton_Hitbox.SetToggleState = Module.Hitbox.Events.SetToggleState;
            ModuleButton_Hitbox.GetToggleState = Module.Hitbox.Events.GetToggleState;
            ModuleButton_Hitbox.ToggleState = false;

            ModuleButton_Instabreak.ModuleName = "Instabreak";
            ModuleButton_Instabreak.SetToggleState = Module.Instabreak.Events.SetToggleState;
            ModuleButton_Instabreak.GetToggleState = Module.Instabreak.Events.GetToggleState;
            ModuleButton_Instabreak.ToggleState = false;

            ModuleButton_Jetpack.ModuleName = "Jetpack";
            ModuleButton_Jetpack.SetToggleState = Module.Jetpack.Events.SetToggleState;
            ModuleButton_Jetpack.GetToggleState = Module.Jetpack.Events.GetToggleState;
            ModuleButton_Jetpack.ToggleState = false;

            ModuleButton_Killaura.ModuleName = "Killaura";
            ModuleButton_Killaura.SetToggleState = Module.Killaura.Events.SetToggleState;
            ModuleButton_Killaura.GetToggleState = Module.Killaura.Events.GetToggleState;
            ModuleButton_Killaura.ToggleState = false;

            ModuleButton_LongJump.ModuleName = "LongJump";
            ModuleButton_LongJump.SetToggleState = Module.LongJump.Events.SetToggleState;
            ModuleButton_LongJump.GetToggleState = Module.LongJump.Events.GetToggleState;
            ModuleButton_LongJump.ToggleState = false;

            ModuleButton_NoFall.ModuleName = "NoFall";
            ModuleButton_NoFall.SetToggleState = Module.NoFall.Events.SetToggleState;
            ModuleButton_NoFall.GetToggleState = Module.NoFall.Events.GetToggleState;
            ModuleButton_NoFall.ToggleState = false;

            ModuleButton_NoHungerSlowDown.ModuleName = "NoHungerSlowDown";
            ModuleButton_NoHungerSlowDown.SetToggleState = Module.NoHungerSlowDown.Events.SetToggleState;
            ModuleButton_NoHungerSlowDown.GetToggleState = Module.NoHungerSlowDown.Events.GetToggleState;
            ModuleButton_NoHungerSlowDown.ToggleState = false;

            ModuleButton_NoJumpDelay.ModuleName = "NoJumpDelay";
            ModuleButton_NoJumpDelay.SetToggleState = Module.NoJumpDelay.Events.SetToggleState;
            ModuleButton_NoJumpDelay.GetToggleState = Module.NoJumpDelay.Events.GetToggleState;
            ModuleButton_NoJumpDelay.ToggleState = false;

            ModuleButton_NoKnockBack.ModuleName = "NoKnockBack";
            ModuleButton_NoKnockBack.SetToggleState = Module.NoKnockBack.Events.SetToggleState;
            ModuleButton_NoKnockBack.GetToggleState = Module.NoKnockBack.Events.GetToggleState;
            ModuleButton_NoKnockBack.ToggleState = false;

            ModuleButton_NoSwing.ModuleName = "NoSwing";
            ModuleButton_NoSwing.SetToggleState = Module.NoSwing.Events.SetToggleState;
            ModuleButton_NoSwing.GetToggleState = Module.NoSwing.Events.GetToggleState;
            ModuleButton_NoSwing.ToggleState = false;

            ModuleButton_NoWater.ModuleName = "NoWater";
            ModuleButton_NoWater.SetToggleState = Module.NoWater.Events.SetToggleState;
            ModuleButton_NoWater.GetToggleState = Module.NoWater.Events.GetToggleState;
            ModuleButton_NoWater.ToggleState = false;

            ModuleButton_NoWeb.ModuleName = "NoWeb";
            ModuleButton_NoWeb.SetToggleState = Module.NoWeb.Events.SetToggleState;
            ModuleButton_NoWeb.GetToggleState = Module.NoWeb.Events.GetToggleState;
            ModuleButton_NoWater.ToggleState = false;

            ModuleButton_RapidHit.ModuleName = "RapidHit";
            ModuleButton_RapidHit.SetToggleState = Module.RapidHit.Events.SetToggleState;
            ModuleButton_RapidHit.GetToggleState = Module.RapidHit.Events.GetToggleState;
            ModuleButton_RapidHit.ToggleState = false;

            ModuleButton_Reach.ModuleName = "Reach";
            ModuleButton_Reach.SetToggleState = Module.Reach.Events.SetToggleState;
            ModuleButton_Reach.GetToggleState = Module.Reach.Events.GetToggleState;
            ModuleButton_Reach.ToggleState = false;

            ModuleButton_Reverse.ModuleName = "Reverse";
            ModuleButton_Reverse.SetToggleState = Module.Reverse.Events.SetToggleState;
            ModuleButton_Reverse.GetToggleState = Module.Reverse.Events.GetToggleState;
            ModuleButton_Reverse.ToggleState = false;

            ModuleButton_Scaffold.ModuleName = "Scaffold";
            ModuleButton_Scaffold.SetToggleState = Module.Scaffold.Events.SetToggleState;
            ModuleButton_Scaffold.GetToggleState = Module.Scaffold.Events.GetToggleState;
            ModuleButton_Scaffold.ToggleState = false;

            ModuleButton_Speed.ModuleName = "Speed";
            ModuleButton_Speed.SetToggleState = Module.Speed.Events.SetToggleState;
            ModuleButton_Speed.GetToggleState = Module.Speed.Events.GetToggleState;
            ModuleButton_Speed.ToggleState = false;

            ModuleButton_SpeedFall.ModuleName = "SpeedFall";
            ModuleButton_SpeedFall.SetToggleState = Module.SpeedFall.Events.SetToggleState;
            ModuleButton_SpeedFall.GetToggleState = Module.SpeedFall.Events.GetToggleState;
            ModuleButton_SpeedFall.ToggleState = false;

            ModuleButton_Step.ModuleName = "Step";
            ModuleButton_Step.SetToggleState = Module.Step.Events.SetToggleState;
            ModuleButton_Step.GetToggleState = Module.Step.Events.GetToggleState;
            ModuleButton_Step.ToggleState = false;

            ModuleButton_TpAura.ModuleName = "TpAura";
            ModuleButton_TpAura.SetToggleState = Module.TpAura.Events.SetToggleState;
            ModuleButton_TpAura.GetToggleState = Module.TpAura.Events.GetToggleState;
            ModuleButton_TpAura.ToggleState = false;
        }
        private void OnConstruct2()
        {
            Button_Toggle_OnTop.ModuleName = "OnTop";
            Button_Toggle_OnTop.SetToggleState = _Module.OnTop.Events.SetToggleState;
            Button_Toggle_OnTop.GetToggleState = _Module.OnTop.Events.GetToggleState;
            Button_Toggle_OnTop.ToggleState = false;

            Button_Toggle_AllowHideWindow.ModuleName = "AllowHideWindow";
            Button_Toggle_AllowHideWindow.SetToggleState = _Module.AllowHideWindow.Events.SetToggleState;
            Button_Toggle_AllowHideWindow.GetToggleState = _Module.AllowHideWindow.Events.GetToggleState;
            Button_Toggle_AllowHideWindow.ToggleState = _Module.AllowHideWindow.ToggleState;
        }
        private void ModuleView_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        }
        private void SettingsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SettingsViewAnimate)
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
                SettingsView.BeginAnimation(MarginProperty, ta);
                SettingsView.BeginAnimation(OpacityProperty, ta2);
                SettingsViewAnimate = false;
            }
        }
        private void SettingsGrid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
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
            SettingsGrid.BeginAnimation(MarginProperty, ta);
            SettingsGrid.BeginAnimation(OpacityProperty, ta2);
            FullsettingsGrid_Background.BeginAnimation(OpacityProperty, ta2);
        }

        private void ApplyKeybindChanges_Click(object sender, RoutedEventArgs e)
        {
            MainPage_GUIEvents.UpdateKeybinds(sender, e, this);
        }
        private void GetMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.microsoft.com/dotnet/api/system.windows.input.key?view=netcore-3.1");
        }
        private void Button_Toggle_DiscordRPC_Click(object sender, RoutedEventArgs e)
        {
            if (!RuntimeSettings.Discord.UseDiscordRPC)
            {
                Button_Toggle_DiscordRPC.Content = "Disable Discord RPC";
                TextBlock_RestartChronClient_DiscordRPC.Visibility = Visibility.Visible;
                TextBlock_RestartChronClient_DiscordRPC.Text = "Enabled";
                TextBlock_RestartChronClient_DiscordRPC.Foreground = new SolidColorBrush(Colors.Lime);
                ChronClient.Discord.DiscordRPC.StartAsync();
                RuntimeSettings.Discord.UseDiscordRPC = true;


            } else
            {
                Button_Toggle_DiscordRPC.Content = "Enable Discord RPC";
                TextBlock_RestartChronClient_DiscordRPC.Visibility = Visibility.Visible;
                //TextBlock_RestartChronClient_DiscordRPC.Text = "Restart ChronClient to Disable";
                TextBlock_RestartChronClient_DiscordRPC.Text = "Disabled";
                TextBlock_RestartChronClient_DiscordRPC.Foreground = new SolidColorBrush(Colors.Red);
                ChronClient.Discord.DiscordRPC.Close();
                RuntimeSettings.Discord.UseDiscordRPC = false;
            }
        }

        private bool Test_001_IsProcessing = false;
        private async void Button_Test_001(object sender, RoutedEventArgs e)
        {
            if (Test_001_IsProcessing == false)
            {
                Test_001_IsProcessing = true;
                //File.ProfileClass profile = File.Profile.GetCurrentProfileClass();
                //string text = File.Profile.GetProfileInfo(profile);
                string text = File.Profile.GetCurrentProfileClassJson();
                System.Windows.Clipboard.SetText(text);
                MessageBox.Show(text);
                Test_001_IsProcessing = false;
            }
        }

        public static class _Module
        {
            public static void OnLoad()
            {
                _Module.HideWindow.OnLoad();
            }
            public static class OnTop
            {
                public static bool? _ToggleState = false;
                public static bool? ToggleState
                {
                    get
                    {
                        return _ToggleState;
                    }
                    set
                    {
                        if (value != _ToggleState)
                        {
                            if (value == true)
                            {
                                Events.OnEnable();
                            }
                            if (value == false || value == null)
                            {
                                Events.OnDisable();
                            }
                        }
                        _ToggleState = value;
                    }
                }

                public static class Events
                {
                    public static void OnEnable()
                    {
                        GlobalData.MainWindow.window.Topmost = true;
                    }
                    public static void OnDisable()
                    {
                        GlobalData.MainWindow.window.Topmost = false;
                    }
                    public static bool? GetToggleState()
                    {
                        return ToggleState;
                    }
                    public static void SetToggleState(bool? value)
                    {
                        ToggleState = value;
                    }
                }
            }
            public static class HideWindow
            {
                public static void OnLoad()
                {
                    if (ToggleKey != null)
                    {
                        Modules.KeyBindListener.RegisterKeyBind((Key)ToggleKey, Events.OnKeyPressed);
                    }
                }

                public static bool? _ToggleState = true;
                public static bool? ToggleState
                {
                    get
                    {
                        return _ToggleState;
                    }
                    set
                    {
                        bool Change = true;
                        if (value != _ToggleState)
                        {
                            if (value == true && AllowHideWindow.ToggleState == true)
                            {
                                Events.OnEnable();
                            }
                            if (value == true && AllowHideWindow.ToggleState == false)
                            {
                                Change = false;
                            }
                            if (value == false || value == null)
                            {
                                Events.OnDisable();
                            }
                        }
                        if (Change)
                        {
                            _ToggleState = value;
                        }
                    }
                }
                public static Key? ToggleKey = Key.RightShift;
                public static void RegisterKeybind_Toggle(Key? key)
                {
                    ToggleKey = key;
                    if (key != null)
                    {
                        Modules.KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressed);
                    }
                }

                public static class Events
                {
                    public static bool? GetToggleState()
                    {
                        return ToggleState;
                    }
                    public static void SetToggleState(bool? value)
                    {
                        ToggleState = value;
                    }
                    public static void OnEnable()
                    {
                        Win32.ShowWindow(GlobalData.MainWindow.windowHandle, 0); // SW_HIDE
                    }
                    public static void OnDisable()
                    {
                        Win32.ShowWindow(GlobalData.MainWindow.windowHandle, 5); // SW_SHOW
                        Win32.SetForegroundWindow(GlobalData.MainWindow.windowHandle);
                    }
                    public static void OnKeyPressed()
                    {
                        if (cmr_input.GetKeyStateDown(Key.LeftCtrl) && cmr_input.GetKeyStateDown(Key.LeftShift))
                        {
                            ToggleState = !ToggleState;
                        }
                    }
                }
            }
            public static class AllowHideWindow
            {
                public static bool? ToggleState = true;
                public static class Events
                {
                    public static bool? GetToggleState()
                    {
                        return ToggleState;
                    }
                    public static void SetToggleState(bool? value)
                    {
                        ToggleState = value;
                    }
                }
            }
        }
    }
}
