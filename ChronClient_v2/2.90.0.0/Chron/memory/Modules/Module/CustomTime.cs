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
    public static class CustomTime
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "CustomTime";
            moduleClass.Category = "World";
            moduleClass.Description1 = "Makes custom time";
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
        public static int? _Value = 18000;
        public static int? Value
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
                    byte[] WriteValue = BitConverter.GetBytes((int)Value);
                    Game.m.PatchMemory("Minecraft.Windows.exe", 0x18725D2, new byte[] { 0xBA, WriteValue[0], WriteValue[1], WriteValue[2], WriteValue[3], 0x90, 0x90 });
                }
            }
            public static void OnDisable()
            {
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x18725D2, new byte[] { 0x41, 0x8B, 0x90, 0x68, 0x03, 0x00, 0x00 });
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
