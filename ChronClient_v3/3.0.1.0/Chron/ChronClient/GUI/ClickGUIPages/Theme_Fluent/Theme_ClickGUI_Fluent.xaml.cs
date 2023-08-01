using ChronClient.Data;
using ChronClient.IModule.UI;
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

namespace ChronClient.GUI.ClickGUIThemes
{
    /// <summary>
    /// Interaction logic for Theme_TabGUI_Fluent.xaml
    /// </summary>
    public partial class Theme_ClickGUI_Fluent : Page
    {
        public Theme_ClickGUI_Fluent()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IModule.UI.UIElementConverter converter = new IModule.UI.UIElementConverter();
            object o = converter.ToWPF(
            CE.UIStackPanel(
                CE.UIModuleSection(
                    new UIModuleButton("Autoclicker") {
                    },
                    CE.UITextBlock("Clicks automaticly"),
                    CE.UISlider(0, 20, 10),
                    CE.UISlider(0, 20, 15)
                ),
                CE.UIModuleSection(
                    new UIModuleButton("TP Aura") {
                    },
                    CE.UITextBlock("Teleports you behind the player when Trigger Pressed")
                )
            ));
            TestGrid.Children.Add(o as System.Windows.UIElement);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlobalData.Overlay.SET_MODE = GlobalData.Overlay.OverlayMode.Normal;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.Overlay.SetCurrentPage(new GUI.OverlayThemes.Theme_Darki());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.Overlay.SetCurrentPage(new GUI.OverlayThemes.Theme_Matrix());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.Overlay.SetCurrentPage(new GUI.OverlayThemes.Theme_Fluent());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.Overlay.SetCurrentPage(new GUI.OverlayThemes.Theme_Chronicel());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.Overlay.SetCurrentPage(null);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.ClickGUI.SetCurrentPage(new GUI.ClickGUIThemes.Theme_ClickGUI_Test());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            GlobalData.Themes.ClickGUI.SetCurrentPage(new GUI.ClickGUIThemes.Theme_ClickGUI_Yeey());
        }
    }
}
