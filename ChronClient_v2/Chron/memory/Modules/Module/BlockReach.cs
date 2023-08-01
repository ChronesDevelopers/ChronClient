using ChronClient.Instance;
using ChronClient.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Module
{
    public static class BlockReach
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "BlockReach";
            moduleClass.Category = "World";
            moduleClass.Description1 = "Allows you to place blocks from far away...";
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
        public static float? _Value = 100f;
        public static float? Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value != null)
                {
                    if (_Value != value && ToggleState == true)
                    {
                        Events.OnEnable();
                    }
                    _Value = value;
                }
                else
                {
                    _Value = 10f;
                }
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
                float value = 10f;
                if (Value != null)
                {
                    value = (float)Value;
                }
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x24043F4, BitConverter.GetBytes(value));
            }
            public static void OnDisable()
            {
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x24043F4, BitConverter.GetBytes(6f));
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
                        Name = "BlockReach_ToggleState",
                        Value = _ToggleState
                    },
                    new File.ProfileClassSetting
                    {
                        Name = "BlockReach_ToggleKey",
                        Value = ToggleKey
                    },
                    new File.ProfileClassSetting
                    {
                        Name = "BlockReach_Value",
                        Value = _Value
                    }
                };
                return settings;
            }
        }
    }
}
