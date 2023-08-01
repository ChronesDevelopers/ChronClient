using ChronClient.Instance;
using ChronClient.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Module
{
    public static class Airjump
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Airjump";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Allows you to jump in the Air";
            moduleClass.HasToggleState = true;
            moduleClass.GetToggleState = Events.GetToggleState;
            moduleClass.SetToggleState = Events.SetToggleState;
            moduleClass.ShowInTabGUI = true;
            moduleClass.ShowInListGUI = true;
            moduleClass.GetShowInListGUI = Events.GetShowInListGUI;
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
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x130D166, new byte[] { 0x41, 0xB0, 0x01 });
            }
            public static void OnDisable()
            {

                Game.m.PatchMemory("Minecraft.Windows.exe", 0x130D166, new byte[] { 0x45, 0x30, 0xC0 });
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }

        public static class Profile
        { 
            public static ChronClient.File.ProfileClassSetting[] GetSettings()
            {
                File.ProfileClassSetting[] settings = new ChronClient.File.ProfileClassSetting[]
                {
                    new File.ProfileClassSetting
                    {
                        Name = "Airjump_ToggleState",
                        Value = _ToggleState
                    },
                    new File.ProfileClassSetting
                    {
                        Name = "Airjump_ToggleKey",
                        Value = ToggleKey
                    }
                };
                return settings;
            }
        }
    }
}
