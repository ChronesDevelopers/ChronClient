using ChronClient.GUI.UserControls.ModuleControl;
using System;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChronClient.GUI.ModulePages
{
    /// <summary>
    /// Interaction logic for ChronClient.xaml
    /// </summary>
    public partial class ModulePage_WorldPage : Page
    {
        public ModulePage_WorldPage()
        {
            InitializeComponent();

            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.CustomTime._ToggleState, new Action(() => { Module.CustomTime.Refresh(); }), "CustomTime"));
            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.Fullbright._ToggleState, new Action(() => { Module.Fullbright.Refresh(); }), "Fullbright"));
            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.Instabreak._ToggleState, new Action(() => { Module.Instabreak.Refresh(); }), "Instabreak"));

        }
    }
}