using ChronClient.Controls.Themes.Darki;
using ChronClient.Data;
using ChronClient.Instance;
using ChronClient.Module;
using ChronClient.Modules;
using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace ChronClient.GUI.Themes
{
    /// <summary>
    /// Interaction logic for Theme_Darki.xaml
    /// </summary>
    public partial class Theme_Darki : UserControl
    {
        List<string> LastListGUIModuleElements = new List<string>();

        public object TEXTMOD { get; private set; }

        public Theme_Darki()
        {
            InitializeComponent();
            OnModuleLoad();

            if (GlobalData.ApplicationData.IsPlusVersion)
            {
                CLIENT_NAME.Text = @$"ChronClient⧫ v{GlobalData.ApplicationData.VERSION}";
            } else
            {
                CLIENT_NAME.Text = @$"ChronClient v{GlobalData.ApplicationData.VERSION}";
            }

            this.NOKEYBINDS.ModuleName = "NO KEYBINDS";
            this.NOKEYBINDS.GetShowInListGUIEventEvent = Module.NOKEYBINDS.Events.GetShowInListGUI;
            this.NOKEYBINDS.Animate_AnimationOut();
        }

        public void Refresh()
        {
            GUIRefresh();

            try
            {
                IntPtr result = Game.m.FindAddressWithPointer(LocalPlayer.AtOffset(0x458));
                float X;
                float Y;
                float Z;
                if (result == IntPtr.Zero)
                {
                    PositionX.Text = "X";
                    PositionY.Text = "Y";
                    PositionZ.Text = "Z";
                    return;
                }
                try
                {
                    if (LocalPlayer.entity != null)
                    {
                        X = (float)LocalPlayer.entity.X;
                        Y = (float)LocalPlayer.entity.Y;
                        Z = (float)LocalPlayer.entity.Z;
                    }
                    else
                    {
                        PositionX.Text = "X";
                        PositionY.Text = "Y";
                        PositionZ.Text = "Z";
                        return;
                    }
                } catch
                {
                    PositionX.Text = "X";
                    PositionY.Text = "Y";
                    PositionZ.Text = "Z";
                    return;
                }
                if (X == 0.3f && Y == 0f && Z == 0.3f)
                {
                    PositionX.Text = "X";
                    PositionY.Text = "Y";
                    PositionZ.Text = "Z";
                    return;
                }

                PositionX.Text = $"{X.ToString("0.00")}";
                PositionY.Text = $"{Y.ToString("0.00")}";
                PositionZ.Text = $"{Z.ToString("0.00")}";
            } catch
            {
                PositionX.Text = "X";
                PositionY.Text = "Y";
                PositionZ.Text = "Z";
                return;
            }
        }

        private void GUIRefresh()
        {
            SolidColorBrush accent = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x92, 0x54));
            SolidColorBrush accent2 = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

            if (cmr_input.GetKeyStateDown(Win32.VK.LBUTTON))
            {
                KeyStroke_LMB_Border.BorderBrush = accent;
            }
            else
            {
                KeyStroke_LMB_Border.BorderBrush = accent2;
            }
            if (cmr_input.GetKeyStateDown(Win32.VK.RBUTTON))
            {
                KeyStroke_RMB_Border.BorderBrush = accent;
            }
            else
            {
                KeyStroke_RMB_Border.BorderBrush = accent2;
            }
            if (Keyboard.IsKeyDown(Key.W))
            {
                KeyStroke_W_Border.BorderBrush = accent;
            }
            else
            {
                KeyStroke_W_Border.BorderBrush = accent2;
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                KeyStroke_A_Border.BorderBrush = accent;
            }
            else
            {
                KeyStroke_A_Border.BorderBrush = accent2;
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                KeyStroke_S_Border.BorderBrush = accent;
            }
            else
            {
                KeyStroke_S_Border.BorderBrush = accent2;
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                KeyStroke_D_Border.BorderBrush = accent;
            }
            else
            {
                KeyStroke_D_Border.BorderBrush = accent2;
            }
            if (Keyboard.IsKeyDown(Key.Space))
            {
                KeyStroke_Space_Border.BorderBrush = accent;
            }
            else
            {
                KeyStroke_Space_Border.BorderBrush = accent2;
            }

            RefreshListGUI();
        }
        public void RefreshListGUI()
        {
            foreach (UIElement obj in ListArrayStackPanel.Children)
            {
                if (obj.GetType() == typeof(ArrayListInstance))
                {
                    ((ArrayListInstance)obj).Refresh();
                }
            }
            this.NOKEYBINDS.Refresh();
        }

        public void OnModuleLoad()
        {
            foreach (ModuleClass module in ModuleRegister.ModuleList)
            {
                if (module.ShowInListGUI == true && module.GetShowInListGUI != null)
                {
                    ArrayListInstance obj = new ArrayListInstance(module.ModuleName) { GetToggleStateEvent = module.GetToggleState, GetShowInListGUIEventEvent = module.GetShowInListGUI };
                    ListArrayStackPanel.Children.Add(obj);
                }
            }
            foreach (UIElement obj in ListArrayStackPanel.Children)
            {
                if (obj.GetType() == typeof(ArrayListInstance))
                {
                    ((ArrayListInstance)obj).Animate_AnimationOut();
                }
            }
        }
    }
}
