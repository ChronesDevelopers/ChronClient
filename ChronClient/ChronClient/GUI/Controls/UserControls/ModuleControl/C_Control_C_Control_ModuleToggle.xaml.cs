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

        public string ModuleName
        {
            get { return (string)GetValue(ModuleNameProperty); }
            set { SetValue(ModuleNameProperty, value); }
        }

        public static readonly DependencyProperty ModuleNameProperty = DependencyProperty.Register("ModuleName", typeof(string), typeof(C_Control_ModuleToggle));

        public C_Control_ModuleToggle()
        {
            InitializeComponent();
            this.ModuleName_TextBlock.Text = ModuleName;
        }
    }
}
