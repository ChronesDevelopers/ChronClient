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
    public static class Scaffold
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Scaffold";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Makes brigding much easier";
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

        public static void Tick10()
        {
            if (ToggleState == true)
            {
                try
                {
                    Entity? player = LocalPlayer.entity;
                    if (player != null)
                    {
                        float? pitch = player.Pitch;
                        float? yaw = player.Yaw;
                        if (pitch != null && yaw != null)
                        {
                            if (pitch > 20f)
                            {
                                if (yaw < -45f && yaw > -135f)
                                    Game.m.WriteMemory(LocalPlayer.blockmode, 5);
                                else if ((yaw <= 0f && yaw >= -45f) || (yaw >= 0f && yaw <= 45f))
                                    Game.m.WriteMemory(LocalPlayer.blockmode, 3);
                                else if (yaw > 45f && yaw < 135f)
                                    Game.m.WriteMemory(LocalPlayer.blockmode, 4);
                                else if (yaw >= 135f && yaw <= 180f || (yaw >= -180f && yaw <= -135))
                                    Game.m.WriteMemory(LocalPlayer.blockmode, 2);
                            }
                        }
                    }
                } catch { }
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
                
            }
            public static void OnDisable()
            {

                
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
