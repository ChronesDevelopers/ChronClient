using ChronClient.Instance;
using ChronClient.Modules;
using Chrones.Cmr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Module
{
    public static class Glide
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Glide";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Makes you Glide trought the air";
            moduleClass.HasToggleState = true;
            moduleClass.GetToggleState = Events.GetToggleState;
            moduleClass.SetToggleState = Events.SetToggleState;
            moduleClass.ShowInTabGUI = true;
            moduleClass.ShowInListGUI = true;
            moduleClass.GetShowInListGUI = Events.GetShowInListGUI;
            moduleClass.Tick10 = Tick10;
            Modules.ModuleRegister.RegisterModule(moduleClass);
            if (ToggleKey != null)
            {
                KeyBindListener.RegisterKeyBind((Key)ToggleKey, Events.OnKeyPressed);
            }
        }
        public static bool? _ToggleState = false;
        public static bool? ToggleState
        {
            get
            {
                return _ToggleState;
            }
            set
            {
                if (value != _ToggleState)
                {
                    if (value == true)
                    {
                        Events.OnEnable();
                    }
                    if (value == false || value == null)
                    {
                        Events.OnDisable();
                    }
                }
                _ToggleState = value;
            }
        }

        public static Key? ToggleKey = null;

        public static void RegisterKeybind_Toggle(Key? key)
        {
            ToggleKey = key;
            if (key != null)
            {
                KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressed);
            }
        }
        public static void Tick10()
        { 
            if (ToggleState == true)
            {
                bool Shift = cmr_input.GetKeyStateDown(Chrones.Cmr.Win32API.Win32.VirtualKeys.Shift);
                bool Space = cmr_input.GetKeyStateDown(Chrones.Cmr.Win32API.Win32.VirtualKeys.Space);

                Entity player = LocalPlayer.entity;
                if (Shift != Space)
                {
                    if (Space)
                    {
                        player.Y = player.Y + 0.3f;
                    }
                    if (Shift)
                    {
                        player.Y = player.Y - 0.1f;
                    }
                }
                player.VelY = 0f;
            }
        }
        public static class Events
        {
            public static bool? GetToggleState()
            {
                return ToggleState;
            }
            public static void SetToggleState(bool? value)
            {
                ToggleState = value;
            }
            public static bool? GetShowInListGUI()
            {
                return ToggleState;
            }
            public static void OnEnable()
            {
                try
                {
                    Game.m.NopMemory("Minecraft.Windows.exe", 0x14A1A8B, 9);
                    LocalPlayer.entity.VelY = 0f;
                } catch { }
            }
            public static void OnDisable()
            {
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x14A1A8B, new byte[] { 0xF3, 0x41, 0x0F, 0x11, 0x86, 0x98, 0x04, 0x00, 0x00 });
            }

            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
