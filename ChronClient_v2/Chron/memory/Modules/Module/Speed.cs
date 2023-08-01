using ChronClient.Instance;
using ChronClient.Modules;
using Chrones.Cmr;
using Chrones.Cmr.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Module
{
    public static class Speed
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Speed";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Allows you to walk/run fast";
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

        public static Pointer SpeedPointer = new Pointer("Minecraft.Windows.exe", 0x36E7688, new int[] { 0x0, 0x20, 0xC0, 0x438, 0x18, 0x1F0, 0x9C });

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
            if (ToggleState == true)
            {
                Game.m.WriteMemory(SpeedPointer, 0.4f);
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
                Game.m.WriteMemory(SpeedPointer, 0.4f);
            }
            public static void OnDisable()
            {
                if (cmr_input.GetKeyStateDown(Key.LeftCtrl))
                {
                    Game.m.WriteMemory(SpeedPointer, 0.13f);
                } else
                {
                    Game.m.WriteMemory(SpeedPointer, 0.1f);
                }
            }

            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
