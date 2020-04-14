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
    public partial class ModulePage_CombatPage : Page
    {
        public ModulePage_CombatPage()
        {
            InitializeComponent();

            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.Hitbox._ToggleState, new Action(() => { Module.Airjump.Refresh(); }), "HitBox"));
            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.Reach._ToggleState, new Action(() => { Module.Reach.Refresh(); }), "Reach"));
        }
    }
}