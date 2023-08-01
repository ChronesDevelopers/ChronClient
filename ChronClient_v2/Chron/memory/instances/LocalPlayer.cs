using Chrones.Cmr.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Instance
{
    public static class LocalPlayer
    {
#nullable enable
        public static readonly Pointer pointer = new Pointer("Minecraft.Windows.exe", 0x36E7688, new int[] { 0x8, 0x20, 0xC0, 0x0 });
        public static readonly Pointer lookingmode = new Pointer("Minecraft.Windows.exe", 0x369D0A8, new int[] { 0xA8, 0x18, 0x10, 0x8E0 });
        public static readonly Pointer lookingobj = new Pointer("Minecraft.Windows.exe", 0x369D0F0, new int[] { 0xA8, 0x18, 0x130, 0x6D0, 0x0, 0x900 });
        public static readonly Pointer blockmode = new Pointer("Minecraft.Windows.exe", 0x369D0F0, new int[] { 0xA8, 0x18, 0x130, 0x6D0, 0x0, 0x8E4 });
        public static readonly Pointer looking_at_block_X = new Pointer("Minecraft.Windows.exe", 0x369D0F0, new int[] { 0xA8, 0x18, 0x130, 0x6D0, 0x0, 0x8E8 });
        public static readonly Pointer looking_at_block_Y = new Pointer("Minecraft.Windows.exe", 0x369D0F0, new int[] { 0xA8, 0x18, 0x130, 0x6D0, 0x0, 0x8EC });
        public static readonly Pointer looking_at_block_Z = new Pointer("Minecraft.Windows.exe", 0x369D0F0, new int[] { 0xA8, 0x18, 0x130, 0x6D0, 0x0, 0x8F0 });
        public static readonly Pointer first_person_yaw = new Pointer("Minecraft.Windows.exe", 0x36A1B88, new int[] { 0x10, 0x128, 0x0, 0x128, 0x28, 0x38, 0x168, 0x0, 0x10 });
        public static readonly Pointer first_person_pitch = new Pointer("Minecraft.Windows.exe", 0x36A1B88, new int[] { 0x10, 0x128, 0x0, 0x128, 0x28, 0x38, 0x168, 0x0, 0x14 });
        public static Pointer PerspectivePointer = new Pointer("Minecraft.Windows.exe", 0x36A1C38, new int[] { 0xC0, 0x828, 0x8, 0x40, 0x20, 0xF0 });

        public static Pointer AtOffset(int offset)
        {
            return new Pointer("Minecraft.Windows.exe", 0x3055650, new int[] { 0xA8, 0x18, 0xC8, offset });
        }
        public static Entity? entity
        {
            get
            {
                try
                {
                    IntPtr addr = Game.m.FindAddressWithPointer(pointer);
                    if (addr != (IntPtr)null || addr != (IntPtr)0)
                    {
                        return new Entity((ulong)addr);
                    }
                    else
                    {
                        return null;
                    }
                } catch { return null; }
            }
        }
#nullable disable
    }
}
