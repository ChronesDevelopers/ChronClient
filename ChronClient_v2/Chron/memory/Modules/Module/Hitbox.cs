using ChronClient.Instance;
using ChronClient.Modules;
using ChronClient.Threads;
using Chrones.Cmr;
using Chrones.Cmr.Main;
using Chrones.Cmr.MemoryManagement;
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
    public static class Hitbox
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Hitbox";
            moduleClass.Category = "Combat";
            moduleClass.Description1 = "Makes the Hitbox of the enemies bigger";
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

        public static float? _Value = 8f;
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
        public static bool? OnlyWhenReachable = true;
        public static void RegisterKeybind_Toggle(Key? key)
        {
            ToggleKey = key;
            if (key != null)
            {
                KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressed);
            }
        }

        public static void Tick100()
        {
            if (ToggleState == true)
            {
                if (Value != null)
                {
                    if (OnlyWhenReachable == true)
                    {
                        List<Entity> entities = EntityListUpdate.Entities;
                        Entity? player = LocalPlayer.entity;
                        if (player != null)
                        {

                            foreach (Entity entity in entities)
                            {
                                if (entity.Exists)
                                {
                                    if (entity.HitBoxWidth != Value)
                                    {
                                        Vector3? from = player.XYZ;
                                        Vector3? to = entity.XYZ;
                                        if (from != null && to != null)
                                        {
                                            if ((float)cmr_math.GetDistance((Vector3)from, (Vector3)to) <= 7.5f)
                                            {
                                                if (ToggleState == true)
                                                {
                                                    entity.HitBoxWidth = Value;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Vector3? from = player.XYZ;
                                        Vector3? to = entity.XYZ;
                                        if (from != null && to != null)
                                        {
                                            if ((float)cmr_math.GetDistance((Vector3)from, (Vector3)to) > 7.5f)
                                            {
                                                if (ToggleState == true)
                                                {
                                                    entity.HitBoxWidth = 0.6f;
                                                }
                                                else
                                                {
                                                    continue;
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
                        List<Entity> entities = EntityListUpdate.Entities;
                        foreach (Entity entity in entities)
                        {
                            if (entity.Exists)
                            {
                                if (ToggleState == true)
                                {
                                    entity.HitBoxWidth = Value;
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
                return ToggleState;
            }
            public static void OnEnable()
            {
                if (Value != null)
                {
                    if (OnlyWhenReachable == true)
                    {
                        List<Entity> entities = EntityListUpdate.Entities;
                        Entity? player = LocalPlayer.entity;
                        if (player != null)
                        {

                            foreach (Entity entity in entities)
                            {
                                if (entity.Exists)
                                {
                                    if (entity.HitBoxWidth != Value)
                                    {
                                        Vector3? from = player.XYZ;
                                        Vector3? to = entity.XYZ;
                                        if (from != null && to != null)
                                        {
                                            if ((float)cmr_math.GetDistance((Vector3)from, (Vector3)to) <= 7.5f)
                                            {
                                                if (ToggleState == true)
                                                {
                                                    entity.HitBoxWidth = Value;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Vector3? from = player.XYZ;
                                        Vector3? to = entity.XYZ;
                                        if (from != null && to != null)
                                        {
                                            if ((float)cmr_math.GetDistance((Vector3)from, (Vector3)to) > 7.5f)
                                            {
                                                if (ToggleState == true)
                                                {
                                                    entity.HitBoxWidth = 0.8f;
                                                }
                                                else
                                                {
                                                    continue;
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
                        List<Entity> entities = EntityListUpdate.Entities;
                        foreach (Entity entity in entities)
                        {
                            if (entity.Exists)
                            {
                                if (ToggleState == true)
                                {
                                    entity.HitBoxWidth = Value;
                                }
                            }
                        }
                    }
                }
            }
            public static void OnDisable()
            {
                List<Entity> entities = EntityList.GetEntityList();
                foreach (Entity entity in entities)
                {
                    entity.HitBoxWidth = 0.8f;
                }
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
