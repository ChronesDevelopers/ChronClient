using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Data
{
    public static class GlobalData
    {
        public static class ApplicationData
        {
            public static readonly bool IsPackageMode = false;
            public static readonly bool IsPlusVersion = true;
            public static readonly bool IsChronLite = true;
            public static readonly string VERSION = "2.1.90";
            public static readonly string VERSIONTAGS = "stable";

            public static readonly bool LaunchMinecraftWhenLoading = true;
            public static readonly bool UseDefaultIcon = false;
            public static readonly bool NoAdmin = true;
        }

        public static class ChronLiteData
        {
            public static readonly string VERSION = "0.0.0.1";
            public static readonly string VERSIONTAGS = "alpha";
            private static string ReadMe1 = "It looks like u found me :) ...";

            public static ChronClient.Lite.GUI.Pages.LoadingPage LoadingPage = null;
            public static ChronClient.Lite.GUI.Pages.ChronLiteMainPage MainPage = null;
        }

        public static class LoginPage
        {
            public static bool HasLoaded = false;
        }

        public static class MainWindow
        {
            public static ChronClient.MainWindow window;
            public static IntPtr windowHandle = IntPtr.Zero;
        }

        public static class OverlayWindow
        {
            public static GUI.OverlayWindow overlay;
            public static bool ShowOverlay = false;

            public static double RefreshRate = 10;
            public static double DrawRefreshRate = (1000 / 60);
        }

        public static class ColorRGBCounter
        {
            public static double ColorRGBCounterSpeed = 1;
        }
    }
}
