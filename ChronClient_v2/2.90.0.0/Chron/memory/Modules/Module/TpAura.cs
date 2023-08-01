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
using System.Windows.Input;

namespace ChronClient.Module
{
    public static class TpAura
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "TpAura";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Ultra Op";
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
        //public static Entity? TARGET_ENTITY = new Entity(0x00000261131AA060);

        public static void Tick10()
        {
            if (ToggleState == true && TriggerKey != null)
            {
                if (cmr_input.GetKeyStateDown((Key)TriggerKey) && Module.NOKEYBINDS.CAN_USE_KEYBINDS)
                {
                    Entity? target_player = new Entity(Game.m.ReadUnsignedLong(LocalPlayer.lookingobj));
                    if (target_player != null && target_player.Exists && target_player.EntityBaseAddress != 0)
                    {
                        Entity? player = LocalPlayer.entity;
                        if (player != null)
                        {
                            float? target_X = target_player.X;
                            float? target_Y = target_player.Y;
                            float? target_Z = target_player.Z;
                            if (!(target_X == 0.3f &&
                                  target_Y == 0 &&
                                  target_Z == 0.3f))
                            {
                                Vector2 LookingVec = (Vector2)target_player.LookingVectorXY;
                                if (cmr_math.GetDistance((Vector3)player.XYZ, new Vector3((float)target_X, (float)target_Y, (float)target_Z)) < 15)
                                {
                                    if (target_player.HitBoxWidth != 0.6f && target_player.HitBoxWidth != 0.8f)
                                    {
                                        player.X = ((LookingVec.X * -1f) * 2f) + (float)target_X + (target_player.HitBoxWidth / 2);
                                        player.Y = (float)target_Y;
                                        player.Z = ((LookingVec.Y * -1f) * 2f) + (float)target_Z + (target_player.HitBoxWidth / 2);
                                        player.VelY = 0f;
                                        float yaw = (float)player.Yaw;
                                    } else
                                    {
                                        player.X = ((LookingVec.X * -1f) * 2f) + (float)target_X;
                                        player.Y = (float)target_Y;
                                        player.Z = ((LookingVec.Y * -1f) * 2f) + (float)target_Z;
                                        float yaw = (float)player.Yaw;
                                        player.VelY = 0f;
                                    }
                                    //if (Game.m.ReadUnsignedLong(LocalPlayer.lookingobj) == 0)
                                    //{
                                    //    Game.m.WriteMemory(LocalPlayer.first_person_yaw, InvertAxes(yaw) / Math.PI * 180);
                                    //}
                                }
                            }
                        }
                    } 
                }
            }
        }

        public static float InvertAxes(float x)
        {
            return (((x + 360f) % 360f) - 180f);
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
                if (TriggerKey != null)
                {
                    if (Module.NOKEYBINDS.CAN_USE_KEYBINDS)
                    {
                        if (cmr_input.GetKeyStateDown((Key)TriggerKey))
                        {
                            return true;
                        }
                    }
                    return false;
                } else
                {
                    return false;
                }
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
