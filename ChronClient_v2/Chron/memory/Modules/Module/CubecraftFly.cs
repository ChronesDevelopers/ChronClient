using ChronClient.Instance;
using ChronClient.Modules;
using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ChronClient.Module
{
    public static class CubecraftFly
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "CubecraftFly";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Allows you to bypass fly anticheat on some servers";
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

        public static void RegisterKeybind_Trigger(Key? key)
        {
            TriggerKey = key;
        }
        public static Key? TriggerKey = null;
        public static Key? ToggleKey = null;
        public static void RegisterKeybind_Toggle(Key? key)
        {
            ToggleKey = key;
            if (key != null)
            {
                KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressed);
            }
        }
        public static int Counter = 0;

        public static void Tick100()
        {
            if (ToggleState == true)
            {
                if (TriggerKey != null)
                {
                    if (cmr_input.GetKeyStateDown((Key)TriggerKey) && Module.NOKEYBINDS.CAN_USE_KEYBINDS)
                    {
                        Entity? player = LocalPlayer.entity;
                        if (player != null && player.EntityBaseAddress != 0)
                        {
                            Vector3? pos = player.XYZ;
                            if (pos != null)
                            {
                                player.Y += 0.4f;
                                player.VelY = 0f;
                            }
                            if (Counter == 1)
                            {
                                if (LocalPlayer.entity == null)
                                {
                                    return;
                                }
                                Vector3 vec = new Vector3();
                                float pitch = (float)LocalPlayer.entity.Pitch;
                                float yaw = (float)LocalPlayer.entity.Yaw;
                                yaw += 90f;
                                yaw = yaw * (float)Math.PI / 180F;
                                pitch = pitch * (float)Math.PI / 180f;
                                vec.X = (float)Math.Cos(yaw) * (float)Math.Cos(pitch);
                                vec.Y = -(float)Math.Sin(pitch);
                                vec.Z = (float)Math.Sin(yaw) * (float)Math.Cos(pitch);
                                float speed = 1.5f;
                                try
                                {
                                    LocalPlayer.entity.X += vec.X * speed;
                                    LocalPlayer.entity.Y += vec.Y * speed;
                                    LocalPlayer.entity.Z += vec.Z * speed;
                                } catch { }
                            }
                            Counter += 1;
                            Counter %= 2;
                        }
                    }
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
                if (ToggleState == true)
                {
                    if (TriggerKey != null)
                    {
                        if (cmr_input.GetKeyStateDown((Key)TriggerKey))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return ToggleState;
                }
            }
            public static void OnEnable()
            {
                Counter = 0;
            }
            public static void OnDisable()
            {
                Counter = 0;
            }

            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
