using ChronClient.Instance;
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
    public partial class ArrayListInstance : UserControl
    {
        public ModuleClass.GetToggleStateEvent? GetToggleStateEvent = null;
        public ModuleClass.GetShowInListGUIEvent? GetShowInListGUIEventEvent = null;
        public bool LastToggleState = false;
        private string _ModuleName;
        public string ModuleName
        {
            get
            {
                return _ModuleName;
            }
            set
            {
                _ModuleName = value;
                Text.Text = value;
            }
        }

        public ArrayListInstance()
        {
            InitializeComponent();
            Animate_AnimationIn();
        }
        public ArrayListInstance(string ModuleName)
        {
            InitializeComponent();
            this.ModuleName = ModuleName;
            this.Text.Text = ModuleName;
            Animate_AnimationIn();
        }


        public void Animate_AnimationIn()
        {
            var ta = new DoubleAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.2);
            QuadraticEase EasingFunction = new QuadraticEase();
            EasingFunction.EasingMode = EasingMode.EaseInOut;
            ta.EasingFunction = EasingFunction;
            ta.From = 0;
            ta.To = 20;

            var ta2 = new ThicknessAnimation();
            ta2.Duration = TimeSpan.FromSeconds(0.2);
            ta2.EasingFunction = EasingFunction;
            ta2.To = new Thickness(0, -1, 0, 0);

            QuadraticEase EasingFunction2 = new QuadraticEase();
            EasingFunction2.EasingMode = EasingMode.EaseInOut;
            ta.EasingFunction = EasingFunction2;
            AnimatedGrid.BeginAnimation(HeightProperty, ta);
            AnimatedGrid.BeginAnimation(MarginProperty, ta2);
        }
        public void Animate_AnimationOut()
        {
            var ta = new DoubleAnimation();
            ta.Duration = TimeSpan.FromSeconds(0.2);
            QuadraticEase EasingFunction = new QuadraticEase();
            EasingFunction.EasingMode = EasingMode.EaseInOut;
            ta.EasingFunction = EasingFunction;
            ta.To = 0;

            var ta2 = new ThicknessAnimation();
            ta2.Duration = TimeSpan.FromSeconds(0.2);
            ta2.EasingFunction = EasingFunction;
            ta2.To = new Thickness(0, 0, 0, 0);

            QuadraticEase EasingFunction2 = new QuadraticEase();
            EasingFunction2.EasingMode = EasingMode.EaseInOut;
            ta.EasingFunction = EasingFunction2;
            AnimatedGrid.BeginAnimation(HeightProperty, ta);
            AnimatedGrid.BeginAnimation(MarginProperty, ta2);
        }

        public void Refresh(bool ToggleState)
        {
            if (ToggleState != LastToggleState)
            {
                if (ToggleState)
                {
                    Animate_AnimationIn();
                } else
                {
                    Animate_AnimationOut();
                }
            }
            LastToggleState = ToggleState;
        }

        public void Refresh()
        {
            if (GetToggleStateEvent != null && GetShowInListGUIEventEvent == null)
            {
                bool? ToggleState = GetToggleStateEvent();
                if (ToggleState == null)
                {
                    ToggleState = false;
                }
                if (ToggleState != LastToggleState)
                {
                    if (ToggleState == true)
                    {
                        Animate_AnimationIn();
                    }
                    else
                    {
                        Animate_AnimationOut();
                    }
                }
                LastToggleState = (bool)ToggleState;
            }
            else if (GetShowInListGUIEventEvent != null)
            {
                bool? ToggleState = GetShowInListGUIEventEvent();
                if (ToggleState == null)
                {
                    ToggleState = false;
                }
                if (ToggleState != LastToggleState)
                {
                    if (ToggleState == true)
                    {
                        Animate_AnimationIn();
                    }
                    else
                    {
                        Animate_AnimationOut();
                    }
                }
                LastToggleState = (bool)ToggleState;
            }
        }
    }
}
