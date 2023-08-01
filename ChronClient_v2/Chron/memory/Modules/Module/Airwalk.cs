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
    public static class AirWalk
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "AirWalk";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Allows you to walk in the Air";
            moduleClass.HasToggleState = true;
            moduleClass.GetToggleState = Events.GetToggleState;
            moduleClass.SetToggleState = Events.SetToggleState;
            moduleClass.ShowInTabGUI = true;
            moduleClass.ShowInListGUI = true;
            moduleClass.GetShowInListGUI = Events.GetShowInListGUI;
            moduleClass.Tick100 = Tick100;
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

        public static void Tick100()
        {
            try
            {
                if (ToggleState == true)
                {
                    LocalPlayer.entity.VelY = 0f;
                }
            } catch
            {

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
                Game.m.NopMemory("Minecraft.Windows.exe", 0x14A1A8B, 9);
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

        public static class Profile
        {
            public static ChronClient.File.ProfileClassSetting[] GetSettings()
            {
                File.ProfileClassSetting[] settings = new ChronClient.File.ProfileClassSetting[]
                {
                    new File.ProfileClassSetting
                    {
                        Name = "Airwalk_ToggleState",
                        Value = _ToggleState
                    },
                    new File.ProfileClassSetting
                    {
                        Name = "Airwalk_ToggleKey",
                        Value = ToggleKey
                    }
                };
                return settings;
            }
        }
    }
}
