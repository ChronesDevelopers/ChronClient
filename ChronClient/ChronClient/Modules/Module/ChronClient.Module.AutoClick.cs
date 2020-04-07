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
        public static Thread thread;

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

            bool LastClicked = false;

            while (true)
            {
                IntPtr ForegroundWindowHandle = Win32.GetForegroundWindow();

                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;

                if (cmr_input.GetKeyStateDown(Win32.VirtualKeys.LeftButton) && cmr_input.GetKeyStateDown(Win32.VirtualKeys.P))
                {
                    if (CommunicationData.Overlay.TargetWindowHandle == ForegroundWindowHandle)
                    {
                        /*//Win32.mouse_event(Win32.MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
                        Win32.SendInput(1, inputsDOWNL, Marshal.SizeOf(typeof(Win32.INPUT)));
                        Thread.Sleep(5);
                        //Win32.mouse_event(Win32.MouseEventFlags.LEFTUP, 0, 0, 0, 0);
                        Win32.SendInput(1, inputsUPL, Marshal.SizeOf(typeof(Win32.INPUT)));
                        Thread.Sleep(5);*/
                        Win32.mouse_event((uint)Win32.MouseEventFlags.LEFTUP, 0, 0, 0, 0);
                        Thread.Sleep(5);
                        Win32.mouse_event((uint)Win32.MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
                        Thread.Sleep(5);
                        LastClicked = true;
                    }
                    else
                    {
                        LastClicked = false;
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    Thread.Sleep(10);
                }
            }
        }

        public static void Start()
        {
            thread = new Thread(new ThreadStart(ThreadLoop));
            thread.Start();
        }
    }
}
