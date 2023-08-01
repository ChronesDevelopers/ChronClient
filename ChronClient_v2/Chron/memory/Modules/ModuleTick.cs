using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChronClient.Modules
{
    public static class ModuleTick
    {
        public static BackgroundWorker tick10worker;
        public static BackgroundWorker tick100worker;
        public static BackgroundWorker tick1000worker;

        public static void Start()
        {
            tick10worker = new BackgroundWorker();
            tick100worker = new BackgroundWorker();
            tick1000worker = new BackgroundWorker();

            if (!tick10worker.IsBusy)
            {
                tick10worker.DoWork += tick10_DoWork;
                tick10worker.RunWorkerAsync();
            }
            Thread.Sleep(5);
            if (!tick100worker.IsBusy)
            {
                tick100worker.DoWork += tick100_DoWork;
                tick100worker.RunWorkerAsync();
            }
            Thread.Sleep(2);
            if (!tick1000worker.IsBusy)
            {
                tick1000worker.DoWork += tick1000_DoWork;
                tick1000worker.RunWorkerAsync();
            }
        }

        private static void tick10_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                foreach (Instance.ModuleClass.TickEvent tick in ModuleRegister.Tick10)
                {
                    if (tick != null)
                    {
                        try
                        {
                            tick();
                        }
                        catch { }
                    }
                    Thread.Sleep(6);
                }
            }
        }
        private static void tick100_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                foreach (Instance.ModuleClass.TickEvent tick in ModuleRegister.Tick100)
                {
                    if (tick != null)
                    {
                        try
                        {
                            tick();
                        }
                        catch { }
                    }
                }
                Thread.Sleep(100);
            }
        }
        private static void tick1000_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                foreach (Instance.ModuleClass.TickEvent tick in ModuleRegister.Tick1000)
                {
                    if (tick != null)
                    {
                        try
                        {
                            tick();
                        }
                        catch { }
                    }
                }
                try
                {
                    Game.m.ConnectToProcess();
                } catch { }
                Thread.Sleep(1000);
            }
        }
    }
}
