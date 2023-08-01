using Chrones.Cmr.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Module
{
    public static class Teleport
    {
        static Pointer X1_Position = new Pointer("Minecraft.Windows.exe", 0x30366F8, new int[] { 0x0, 0x20, 0x88, 0x434 - 4  });
        static Pointer Y1_Position = new Pointer("Minecraft.Windows.exe", 0x30366F8, new int[] { 0x0, 0x20, 0x88, 0x434      });
        static Pointer Z1_Position = new Pointer("Minecraft.Windows.exe", 0x30366F8, new int[] { 0x0, 0x20, 0x88, 0x434 + 4  });
        static Pointer X2_Position = new Pointer("Minecraft.Windows.exe", 0x30366F8, new int[] { 0x0, 0x20, 0x88, 0x434 + 8  });
        static Pointer Y2_Position = new Pointer("Minecraft.Windows.exe", 0x30366F8, new int[] { 0x0, 0x20, 0x88, 0x434 + 12 });
        static Pointer Z2_Position = new Pointer("Minecraft.Windows.exe", 0x30366F8, new int[] { 0x0, 0x20, 0x88, 0x434 + 13 });

        public static void SetPosition(float X, float Y, float Z)
        {
            Memory0.mem.WriteMemory(X1_Position, X - 0.3f);
            Memory0.mem.WriteMemory(Y1_Position, X);
            Memory0.mem.WriteMemory(Z1_Position, X - 0.3f);
            Memory0.mem.WriteMemory(X2_Position, X + 0.3f);
            Memory0.mem.WriteMemory(Y2_Position, X + 1.8f);
            Memory0.mem.WriteMemory(Z2_Position, X + 0.3f);
        }

        public static void SetPosition(float X, float Y, float Z, bool SetX, bool SetY, bool SetZ)
        {
            if (SetX)
            {
                Memory0.mem.WriteMemory(X1_Position, X - 0.3f);
                Memory0.mem.WriteMemory(X2_Position, X + 0.3f);
            }

            if (SetY)
            {
                Memory0.mem.WriteMemory(Y1_Position, X);
                Memory0.mem.WriteMemory(Y2_Position, X + 1.8f);
            }

            if (SetZ)
            {
                Memory0.mem.WriteMemory(Z1_Position, X - 0.3f);
                Memory0.mem.WriteMemory(Z2_Position, X + 0.3f);
            }
        }

        public static void SetPosition(Vector3 Position, bool SetX, bool SetY, bool SetZ)
        {
            if (SetX)
            {
                Memory0.mem.WriteMemory(X1_Position, Position.X - 0.3f);
                Memory0.mem.WriteMemory(X2_Position, Position.X + 0.3f);
            }

            if (SetY)
            {
                Memory0.mem.WriteMemory(Y1_Position, Position.Y);
                Memory0.mem.WriteMemory(Y2_Position, Position.Y + 1.8f);
            }

            if (SetZ)
            {
                Memory0.mem.WriteMemory(Z1_Position, Position.Z - 0.3f);
                Memory0.mem.WriteMemory(Z2_Position, Position.Z + 0.3f);
            }
        }

        public static void SetPosition(Vector3 Position)
        {
            Memory0.mem.WriteMemory(X1_Position, Position.X - 0.3f);
            Memory0.mem.WriteMemory(Y1_Position, Position.Y);
            Memory0.mem.WriteMemory(Z1_Position, Position.Z - 0.3f);
            Memory0.mem.WriteMemory(X2_Position, Position.X + 0.3f);
            Memory0.mem.WriteMemory(Y2_Position, Position.Y + 1.8f);
            Memory0.mem.WriteMemory(Z2_Position, Position.Z + 0.3f);
        }

        public static Vector3 GetPosition()
        {
            Vector3 Position;
            Position.X = Memory0.mem.ReadFloat(X1_Position) + 0.3f;
            Position.Y = Memory0.mem.ReadFloat(Y1_Position);
            Position.Z = Memory0.mem.ReadFloat(Z1_Position) + 0.3f;

            return Position;
        }

        public static float GetPositionX()
        {
            float Position;
            Position = Memory0.mem.ReadFloat(X1_Position);
            return Position;
        }

        public static float GetPositionY()
        {
            float Position;
            Position = Memory0.mem.ReadFloat(Y1_Position);
            return Position;
        }

        public static float GetPositionZ()
        {
            float Position;
            Position = Memory0.mem.ReadFloat(Z1_Position);
            return Position;
        }

        public static float GetPositionX2()
        {
            float Position;
            Position = Memory0.mem.ReadFloat(X2_Position);
            return Position;
        }

        public static float GetPositionY2()
        {
            float Position;
            Position = Memory0.mem.ReadFloat(Y2_Position);
            return Position;
        }

        public static float GetPositionZ2()
        {
            float Position;
            Position = Memory0.mem.ReadFloat(Z2_Position);
            return Position;
        }
    }
}
