using Chrones.Cmr;
using Chrones.Cmr.Win32API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChronClient.Input
{
    public static class CInput
    {
        private static Thread thread;

        private static void ThreadLoop()
        {
            while (true)
            {
                SavedState_VK_Control = State_VK_Control;
                SavedState_VK_RightShift = State_VK_RightShift;
                State_VK_Control = cmr_input.GetKeyStateDown(Win32.VirtualKeys.Control);
                State_VK_RightShift = cmr_input.GetKeyStateDown(Win32.VirtualKeys.RightShift);
                Thread.Sleep(20);
            }
        }

        public static void StartThread()
        {
            thread = new Thread(new ThreadStart(ThreadLoop));
            thread.Priority = ThreadPriority.AboveNormal;
            thread.Start();
        }

        private static bool State_VK_Control = false;
        private static bool State_VK_RightShift = false;
        private static bool SavedState_VK_Control = false;
        private static bool SavedState_VK_RightShift = false;

        public static bool GetKeyStateControlPressed()
        {
            bool _return = false;
            if (!State_VK_Control && SavedState_VK_Control)
            {
                _return = true;
            }
            return _return;
        }

        public static bool GetKeyStateRightShiftPressed()
        {
            bool _return = false;
            if (!State_VK_RightShift && SavedState_VK_RightShift)
            {
                _return = true;
            }
            return _return;
        }
    }
}
