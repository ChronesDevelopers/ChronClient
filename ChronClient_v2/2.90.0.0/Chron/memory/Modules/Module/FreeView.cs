using ChronClient.Instance;
using ChronClient.Modules;
using Chrones.Cmr;
using Chrones.Cmr.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Module
{
    public static class FreeView
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "FreeView";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Allows you to look arround (clientside)";
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
                        if (Mode == FreeViewMode.Toggle)
                        {
                            Events.OnEnable();
                        }
                    }
                    if (value == false || value == null)
                    {
                        if (Mode == FreeViewMode.Toggle)
                        {
                            Events.OnDisable();
                        }
                    }
                }
                _ToggleState = value;
            }
        }
        public static void Refresh()
        {
            if (Mode == FreeViewMode.Toggle)
            {
                if (ToggleState == true)
                {
                    Events.OnEnable();
                }
                else
                {
                    Events.OnDisable();
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
        public static Key? TriggerKey = null;
        public static void RegisterKeybind_Trigger(Key? key)
        {
            TriggerKey = key;
            if (key != null)
            {
                //KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressedTrigger);
            }
        }
        public static FreeViewMode Mode = FreeViewMode.Trigger;
        static bool LastTriggerState = false;
        static int LastPerspective = 0;

        public static bool ChangePerspective = true;
        public static void Tick10()
        {
            if (Mode == FreeViewMode.Trigger)
            {
                if (TriggerKey != null)
                {
                    if (cmr_input.GetKeyStateDown((Key)TriggerKey) && Module.NOKEYBINDS.CAN_USE_KEYBINDS)
                    {
                        if (!LastTriggerState)
                        {
                            Events.OnEnable();
                            if (ChangePerspective)
                            {
                                LastPerspective = Game.m.ReadInt(LocalPlayer.PerspectivePointer);
                                Game.m.WriteMemory(LocalPlayer.PerspectivePointer, (int)1);
                            }
                        }
                        LastTriggerState = true;
                    }
                    else if (LastTriggerState)
                    {
                        Events.OnDisable();
                        LastTriggerState = false;
                        if (ChangePerspective && LastPerspective != -1)
                        {
                            Game.m.WriteMemory(LocalPlayer.PerspectivePointer, LastPerspective);
                            LastPerspective = -1;
                        }
                    }
                    else
                    {
                        LastTriggerState = false;
                    }
                } else
                {
                    LastTriggerState = false;
                }
            }
            else
            {
                LastTriggerState = false;
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
                if (Mode == FreeViewMode.Toggle)
                {
                    return ToggleState;
                } else if (Mode == FreeViewMode.Trigger)
                {
                    if (TriggerKey.HasValue)
                    {
                        return cmr_input.GetKeyStateDown((Key)TriggerKey);
                    }
                    else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                }
            }
            public static void OnEnable()
            {
                Game.m.NopMemory("Minecraft.Windows.exe", 0x130FAD2, 6);
                Game.m.NopMemory("Minecraft.Windows.exe", 0x130FAC7, 2);
                Game.m.NopMemory("Minecraft.Windows.exe", 0x09587B2, 8);
                Game.m.NopMemory("Minecraft.Windows.exe", 0x095800A, 8);
            }
            public static void OnDisable()
            {
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x130FAD2, new byte[] { 0x89, 0x87, 0x00, 0x01, 0x00, 0x00 });
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x130FAC7, new byte[] { 0x89, 0x01 });
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x09587B2, new byte[] { 0xF3, 0x0F, 0x11, 0x83, 0x28, 0x06, 0x00, 0x00 });
                Game.m.PatchMemory("Minecraft.Windows.exe", 0x095800A, new byte[] { 0xF3, 0x0F, 0x11, 0x83, 0x28, 0x06, 0x00, 0x00 });
            }
            public static void OnKeyPressed()
            {
                if (Mode == FreeViewMode.Toggle)
                {
                    ToggleState = !ToggleState;
                }
            }
        }

        public enum FreeViewMode
        {
            Toggle,
            Trigger
        }
    }
}
