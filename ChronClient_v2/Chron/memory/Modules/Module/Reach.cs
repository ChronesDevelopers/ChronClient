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
    public static class Reach
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Reach";
            moduleClass.Category = "Combat";
            moduleClass.Description1 = "Let's your hit players from longer distances";
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
        public static float? _Value = 7f;
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
                    if  (_Value != value && ToggleState == true)
                    {
                        Events.OnEnable();
                    }
                    _Value = value;
                }
                else
                {
                    _Value = 7f;
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
                //Game.Statics.SurvivalReach = 7f;
                float value = 7f;
                if (Value != null)
                {
                    value = (float)Value;
                }
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x2404320, BitConverter.GetBytes(value));
            }
            public static void OnDisable()
            {
                //Game.Statics.SurvivalReach = 3f;
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x2404320, BitConverter.GetBytes(3f));
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}