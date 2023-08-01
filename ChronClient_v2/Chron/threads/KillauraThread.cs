using ChronClient.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChronClient.Threads
{
    public static class KillauraThread
    {
        public static void OnUpdate()
        {
            Module.Killaura.Events.OnThreadLoop();
        }

        public static class Loop
        {
            static Thread thread;

            public static void Start()
            {
                thread = new Thread(ThreadLoop);
                thread.Priority = ThreadPriority.BelowNormal;
                thread.Start();
            }

            public static void ThreadLoop()
            {
                while (true)
                {
                    OnUpdate();
                    Thread.Sleep(2);
                }
            }
        }
    }
}
