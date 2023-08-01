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

namespace ChronClient.Controls.Themes.Darki 
{
    /// <summary>
    /// Interaction logic for TabGUIElement.xaml
    /// </summary>
    public partial class TabGUIElement : UserControl
    {
        public bool _ToggleState = false;
        public bool ToggleState
        {
            get
            {
                return _ToggleState;
            }

            set
            {
                if (value != _ToggleState)
                {
                    if (value)
                    {
                        OnAnimateInToggle();
                        _ToggleState = value;
                    } else
                    {
                        OnAnimateOutToggle();
                        _ToggleState = value;
                    }
                }
            }
        }
        public bool _SelectedState = false;
        public bool SelectedState
        {
            get
            {
                return _SelectedState;
            }

            set
            {
                if (value != _SelectedState)
                {
                    if (value)
                    {
                        OnAnimateInSelected();
                        _SelectedState = value;
                    }
                    else
                    {
                        OnAnimateOutSelected();
                        _SelectedState = value;
                    }
                }
            }
        }
        public string TEXT
        {
            get
            {
                return (string)GetValue(TEXTProperty);
            }
            set
            {
                SetValue(TEXTProperty, value);
                TEXTBLOCK1.Text = value;
                TEXTBLOCK2.Text = value;
            }
        }
        public TabGUIElement()
        {
            InitializeComponent();
            OnAnimateOutToggle();
            OnAnimateOutSelected();
        }
        public void OnAnimateInToggle()
        {
            try
            {
                var ta = new DoubleAnimation();
                ta.Duration = TimeSpan.FromSeconds(0.3);
                QuadraticEase EasingFunction = new QuadraticEase();
                EasingFunction.EasingMode = EasingMode.EaseOut;
                ta.EasingFunction = EasingFunction;
                ta.To = 200;
                ToggleSection2.BeginAnimation(WidthProperty, ta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void OnAnimateOutToggle()
        {
            try
            {
                var ta = new DoubleAnimation();
                ta.Duration = TimeSpan.FromSeconds(0.2);
                QuadraticEase EasingFunction = new QuadraticEase();
                EasingFunction.EasingMode = EasingMode.EaseOut;
                ta.EasingFunction = EasingFunction;
                ta.To = 0;
                ToggleSection2.BeginAnimation(WidthProperty, ta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void OnAnimateInSelected()
        {
            try
            {
                var ta = new ThicknessAnimation();
                ta.Duration = TimeSpan.FromSeconds(0.2);
                QuadraticEase EasingFunction = new QuadraticEase();
                EasingFunction.EasingMode = EasingMode.EaseOut;
                ta.EasingFunction = EasingFunction;
                ta.To = new Thickness(2,2,2,3);
                BORDER1.BeginAnimation(BorderThicknessProperty, ta);
                BORDER2.BeginAnimation(BorderThicknessProperty, ta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void OnAnimateOutSelected()
        {
            try
            {
                var ta = new ThicknessAnimation();
                ta.Duration = TimeSpan.FromSeconds(0.1);
                QuadraticEase EasingFunction = new QuadraticEase();
                EasingFunction.EasingMode = EasingMode.EaseOut;
                ta.EasingFunction = EasingFunction;
                ta.To = new Thickness(0);
                BORDER1.BeginAnimation(BorderThicknessProperty, ta);
                BORDER2.BeginAnimation(BorderThicknessProperty, ta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static readonly DependencyProperty TEXTProperty = DependencyProperty.Register("TEXTProperty", typeof(string), typeof(KeybindControl), null);
    }
}
