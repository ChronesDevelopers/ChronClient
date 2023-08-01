using ChronClient.Instance;
using ChronClient.Modules;
using Chrones.Cmr.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Module
{
    public static class Fullbright
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Fullbright";
            moduleClass.Category = "World";
            moduleClass.Description1 = "Lets you view the world in full brightness";
            moduleClass.HasToggleState = true;
            moduleClass.GetToggleState = Events.GetToggleState;
            moduleClass.SetToggleState = Events.SetToggleState;
            moduleClass.ShowInTabGUI = true;
            moduleClass.ShowInListGUI = true;
            moduleClass.GetShowInListGUI = Events.GetShowInListGUI;
            moduleClass.Tick1000 = Tick1000;
            Modules.ModuleRegister.RegisterModule(moduleClass);
            if (ToggleKey != null)
            {
                KeyBindListener.RegisterKeyBind((Key)ToggleKey, Events.OnKeyPressed);
            }
        }

        static Pointer Brightness = new Pointer("Minecraft.Windows.exe", 0x36D94B8, new int[] { 0xC8, 0x88, 0xB0, 0xB8, 0xB0, 0x138, 0xF0 });

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
        public static float? _Value = 15f;
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
                    _Value = value;
                } else
                {
                    _Value = 10f;
                }
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

        public static void Tick1000()
        {
            if (ToggleState == true)
            {
                if (Value != null)
                {
                    Game.m.WriteMemory(Brightness, _Value);
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
                if (Value != null)
                {
                    Game.m.WriteMemory(Brightness, _Value);
                }
            }
            public static void OnDisable()
            {
                Game.m.WriteMemory(Brightness, 1f);
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
