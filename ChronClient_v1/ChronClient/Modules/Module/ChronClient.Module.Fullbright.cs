using Chrones.Cmr.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Module
{
    public static class Fullbright
    {
        public static Modules.ModuleType ModuleType = new Modules.ModuleType("Fullbright", "World", true, ref _ToggleState, new Action(OnEnable), new Action(OnDisable), null, null, null, null, new Action(Refresh), new Action(Toggle));

        public static void OnLoad()
        {
            Modules.ModuleManagment.ValueRegister.RegisterModule(ModuleType);
        }

        static Pointer Brightness = new Pointer("Minecraft.Windows.exe", 0x2FFECD8, new int[] { 0xC0, 0x20, 0xB0, 0x138, 0xF0 });

        public static bool _ToggleState = false;

        private static float _Value = 0.45f;

        public static bool ToggleState
        {
            get { return _ToggleState; }
            set
            {
                if (_ToggleState != value)
                {
                    if (value)
                    {
                        OnEnable();
                        _ToggleState = value;
                    }
                    else if (!value)
                    {
                        OnDisable();
                        _ToggleState = value;
                    }
                }
            }
        }

        public static float Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
            }
        }

        public static void OnEnable()
        {
            Memory0.mem.WriteMemory(Brightness, _Value);
        }

        public static void OnDisable()
        {
            Memory0.mem.WriteMemory(Brightness, 1f);
        }

        public static void Tick1000()
        {
            if (_ToggleState)
            {
                Memory0.mem.WriteMemory(Brightness, _Value);
            }
        }

        public static void Refresh()
        {
            if (_ToggleState)
            {
                OnEnable();
            } else if (!_ToggleState)
            {
                OnDisable();
            }
        }

        public static void Toggle()
        {
            _ToggleState = !_ToggleState;
        }
    }
}
