using ChronClient.Data;
using ChronClient.Instance;
using ChronClient.Modules;
using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Lite.Module
{
    public static class AutoClicker
    {
        public static void OnLoad()
        {
            random = new Random();

            ModuleClass moduleClass = new ModuleClass();
            moduleClass.ModuleName = "AutoClicker";
            moduleClass.Category = "null";
            moduleClass.Description1 = "Clicks automaticly";
            moduleClass.HasToggleState = true;
            moduleClass.GetToggleState = Events.GetToggleState;
            moduleClass.SetToggleState = Events.SetToggleState;
            moduleClass.ShowInTabGUI = null;
            moduleClass.ShowInListGUI = true;
            moduleClass.GetShowInListGUI = Events.GetShowInListGUI;
            //moduleClass.Tick100 = Tick100;
            ChronClient.Modules.ModuleRegister.RegisterModule(moduleClass);

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += Tick;
            backgroundWorker.RunWorkerAsync();

            if (ToggleKey != null)
            {
                KeyBindListener.RegisterKeyBind((Key)ToggleKey, Events.OnKeyPressed);
            }
        }

        public static bool? _ToggleState = false;
        public static bool? ToggleState
        {
            get
            {
                return _ToggleState;
            }
            set
            {
                if (value != _ToggleState)
                {
                    if (value == true)
                    {
                        Events.OnEnable();
                    }
                    if (value == false || value == null)
                    {
                        Events.OnDisable();
                    }
                }
                _ToggleState = value;
            }
        }
        public static Key? ToggleKey = null;
        public static void RegisterKeybind_Toggle(Key? key)
        {
            ToggleKey = key;
            if (key != null)
            {
                KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressed);
            }
        }
        public static Key? TriggerKey = Key.F;
        public static void RegisterKeybind_Trigger(Key? key)
        {
            TriggerKey = key;
        }
        public static int CPS_L_Min;
        public static int CPS_L_Max;
        static Random random;

        public static BackgroundWorker backgroundWorker;

        public static void Tick(object sender, EventArgs e)
        {
            while (true)
            {
                if (ToggleState == true)
                {
                    try
                    {
                        if (TriggerKey != null)
                        {
                            if (cmr_input.GetKeyStateDown(Win32.VirtualKeys.LeftButton))
                            {
                                Click(Convert.ToDouble(random.Next(CPS_L_Min, CPS_L_Max)));
                            }
                            else
                            {
                                Thread.Sleep(5);
                            }
                        }
                        else
                        {
                            Thread.Sleep(300);
                        }
                    } catch { }
                } else
                {
                    Thread.Sleep(300);
                }
            }
        }

        public static void Click(double cps)
        {
            int _cps = Convert.ToInt32(cps);
            int t = Convert.ToInt32(1000 / cps - 3);
            IntPtr foregroundWindowHandle = Win32.GetForegroundWindow();
            IntPtr MinecraftWindowHandle = Win32.FindWindow(null, "Minecraft");
            for (int i = 0; i < _cps; i++)
            {
                /*
                if (TriggerKey != null && foregroundWindowHandle == MinecraftWindowHandle)
                {
                    if (cmr_input.GetKeyStateDown(Win32.VirtualKeys.LeftButton))
                    {
                        cmr_input.Click_MousEventL(true);
                        Thread.Sleep(t / 2);
                        cmr_input.Click_MousEventL(false);
                        Thread.Sleep(t / 2);
                    }
                } /* */

                if (cmr_input.GetKeyStateDown(Win32.VirtualKeys.LeftButton))
                {
                    ChronClient.Game.m.WriteMemory(0x0, (byte)1);
                    ChronClient.Game.m.WriteMemory(0x0, (byte)0);
                    Thread.Sleep(t);
                }
            }
        }

        public static class Events
        {
            public static void backgroundWorker_Worker()
            {
                while(true)
                {

                }
            }
            public static bool? GetToggleState()
            {
                return ToggleState;
            }
            public static void SetToggleState(bool? value)
            {
                ToggleState = value;
            }
            public static bool? GetShowInListGUI()
            {
                return ToggleState;
            }
            public static void OnEnable()
            {

            }
            public static void OnDisable()
            {

            }
            public static void OnKeyPressed()
            {
                ToggleState = !ToggleState;
            }
        }
    }
}
