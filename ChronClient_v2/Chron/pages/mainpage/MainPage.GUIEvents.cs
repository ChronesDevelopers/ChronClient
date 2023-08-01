using ChronClient.Controls;
using ChronClient.Instance;
using ChronClient.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChronClient.GUI.Pages
{
    public static class MainPage_GUIEvents
    {
        public static void ModuleButton_Click(object sender, RoutedEventArgs e, MainPage page)
        {
            
        }

        public static void CategoryButton_Settings_Click(object sender, RoutedEventArgs e, MainPage page)
        {
            if (sender == page.CategoryButton_Setting_0)
            {
                page.SettingsViewAnimate = true; 
                page.SettingsView.SelectedIndex = 0;
            } else if (sender == page.CategoryButton_Setting_1)
            {
                page.SettingsViewAnimate = true; 
                page.SettingsView.SelectedIndex = 1;
            }
            else if (sender == page.CategoryButton_Setting_2)
            {
                page.SettingsViewAnimate = true; 
                page.SettingsView.SelectedIndex = 2;
            }
            else if (sender == page.CategoryButton_Setting_3)
            {
                page.SettingsViewAnimate = true; 
                page.SettingsView.SelectedIndex = 3;
            }
            else if (sender == page.CategoryButton_Setting_4)
            {
                page.SettingsViewAnimate = true; 
                page.SettingsView.SelectedIndex = 4;
            }
            else if (sender == page.CategoryButton_Setting_5)
            {
                page.SettingsViewAnimate = true; 
                page.SettingsView.SelectedIndex = 5;
            }
        }
        public static void UpdateKeybinds(object sender, EventArgs e, MainPage page)
        {
            KeyBindListener.Keybinds = new List<Keybind>();
            Key? obj;
            KeyBindListener.RegisterKeybind action = null;


            // Airjump
            try
            {
                obj = page.KeybindControl_Airjump_Toggle.GetKey();
                action = Module.Airjump.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // AirWalk
            try
            {
                obj = page.KeybindControl_AirWalk_Toggle.GetKey();
                action = Module.AirWalk.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Antivoid
            // Toggle
            try
            {
                obj = page.KeybindControl_Antivoid_Toggle.GetKey();
                action = Module.Antivoid.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }
            // Trigger
            try
            {
                obj = page.KeybindControl_Antivoid_Trigger.GetKey();
                action = Module.Antivoid.RegisterKeybind_Trigger;
                UpdateKeybind(obj, action);
            }
            catch { }

            // BlockReach
            try
            {
                obj = page.KeybindControl_BlockReach_Toggle.GetKey();
                action = Module.BlockReach.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // ClickTp
            // Toggle
            try
            {
                obj = page.KeybindControl_ClickTp_Toggle.GetKey();
                action = Module.ClickTp.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }
            // Trigger
            try
            {
                obj = page.KeybindControl_ClickTp_Trigger.GetKey();
                action = Module.ClickTp.RegisterKeybind_Trigger;
                UpdateKeybind(obj, action);
            }
            catch { }

            // CubecraftFly
            // Toggle
            try
            {
                obj = page.KeybindControl_CubecraftFly_Toggle.GetKey();
                action = Module.CubecraftFly.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }
            // Trigger
            try
            {
                obj = page.KeybindControl_CubecraftFly_Trigger.GetKey();
                action = Module.CubecraftFly.RegisterKeybind_Trigger;
                UpdateKeybind(obj, action);
            }
            catch { }

            // CustomTime
            try
            {
                obj = page.KeybindControl_CustomTime_Toggle.GetKey();
                action = Module.CustomTime.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // DirectionalBoost
            // Toggle
            try
            {
                obj = page.KeybindControl_DirectionalBoost_Toggle.GetKey();
                action = Module.DirectionalBoost.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }
            // Trigger
            try
            {
                obj = page.KeybindControl_DirectionalBoost_Trigger.GetKey();
                action = Module.DirectionalBoost.RegisterKeybind_Trigger;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Fly
            try
            {
                obj = page.KeybindControl_Fly_Toggle.GetKey();
                action = Module.Fly.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // FreeView
            // Toggle
            try
            {
                obj = page.KeybindControl_FreeView_Toggle.GetKey();
                action = Module.FreeView.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }
            // Trigger
            try
            {
                obj = page.KeybindControl_FreeView_Trigger.GetKey();
                action = Module.FreeView.RegisterKeybind_Trigger;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Fullbright
            try
            {
                obj = page.KeybindControl_Fullbright_Toggle.GetKey();
                action = Module.Fullbright.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Glide
            try
            {
                obj = page.KeybindControl_Glide_Toggle.GetKey();
                action = Module.Glide.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Highjump
            try
            {
                obj = page.KeybindControl_Highjump_Toggle.GetKey();
                action = Module.Highjump.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Hitbox
            try
            {
                obj = page.KeybindControl_Hitbox_Toggle.GetKey();
                action = Module.Hitbox.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Instabreak
            try
            {
                obj = page.KeybindControl_Instabreak_Toggle.GetKey();
                action = Module.Instabreak.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Jetpack
            // Toggle
            try
            {
                obj = page.KeybindControl_Jetpack_Toggle.GetKey();
                action = Module.Jetpack.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }
            // Trigger
            try
            {
                obj = page.KeybindControl_Jetpack_Trigger.GetKey();
                action = Module.Jetpack.RegisterKeybind_Trigger;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Killaura
            try
            {
                obj = page.KeybindControl_Killaura_Toggle.GetKey();
                action = Module.Killaura.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // LongJump
            try
            {
                obj = page.KeybindControl_LongJump_Toggle.GetKey();
                action = Module.LongJump.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // NoFall
            try
            {
                obj = page.KeybindControl_NoFall_Toggle.GetKey();
                action = Module.NoFall.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // NoHungerSlowDown
            try
            {
                obj = page.KeybindControl_NoHungerSlowDown_Toggle.GetKey();
                action = Module.NoHungerSlowDown.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // NoJumpDelay
            try
            {
                obj = page.KeybindControl_NoJumpDelay_Toggle.GetKey();
                action = Module.NoJumpDelay.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // NoKnockBack
            try
            {
                obj = page.KeybindControl_NoKnockBack_Toggle.GetKey();
                action = Module.NoKnockBack.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // NoSwing
            try
            {
                obj = page.KeybindControl_NoSwing_Toggle.GetKey();
                action = Module.NoSwing.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // NoWater
            try
            {
                obj = page.KeybindControl_NoWater_Toggle.GetKey();
                action = Module.NoWater.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // NoWeb
            try
            {
                obj = page.KeybindControl_NoWeb_Toggle.GetKey();
                action = Module.NoWeb.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // RapidHit
            try
            {
                obj = page.KeybindControl_RapidHit_Toggle.GetKey();
                action = Module.RapidHit.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Reach
            try
            {
                obj = page.KeybindControl_Reach_Toggle.GetKey();
                action = Module.Airjump.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Reverse
            // Toggle
            try
            {
                obj = page.KeybindControl_Reverse_Toggle.GetKey();
                action = Module.Reverse.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }
            // Trigger
            try
            {
                obj = page.KeybindControl_Reverse_Trigger.GetKey();
                action = Module.Reverse.RegisterKeybind_Trigger;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Scaffold
            try
            {
                obj = page.KeybindControl_Scaffold_Toggle.GetKey();
                action = Module.Scaffold.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Speed
            try
            {
                obj = page.KeybindControl_Speed_Toggle.GetKey();
                action = Module.Speed.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // SpeedFall
            try
            {
                obj = page.KeybindControl_SpeedFall_Toggle.GetKey();
                action = Module.SpeedFall.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // Step
            try
            {
                obj = page.KeybindControl_Step_Toggle.GetKey();
                action = Module.Step.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }

            // TpAura
            // Toggle
            try
            {
                obj = page.KeybindControl_TpAura_Toggle.GetKey();
                action = Module.TpAura.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }
            // Trigger
            try
            {
                obj = page.KeybindControl_TpAura_Trigger.GetKey();
                action = Module.TpAura.RegisterKeybind_Trigger;
                UpdateKeybind(obj, action);
            }
            catch { }

            // NOKEYBINDS
            try
            {
                obj = Key.Insert;
                action = Module.NOKEYBINDS.RegisterKeybind_Toggle;
                UpdateKeybind(obj, action);
            }
            catch { }
        }
        public static void UpdateKeybind(Key? key, KeyBindListener.RegisterKeybind action)
        {
            action(key);
        }
    
        public static class Sliders
        {
            //public static 
        }
    }
}
