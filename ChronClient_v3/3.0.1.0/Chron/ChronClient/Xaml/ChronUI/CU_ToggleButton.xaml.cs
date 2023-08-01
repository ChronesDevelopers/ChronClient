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

namespace ChronClient.GUI.ChronUI
{
    /// <summary>
    /// Interaction logic for CU_ToggleButton.xaml
    /// </summary>
    public partial class CU_ToggleButton : UserControl
    {
        public CU_ToggleButton()
        {
            InitializeComponent();
        }

        public bool _Enabled { get; private set; } = false;
        public bool Enabled
        {
            get => _Enabled;
            set
            {
                if (value != _Enabled)
                {
                    _Enabled = value;
                    Refresh();
                }
            }
        }
        public string Text
        {
            get => TextBlock_Disabled.Text;
            set
            {
                TextBlock_Enabled.Text = value;
                TextBlock_Disabled.Text = value;
            }
        }

        public event OnEnabledEvent OnEnabled;
        public event OnDisabledEvent OnDisabled;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Enabled = !Enabled;
        }
        public void Refresh()
        {
            var OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.Duration = TimeSpan.FromSeconds(0.3);
            OpacityAnimation.To = 1;

            var OpacityAnimation2 = new DoubleAnimation();
            OpacityAnimation2.Duration = TimeSpan.FromSeconds(0.3);
            OpacityAnimation2.To = 0;
            if (Enabled)
            {
                OnEnabled?.Invoke();

                Border_Enabled.BeginAnimation(OpacityProperty, OpacityAnimation);
                Border_Disabled.BeginAnimation(OpacityProperty, OpacityAnimation2);
            } else
            {
                OnDisabled?.Invoke();

                Border_Enabled.BeginAnimation(OpacityProperty, OpacityAnimation2);
                Border_Disabled.BeginAnimation(OpacityProperty, OpacityAnimation);
            }
        }

        public delegate void OnEnabledEvent();
        public delegate void OnDisabledEvent();
    }
}
