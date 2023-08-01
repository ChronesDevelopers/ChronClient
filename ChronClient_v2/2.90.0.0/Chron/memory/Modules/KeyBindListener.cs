using ChronClient.Instance;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ChronClient.Modules
{
    public static class KeyBindListener
    {
        public static Thread thread;

        public static List<Keybind> Keybinds = new List<Keybind>();

        public static void Start()
        {
            thread = new Thread(new ThreadStart(Loop));
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.BelowNormal;
            thread.Start();
        }

        public static void RegisterKeyBind(Key key, Keybind.OnKeyPressedEvent onKeyPressed)
        {
            if (Keybinds == null)
            {
                Keybinds = new List<Keybind>();
            }
            if (Keybinds.Count == 0)
            {
                List<Keybind.OnKeyPressedEvent> listevents = new List<Keybind.OnKeyPressedEvent>();
                listevents.Add(onKeyPressed);
                Keybinds.Add(new Keybind { targetkey = key, OnKeyPressed = listevents });
                return;
            }
            List<Keybind> keybinds = new List<Keybind>();
            bool TargetIsAdded = false;
            foreach(Keybind keybind in Keybinds)
            {
                if (keybind.targetkey == key)
                {
                    keybind.OnKeyPressed.Add(onKeyPressed);
                    TargetIsAdded = true;
                }
                keybinds.Add(keybind);
            }
            if (!TargetIsAdded)
            {
                List<Keybind.OnKeyPressedEvent> listevents = new List<Keybind.OnKeyPressedEvent>();
                listevents.Add(onKeyPressed);
                Keybinds.Add(new Keybind { targetkey = key, OnKeyPressed = listevents });
                return;
            }
            Keybinds = keybinds;
        }

        private static void Loop()
        {
            while (true)
            {
                try
                {
                    if (Win32.GetForegroundWindow() == Win32.FindWindow(null, "Minecraft"))
                    {
                        List<Keybind> keybinds = new List<Keybind>();
                        foreach (Keybind keybind in Keybinds)
                        {
                            bool KeyState = Keyboard.IsKeyDown(keybind.targetkey);
                            if (keybind.LastKeyState == false && KeyState == true)
                            {
                                foreach (Keybind.OnKeyPressedEvent onKeyPressed in keybind.OnKeyPressed)
                                {
                                    try
                                    {
                                        if (Module.NOKEYBINDS.CAN_USE_KEYBINDS || onKeyPressed == Module.NOKEYBINDS.Events.OnKeyPressed)
                                        {
                                            onKeyPressed();
                                        }
                                    }
                                    catch { }
                                }
                            }
                            keybind.LastKeyState = KeyState;
                            keybinds.Add(keybind);
                        }
                        Keybinds = keybinds;
                    }
                    else
                    {
                        Thread.Sleep(50);
                    }
                }
                catch { }
                Thread.Sleep(10);
            }
        }

        public delegate void RegisterKeybind(Key? key);
    }
}
