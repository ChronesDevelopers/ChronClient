using ChronClient.Instance;
using ChronClient.Modules;
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
    public static class Killaura
    {
        public static void OnLoad()
        {
            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "Killaura";
            moduleClass.Category = "Combat";
            moduleClass.Description1 = "Attacks other players";
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
        public static KillauraMode Mode = KillauraMode.Multi;
        private static long Counter = 0;

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
                Game.m.NopMemory("Minecraft.Windows.exe", 0x655E47, 7);
            }
            public static void OnDisable()
            {
                //IntPtr lookingmode = Game.m.FindAddressWithPointer(LocalPlayer.lookingmode);
                //Memory.WriteProcessMemory(Game.m.hProc, lookingmode, (int)3, 4, out _);
                //Game.m.PatchMemory("Minecraft.Windows.exe", 0x655E47, new byte[] { 0x49, 0x89, 0x86, 0x00, 0x09, 0x00, 0x00 });
            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
            public static void OnThreadLoop()
            {
                if (ToggleState == true)
                {
                    Entity? localplayer = LocalPlayer.entity;
                    if (localplayer != null) 
                    {
                        //float? _reach = Game.Statics.SurvivalReach;
                        float? _reach = 3f;
                        if (Module.Reach.ToggleState == true)
                        {
                            _reach = 7f;
                        }
                        if (_reach == null)
                        {
                            return;
                        }
                        Entity[] entities = EntityList.GetTargetEntitiesList_Reachable((Vector3)localplayer.XYZ, (float)_reach).ToArray();
                        if (entities.Length == 0)
                        {
                            return;
                        }
                        Counter %= entities.Length;
                        if (Mode == KillauraMode.Multi)
                        {
                            Vector3? _to = entities[Counter].XYZ;
                            Vector3? _from = localplayer.XYZ;
                            if (_to == null || _from == null)
                            {
                                return;
                            }
                            //Vector3 to = (Vector3)_to;
                            //Vector3 from = (Vector3)_from;
                            //Debug.WriteLine(entities[Counter].UserName + $" {localplayer.UserName} {_reach} {Math.Round((float)Math.Sqrt((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y) + (to.Z - from.Z) * (to.Z - from.Z)), 2)}");
                            IntPtr lookingobj = Game.m.FindAddressWithPointer(LocalPlayer.lookingobj);
                            IntPtr lookingmode = Game.m.FindAddressWithPointer(LocalPlayer.lookingmode);
                            
                            Game.m.NopMemory("Minecraft.Windows.exe", 0x655E47, 7);
                            Game.m.NopMemory("Minecraft.Windows.exe", 0x650307, 4);
                            Memory.WriteProcessMemory(Game.m.hProc, lookingobj, (ulong)entities[Counter].EntityBaseAddress, 8, out _);
                            Memory.WriteProcessMemory(Game.m.hProc, lookingmode, (int)1, 4, out _);
                            Memory.WriteProcessMemory(Game.m.hProc, lookingobj, (ulong)entities[Counter].EntityBaseAddress, 8, out _);
                            Task.Delay(1);
                            Memory.WriteProcessMemory(Game.m.hProc, lookingmode, (int)1, 4, out _);
                            Memory.WriteProcessMemory(Game.m.hProc, lookingobj, (ulong)entities[Counter].EntityBaseAddress, 8, out _);
                            Task.Delay(1);
                            Memory.WriteProcessMemory(Game.m.hProc, lookingmode, (int)3, 4, out _);
                            Memory.WriteProcessMemory(Game.m.hProc, lookingobj, (ulong)0x00000000, 8, out _);
                            Game.m.PatchMemory("Minecraft.Windows.exe", 0x655E47, new byte[] { 0x49, 0x89, 0x86, 0x00, 0x09, 0x00, 0x00 });
                            Game.m.PatchMemory("Minecraft.Windows.exe", 0x650307, new byte[] { 0x48, 0x89, 0x41, 0x38 });

                            //Console.WriteLine(string.Format("{0:x2} ", entities[Counter].EntityBaseAddress));
                        }
                        Counter += 1;

                        if (Mode == KillauraMode.Single)
                        {

                        }
                    }
                }
            }
        }
        public enum KillauraMode
        {
            Single = 0,
            Multi = 1
        }
    }
}