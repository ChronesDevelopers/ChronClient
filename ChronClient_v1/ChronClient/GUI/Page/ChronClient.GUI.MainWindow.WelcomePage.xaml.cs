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

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaktionslogik für ChronClient.xaml
    /// </summary>
    public partial class MainWindow_WelcomePage : Page
    {
        public MainWindow_WelcomePage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainWindow_DashboardPage());
        }
    }
}
