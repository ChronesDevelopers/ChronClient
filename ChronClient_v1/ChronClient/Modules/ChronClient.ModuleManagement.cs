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

            public static List<Action> Tick10List = new List<Action>();
            public static List<Action> Tick100List = new List<Action>();
            public static List<Action> Tick1000List = new List<Action>();

            private static void Tick10()
            {
                while (true)
                {
                    foreach(Action TickAction in Tick10List)
                    {
                        if (TickAction != null)
                        {
                            Task.Run(TickAction);
                        }
                    }
                    Thread.Sleep(10);
                }
            }

            private static void Tick100()
            {
                while (true)
                {
                    foreach (Action TickAction in Tick100List)
                    {
                        if (TickAction != null)
                        {
                            Task.Run(TickAction);
                        }
                    }
                    Thread.Sleep(100);
                }
            }

            private static void Tick1000()
            {
                while (true)
                {
                    foreach (Action TickAction in Tick1000List)
                    {
                        if (TickAction != null)
                        {
                            Task.Run(TickAction);
                        }
                    }
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
                Module.Airjump.OnLoad();
                Module.AutoClick.OnLoad();
                Module.CustomTime.OnLoad();
                Module.Fullbright.OnLoad();
                Module.Highjump.OnLoad();
                Module.Hitbox.OnLoad();
                Module.Instabreak.OnLoad();
                Module.NoFall.OnLoad();
                Module.NoKnockBack.OnLoad();
                Module.NoSwing.OnLoad();
                Module.NoWater.OnLoad();
                Module.ParticleTrace.OnLoad();
                Module.Reach.OnLoad();
                Module.Speed.OnLoad();
            }
        }

        public static class ValueRegister
        {
            public static List<ModuleType> ModuleRegister = new List<ModuleType>();

            public static ModuleType GetModuleByName(string Name)
            {
                ModuleType _return = null;
                foreach (ModuleType module in ModuleRegister)
                {
                    if (module.Name == Name)
                    {
                        _return = module;
                        break;
                    }
                }
                return _return;
            }

            public static void RegisterModule(ModuleType mod)
            {
                ModuleRegister.Add(mod);
                if (mod.Tick10 != null)
                {
                    Tick.Tick10List.Add(mod.Tick10);
                }
                if (mod.Tick100 != null)
                {
                    Tick.Tick100List.Add(mod.Tick100);
                }
                if (mod.Tick1000 != null)
                {
                    Tick.Tick1000List.Add(mod.Tick1000);
                }
            }
        }

        public static class ModuleGUI 
        {
            public static string GetFullModuleString()
            {
                string _return = "";
                foreach (ModuleType mod in ValueRegister.ModuleRegister)
                {
                    if (mod.Category != "NULL" || mod.Category != "")
                    {
                        unsafe 
                        {
                            if (mod.ToggleStatePtr != null) 
                            {
                                if (mod.ToggleState)
                                {
                                    _return += mod.Name + "\n";
                                }
                            }
                        }
                    }
                }
                return _return;
            }
        }
    }

    public class ModuleType
    {
        public static string NULLSTRING = "NULL";

        public string Name
        {
            get; private set;
        }

        public string Category
        {
            get; private set;
        }

        public bool ListedInList
        {
            get; private set;
        }

        unsafe public bool* ToggleStatePtr = null;

        public bool ToggleState
        {
            get
            {
                unsafe
                {
                    return *ToggleStatePtr;
                }
            }

            set
            {
                unsafe
                {
                    *ToggleStatePtr = value;
                }
            }
        }

        public Action OnEnable
        {
            get; private set;
        }

        public Action OnDisable
        {
            get; private set;
        }

        public Action OnTrigger
        {
            get; private set;
        }

        public Action Tick10
        {
            get; private set;
        }

        public Action Tick100
        {
            get; private set;
        }

        public Action Tick1000
        {
            get; private set;
        }

        public Action Refresh
        {
            get; private set;
        }

        public Action Toggle
        {
            get; private set;
        }

        public ModuleType(string Name, string Category, bool ListedInList, ref bool ToggleStateRefrence, Action OnEnable, Action OnDisable, Action OnTrigger, Action Tick10, Action Tick100, Action Tick1000, Action Refresh, Action Toggle)
        {
            this.Name = Name;
            this.Category = Category;
            this.ListedInList = ListedInList;
            this.OnEnable = OnEnable;
            this.OnDisable = OnDisable;
            this.OnTrigger = OnTrigger;
            this.Tick10 = Tick10;
            this.Tick100 = Tick100;
            this.Tick1000 = Tick1000;
            this.Tick1000 = Tick1000;
            this.Refresh = Refresh;
            this.Toggle = Toggle;
            unsafe
            {
                fixed (bool* ptr = &ToggleStateRefrence)
                {
                    if (&ptr != null)
                    {
                        ToggleStatePtr = ptr;
                    } else
                    {
                        ToggleStatePtr = null;
                    }
                }
            }
        }
    }
}
