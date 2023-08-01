using ChronClient.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChronClient.Threads
{
    public static class Threads
    {
        public static Thread thread;
        public static void Start()
        {
            thread = new Thread(ThreadStart);
            thread.Priority = ThreadPriority.AboveNormal;
            thread.IsBackground = true;
            thread.Start();
        }
        public static void StartLite()
        {
            thread = new Thread(ThreadStartLite);
            thread.Priority = ThreadPriority.Normal;
            thread.IsBackground = true;
            thread.Start();
        }

        private static void ThreadStart()
        {
            Game.m = new Chrones.Cmr.MemoryManagement.Memory("Minecraft.Windows");
            EntityListUpdate.Loop.Start();
            ColorRGBUpdate.Start();
            ModuleTick.Start();
            KeyBindListener.Start();
            //KillauraThread.Loop.Start();
        }
        private static void ThreadStartLite()
        {
            Game.m = new Chrones.Cmr.MemoryManagement.Memory("Minecraft.Windows");
            //EntityListUpdate.Loop.Start();
            ColorRGBUpdate.Start();
            ModuleTick.Start();
            KeyBindListener.Start();
            //KillauraThread.Loop.Start();
        }
    }
}
