using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChronClient.Data
{
    public static class CommunicationData
    {
        
        public static class MainWindow
        {
            public static ChronClient.GUI.MainWindow WindowObject;
            public static IntPtr WindowHandle;
        }

        public static class Overlay
        {
            public static ChronClient.GUI.Forms.OldOverlay overlay;
            public static IntPtr TargetWindowHandle;
        }

        public static class GUI
        {
            public static double ColorRGBCounter = 0;
        }
    }
}
