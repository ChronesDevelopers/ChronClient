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
    public partial class ModulePage_OtherPage : Page
    {
        public ModulePage_OtherPage()
        {
            InitializeComponent();

            ListSettings.Children.Add(new C_Control_ModuleToggle(ref Module.AutoClick._ToggleState, new Action(() => { }), "AutoClick"));
        }
    }
}