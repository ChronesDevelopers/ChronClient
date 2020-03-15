using System;
using System.Runtime.InteropServices;
using Chrones.Cmr.Imports;

namespace Chrones.Cmr.Font
{
    public class cmr_font
    {
        public static void SetConsoleFont(string fontName, short fontSizeX = 9, short fontSizeY = 19, int fontWeight = 0)
        {
            unsafe
            {
                IntPtr hnd = Import.GetStdHandle(Import.STD_OUTPUT_HANDLE);
                if (hnd != Import.INVALID_HANDLE_VALUE)
                {
                    Imports.Import.CONSOLE_FONT_INFO_EX info = new Import.CONSOLE_FONT_INFO_EX();
                    info.cbSize = (uint)Marshal.SizeOf(info);

                    // Set console font to Lucida Console.
                    Import.CONSOLE_FONT_INFO_EX newInfo = new Import.CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                    newInfo.FontFamily = Import.TMPF_TRUETYPE;
                    IntPtr ptr = new IntPtr(newInfo.FaceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

                    // Get some settings from current font.
                    newInfo.dwFontSize = new Import.COORD(fontSizeX, fontSizeY);
                    if (fontWeight != 0) { newInfo.FontWeight = 700; }
                    Import.SetCurrentConsoleFontEx(hnd, false, ref newInfo);
                }
            }
        }
    }
}
