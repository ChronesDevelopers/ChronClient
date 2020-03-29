using Chrones.Cmr.MemoryManagement;

namespace ChronClient.Module
{
    public static class Airjump
    {
        //static Pointer OnGround = new Pointer("Minecraft.Windows.exe", 0x3022668, new int[] { 0x30, 0x28, 0x8, 0x1F8, 0x1F0, 0x0, 0xF0, 0x178 });

        private static bool _ToggleState = false;

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

        public static void OnEnable()
        {
            // Nop Memory
            Memory0.mem.PatchMemory("Minecraft.Windows.exe", 0x121090E, new byte[] { 0xC6, 0x87, 0x78, 0x1, 0x0, 0x0, 0x1 });
        }

        public static void OnDisable()
        {
            // Restore Memory
            Memory0.mem.PatchMemory("Minecraft.Windows.exe", 0x121090E, new byte[] { 0x44, 0x88, 0x87, 0x78, 0x01, 0x00, 0x00 });
        }
    }
}
