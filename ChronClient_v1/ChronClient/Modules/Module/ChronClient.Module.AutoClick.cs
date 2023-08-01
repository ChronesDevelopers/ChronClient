using ChronClient.Data;
using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Windows.Input;

namespace ChronClient.Module
{
    public static class AutoClick
    {
        public static Modules.ModuleType ModuleType = new Modules.ModuleType("AutoClick", "Combat", true, ref _ToggleState, new Action(OnEnable), new Action(OnDisable), null, null, null, null, null, new Action(Toggle));

        public static void OnEnable()
        {
            ToggleState = true;
        }

        public static void OnDisable()
        {
            ToggleState = false;
        }

        public static void OnLoad()
        {
            Modules.ModuleManagment.ValueRegister.RegisterModule(ModuleType);
            Start();
        }

        public static Thread thread;

        public static bool _ToggleState = false;

        public static bool ToggleState
        {
            get { return _ToggleState; }
            set
            {
                _ToggleState = value;
            }
        }

        public static void ThreadLoop()
        {
            Win32.INPUT inputMouseUpL = new Win32.INPUT { Type = 1 };
            inputMouseUpL.U.KeyboardInput = new Win32.KEYBDINPUT();
            inputMouseUpL.U.KeyboardInput.wVk = Win32.VirtualKeys.LeftButton;
            inputMouseUpL.U.KeyboardInput.wScan = 0;
            inputMouseUpL.U.KeyboardInput.dwFlags = Win32.KEYEVENTF.UNICODE;
            inputMouseUpL.U.KeyboardInput.dwExtraInfo = UIntPtr.Zero;

            Win32.INPUT inputMouseDownL = new Win32.INPUT { Type = 1 };
            inputMouseDownL.U.KeyboardInput = new Win32.KEYBDINPUT();
            inputMouseDownL.U.KeyboardInput.wVk = Win32.VirtualKeys.LeftButton;
            inputMouseDownL.U.KeyboardInput.wScan = 0;
            inputMouseDownL.U.KeyboardInput.dwFlags = Win32.KEYEVENTF.KEYUP;
            inputMouseDownL.U.KeyboardInput.dwExtraInfo = UIntPtr.Zero;

            Win32.INPUT inputMouseUpR = new Win32.INPUT { Type = 1 };
            inputMouseUpL.U.KeyboardInput = new Win32.KEYBDINPUT();
            inputMouseUpL.U.KeyboardInput.wVk = Win32.VirtualKeys.RightButton;
            inputMouseUpL.U.KeyboardInput.wScan = 0;
            inputMouseUpL.U.KeyboardInput.dwFlags = Win32.KEYEVENTF.UNICODE;
            inputMouseUpL.U.KeyboardInput.dwExtraInfo = UIntPtr.Zero;

            Win32.INPUT inputMouseDownR = new Win32.INPUT { Type = 1 };
            inputMouseDownL.U.KeyboardInput = new Win32.KEYBDINPUT();
            inputMouseDownL.U.KeyboardInput.wVk = Win32.VirtualKeys.RightButton;
            inputMouseDownL.U.KeyboardInput.wScan = 0;
            inputMouseDownL.U.KeyboardInput.dwFlags = Win32.KEYEVENTF.KEYUP;
            inputMouseDownL.U.KeyboardInput.dwExtraInfo = UIntPtr.Zero;

            Win32.INPUT[] inputsUPL = new Win32.INPUT[] { inputMouseUpL };
            Win32.INPUT[] inputsDOWNL = new Win32.INPUT[] { inputMouseDownL };

            Win32.INPUT[] inputsUPR = new Win32.INPUT[] { inputMouseUpR };
            Win32.INPUT[] inputsDOWNR = new Win32.INPUT[] { inputMouseDownR };

            while (true)
            {
                /*try
                {*/
                    IntPtr ForegroundWindowHandle = Win32.GetForegroundWindow();

                    int x = Cursor.Position.X;
                    int y = Cursor.Position.Y;

                    if (ToggleState)
                    {

                        if (cmr_input.GetKeyStateDown(Win32.VirtualKeys.P) && ForegroundWindowHandle == CommunicationData.Overlay.TargetWindowHandle)
                        {
                            while (true)
                            {
                                Win32.mouse_event((uint)Win32.MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
                                Thread.Sleep(5);
                                Win32.mouse_event((uint)Win32.MouseEventFlags.LEFTUP, 0, 0, 0, 0);
                                Thread.Sleep(5);

                                if (cmr_input.GetKeyStateUp(Win32.VirtualKeys.P))
                                {
                                    break;
                                }

                                ForegroundWindowHandle = Win32.GetForegroundWindow();

                                if (ForegroundWindowHandle == CommunicationData.Overlay.TargetWindowHandle)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Thread.Sleep(10);
                        }
                    }
                //} catch { }
            }
        }

        public static void Start()
        {
            thread = new Thread(new ThreadStart(ThreadLoop));
            thread.Start();
        }

        public static void Toggle()
        {
            _ToggleState = !_ToggleState;
        }
    }
}
