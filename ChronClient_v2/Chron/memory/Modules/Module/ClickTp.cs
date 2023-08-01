using ChronClient.Instance;
using ChronClient.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ChronClient.Module
{
    public static class ClickTp
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "ClickTp";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Teleports you above the block you are looking at";
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
            if (TriggerKey != null)
            {
                KeyBindListener.RegisterKeyBind((Key)TriggerKey, Events.OnKeyPressedTrigger);
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
            if (key != null)
            {
                KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressedTrigger);
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

            public static void OnKeyPressedTrigger()
            {
                if (ToggleState == true)
                {
                    Debug.WriteLine("CLICK");
                    if (Game.m.ReadInt(LocalPlayer.lookingmode) == 0)
                    {
                        Entity? player = LocalPlayer.entity;
                        Vector3 vec = new Vector3(Game.m.ReadInt(LocalPlayer.looking_at_block_X), Game.m.ReadInt(LocalPlayer.looking_at_block_Y), Game.m.ReadInt(LocalPlayer.looking_at_block_Z));
                        if (player != null)
                        {
                            if   (!(vec.X == 0 &&
                                    vec.Y == 0 && 
                                    vec.Z == 0))
                            {
                                vec.Y += 1f;
                                vec.X += 0.5f;
                                vec.Z += 0.5f;
                                Debug.WriteLine("SET");
                                player.XYZ = vec;
                            }
                        }
                    } else if (Game.m.ReadInt(LocalPlayer.lookingmode) == 1)
                    {
                        Entity? player = LocalPlayer.entity;
                        Entity? targetplayer = new Entity(Game.m.ReadUnsignedLong(LocalPlayer.lookingobj));
                        if (player != null && targetplayer != null && targetplayer.EntityBaseAddress != 0)
                        {
                            float? X = targetplayer.X;
                            float? Y = targetplayer.Y;
                            float? Z = targetplayer.Z;
                            if (!(X == 0.3f &&
                                    Y == 0 &&
                                    Z == 0.3f))
                            {
                                Vector3 vec = new Vector3((float)X, (float)Y, (float)Z);
                                player.XYZ = vec;
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
                        Name = "ClickTp_ToggleState",
                        Value = _ToggleState
                    },
                    new File.ProfileClassSetting
                    {
                        Name = "ClickTp_ToggleKey",
                        Value = ToggleKey
                    },
                    new File.ProfileClassSetting
                    {
                        Name = "ClickTp_TriggerKey",
                        Value = TriggerKey
                    }
                };
                return settings;
            }
        }
    }
}
