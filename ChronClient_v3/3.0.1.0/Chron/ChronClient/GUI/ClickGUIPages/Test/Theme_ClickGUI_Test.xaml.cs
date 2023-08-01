using ChronClient.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChronClient.GUI.ClickGUIThemes
{
    /// <summary>
    /// Interaction logic for Theme_Test.xaml
    /// </summary>
    public partial class Theme_ClickGUI_Test : Page
    {
        public Theme_ClickGUI_Test()
        {
            InitializeComponent();
        }

        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            GlobalData.Overlay.SET_MODE = GlobalData.Overlay.OverlayMode.Normal;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.ClickGUI.SetCurrentPage(new Theme_ClickGUI_Fluent());
        }
    }
}
