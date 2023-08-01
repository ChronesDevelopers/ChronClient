using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ChronClient.Controls
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class ModuleButtonToggleControl : UserControl
    {
        public delegate void OnClickEvent();
        public delegate bool? GetToggleStateEvent();
        public delegate void SetToggleStateEvent(bool? _ToggleState);
        public delegate void OnRefreshEvent();

        public string ModuleName
        {
            get { return (string)GetValue(ModuleNameProperty); }
            set { SetValue(ModuleNameProperty, value); }
        }
        public OnClickEvent OnClick
        {
            get { return (OnClickEvent)GetValue(OnClickProperty); }
            set { SetValue(OnClickProperty, value); }
        }
        public GetToggleStateEvent GetToggleState
        {
            get { return (GetToggleStateEvent)GetValue(GetToggleStateProperty); }
            set { SetValue(GetToggleStateProperty, value); }
        }
        public SetToggleStateEvent SetToggleState
        {
            get { return (SetToggleStateEvent)GetValue(SetToggleStateProperty); }
            set { SetValue(SetToggleStateProperty, value); }
        }
        public OnRefreshEvent OnRefresh
        {
            get { return (OnRefreshEvent)GetValue(OnRefreshProperty); }
            set { SetValue(OnRefreshProperty, value); }
        }

        public static readonly DependencyProperty ModuleNameProperty = DependencyProperty.Register("ModuleName", typeof(string), typeof(ModuleButtonToggleControl), null);
        public static readonly DependencyProperty OnClickProperty = DependencyProperty.Register("OnClick", typeof(OnClickEvent), typeof(ModuleButtonToggleControl), null);
        public static readonly DependencyProperty GetToggleStateProperty = DependencyProperty.Register("GetToggleState", typeof(GetToggleStateEvent), typeof(ModuleButtonToggleControl), null);
        public static readonly DependencyProperty SetToggleStateProperty = DependencyProperty.Register("SetToggleState", typeof(SetToggleStateEvent), typeof(ModuleButtonToggleControl), null);
        public static readonly DependencyProperty OnRefreshProperty = DependencyProperty.Register("OnRefresh", typeof(OnRefreshEvent), typeof(ModuleButtonToggleControl), null);

        private bool? LastToggleState = false;
        public bool? ToggleState
        {
            get 
            { 
                try
                {
                    if (GetToggleState != null)
                    {
                        bool? _return = GetToggleState();
                        return _return;
                    } else
                    {
                        return null;
                    }
                }
                catch { return null; }
            }
            set 
            {
                    if (value != null)
                    {
                        if (SetToggleState != null)
                        {
                            SetToggleState(value);
                            OnToggleStateChanged();
                        }
                    }
            }
        }
        public void Refresh()
        {
            if (OnRefresh != null)
            {
                OnRefresh();
            }

            if (ToggleState != null)
            {
                bool togglestate = (bool)ToggleState;
                if (togglestate)
                {
                    if (ModuleName != null)
                    {
                        //ModuleToggleButton.Content = ModuleName + " [•]";
                        ModuleToggleButton.Content = ModuleName + " ●";
                    } else
                    {
                        //ModuleToggleButton.Content = "[•]";
                        ModuleToggleButton.Content = "●";
                    }
                } else
                {
                    if (ModuleName != null)
                    {
                        //ModuleToggleButton.Content = ModuleName + " [ ]";
                        ModuleToggleButton.Content = ModuleName + " ○";
                    }
                    else
                    {
                        //ModuleToggleButton.Content = "[ ]";
                        ModuleToggleButton.Content = "○";
                    }
                }

            } else
            {
                ModuleToggleButton.Content = "";
            }
            OnToggleStateChanged();
        }

        public ModuleButtonToggleControl()
        {
            InitializeComponent();
            if (ModuleName != null)
            {
                ModuleToggleButton.Content = ModuleName;
            }
        }
        public ModuleButtonToggleControl(string ModuleName)
        {
            this.ModuleName = ModuleName;
            InitializeComponent();
            if (ModuleName != null)
            {
                ModuleToggleButton.Content = ModuleName;
            }
        }

        public void OnToggleStateChanged()
        {
            if (ToggleState != null)
            {
                if (LastToggleState != ToggleState)
                {
                    if (ToggleState == true)
                    {
                        QuinticEase easefunction = new QuinticEase();
                        easefunction.EasingMode = EasingMode.EaseInOut;

                        ModuleToggleButton.Background = new SolidColorBrush(Color.FromArgb(255, 0xFF, 0x92, 0x54));
                        ModuleToggleButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                    }

                    if (ToggleState == false)
                    {
                        QuinticEase easefunction = new QuinticEase();
                        easefunction.EasingMode = EasingMode.EaseInOut;

                        ModuleToggleButton.Background = new SolidColorBrush(Color.FromArgb(0, 0xFF, 0x92, 0x54));
                        ModuleToggleButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 0xFF, 0x92, 0x54));
                    }
                }
            }
            LastToggleState = ToggleState;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            if (ToggleState != null)
            {
                ToggleState = !ToggleState;
            }

            if (OnClick != null)
            {
                OnClick();
            }

            Refresh();
        }
    }
}
