using Chrones.Cmr;
using System;
using System.Windows;

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class Template_Window : Window
    {
        public Template_Window()
        {
            InitializeComponent();
        }

        private void Control_Close_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
            cmr.ExitApplication();
        }

        private void Control_Maximize_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            } else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Control_Minimize_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
