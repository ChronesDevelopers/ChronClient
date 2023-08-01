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
    public static class Highjump
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Highjump";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Allows you to jump high";
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
        public static float? _Value = 1f;
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
                }
                else
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
                    byte[] ValueAsBytes = BitConverter.GetBytes((float)Value);
                    Game.m.PatchMemory("Minecraft.Windows.exe", 0x14A4445, new byte[] { 0xC7, 0x87, 0x98, 0x04, 0x00, 0x00, ValueAsBytes[0], ValueAsBytes[1], ValueAsBytes[2], ValueAsBytes[3], 0x90, 0x90 });
                }
            }
            public static void OnDisable()
            {
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x14A4445, new byte[] { 0xF3, 0x0F, 0x59, 0xCE, 0xF3, 0x0F, 0x11, 0x8F, 0x98, 0x04, 0x00, 0x00 });
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
