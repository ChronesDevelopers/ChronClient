using Chrones.Cmr.Win32API;
using System;

namespace Chrones.Cmr
{
    public class cmr
    {
        public static void EnableVirtualTerminalProcessing()
        {
            IntPtr hOut = Win32.GetStdHandle(-11);
            UInt32 dwMode;
            Win32.GetConsoleMode(hOut, out dwMode);
            Win32.SetConsoleMode(hOut, dwMode | 0x4);
        }

        public static void cout()
        {

        }

        public static string cin(bool ClearImput = true)
        {
            return "";
        }

        public static void cli()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        public static void clog(string name, string print)
        {
            Console.Write($"{cf(120, 120, 120)}[{cf(200, 200, 200)}{name}{cf(120, 120, 120)}] {print}");
        }

        public static void clogl(string name, string print)
        {
            Console.WriteLine($"{cf(120, 120, 120)}[{cf(200, 200, 200)}{name}{cf(120, 120, 120)}] {print}");
        }

        public static void ccout(string name, string print)
        {
            Console.WriteLine($"{cf(120, 120, 120)}[{cf(255, 255, 255)}{name}{cf(120, 120, 120)}] {cf(255, 59, 59)}: {cf(255, 255, 255)}{print}");
        }

        public static void ccoutl(string name, string print)
        {
            Console.WriteLine($"{cf(120, 120, 120)}[{cf(255, 255, 255)}{name}{cf(120, 120, 120)}] {cf(255, 59, 59)}: {cf(255, 255, 255)}{print}");
        }

        #region ConsoleText

        public static string cf(uint r, uint g, uint b)
        {
            string _return = "\x1b[38;2;" + r + ";" + g + ";" + b + "m";
            return _return;
        }
        public static string cf(int r, int g, int b)
        {
            string _return = "\x1b[38;2;" + r + ";" + g + ";" + b + "m";
            return _return;
        }

        public static string cb(uint r, uint g, uint b)
        {
            string _return = "\x1b[48;2;" + r + ";" + g + ";" + b + "m";
            return _return;
        }
        public static string cb(int r, int g, int b)
        {
            string _return = "\x1b[48;2;" + r + ";" + g + ";" + b + "m";
            return _return;
        }

        public static string cr
        {
            get { return cfr + cbr; }
            set { }
        }

        public static string cfr
        {
            get { return "\x1b[39m"; }
            set { }
        }

        public static string cbr
        {
            get { return "\x1b[49m"; }
            set { }
        }

        public static string tb
        {
            get { return "\x1b[1m"; }
            set { }
        }

        public static string tu
        {
            get { return "\x1b[4m"; }
            set { }
        }

        public static string tn
        {
            get { return "\x1b[7m"; }
            set { }
        }

        public static string tr
        {
            get { return "\x1b[0m"; }
            set { }
        }

        #region var
        public static readonly string esc = "\x1b[";
        #endregion

        #endregion

        #region Console

        #endregion

        #region ConsoleWindow
        public static void CenterConsole()
        {
            IntPtr hwnd = Win32.GetConsoleWindow();
            Win32.RECT rectWindow;
            Win32.GetWindowRect(hwnd, out rectWindow);

            int screen_width = Win32.GetSystemMetrics(Win32.SystemMetric.SM_CXSCREEN);
            int screen_height = Win32.GetSystemMetrics(Win32.SystemMetric.SM_CYSCREEN);
            int console_width = (rectWindow.right - rectWindow.left);
            int console_height = (rectWindow.bottom - rectWindow.top);

            Win32.SetWindowPos(hwnd,(IntPtr)0,(screen_width - console_width) / 2, (screen_height - console_height) / 2, 0, 0, 1);
        }
        
        public static void MaximizeConsole()
        {
            Win32.ShowWindow(Win32.GetConsoleWindow(), 3);
        }

        public static void MinimizeConsole()
        {
            Win32.ShowWindow(Win32.GetConsoleWindow(), 6);
        }

        public static void HideConsole()
        {
            Win32.ShowWindow(Win32.GetConsoleWindow(), 0);
        }

        public static void RestoreConsole()
        {
            Win32.ShowWindow(Win32.GetConsoleWindow(), 9);
        }

        public static void FullscreenConsole()
        {
            Win32.COORD zero = new Win32.COORD(100,100);
            Win32.SetConsoleDisplayMode(Win32.GetStdHandle(Win32.STD_OUTPUT_HANDLE), 1, out zero);

            IntPtr hConsole = Win32.GetStdHandle(-11);   // get console handle
            Win32.COORD xy = new Win32.COORD(100, 100);
            //Import.SetConsoleDisplayMode(hConsole, 1, out xy); // set the console to fullscreen
            Win32.SetConsoleDisplayMode(hConsole, 2, out xy);
        }

        public static void FullscreenWindowedConsole()
        {

        }

        public static void DisableQuickEdit()
        {
            IntPtr conHandle = Win32.GetStdHandle(-10);
            int mode;

            if (!Win32.GetConsoleMode(conHandle, out mode))
            {
                // error getting the console mode. Exit.
                return;
            }

            mode = mode & ~(64 | 128);

            if (!Win32.SetConsoleMode(conHandle, mode))
            {
                // error setting console mode.
            }
        }

        public static void EnableQuickEdit()
        {
            IntPtr conHandle = Win32.GetStdHandle(-10);
            int mode;

            if (!Win32.GetConsoleMode(conHandle, out mode))
            {
                // error getting the console mode. Exit.
                return;
            }

            mode = mode | (64 | 128);

            if (!Win32.SetConsoleMode(conHandle, mode))
            {
                // error setting console mode.
            }
        }
        #endregion

        public static bool DownloadFileFromURL()
        {
            return false;
        }

        public static void ExitApplicationPrint()
        {
            Console.WriteLine($"{cr}\n{cf(255, 207, 105)}Press any key to {cf(255, 207, 105)}exit{cf(220, 220, 220)}...{cr}\n");
            Console.ReadKey(true);
            Console.WriteLine($"{cf(255, 140, 46)}Exiting... ");
            Environment.Exit(0);
        }

        public static void ExitApplication(bool ExitDialog = true)
        {
            if (ExitDialog)
            {
                Console.WriteLine($"{cr}\n{cf(255, 140, 46)}Exiting... \n");
            }
            Environment.Exit(0);
        }

        public static bool IsNumberOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
