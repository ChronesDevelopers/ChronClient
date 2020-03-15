using Chrones.Cmr.Imports;
using System;

namespace Chrones.Cmr
{
    public class cmr
    {
        public static void EnableVirtualTerminalProcessing()
        {
            IntPtr hOut = Import.GetStdHandle(-11);
            UInt32 dwMode;
            Import.GetConsoleMode(hOut, out dwMode);
            Import.SetConsoleMode(hOut, dwMode | 0x4);
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
            IntPtr hwnd = Import.GetConsoleWindow();
            Import.RECT rectWindow;
            Import.GetWindowRect(hwnd, out rectWindow);

            int screen_width = Import.GetSystemMetrics(Import.SystemMetric.SM_CXSCREEN);
            int screen_height = Import.GetSystemMetrics(Import.SystemMetric.SM_CYSCREEN);
            int console_width = (rectWindow.right - rectWindow.left);
            int console_height = (rectWindow.bottom - rectWindow.top);

            Import.SetWindowPos(hwnd,(IntPtr)0,(screen_width - console_width) / 2, (screen_height - console_height) / 2, 0, 0, 1);
        }
        
        public static void MaximizeConsole()
        {
            Import.ShowWindow(Import.GetConsoleWindow(), 3);
        }

        public static void MinimizeConsole()
        {
            Import.ShowWindow(Import.GetConsoleWindow(), 6);
        }

        public static void HideConsole()
        {
            Import.ShowWindow(Import.GetConsoleWindow(), 0);
        }

        public static void RestoreConsole()
        {
            Import.ShowWindow(Import.GetConsoleWindow(), 9);
        }

        public static void FullscreenConsole()
        {
            Import.COORD zero = new Import.COORD(100,100);
            Import.SetConsoleDisplayMode(Import.GetStdHandle(Import.STD_OUTPUT_HANDLE), 1, out zero);

            IntPtr hConsole = Import.GetStdHandle(-11);   // get console handle
            Import.COORD xy = new Import.COORD(100, 100);
            //Import.SetConsoleDisplayMode(hConsole, 1, out xy); // set the console to fullscreen
            Import.SetConsoleDisplayMode(hConsole, 2, out xy);
        }

        public static void FullscreenWindowedConsole()
        {

        }

        public static void DisableQuickEdit()
        {
            IntPtr conHandle = Import.GetStdHandle(-10);
            int mode;

            if (!Import.GetConsoleMode(conHandle, out mode))
            {
                // error getting the console mode. Exit.
                return;
            }

            mode = mode & ~(64 | 128);

            if (!Import.SetConsoleMode(conHandle, mode))
            {
                // error setting console mode.
            }
        }

        public static void EnableQuickEdit()
        {
            IntPtr conHandle = Import.GetStdHandle(-10);
            int mode;

            if (!Import.GetConsoleMode(conHandle, out mode))
            {
                // error getting the console mode. Exit.
                return;
            }

            mode = mode | (64 | 128);

            if (!Import.SetConsoleMode(conHandle, mode))
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

        public static void ExitApplication()
        {
            Console.WriteLine($"{cr}\n{cf(255, 140, 46)}Exiting... \n");
            Environment.Exit(0);
        }
    }
}
