using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Chrones.Cmr.Imports
{
    public class Import
    {

        #region ConsoleFunctions
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // http://pinvoke.net/default.aspx/kernel32/AddConsoleAlias.html
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AddConsoleAlias(
            string Source,
            string Target,
            string ExeName
            );

        // http://pinvoke.net/default.aspx/kernel32/AllocConsole.html
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AllocConsole();

        // http://pinvoke.net/default.aspx/kernel32/AttachConsole.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool AttachConsole(
            uint dwProcessId
            );

        // http://pinvoke.net/default.aspx/kernel32/CreateConsoleScreenBuffer.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateConsoleScreenBuffer(
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwFlags,
            IntPtr lpScreenBufferData
            );

        // http://pinvoke.net/default.aspx/kernel32/FillConsoleOutputAttribute.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FillConsoleOutputAttribute(
            IntPtr hConsoleOutput,
            ushort wAttribute,
            uint nLength,
            COORD dwWriteCoord,
            out uint lpNumberOfAttrsWritten
            );

        // http://pinvoke.net/default.aspx/kernel32/FillConsoleOutputCharacter.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FillConsoleOutputCharacter(
            IntPtr hConsoleOutput,
            char cCharacter,
            uint nLength,
            COORD dwWriteCoord,
            out uint lpNumberOfCharsWritten
            );

        // http://pinvoke.net/default.aspx/kernel32/FlushConsoleInputBuffer.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FlushConsoleInputBuffer(
            IntPtr hConsoleInput
            );

        // http://pinvoke.net/default.aspx/kernel32/FreeConsole.html
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool FreeConsole();

        // http://pinvoke.net/default.aspx/kernel32/GenerateConsoleCtrlEvent.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GenerateConsoleCtrlEvent(
            uint dwCtrlEvent,
            uint dwProcessGroupId
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleAlias.html
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool GetConsoleAlias(
            string Source,
            out StringBuilder TargetBuffer,
            uint TargetBufferLength,
            string ExeName
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleAliases.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetConsoleAliases(
            StringBuilder[] lpTargetBuffer,
            uint targetBufferLength,
            string lpExeName
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleAliasesLength.html
        [DllImport("kernel32", SetLastError = true)]
        public static extern uint GetConsoleAliasesLength(
            string ExeName
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleAliasExes.html
        [DllImport("kernel32", SetLastError = true)]
        public static extern uint GetConsoleAliasExes(
            out StringBuilder ExeNameBuffer,
            uint ExeNameBufferLength
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleAliasExesLength.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetConsoleAliasExesLength();

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleCP.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetConsoleCP();

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleCursorInfo.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleCursorInfo(
            IntPtr hConsoleOutput,
            out CONSOLE_CURSOR_INFO lpConsoleCursorInfo
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleDisplayMode.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleDisplayMode(
            out uint ModeFlags
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleFontSize.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern COORD GetConsoleFontSize(
            IntPtr hConsoleOutput,
            Int32 nFont
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleHistoryInfo.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleHistoryInfo(
            out CONSOLE_HISTORY_INFO ConsoleHistoryInfo
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleMode.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(
            IntPtr hConsoleHandle,
            out uint lpMode
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleMode(
           IntPtr hConsoleHandle,
           out int lpMode
           );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleOriginalTitle.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetConsoleOriginalTitle(
            out StringBuilder ConsoleTitle,
            uint Size
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleOutputCP.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetConsoleOutputCP();

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleProcessList.html
        // TODO: Test - what's an out uint[] during interop? This probably isn't quite right, but provides a starting point:
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetConsoleProcessList(
            out uint[] ProcessList,
            uint ProcessCount
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleScreenBufferInfo.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleScreenBufferInfo(
            IntPtr hConsoleOutput,
            out CONSOLE_SCREEN_BUFFER_INFO lpConsoleScreenBufferInfo
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleScreenBufferInfoEx.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleScreenBufferInfoEx(
            IntPtr hConsoleOutput,
            ref CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfo
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleSelectionInfo.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetConsoleSelectionInfo(
            CONSOLE_SELECTION_INFO ConsoleSelectionInfo
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleTitle.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetConsoleTitle(
            [Out] StringBuilder lpConsoleTitle,
            uint nSize
            );

        // http://pinvoke.net/default.aspx/kernel32/GetConsoleWindow.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();

        // http://pinvoke.net/default.aspx/kernel32/GetCurrentConsoleFont.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetCurrentConsoleFont(
            IntPtr hConsoleOutput,
            bool bMaximumWindow,
            out CONSOLE_FONT_INFO lpConsoleCurrentFont
            );

        // http://pinvoke.net/default.aspx/kernel32/GetCurrentConsoleFontEx.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetCurrentConsoleFontEx(
            IntPtr ConsoleOutput,
            bool MaximumWindow,
            out CONSOLE_FONT_INFO_EX ConsoleCurrentFont
            );

        // http://pinvoke.net/default.aspx/kernel32/GetLargestConsoleWindowSize.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern COORD GetLargestConsoleWindowSize(
            IntPtr hConsoleOutput
            );

        // http://pinvoke.net/default.aspx/kernel32/GetNumberOfConsoleInputEvents.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetNumberOfConsoleInputEvents(
            IntPtr hConsoleInput,
            out uint lpcNumberOfEvents
            );

        // http://pinvoke.net/default.aspx/kernel32/GetNumberOfConsoleMouseButtons.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetNumberOfConsoleMouseButtons(
            ref uint lpNumberOfMouseButtons
            );

        // http://pinvoke.net/default.aspx/kernel32/GetStdHandle.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(
            int nStdHandle
            );

        // http://pinvoke.net/default.aspx/kernel32/HandlerRoutine.html
        // Delegate type to be used as the Handler Routine for SCCH
        public delegate bool ConsoleCtrlDelegate(CtrlTypes CtrlType);

        // http://pinvoke.net/default.aspx/kernel32/PeekConsoleInput.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool PeekConsoleInput(
            IntPtr hConsoleInput,
            [Out] INPUT_RECORD[] lpBuffer,
            uint nLength,
            out uint lpNumberOfEventsRead
            );

        // http://pinvoke.net/default.aspx/kernel32/ReadConsole.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadConsole(
            IntPtr hConsoleInput,
            [Out] StringBuilder lpBuffer,
            uint nNumberOfCharsToRead,
            out uint lpNumberOfCharsRead,
            IntPtr lpReserved
            );

        // http://pinvoke.net/default.aspx/kernel32/ReadConsoleInput.html
        [DllImport("kernel32.dll", EntryPoint = "ReadConsoleInputW", CharSet = CharSet.Unicode)]
        public static extern bool ReadConsoleInput(
            IntPtr hConsoleInput,
            [Out] INPUT_RECORD[] lpBuffer,
            uint nLength,
            out uint lpNumberOfEventsRead
            );

        // http://pinvoke.net/default.aspx/kernel32/ReadConsoleOutput.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadConsoleOutput(
            IntPtr hConsoleOutput,
            [Out] CHAR_INFO[] lpBuffer,
            COORD dwBufferSize,
            COORD dwBufferCoord,
            ref SMALL_RECT lpReadRegion
            );

        // http://pinvoke.net/default.aspx/kernel32/ReadConsoleOutputAttribute.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadConsoleOutputAttribute(
            IntPtr hConsoleOutput,
            [Out] ushort[] lpAttribute,
            uint nLength,
            COORD dwReadCoord,
            out uint lpNumberOfAttrsRead
            );

        // http://pinvoke.net/default.aspx/kernel32/ReadConsoleOutputCharacter.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadConsoleOutputCharacter(
            IntPtr hConsoleOutput,
            [Out] StringBuilder lpCharacter,
            uint nLength,
            COORD dwReadCoord,
            out uint lpNumberOfCharsRead
            );

        // http://pinvoke.net/default.aspx/kernel32/ScrollConsoleScreenBuffer.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ScrollConsoleScreenBuffer(
            IntPtr hConsoleOutput,
           [In] ref SMALL_RECT lpScrollRectangle,
            IntPtr lpClipRectangle,
           COORD dwDestinationOrigin,
            [In] ref CHAR_INFO lpFill
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleActiveScreenBuffer.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleActiveScreenBuffer(
            IntPtr hConsoleOutput
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleCP.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleCP(
            uint wCodePageID
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleCtrlHandler.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleCtrlHandler(
            ConsoleCtrlDelegate HandlerRoutine,
            bool Add
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleCursorInfo.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleCursorInfo(
            IntPtr hConsoleOutput,
            [In] ref CONSOLE_CURSOR_INFO lpConsoleCursorInfo
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleCursorPosition.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleCursorPosition(
            IntPtr hConsoleOutput,
           COORD dwCursorPosition
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleDisplayMode.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleDisplayMode(
            IntPtr ConsoleOutput,
            uint Flags,
            out COORD NewScreenBufferDimensions
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleHistoryInfo.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleHistoryInfo(
            CONSOLE_HISTORY_INFO ConsoleHistoryInfo
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleMode.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(
            IntPtr hConsoleHandle,
            uint dwMode
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleMode(
            IntPtr hConsoleHandle,
            int dwMode
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleOutputCP.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleOutputCP(
            uint wCodePageID
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleScreenBufferInfoEx.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleScreenBufferInfoEx(
            IntPtr ConsoleOutput,
            CONSOLE_SCREEN_BUFFER_INFO_EX ConsoleScreenBufferInfoEx
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleScreenBufferSize.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleScreenBufferSize(
            IntPtr hConsoleOutput,
            COORD dwSize
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleTextAttribute.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleTextAttribute(
            IntPtr hConsoleOutput,
           ushort wAttributes
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleTitle.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleTitle(
            string lpConsoleTitle
            );

        // http://pinvoke.net/default.aspx/kernel32/SetConsoleWindowInfo.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetConsoleWindowInfo(
            IntPtr hConsoleOutput,
            bool bAbsolute,
            [In] ref SMALL_RECT lpConsoleWindow
            );

        // http://pinvoke.net/default.aspx/kernel32/SetCurrentConsoleFontEx.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetCurrentConsoleFontEx(
            IntPtr ConsoleOutput,
            bool MaximumWindow,
            ref CONSOLE_FONT_INFO_EX ConsoleCurrentFontEx
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetCurrentConsoleFontEx(
            IntPtr ConsoleOutput,
            bool MaximumWindow,
            CONSOLE_FONT_INFO_EX ConsoleCurrentFontEx
            );

        // http://pinvoke.net/default.aspx/kernel32/SetStdHandle.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetStdHandle(
            uint nStdHandle,
            IntPtr hHandle
            );

        // http://pinvoke.net/default.aspx/kernel32/WriteConsole.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteConsole(
            IntPtr hConsoleOutput,
            string lpBuffer,
            uint nNumberOfCharsToWrite,
            out uint lpNumberOfCharsWritten,
            IntPtr lpReserved
            );

        // http://pinvoke.net/default.aspx/kernel32/WriteConsoleInput.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteConsoleInput(
            IntPtr hConsoleInput,
            INPUT_RECORD[] lpBuffer,
            uint nLength,
            out uint lpNumberOfEventsWritten
            );

        // http://pinvoke.net/default.aspx/kernel32/WriteConsoleOutput.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteConsoleOutput(
            IntPtr hConsoleOutput,
            CHAR_INFO[] lpBuffer,
            COORD dwBufferSize,
            COORD dwBufferCoord,
            ref SMALL_RECT lpWriteRegion
            );

        // http://pinvoke.net/default.aspx/kernel32/WriteConsoleOutputAttribute.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteConsoleOutputAttribute(
            IntPtr hConsoleOutput,
            ushort[] lpAttribute,
            uint nLength,
            COORD dwWriteCoord,
            out uint lpNumberOfAttrsWritten
            );

        // http://pinvoke.net/default.aspx/kernel32/WriteConsoleOutputCharacter.html
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteConsoleOutputCharacter(
            IntPtr hConsoleOutput,
            string lpCharacter,
            uint nLength,
            COORD dwWriteCoord,
            out uint lpNumberOfCharsWritten
            );

        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            internal short X;
            internal short Y;

            internal COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }

        public struct SMALL_RECT
        {

            public short Left;
            public short Top;
            public short Right;
            public short Bottom;

        }

        public struct CONSOLE_SCREEN_BUFFER_INFO
        {

            public COORD dwSize;
            public COORD dwCursorPosition;
            public short wAttributes;
            public SMALL_RECT srWindow;
            public COORD dwMaximumWindowSize;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CONSOLE_SCREEN_BUFFER_INFO_EX
        {
            public uint cbSize;
            public COORD dwSize;
            public COORD dwCursorPosition;
            public short wAttributes;
            public SMALL_RECT srWindow;
            public COORD dwMaximumWindowSize;

            public ushort wPopupAttributes;
            public bool bFullscreenSupported;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public COLORREF[] ColorTable;

            public static CONSOLE_SCREEN_BUFFER_INFO_EX Create()
            {
                return new CONSOLE_SCREEN_BUFFER_INFO_EX { cbSize = 96 };
            }
        }

        //[StructLayout(LayoutKind.Sequential)]
        //struct COLORREF
        //{
        //    public byte R;
        //    public byte G;
        //    public byte B;
        //}

        [StructLayout(LayoutKind.Sequential)]
        public struct COLORREF
        {
            public uint ColorDWORD;

            public COLORREF(Color color)
            {
                ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
            }

            public Color GetColor()
            {
                return Color.FromArgb((int)(0x000000FFU & ColorDWORD),
                   (int)(0x0000FF00U & ColorDWORD) >> 8, (int)(0x00FF0000U & ColorDWORD) >> 16);
            }

            public void SetColor(Color color)
            {
                ColorDWORD = (uint)color.R + (((uint)color.G) << 8) + (((uint)color.B) << 16);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CONSOLE_FONT_INFO
        {
            public int nFont;
            public COORD dwFontSize;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[32];
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT_RECORD
        {
            [FieldOffset(0)]
            public ushort EventType;
            [FieldOffset(4)]
            public KEY_EVENT_RECORD KeyEvent;
            [FieldOffset(4)]
            public MOUSE_EVENT_RECORD MouseEvent;
            [FieldOffset(4)]
            public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;
            [FieldOffset(4)]
            public MENU_EVENT_RECORD MenuEvent;
            [FieldOffset(4)]
            public FOCUS_EVENT_RECORD FocusEvent;
        };

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct KEY_EVENT_RECORD
        {
            [FieldOffset(0), MarshalAs(UnmanagedType.Bool)]
            public bool bKeyDown;
            [FieldOffset(4), MarshalAs(UnmanagedType.U2)]
            public ushort wRepeatCount;
            [FieldOffset(6), MarshalAs(UnmanagedType.U2)]
            //public VirtualKeys wVirtualKeyCode;
            public ushort wVirtualKeyCode;
            [FieldOffset(8), MarshalAs(UnmanagedType.U2)]
            public ushort wVirtualScanCode;
            [FieldOffset(10)]
            public char UnicodeChar;
            [FieldOffset(12), MarshalAs(UnmanagedType.U4)]
            //public ControlKeyState dwControlKeyState;
            public uint dwControlKeyState;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSE_EVENT_RECORD
        {
            public COORD dwMousePosition;
            public uint dwButtonState;
            public uint dwControlKeyState;
            public uint dwEventFlags;
        }

        public struct WINDOW_BUFFER_SIZE_RECORD
        {
            public COORD dwSize;

            public WINDOW_BUFFER_SIZE_RECORD(short x, short y)
            {
                dwSize = new COORD();
                dwSize.X = x;
                dwSize.Y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MENU_EVENT_RECORD
        {
            public uint dwCommandId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FOCUS_EVENT_RECORD
        {
            public uint bSetFocus;
        }

        //CHAR_INFO struct, which was a union in the old days
        // so we want to use LayoutKind.Explicit to mimic it as closely
        // as we can
        [StructLayout(LayoutKind.Explicit)]
        public struct CHAR_INFO
        {
            [FieldOffset(0)]
            char UnicodeChar;
            [FieldOffset(0)]
            char AsciiChar;
            [FieldOffset(2)] //2 bytes seems to work properly
            UInt16 Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CONSOLE_CURSOR_INFO
        {
            uint Size;
            bool Visible;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CONSOLE_HISTORY_INFO
        {
            ushort cbSize;
            ushort HistoryBufferSize;
            ushort NumberOfHistoryBuffers;
            uint dwFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CONSOLE_SELECTION_INFO
        {
            uint Flags;
            COORD SelectionAnchor;
            SMALL_RECT Selection;

            // Flags values:
            const uint CONSOLE_MOUSE_DOWN = 0x0008; // Mouse is down
            const uint CONSOLE_MOUSE_SELECTION = 0x0004; //Selecting with the mouse
            const uint CONSOLE_NO_SELECTION = 0x0000; //No selection
            const uint CONSOLE_SELECTION_IN_PROGRESS = 0x0001; //Selection has begun
            const uint CONSOLE_SELECTION_NOT_EMPTY = 0x0002; //Selection rectangle is not empty
        }

        // Enumerated type for the control messages sent to the handler routine
        public enum CtrlTypes : uint
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }
        #endregion

        #region User32.dll
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(SystemMetric smIndex);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        public enum SystemMetric
        {
            SM_CXSCREEN = 0,  // 0x00
            SM_CYSCREEN = 1,  // 0x01
            SM_CXVSCROLL = 2,  // 0x02
            SM_CYHSCROLL = 3,  // 0x03
            SM_CYCAPTION = 4,  // 0x04
            SM_CXBORDER = 5,  // 0x05
            SM_CYBORDER = 6,  // 0x06
            SM_CXDLGFRAME = 7,  // 0x07
            SM_CXFIXEDFRAME = 7,  // 0x07
            SM_CYDLGFRAME = 8,  // 0x08
            SM_CYFIXEDFRAME = 8,  // 0x08
            SM_CYVTHUMB = 9,  // 0x09
            SM_CXHTHUMB = 10, // 0x0A
            SM_CXICON = 11, // 0x0B
            SM_CYICON = 12, // 0x0C
            SM_CXCURSOR = 13, // 0x0D
            SM_CYCURSOR = 14, // 0x0E
            SM_CYMENU = 15, // 0x0F
            SM_CXFULLSCREEN = 16, // 0x10
            SM_CYFULLSCREEN = 17, // 0x11
            SM_CYKANJIWINDOW = 18, // 0x12
            SM_MOUSEPRESENT = 19, // 0x13
            SM_CYVSCROLL = 20, // 0x14
            SM_CXHSCROLL = 21, // 0x15
            SM_DEBUG = 22, // 0x16
            SM_SWAPBUTTON = 23, // 0x17
            SM_CXMIN = 28, // 0x1C
            SM_CYMIN = 29, // 0x1D
            SM_CXSIZE = 30, // 0x1E
            SM_CYSIZE = 31, // 0x1F
            SM_CXSIZEFRAME = 32, // 0x20
            SM_CXFRAME = 32, // 0x20
            SM_CYSIZEFRAME = 33, // 0x21
            SM_CYFRAME = 33, // 0x21
            SM_CXMINTRACK = 34, // 0x22
            SM_CYMINTRACK = 35, // 0x23
            SM_CXDOUBLECLK = 36, // 0x24
            SM_CYDOUBLECLK = 37, // 0x25
            SM_CXICONSPACING = 38, // 0x26
            SM_CYICONSPACING = 39, // 0x27
            SM_MENUDROPALIGNMENT = 40, // 0x28
            SM_PENWINDOWS = 41, // 0x29
            SM_DBCSENABLED = 42, // 0x2A
            SM_CMOUSEBUTTONS = 43, // 0x2B
            SM_SECURE = 44, // 0x2C
            SM_CXEDGE = 45, // 0x2D
            SM_CYEDGE = 46, // 0x2E
            SM_CXMINSPACING = 47, // 0x2F
            SM_CYMINSPACING = 48, // 0x30
            SM_CXSMICON = 49, // 0x31
            SM_CYSMICON = 50, // 0x32
            SM_CYSMCAPTION = 51, // 0x33
            SM_CXSMSIZE = 52, // 0x34
            SM_CYSMSIZE = 53, // 0x35
            SM_CXMENUSIZE = 54, // 0x36
            SM_CYMENUSIZE = 55, // 0x37
            SM_ARRANGE = 56, // 0x38
            SM_CXMINIMIZED = 57, // 0x39
            SM_CYMINIMIZED = 58, // 0x3A
            SM_CXMAXTRACK = 59, // 0x3B
            SM_CYMAXTRACK = 60, // 0x3C
            SM_CXMAXIMIZED = 61, // 0x3D
            SM_CYMAXIMIZED = 62, // 0x3E
            SM_NETWORK = 63, // 0x3F
            SM_CLEANBOOT = 67, // 0x43
            SM_CXDRAG = 68, // 0x44
            SM_CYDRAG = 69, // 0x45
            SM_SHOWSOUNDS = 70, // 0x46
            SM_CXMENUCHECK = 71, // 0x47
            SM_CYMENUCHECK = 72, // 0x48
            SM_SLOWMACHINE = 73, // 0x49
            SM_MIDEASTENABLED = 74, // 0x4A
            SM_MOUSEWHEELPRESENT = 75, // 0x4B
            SM_XVIRTUALSCREEN = 76, // 0x4C
            SM_YVIRTUALSCREEN = 77, // 0x4D
            SM_CXVIRTUALSCREEN = 78, // 0x4E
            SM_CYVIRTUALSCREEN = 79, // 0x4F
            SM_CMONITORS = 80, // 0x50
            SM_SAMEDISPLAYFORMAT = 81, // 0x51
            SM_IMMENABLED = 82, // 0x52
            SM_CXFOCUSBORDER = 83, // 0x53
            SM_CYFOCUSBORDER = 84, // 0x54
            SM_TABLETPC = 86, // 0x56
            SM_MEDIACENTER = 87, // 0x57
            SM_STARTER = 88, // 0x58
            SM_SERVERR2 = 89, // 0x59
            SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
            SM_CXPADDEDBORDER = 92, // 0x5C
            SM_DIGITIZER = 94, // 0x5E
            SM_MAXIMUMTOUCHES = 95, // 0x5F

            SM_REMOTESESSION = 0x1000, // 0x1000
            SM_SHUTTINGDOWN = 0x2000, // 0x2000
            SM_REMOTECONTROL = 0x2001, // 0x2001


            SM_CONVERTIBLESLATEMODE = 0x2003,
            SM_SYSTEMDOCKED = 0x2004,
        }
        public const int SWP_ASYNCWINDOWPOS = 0x4000;
        public const int SWP_DEFERERASE = 0x2000;
        public const int SWP_DRAWFRAME = 0x0020;
        public const int SWP_FRAMECHANGED = 0x0020;
        public const int SWP_HIDEWINDOW = 0x0080;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOOWNERZORDER = 0x0200;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOREPOSITION = 0x0200;
        public const int SWP_NOSENDCHANGING = 0x0400;
        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_SHOWWINDOW = 0x0040;

        public const int HWND_TOP = 0;
        public const int HWND_BOTTOM = 1;
        public const int HWND_TOPMOST = -1;
        public const int HWND_NOTOPMOST = -2;

        public static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        public static readonly int TMPF_TRUETYPE = 4;
        public static readonly int STD_OUTPUT_HANDLE = -11;

        public struct RECT
        {
            public int left, top, right, bottom;

            public RECT(int Left, int Top, int Right, int Bottom)
            {
                this.left = Left;
                this.top = Top;
                this.right = Right;
                this.bottom = Bottom;
            }

            public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

            public int X
            {
                get { return left; }
                set { right -= (left - value); left = value; }
            }

            public int Y
            {
                get { return top; }
                set { bottom -= (top - value); top = value; }
            }

            public int Height
            {
                get { return bottom - top; }
                set { bottom = value + top; }
            }

            public int Width
            {
                get { return right - left; }
                set { right = value + left; }
            }

            public System.Drawing.Point Location
            {
                get { return new System.Drawing.Point(left, top); }
                set { X = value.X; Y = value.Y; }
            }

            public System.Drawing.Size Size
            {
                get { return new System.Drawing.Size(Width, Height); }
                set { Width = value.Width; Height = value.Height; }
            }

            public static implicit operator System.Drawing.Rectangle(RECT r)
            {
                return new System.Drawing.Rectangle(r.left, r.top, r.Width, r.Height);
            }

            public static implicit operator RECT(System.Drawing.Rectangle r)
            {
                return new RECT(r);
            }

            public static bool operator ==(RECT r1, RECT r2)
            {
                return r1.Equals(r2);
            }

            public static bool operator !=(RECT r1, RECT r2)
            {
                return !r1.Equals(r2);
            }

            public bool Equals(RECT r)
            {
                return r.left == left && r.top == top && r.right == right && r.bottom == bottom;
            }

            public override bool Equals(object obj)
            {
                if (obj is RECT)
                    return Equals((RECT)obj);
                else if (obj is System.Drawing.Rectangle)
                    return Equals(new RECT((System.Drawing.Rectangle)obj));
                return false;
            }

            public override int GetHashCode()
            {
                return ((System.Drawing.Rectangle)this).GetHashCode();
            }
        }
        #endregion

    }

}
