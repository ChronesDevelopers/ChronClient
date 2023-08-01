using ChronClient.Instance;
using ChronClient.Modules;
using Chrones.Cmr;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChronClient.Module
{
    public static class Reverse
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Reverse";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Reverse esrveeR";
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
        public static uint Lenght = 10000;
        public static int DezimalsEndings = 3;
        public static Key? ToggleKey = null;
        public static Key? TriggerKey = null;
        public static void RegisterKeybind_Toggle(Key? key)
        {
            ToggleKey = key;
            if (key != null)
            {
                KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressed);
            }
        }
        public static void RegisterKeybind_Trigger(Key? key)
        {
            TriggerKey = key;
        }
        public static List<Vector3?> LastVectors = null;

        public static void Tick10()
        {
            if (ToggleState == true)
            {
                if (LastVectors != null)
                {
                    Entity player = LocalPlayer.entity;
                    if (player == null)
                    {
                        return;
                    }
                    Vector3? vec;
                    if (DezimalsEndings != 0)
                    {
                        vec = new Vector3((float)Math.Round((double)player.X, DezimalsEndings), (float)Math.Round((double)player.Y, DezimalsEndings + 1), (float)Math.Round((double)player.Z, DezimalsEndings));
                    }
                    else
                    {
                        vec = new Vector3((float)player.X, (float)player.Y, (float)player.Z);
                    }
                    if (player != null)
                    {
                        if (TriggerKey == null)
                        {
                            if (LastVectors.Count == 0)
                            {
                                LastVectors.Add(vec);
                            }
                            else
                            {
                                if (LastVectors.ElementAt(0) != vec)
                                {
                                    LastVectors.Insert(0, vec);
                                    while (LastVectors.Count > Lenght)
                                    {
                                        LastVectors.RemoveAt(-1);
                                    }
                                }
                            }
                        } else
                        {
                            if (cmr_input.GetKeyStateDown((Key)TriggerKey) && Module.NOKEYBINDS.CAN_USE_KEYBINDS)
                            {
                                if (LastVectors.Count != 0) 
                                {
                                    Vector3? to = LastVectors.ElementAt(0);
                                    if (vec != null && to != null)
                                    {
                                        if (cmr_math.GetDistance(new Vector2((float)player.X, (float)player.Z), new Vector2((float)to.Value.X, (float)to.Value.Z)) < 7f)
                                        {
                                            player.XYZ = to.Value;
                                            player.VelX = 0f;
                                            player.VelY = 0f;
                                            player.VelZ = 0f;
                                            LastVectors.RemoveAt(0);
                                        }
                                    }
                                }
                            } else
                            {
                                if (LastVectors.Count == 0)
                                {
                                    LastVectors.Add(vec);
                                }
                                else
                                {
                                    if (LastVectors.ElementAt(0) != vec)
                                    {
                                        LastVectors.Insert(0, vec);
                                        while (LastVectors.Count > Lenght)
                                        {
                                            LastVectors.RemoveAt(-1);
                                        }
                                    }
                                }
                            }
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
                if (ToggleState != true)
                {
                    return false;
                } else
                {
                    if (TriggerKey.HasValue)
                    {
                        if (cmr_input.GetKeyStateDown((Key)TriggerKey))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public static void OnEnable()
            {
                LastVectors = new List<Vector3?>();
            }
            public static void OnDisable()
            {
                LastVectors = null;
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}