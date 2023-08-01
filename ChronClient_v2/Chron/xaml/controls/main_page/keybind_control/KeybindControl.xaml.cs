using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChronClient.Controls
{
    /// <summary>
    /// Interaction logic for KeybindControl.xaml
    /// </summary>
    public partial class KeybindControl : UserControl
    {
        public string ModuleName
        {
            get { return (string)GetValue(ModuleNameProperty); }
            set { SetValue(ModuleNameProperty, value); }
        }

        public static readonly DependencyProperty ModuleNameProperty = DependencyProperty.Register("ModuleName", typeof(string), typeof(KeybindControl), null);

        public KeybindControl()
        {
            InitializeComponent();
        }

        public KeybindControl(string ModuleName)
        {
            InitializeComponent();
            InputTextBlock.Text = ModuleName;
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            InputTextBlock.Text = ModuleName;
        }

        public Key? GetKey()
        {
            if (Input.Text.Trim() == "" || Input.Text == "null")
            {
                return null;
            }

            Key? key = null;

            KeyConverter keyConverter = new KeyConverter();
            try
            {
                key = (Key?)keyConverter.ConvertFromString(Input.Text);
                if (key == 0)
                {
                    return null;
                }
            } catch
            {
                return null;
            }
            return key;
        }
    }
}
