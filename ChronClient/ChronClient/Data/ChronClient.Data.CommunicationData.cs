using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Data
{
    public static class CommunicationData
    {
        
        public static class MainWindow
        {
            public static bool WelcomeScreenAllowed = false;
        }

        public static class Overlay
        {
            public static ChronClient.GUI.Forms.Overlay overlay;
            public static IntPtr TargetWindowHandle;
        }
    }
}
