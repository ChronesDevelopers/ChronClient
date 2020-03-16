using Chrones.Cmr;
using System;
using System.Windows;

namespace ChronClient.GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class C_MessageBox : Window
    {
        public C_MessageBox(string TextMessageA, string TitleA, string Option1, string Option2, RoutedEventHandler Option1OnClick, RoutedEventHandler Option2OnClick)
        {
            InitializeComponent();
            if (TextMessageA != null)
            {
                this.TEXT.Text = TextMessageA;
            } else
            {
                this.TEXT.Text = "";
            }

            if (TitleA != null)
            {
                this.Title = TitleA;
                this.TitleBlock.Text = TitleA;
            } else
            {
                this.Title = "";
                this.TitleBlock.Text = "";
            }

            if (Option1 != null)
            {
                this.Option1.Content = Option1;
            } else
            {
                this.Option1.Content = "";
            }

            if (Option2 != null)
            {
                this.Option2.Content = Option2;
            } else
            {
                this.Option2.Content = "";
            }

            if (Option1OnClick != null)
            {
                this.Option1.Click += Option1OnClick;
            }

            if (Option2OnClick != null)
            {
                this.Option1.Click += Option2OnClick;
            }

            this.Show();
        }

        public string TextMessage
        {
            get { return TEXT.Text; }
            set { TEXT.Text = TextMessage; }
        }

        private void Control_Close_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
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
        
        public void _CLOSE()
        {
            this.Close();
        }
    }
}
