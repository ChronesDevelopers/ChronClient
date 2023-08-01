using ChronClient.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChronClient.Threads
{
    public static class EntityListUpdate
    {
#nullable enable
        public static List<Entity>? Entities;
#nullable disable

        public static void OnUpdate()
        {
            Entities = EntityList.GetEntityList();
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
                    Thread.Sleep(50);
                }
            }
        }
    }
}
