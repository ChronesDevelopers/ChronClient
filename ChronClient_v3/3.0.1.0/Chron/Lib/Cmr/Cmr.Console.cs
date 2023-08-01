using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrones
{
    public static partial class Cmr
    {
        public static partial class Console
        {
            public static void EnableVirtualTerminalProcessing()
            {
                IntPtr hOut = Cmr.Win32.GetStdHandle(-11);
                UInt32 dwMode;
                Cmr.Win32.GetConsoleMode(hOut, out dwMode);
                Cmr.Win32.SetConsoleMode(hOut, dwMode | 0x4);
            }
            public static void ConsoleWrite(object value)
            {
                System.Console.Write(value);
            }
            public static void ConsoleWriteLine(object value)
            {
                System.Console.WriteLine(value);
            }
            public static void SetForegroundColor(byte r, byte g, byte b)
            {
                System.Console.Write("\x1b[38;2;" + r + ";" + g + ";" + b + "m");
            }
            public static void SetBackgroundColor(byte r, byte g, byte b)
            {
                System.Console.Write("\x1b[48;2;" + r + ";" + g + ";" + b + "m");
            }
            public static ConsoleKeyInfo ReadKey()
            {
                return ReadKey();
            }
        }
    }
}
