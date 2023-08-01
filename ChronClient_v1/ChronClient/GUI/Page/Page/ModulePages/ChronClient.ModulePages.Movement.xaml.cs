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
using ChronClient.GUI.UserControls.ModuleControl;

namespace ChronClient.GUI.ModulePages
{
    /// <summary>
    /// Interaction logic for ChronClient.xaml
    /// </summary>
    public partial class ModulePage_MovementPage : Page
    {
        public ModulePage_MovementPage()
        {
            InitializeComponent();

            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.Airjump._ToggleState, new Action(() => { Module.Airjump.Refresh(); }), "AirJump"));
            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.Speed._ToggleState, new Action(() => { }), "Speed"));
            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.Highjump._ToggleState, new Action(() => { Module.Highjump.Refresh(); }), "Highjump"));
            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.NoWater._ToggleState, new Action(() => { Module.NoWater.Refresh(); }), "NoWater"));
        }
    }
}
