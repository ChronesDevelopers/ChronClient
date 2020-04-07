using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Module
{
    public static class Highjump
    {
        private static bool _ToggleState = false;

        private static float _Value = 0.8f;

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
            byte[] ValueAsBytes = BitConverter.GetBytes(_Value);
            //Debug.WriteLine($"I got that: {ValueAsBytes[3].ToString("X2")} + {ValueAsBytes[2].ToString("X2")} + {ValueAsBytes[1].ToString("X2")} + {ValueAsBytes[0].ToString("X2")}");
            // Patch
            Memory0.mem.PatchMemory("Minecraft.Windows.exe", 0x13CFB32, new byte[] { 0xC7, 0x87, 0x70, 0x04, 0x00, 0x00, ValueAsBytes[0], ValueAsBytes[1], ValueAsBytes[2], ValueAsBytes[3], 0x90, 0x90, 0x90, 0x90, 0x90 });
        }

        public static void OnDisable()
        {
            // Restore Memory
            Memory0.mem.PatchMemory("Minecraft.Windows.exe", 0x13CFB32, new byte[] { 0x0F, 0x28, 0xC8, 0xF3, 0x0F, 0x59, 0xCE, 0xF3, 0x0F, 0x11, 0x8F, 0x70, 0x04, 0x00, 0x00 });
        }

        public static void Refresh()
        {
            if (_ToggleState)
            {
                OnEnable();
            }

            if (!_ToggleState)
            {
                OnDisable();
            }
        }
    }
}
