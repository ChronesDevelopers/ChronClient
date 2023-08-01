using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Chrones.Cmr.Win32API;

namespace Chrones.Cmr
{
    public static class cmr_input
    {
        public static bool GetKeyStateDown(Win32.VirtualKeys vk)
        {
            return Convert.ToBoolean(Win32.GetAsyncKeyState(vk) & 0x8000);
        }
        public static bool GetKeyStateDown(Win32.VK vk)
        {
            return Convert.ToBoolean(Win32.GetAsyncKeyState(vk) & 0x8000);
        }
        public static bool GetKeyStateDown(short vk)
        {
            return Convert.ToBoolean(Win32.GetAsyncKeyState(vk) & 0x8000);
        }
        public static bool GetKeyStateDown(int vk)
        {
            return Convert.ToBoolean(Win32.GetAsyncKeyState(vk) & 0x8000);
        }
        public static bool GetKeyStateDown(Key vk)
        {
            return Convert.ToBoolean(Win32.GetAsyncKeyState(KeyInterop.VirtualKeyFromKey(vk)) & 0x8000);
        }

        public static bool GetKeyStateUp(Win32.VirtualKeys vk)
        {
            return !Convert.ToBoolean(Win32.GetAsyncKeyState(vk) & 0x8000);
        }
        public static bool GetKeyStateUp(Win32.VK vk)
        {
            return !Convert.ToBoolean(Win32.GetAsyncKeyState(vk) & 0x8000);
        }
        public static bool GetKeyStateUp(short vk)
        {
            return !Convert.ToBoolean(Win32.GetAsyncKeyState(vk) & 0x8000);
        }
        public static bool GetKeyStateUp(int vk)
        {
            return !Convert.ToBoolean(Win32.GetAsyncKeyState(vk) & 0x8000);
        }
        public static bool GetKeyStateUp(Key vk)
        {
            return !Convert.ToBoolean(Win32.GetAsyncKeyState(KeyInterop.VirtualKeyFromKey(vk)) & 0x8000);
        }

        private static IntPtr CreateLParam(int LoWord, int HiWord)
        {
            return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
        }

        public static void Click_SendMessageL(IntPtr Handle, bool KeyState, Point? MousePosition = null)
        {
            if (KeyState)
                Win32.SendMessage((int)Handle, Win32.WM_LBUTTONDOWN, 0x1, CreateLParam(150, 150));
            else if (!KeyState)
                Win32.SendMessage((int)Handle, Win32.WM_LBUTTONUP, 0x0, CreateLParam(150, 150));
        }

        public static void Click_SendMessageR(IntPtr Handle, bool KeyState, Point? MousePosition = null)
        {
            if (KeyState)
                Win32.SendMessage((int)Handle, Win32.WM_RBUTTONDOWN, 0x1, CreateLParam(150, 150));
            else if (!KeyState)
                Win32.SendMessage((int)Handle, Win32.WM_RBUTTONUP, 0x0, CreateLParam(150, 150));
        }

        public static void Click_MousEventL(bool KeyState, Point? MousePosition = null)
        {
            if (KeyState)
                Win32.mouse_event(Win32.MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            else if (!KeyState)
                Win32.mouse_event(Win32.MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        public static void Click_MousEventR(bool KeyState, Point? MousePosition = null)
        {
            if (KeyState)
                Win32.mouse_event(Win32.MouseEventFlags.RIGHTDOWN, 0, 0, 0, 0);
            else if (!KeyState)
                Win32.mouse_event(Win32.MouseEventFlags.RIGHTUP, 0, 0, 0, 0);
        }
    }
}
