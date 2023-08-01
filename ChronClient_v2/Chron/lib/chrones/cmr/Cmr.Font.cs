using System;
using System.Runtime.InteropServices;
using Chrones.Cmr.Win32API;

namespace Chrones.Cmr.Font
{
    public class cmr_font
    {
        public static void SetConsoleFont(string fontName, short fontSizeX = 9, short fontSizeY = 19, int fontWeight = 0)
        {
            unsafe
            {
                IntPtr hnd = Win32.GetStdHandle(Win32.STD_OUTPUT_HANDLE);
                if (hnd != Win32.INVALID_HANDLE_VALUE)
                {
                    Win32API.Win32.CONSOLE_FONT_INFO_EX info = new Win32.CONSOLE_FONT_INFO_EX();
                    info.cbSize = (uint)Marshal.SizeOf(info);

                    // Set console font to Lucida Console.
                    Win32.CONSOLE_FONT_INFO_EX newInfo = new Win32.CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                    newInfo.FontFamily = Win32.TMPF_TRUETYPE;
                    IntPtr ptr = new IntPtr(newInfo.FaceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

                    // Get some settings from current font.
                    newInfo.dwFontSize = new Win32.COORD(fontSizeX, fontSizeY);
                    if (fontWeight != 0) { newInfo.FontWeight = 700; }
                    Win32.SetCurrentConsoleFontEx(hnd, false, ref newInfo);
                }
            }
        }
    }
}
