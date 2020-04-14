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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChronClient.GUI.UserControls.ModuleControl
{
    /// <summary>
    /// Interaction logic for C_Control_ModuleToggle.xaml
    /// </summary>
    public partial class C_Control_ModuleToggle : UserControl
    {
        private static void RefreshActionNULL()
        {

        }

        bool NULL = false;

        unsafe bool* _ToggleState;

        public bool ToggleState
        {
            get
            {
                unsafe
                {
                    return *_ToggleState;
                }
            }

            set
            {
                unsafe
                {
                    *_ToggleState = value;
                }
                Refresh();
            }
        }
        public Action RefreshAction = new Action(RefreshActionNULL);

        public string ModuleName
        {
            get { return (string)GetValue(ModuleNameProperty); }
            set { SetValue(ModuleNameProperty, value); }
        }

        public static readonly DependencyProperty ModuleNameProperty = DependencyProperty.Register("ModuleName", typeof(string), typeof(C_Control_ModuleToggle));

        public C_Control_ModuleToggle(ref bool ToggleStateRefrence, Action RefreshAction)
        {
            unsafe
            {
                fixed (bool* ptr = &NULL)
                {
                    _ToggleState = ptr;
                }
                fixed (bool* ptr = &ToggleStateRefrence)
                {
                    _ToggleState = ptr;
                }
            }
            this.RefreshAction = RefreshAction;
            InitializeComponent();
            DataContext = this;
            ToggleState = false;
            Refresh();
        }

        public C_Control_ModuleToggle(ref bool ToggleStateRefrence, Action RefreshAction, string ModuleName)
        {
            unsafe
            {
                fixed (bool* ptr = &NULL)
                {
                    _ToggleState = ptr;
                }
                fixed (bool* ptr = &ToggleStateRefrence)
                {
                    _ToggleState = ptr;
                }
            }
            this.RefreshAction = RefreshAction;
            InitializeComponent();
            DataContext = this;
            this.ModuleName = ModuleName;
            Refresh();
        }

        public C_Control_ModuleToggle()
        {
            unsafe
            {
                fixed (bool* ptr = &NULL)
                {
                    _ToggleState = ptr;
                }
                ToggleState = false;
            }
            InitializeComponent();
            DataContext = this;
            Refresh();
        }

        private string GetBoolStringToogleState(bool Value)
        {
            if (Value)
            {
                return "On";
            } 
            else if (!Value)
            {
                return "Off";
            }
            return "";
        }

        public void Refresh()
        {
            Toggle_Button.Content = GetBoolStringToogleState(ToggleState);
            Task.Run(RefreshAction);
        }

        public void Enable()
        {
            ToggleState = true;
            Refresh();
        }

        public void Disable()
        {
            ToggleState = false;
            Refresh();
        }

        public void Toggle()
        {
            ToggleState = !ToggleState;
            Refresh();
        }

        private void Toggle_Button_Click(object sender, RoutedEventArgs e)
        {
            Toggle();
        }
    }
}
