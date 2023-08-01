using ChronClient.Instance;
using ChronClient.Modules;
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
    public static class DirectionalBoost
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "DirectionalBoost";
            moduleClass.Category = "Movement";
            moduleClass.Description1 = "Allows you to boost in the direction you are looking at";
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
        public static Key? TriggerKey = null;
        public static void RegisterKeybind_Trigger(Key? key)
        {
            TriggerKey = key;
            if (key != null)
            {
                KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressedTrigger);
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
                    try
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
                        LocalPlayer.entity.VelX = vec.X * speed;
                        LocalPlayer.entity.VelY = vec.Y * speed;
                        LocalPlayer.entity.VelZ = vec.Z * speed;
                    }
                    catch { }
                }
            }
        }
    }
}
