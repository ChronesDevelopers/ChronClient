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
    public static class NoSwing
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "NoSwing";
            moduleClass.Category = "Player";
            moduleClass.Description1 = "Disables Swinging (Clientside)";
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
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x953824, new byte[] { 0xC6, 0x83, 0x9C, 0x06, 0x00, 0x00, 0x00 });
            }
            public static void OnDisable()
            {

                Game.m.PatchMemory("Minecraft.Windows.exe", 0x953824, new byte[] { 0xC6, 0x83, 0x9C, 0x06, 0x00, 0x00, 0x01 });
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
