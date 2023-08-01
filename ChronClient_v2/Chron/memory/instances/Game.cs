using Chrones.Cmr.MemoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ChronClient
{
    public static class Game
    {
        public static Memory m;
        public static class Statics
        {
            // Reach Gamemode 0/2
            // Reach Gamemode 1
            public static float? AirAccelaretion_Sprinting { get { try { return Game.m.ReadFloat(Game.m.GetModuleBaseAddress("Minecraft.Windows.exe") + 0x20D8504); } catch { return null; } } set { if (value == null) { return; } try { Game.m.WriteMemory(Game.m.GetModuleBaseAddress("Minecraft.Windows.exe") + 0x20D8504, value); } catch { } } }
            public static float? SurvivalReach { get { try { return Game.m.ReadFloat(Game.m.GetModuleBaseAddress("Minecraft.Windows.exe") + 0x20D91A8); } catch { return null; } } set { if (value == null) { return; } try { Game.m.WriteMemory(Game.m.GetModuleBaseAddress("Minecraft.Windows.exe") + 0x20D91A8, value); } catch { } } }
            public static float? HungerSlowDown { get { try { return Game.m.ReadFloat(Game.m.GetModuleBaseAddress("Minecraft.Windows.exe") + 0x20D928C); } catch { return null; } } set { if (value != null) { try { Game.m.WriteMemory(Game.m.GetModuleBaseAddress("Minecraft.Windows.exe") + 0x20D928C, (float)value); } catch { } } } }
        }
    }
}
