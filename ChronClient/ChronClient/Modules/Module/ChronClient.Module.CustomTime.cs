using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Module
{
    public static class CustomTime
    {
        public static Modules.ModuleType ModuleType = new Modules.ModuleType("CustomTime", "World", true, ref _ToggleState, new Action(OnEnable), new Action(OnDisable), null, null, null, null, new Action(Refresh), new Action(Toggle));

        public static void OnLoad()
        {
            Modules.ModuleManagment.ValueRegister.RegisterModule(ModuleType);
        }

        public enum Mode
        {
            Fixed,
            Offset,
            Crazy
        }

        public static bool _ToggleState = false;

        private static int _Value = 10200;

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

        public static int Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
            }
        }

        public static void OnEnable()
        {
            byte[] WriteValue = BitConverter.GetBytes(Value);
            // Write value
            Memory0.mem.PatchMemory("Minecraft.Windows.exe", 0x175CB12, new byte[] { 0xBA, WriteValue[0], WriteValue[1], WriteValue[2], WriteValue[3], 0x90, 0x90 });
        }

        public static void OnDisable()
        {
            // Restore Memory
            Memory0.mem.PatchMemory("Minecraft.Windows.exe", 0x175CB12, new byte[] { 0x41, 0x8B, 0x90, 0x78, 0x03, 0x00, 0x00 });
        }

        public static void Toggle()
        {
            _ToggleState = !_ToggleState;
        }

        public static void Refresh()
        {
            if (ToggleState)
            {
                OnEnable();
            } else if (!ToggleState)
            {
                OnDisable();
            }
        }
    }
}
