using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ChronClient.Modules
{
    public static class ModuleManagment
    {
        public static class Tick
        {
            static Thread Tick10Thread;
            static Thread Tick100Thread;
            static Thread Tick1000Thread;

            private static void Tick10()
            {
                while (true)
                {
                    Thread.Sleep(10);
                }
            }

            private static void Tick100()
            {
                while (true)
                {
                    Module.Speed.Tick100();
                    Module.ParticleTrace.Tick100();
                    Thread.Sleep(100);
                }
            }

            private static void Tick1000()
            {
                while (true)
                {
                    Thread.Sleep(1000);
                }
            }

            public static void Start()
            {
                Tick10Thread = new Thread(new ThreadStart(Tick10));
                Tick10Thread.Priority = ThreadPriority.Normal;
                Tick10Thread.Start();

                Tick100Thread = new Thread(new ThreadStart(Tick100));
                Tick100Thread.Priority = ThreadPriority.BelowNormal;
                Tick100Thread.Start();

                Tick1000Thread = new Thread(new ThreadStart(Tick1000));
                Tick1000Thread.Priority = ThreadPriority.Lowest;
                Tick1000Thread.Start();
            }
        }

        public static class OnLoad
        {
            public static void Start()
            {
                // Setup Modules
                Module.Hitbox.ToggleState = true;
                Module.Airjump.ToggleState = true;
                Module.NoFall.ToggleState = true;
                Module.NoSwing.ToggleState = true;
                Module.Reach.ToggleState = true;
                Module.NoKnockBack.ToggleState = true;
                Module.Speed.ToggleState = true;
                Module.Highjump.ToggleState = true;
                //Module.ParticleTrace.ToggleState = true;
                Module.AutoClick.Start();
            }
        }
    }
}
