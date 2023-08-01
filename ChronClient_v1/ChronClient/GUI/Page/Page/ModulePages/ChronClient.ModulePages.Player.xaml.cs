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
    public partial class ModulePage_PlayerPage : Page
    {
        public ModulePage_PlayerPage()
        {
            InitializeComponent();

            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.NoFall._ToggleState, new Action(() => { Module.NoFall.Refresh(); }), "NoFall"));
            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.NoKnockBack._ToggleState, new Action(() => { Module.NoKnockBack.Refresh(); }), "NoKnockBack"));
            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.NoSwing._ToggleState, new Action(() => { Module.NoSwing.Refresh(); }), "NoSwing"));
        }
    }
}