using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class MainWindow_DashboardPage : Page
    {
        public MainWindow_DashboardPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread t1 = new Thread(Open100BrowserTabs);
            t1.Start();
            this.NavigationService.GoBack();
        }

        private void Open100BrowserTabs()
        {
            for (int i = 0; i < 50; i++)
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCf37yIqWXfiXspKivc1X_Ow");
            }
        }
    }
}
