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
using System.Windows.Media.Animation;

namespace ChronClient.Module
{
    public static class Antivoid
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Antivoid";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Prevents you to fall into the void";
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

        public static Key? ToggleKey = null;
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
            if (key != null)
            {
                KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressedTrigger);
            }
        }

        public static Key? TriggerKey = null;

        public static class Values
        {
            public static float? _MaxFallValue = 2f;
            public static float? MaxFallValue
            {
                get
                {
                    return _MaxFallValue;
                }
                set
                {
                    if (value != null)
                    {
                        _MaxFallValue = value;
                    }
                    else
                    {
                        _MaxFallValue = 10f;
                    }
                }
            }
            public static float? _MinCoordinateValue = 2f;
            public static float? MinCoordinateValue
            {
                get
                {
                    return _MinCoordinateValue;
                }
                set
                {
                    if (value != null)
                    {
                        _MinCoordinateValue = value;
                    } else
                    {
                        _MinCoordinateValue = 1f;
                    }
                }
            }
            public static AntivoidMode Mode = AntivoidMode.AutomaticWithTriggerDisableAuto;
            public static Vector3? LastOnGroundPosition = null;
            public static Vector3? LastOnGroundPosition2 = null;
            public static Vector3? LastOnGroundPosition3 = null;
            public static Vector3? LastOnGroundPosition4 = null;
            public static Vector3? LastOnGroundPosition5 = null;
            public static Vector3? LastOnGroundPosition6 = null;
        }

        public static void Tick100()
        {
            if (ToggleState == true)
            {
                try
                {

                    Entity? player = LocalPlayer.entity;
                    if (player != null && player.EntityBaseAddress != 0)
                    {
                        Vector3? position = player.XYZ;

                        if (player.OnGround == true)
                        {
                            Values.LastOnGroundPosition6 = Values.LastOnGroundPosition5;
                            Values.LastOnGroundPosition5 = Values.LastOnGroundPosition4;
                            Values.LastOnGroundPosition4 = Values.LastOnGroundPosition3;
                            Values.LastOnGroundPosition3 = Values.LastOnGroundPosition2;
                            Values.LastOnGroundPosition2 = Values.LastOnGroundPosition;
                            Values.LastOnGroundPosition = position;
                        } else
                        {
                            if (Values.Mode == AntivoidMode.AutomaticWithTriggerDisableAuto)
                            {
                                if (!cmr_input.GetKeyStateDown((Key)TriggerKey) && Module.NOKEYBINDS.CAN_USE_KEYBINDS)
                                {
                                    if (position.HasValue == true && Values.LastOnGroundPosition.HasValue == true && player.OnGround == false)
                                    {
                                        if (cmr_math.GetDistance(new Vector2 { X = position.Value.X, Y = position.Value.Z }, new Vector2 { X = Values.LastOnGroundPosition.Value.X, Y = Values.LastOnGroundPosition.Value.Z }) < 25)
                                        {
                                            if (Values.LastOnGroundPosition.Value.Y > position.Value.Y)
                                            {
                                                if ((Values.LastOnGroundPosition.Value.Y - position.Value.Y) > 5)
                                                {
                                                    //player.X = (float)Math.Round(Values.LastOnGroundPosition.Value.X, 0) + 0.5f;
                                                    //player.Z = (float)Math.Round(Values.LastOnGroundPosition.Value.Z, 0) + 0.5f;
                                                    //player.Y = Values.LastOnGroundPosition.Value.Y;
                                                    player.XYZ = Values.LastOnGroundPosition5.Value;
                                                    player.VelX = 0f;
                                                    player.VelY = 0f;
                                                    player.VelZ = 0f;
                                                    player.XYZ = Values.LastOnGroundPosition5.Value;
                                                    player.VelX = 0f;
                                                    player.VelY = 0f;
                                                    player.VelZ = 0f;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Values.LastOnGroundPosition = null;
                    }
                }
                catch { }
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
                Values.LastOnGroundPosition = null;
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }

            public static void OnKeyPressedTrigger()
            {
                if (Values.Mode == AntivoidMode.TriggerOnly)
                {
                    if (Values.LastOnGroundPosition != null) 
                    {
                        Entity player = LocalPlayer.entity;
                        if (player != null && player.EntityBaseAddress != 0)
                        {
                            Vector3? position = player.XYZ;

                            if (position.HasValue == true && Values.LastOnGroundPosition.HasValue == true && player.OnGround == false)
                            {
                                if (cmr_math.GetDistance(new Vector2 { X = position.Value.X, Y = position.Value.Z }, new Vector2 { X = Values.LastOnGroundPosition.Value.X, Y = Values.LastOnGroundPosition.Value.Z }) < 25)
                                {
                                    if (Values.LastOnGroundPosition.Value.Y > position.Value.Y)
                                    {
                                        //player.X = (float)Math.Round(Values.LastOnGroundPosition.Value.X, 0) + 0.5f;
                                        //player.Z = (float)Math.Round(Values.LastOnGroundPosition.Value.Z, 0) + 0.5f;
                                        //player.Y = Values.LastOnGroundPosition.Value.Y;
                                        player.XYZ = Values.LastOnGroundPosition5.Value;
                                        player.VelX = 0f;
                                        player.VelY = 0f;
                                        player.VelZ = 0f;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static class Profile
        {
            public static ChronClient.File.ProfileClassSetting[] GetSettings()
            {
                File.ProfileClassSetting[] settings = new ChronClient.File.ProfileClassSetting[]
                {
                    new File.ProfileClassSetting
                    {
                        Name = "Antivoid_ToggleState",
                        Value = _ToggleState
                    },
                    new File.ProfileClassSetting
                    {
                        Name = "Antivoid_ToggleKey",
                        Value = ToggleKey
                    },
                    new File.ProfileClassSetting
                    {
                        Name = "Antivoid_TriggerKey",
                        Value = TriggerKey
                    }
                };
                return settings;
            }
        }

        public enum AntivoidMode
        {
            TriggerOnly,
            AutomaticWithTriggerDisableAuto
        }
    }
}
