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
    /// Interaction logic for Theme_Yeet.xaml
    /// </summary>
    public partial class Theme_ClickGUI_Yeey : Page
    {
        public Theme_ClickGUI_Yeey()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.ClickGUI.SetCurrentPage(new GUI.ClickGUIThemes.Theme_ClickGUI_Fluent());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.Overlay.SetCurrentPage(new GUI.OverlayThemes.Theme_Yeey());
        }
    }
}
