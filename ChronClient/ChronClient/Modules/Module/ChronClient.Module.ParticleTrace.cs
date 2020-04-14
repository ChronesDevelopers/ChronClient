using Chrones.Cmr.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Module
{
    public static class ParticleTrace
    {
        public static Modules.ModuleType ModuleType = new Modules.ModuleType("ParticleTrace", "World", true, ref _ToggleState, new Action(OnEnable), new Action(OnDisable), null, null, new Action(Tick100), null, null, new Action(Toggle));

        public static void OnEnable()
        {
            ToggleState = true;
        }

        public static void OnDisable()
        {
            ToggleState = false;
        }

        public static void OnLoad()
        {
            Modules.ModuleManagment.ValueRegister.RegisterModule(ModuleType);
        }

        static Pointer ParticleTracePointer = new Pointer("Minecraft.Windows.exe", 0x3036708, new int[] { 0x20, 0x08, 0x18, 0x58, 0x78, 0x420, 0x78, 0x194 });

        private static float _Value = 5f;

        public static bool _ToggleState = false;

        public static bool ToggleState
        {
            get { return _ToggleState; }
            set
            {
                _ToggleState = value;
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

        public static void Tick100()
        {
            if (_ToggleState)
            {
                Memory0.mem.WriteMemory(ParticleTracePointer, _Value);
            }
        }

        public static void Toggle()
        {
            _ToggleState = !_ToggleState;
        }
    }
}
