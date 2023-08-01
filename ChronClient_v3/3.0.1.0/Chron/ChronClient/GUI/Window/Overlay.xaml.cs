using ChronClient.Data;
using Chrones;
using System;
using System.Collections.Generic;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChronClient.GUI
{
    public partial class Overlay : Window
    {
        public IntPtr Handle { get; set; } 
        public DispatcherTimer timer { get; set; }
        public Overlay()
        {
            InitializeComponent();

            GlobalData.Overlay.WindowHandle = new WindowInteropHelper(this).Handle;
            timer = new DispatcherTimer();
            timer.Interval = GlobalData.Overlay.TimerInterval;
            timer.Tick += Timer_Tick;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Handle = new WindowInteropHelper(this).Handle;
            OverlayLoad();
            timer.Start();
        }
        public void OverlayLoad()
        {
            GlobalData.Themes.Overlay.SetCurrentPage(new ChronClient.GUI.OverlayThemes.Theme_Chronicel());
            GlobalData.Themes.ClickGUI.SetCurrentPage(new ChronClient.GUI.ClickGUIThemes.Theme_ClickGUI_Fluent());
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            GlobalData.Overlay.WindowHandle = new WindowInteropHelper(this).Handle;
            SetWindowTransparent();
        }
        public void SetWindowTransparent()
        {
            const int WS_EX_TRANSPARENT = 0x00000020;
            const int GWL_EXSTYLE = -20;

            int extendedStyle = Cmr.Win32.GetWindowLong(GlobalData.Overlay.WindowHandle, GWL_EXSTYLE);
            Cmr.Win32.SetWindowLong(GlobalData.Overlay.WindowHandle, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        }
        public void SetWindowNormal()
        {
            const int WS_EX_TRANSPARENT = 0x00000020;
            const int GWL_EXSTYLE = -20;

            int extendedStyle = Cmr.Win32.GetWindowLong(GlobalData.Overlay.WindowHandle, GWL_EXSTYLE);
            Cmr.Win32.SetWindowLong(GlobalData.Overlay.WindowHandle, GWL_EXSTYLE, extendedStyle & ~WS_EX_TRANSPARENT);
        }
        bool LastState { get; set; } = false;
        private void Timer_Tick(object sender, EventArgs e)
        {
            bool State = Cmr.Input.IsKeyDown(Cmr.Input.VK.INSERT);
            if (LastState == false && State == true)
            {
                LastState = true;
                if (GlobalData.Overlay.Mode == GlobalData.Overlay.OverlayMode.Normal)
                {
                    GlobalData.Overlay.Mode = GlobalData.Overlay.OverlayMode.ClickGUI;
                    SetWindowNormal();
                    SetOverlayMode(OverlayMode.ClickGUI);
                }
                else if (GlobalData.Overlay.Mode == GlobalData.Overlay.OverlayMode.ClickGUI)
                {
                    GlobalData.Overlay.Mode = GlobalData.Overlay.OverlayMode.Normal;
                    SetWindowTransparent();
                    SetOverlayMode(OverlayMode.Normal);
                }
            }
            else
            {
                LastState = State;
            }
            if (GlobalData.Overlay.Mode == GlobalData.Overlay.OverlayMode.ClickGUI)
            {
                if (Cmr.Input.IsKeyDown(Cmr.Input.VK.ESCAPE))
                {
                    GlobalData.Overlay.Mode = GlobalData.Overlay.OverlayMode.Normal;
                    SetWindowTransparent();
                    SetOverlayMode(OverlayMode.Normal);
                }
            }
            if (GlobalData.Overlay.Mode != GlobalData.Overlay.OverlayMode.None)
            {
                GlobalData.Minecraft.WindowHandle = Cmr.Win32.FindWindow(null, GlobalData.Minecraft.WindowName);
                IntPtr foregroundHandle = Cmr.Win32.GetForegroundWindow();
                if (GlobalData.Overlay.Mode == GlobalData.Overlay.OverlayMode.Normal)
                {
                    if (foregroundHandle == GlobalData.Minecraft.WindowHandle)
                    {
                        this.Show();
                        if (this.WindowState != WindowState.Normal)
                        {
                            this.WindowState = WindowState.Normal;
                        }
                        RepositionToWindow(GlobalData.Minecraft.WindowHandle);
                    }
                    else if (foregroundHandle == GlobalData.Overlay.WindowHandle)
                    {
                        this.Show();
                        if (this.WindowState != WindowState.Normal)
                        {
                            this.WindowState = WindowState.Normal;
                        }
                        Cmr.Win32.SetForegroundWindow(GlobalData.Minecraft.WindowHandle);
                        RepositionToWindow(GlobalData.Minecraft.WindowHandle);
                    }
                    else
                    {
                        if (this.WindowState != WindowState.Minimized)
                        {
                            this.WindowState = WindowState.Minimized;
                        }
                        this.Hide();
                    }
                }
                else if (GlobalData.Overlay.Mode == GlobalData.Overlay.OverlayMode.ClickGUI)
                {
                    if (foregroundHandle == GlobalData.Minecraft.WindowHandle)
                    {
                        this.Show();
                        if (this.WindowState != WindowState.Normal)
                        {
                            this.WindowState = WindowState.Normal;
                        }

                        Cmr.Win32.SetForegroundWindow(GlobalData.Overlay.WindowHandle); // Crash ?
                                                               //this.Activate();
                                                               //this.Focus();
                        RepositionToWindow(GlobalData.Minecraft.WindowHandle);
                    }
                    else if (foregroundHandle == GlobalData.Overlay.WindowHandle)
                    {
                        this.Show();
                        if (this.WindowState != WindowState.Normal)
                        {
                            this.WindowState = WindowState.Normal;
                        }
                        RepositionToWindow(GlobalData.Minecraft.WindowHandle);
                    }
                    else
                    {
                        if (this.WindowState != WindowState.Minimized)
                        {
                            this.WindowState = WindowState.Minimized;
                        }
                        this.Hide();
                    }
                }
            }
            else
            {
                if (this.WindowState != WindowState.Minimized)
                {
                    this.WindowState = WindowState.Minimized;
                }
                this.Hide();
            }
        }
        public void RepositionToWindow(IntPtr handle)
        {
            Cmr.Win32.SimpleRECT rect = new Cmr.Win32.SimpleRECT();
            Cmr.Win32.GetWindowRect(handle, out rect);
            this.Width = rect.right - rect.left;
            this.Height = rect.bottom - rect.top;
            this.Top = rect.top;
            this.Left = rect.left;
        }
        public void SetOverlayMode(OverlayMode mode)
        {
            var EaseMode = new QuarticEase();
            EaseMode.EasingMode = EasingMode.EaseInOut;
            if (mode == OverlayMode.ClickGUI)
            {
                if (!this.HasClickGUI())
                {
                    if (this.HasOverlay())
                    {
                        GlobalData.Overlay.Mode = GlobalData.Overlay.OverlayMode.Normal;
                    }
                    else
                    {
                        GlobalData.Overlay.Mode = GlobalData.Overlay.OverlayMode.None;
                    }
                    return;
                }
                var OpacityAnimation = new DoubleAnimation();
                OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
                OpacityAnimation.EasingFunction = EaseMode;
                OpacityAnimation.To = 1;
                //OpacityAnimation.From = 0;

                var OpacityAnimation2 = new DoubleAnimation();
                OpacityAnimation2.Duration = TimeSpan.FromSeconds(0.2);
                OpacityAnimation.EasingFunction = EaseMode;
                OpacityAnimation2.To = 0;
                //OpacityAnimation2.From = 1;

                ClickGUINavigationFrame.BeginAnimation(OpacityProperty, OpacityAnimation);
                OverlayNavigationFrame.BeginAnimation(OpacityProperty, OpacityAnimation2);
            } else
            if (mode == OverlayMode.Normal)
            {
                if (!this.HasOverlay())
                {
                    if (this.HasClickGUI())
                    {
                        GlobalData.Overlay.Mode = GlobalData.Overlay.OverlayMode.ClickGUI;
                    } else
                    {
                        GlobalData.Overlay.Mode = GlobalData.Overlay.OverlayMode.None;
                    }
                    return;
                }
                var OpacityAnimation = new DoubleAnimation();
                OpacityAnimation.Duration = TimeSpan.FromSeconds(0.5);
                //OpacityAnimation.EasingFunction;
                OpacityAnimation.To = 1;
                //OpacityAnimation.From = 0;

                var OpacityAnimation2 = new DoubleAnimation();
                OpacityAnimation2.Duration = TimeSpan.FromSeconds(0.2);
                //OpacityAnimation.EasingFunction;
                OpacityAnimation2.To = 0;
                //OpacityAnimation2.From = 1;

                ClickGUINavigationFrame.BeginAnimation(OpacityProperty, OpacityAnimation2);
                OverlayNavigationFrame.BeginAnimation(OpacityProperty, OpacityAnimation);
            }
        }
        public bool HasOverlay()
        {
            return (this.OverlayNavigationFrame.NavigationService.Content != null);
        }
        public bool HasClickGUI()
        {
            return (this.ClickGUINavigationFrame.NavigationService.Content != null);
        }
        public enum OverlayMode
        {
            Normal,
            ClickGUI
        }
    }
}
