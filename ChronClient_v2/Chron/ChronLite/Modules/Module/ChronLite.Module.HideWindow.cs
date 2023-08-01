using ChronClient.Data;
using ChronClient.Modules;
using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Lite.Module
{
    public static class HideWindow
    {
        public static void OnLoad()
        {
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
        public static Key? ToggleKey = Key.RightShift;
        public static void RegisterKeybind_Toggle(Key? key)
        {
            ToggleKey = key;
            if (key != null)
            {
                KeyBindListener.RegisterKeyBind((Key)key, Events.OnKeyPressed);
            }
        }

        public static class Events
        {
            public static bool? GetToggleState()
            {
                return ToggleState;
            }
            public static void SetToggleState(bool? value)
            {
                ToggleState = value;
            }
            public static void OnEnable()
            {
                Win32.ShowWindow(GlobalData.MainWindow.windowHandle, 0); // SW_HIDE
            }
            public static void OnDisable()
            {
                Win32.ShowWindow(GlobalData.MainWindow.windowHandle, 5); // SW_SHOW
                Win32.SetForegroundWindow(GlobalData.MainWindow.windowHandle);
            }
            public static void OnKeyPressed()
            {
                if (cmr_input.GetKeyStateDown(Key.LeftCtrl) && cmr_input.GetKeyStateDown(Key.LeftShift))
                {
                    ToggleState = !ToggleState;
                }
            }
        }
    }
}
