using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrones
{
    public static partial class cmr
    {
        /// <summary>
        /// Console.Write
        /// </summary>
        /// <param name="value">Value</param>
        public static void cout(object value)
        {
            Console.Write(value);
        }
        /// <summary>
        /// Console.WriteLine
        /// </summary>
        /// <param name="value">Value</param>
        public static void coutl(object value)
        {
            Console.WriteLine(value);
        }
        /// <summary>
        /// Debug.Write
        /// </summary>
        /// <param name="value">Value</param>
        public static void dout(object value)
        {
            Debug.Write(value);
        }
        /// <summary>
        /// Debug.WriteLine
        /// </summary>
        /// <param name="value">Value</param>
        public static void doutl(object value)
        {
            Debug.WriteLine(value);
        }
        /// <summary>
        /// Console.ReadLine
        /// </summary>
        public static string getl()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// Console.ReadKey
        /// </summary>
        public static ConsoleKeyInfo getk()
        {
            return Console.ReadKey();
        }
        /// <summary>
        /// Console.ReadKey
        /// </summary>
        /// <param name="ShowInput">Show Input when typing | True: Shows Input | False: Does not Show Input </param>
        /// <returns></returns>
        public static ConsoleKeyInfo getk(bool ShowInput)
        {
            return Console.ReadKey(!ShowInput);
        }
        /// <summary>
        /// Console.ReadKey -> Char
        /// </summary>
        public static char getch()
        {
            return Console.ReadKey().KeyChar;
        }
        /// <summary>
        /// Console.ReadKey -> Char
        /// </summary>
        /// <param name="ShowInput">Show Input when typing | True: Shows Input | False: Does not Show Input </param>
        /// <returns></returns>
        public static char getch(bool ShowInput)
        {
            return Console.ReadKey(!ShowInput).KeyChar;
        }
        /// <summary>
        /// Console.ReadKey -> String
        /// </summary>
        public static string getstr()
        {
            return Console.ReadKey().KeyChar.ToString();
        }
        /// <summary>
        /// Console.ReadKey -> String
        /// </summary>
        /// <param name="ShowInput">Show Input when typing | True: Shows Input | False: Does not Show Input </param>
        /// <returns></returns>
        public static string getstr(bool ShowInput)
        {
            return Console.ReadKey(!ShowInput).KeyChar.ToString();
        }
        public static void ctitle(string Title)
        {
            Console.Title = Title;
        }
        public static string cf(byte r, byte g, byte b)
        {
            return "\x1b[38;2;" + r + ";" + g + ";" + b + "m";
        }
        public static string cb(byte r, byte g, byte b)
        {
            return "\x1b[48;2;" + r + ";" + g + ";" + b + "m";
        }
        public static string cf(int r, int g, int b)
        {
            return "\x1b[38;2;" + r + ";" + g + ";" + b + "m";
        }
        public static string cb(int r, int g, int b)
        {
            return "\x1b[48;2;" + r + ";" + g + ";" + b + "m";
        }
        public static string cf(System.Drawing.Color c)
        {
            return "\x1b[38;2;" + c.R + ";" + c.G + ";" + c.B + "m";
        }
        public static string cb(System.Drawing.Color c)
        {
            return "\x1b[48;2;" + c.R + ";" + c.G + ";" + c.B + "m";
        }
        public static string cf(System.Windows.Media.Color c)
        {
            return "\x1b[38;2;" + c.R + ";" + c.G + ";" + c.B + "m";
        }
        public static string cb(System.Windows.Media.Color c)
        {
            return "\x1b[48;2;" + c.R + ";" + c.G + ";" + c.B + "m";
        }
        public static string cr { get; } = "\x1b[39m\x1b[49m";
        public static string cfr { get; } = "\x1b[39m";
        public static string cbr { get; } = "\x1b[49m";
        public static void ccoutr()
        {
            Console.Write(cmr.cr);
        }
        public static void ccoutlr()
        {
            Console.WriteLine(cmr.cr);
        }
        public static void ccoutfr()
        {
            Console.Write(cmr.cfr);
        }
        public static void ccoutlfr()
        {
            Console.WriteLine(cmr.cfr);
        }
        public static void ccoutbr()
        {
            Console.Write(cmr.cbr);
        }
        public static void ccoutlbr()
        {
            Console.WriteLine(cmr.cbr);
        }
        public static void ccout(object value, string colorcode)
        {
            Console.Write(colorcode + value.ToString());
        }
        public static void ccout(object value, string colorcode1, string colorcode2)
        {
            Console.Write(colorcode1 + colorcode2 + value.ToString());
        }
        public static void ccout(object value, string colorcode1, string colorcode2, string colorcode3)
        {
            Console.Write(colorcode1 + colorcode2 + colorcode3 + value.ToString());
        }
        public static void ccout(object value, string colorcode1, string colorcode2, string colorcode3, string colorcode4)
        {
            Console.Write(colorcode1 + colorcode2 + colorcode3 + colorcode4 + value.ToString());
        }
        public static void ccout(object value, string colorcode1, string colorcode2, string colorcode3, string colorcode4, string colorcode5)
        {
            Console.Write(colorcode1 + colorcode2 + colorcode3 + colorcode4 + colorcode5 + value.ToString());
        }
        public static void ccoutl(object value, string colorcode)
        {
            Console.WriteLine(colorcode + value.ToString());
        }
        public static void ccoutl(object value, string colorcode1, string colorcode2)
        {
            Console.WriteLine(colorcode1 + colorcode2 + value.ToString());
        }
        public static void ccoutl(object value, string colorcode1, string colorcode2, string colorcode3)
        {
            Console.WriteLine(colorcode1 + colorcode2 + colorcode3 + value.ToString());
        }
        public static void ccoutl(object value, string colorcode1, string colorcode2, string colorcode3, string colorcode4)
        {
            Console.WriteLine(colorcode1 + colorcode2 + colorcode3 + colorcode4 + value.ToString());
        }
        public static void ccoutl(object value, string colorcode1, string colorcode2, string colorcode3, string colorcode4, string colorcode5)
        {
            Console.WriteLine(colorcode1 + colorcode2 + colorcode3 + colorcode4 + colorcode5 + value.ToString());
        }
        public static void ccoutf(object value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cf(r,g,b) + value.ToString());
        }
        public static void ccoutb(object value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
        }
        public static void ccoutf(object value, int r, int g, int b)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
        }
        public static void ccoutb(object value, int r, int g, int b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
        }
        public static void ccoutlf(object value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
        }
        public static void ccoutlb(object value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
        }
        public static void ccoutlf(object value, int r, int g, int b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
        }
        public static void ccoutlb(object value, int r, int g, int b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
        }
        public static void ccoutf(byte r, byte g, byte b, object value)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
        }
        public static void ccoutb(byte r, byte g, byte b, object value)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
        }
        public static void ccoutf(int r, int g, int b, object value)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
        }
        public static void ccoutb(int r, int g, int b, object value)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
        }
        public static void ccoutlf(byte r, byte g, byte b, object value)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
        }
        public static void ccoutlb(byte r, byte g, byte b, object value)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
        }
        public static void ccoutlf(int r, int g, int b, object value)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
        }
        public static void ccoutlb(int r, int g, int b, object value)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
        }
        public static void ccoutf(byte r, byte g, byte b)
        {
            Console.Write(cmr.cf(r, g, b));
        }
        public static void ccoutb(byte r, byte g, byte b)
        {
            Console.Write(cmr.cb(r, g, b));
        }
        public static void ccoutf(int r, int g, int b)
        {
            Console.Write(cmr.cf(r, g, b));
        }
        public static void ccoutb(int r, int g, int b)
        {
            Console.Write(cmr.cb(r, g, b));
        }
        // String
        public static string cout(this string value)
        {
            Console.Write(value);
            return value;
        }
        public static char cout(this char value)
        {
            Console.Write(value);
            return value;
        }
        public static string coutl(this string value)
        {
            Console.WriteLine(value);
            return value;
        }
        public static char coutl(this char value)
        {
            Console.WriteLine(value);
            return value;
        }
        public static string dout(this string value)
        {
            Debug.Write(value);
            return value;
        }
        public static char dout(this char value)
        {
            Debug.Write(value);
            return value;
        }
        public static string doutl(this string value)
        {
            Debug.WriteLine(value);
            return value;
        }
        public static char doutl(this char value)
        {
            Debug.WriteLine(value);
            return value;
        }
        public static string ccoutf(this string value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static string ccoutb(this string value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static string ccoutf(this string value, int r, int g, int b)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static string ccoutb(this string value, int r, int g, int b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static string ccoutlf(this string value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static string ccoutlb(this string value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static string ccoutlf(this string value, int r, int g, int b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static string ccoutlb(this string value, int r, int g, int b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static string ccoutf(this string value, System.Drawing.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static string ccoutb(this string value, System.Drawing.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static string ccoutlf(this string value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static string ccoutlb(this string value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        public static string ccoutf(this string value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static string ccoutb(this string value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static string ccoutlf(this string value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static string ccoutlb(this string value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        // Int
        public static int cout(this int value)
        {
            Console.Write(value);
            return value;
        }
        public static int coutl(this int value)
        {
            Console.WriteLine(value);
            return value;
        }
        public static int dout(this int value)
        {
            Debug.Write(value);
            return value;
        }
        public static int doutl(this int value)
        {
            Debug.WriteLine(value);
            return value;
        }
        public static int ccoutf(this int value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static int ccoutb(this int value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static int ccoutlf(this int value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static int ccoutlb(this int value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static int ccoutf(this int value, System.Drawing.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static int ccoutb(this int value, System.Drawing.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static int ccoutlf(this int value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static int ccoutlb(this int value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        public static int ccoutf(this int value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static int ccoutb(this int value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static int ccoutlf(this int value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static int ccoutlb(this int value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        // Long
        public static long cout(this long value)
        {
            Console.Write(value);
            return value;
        }
        public static long coutl(this long value)
        {
            Console.WriteLine(value);
            return value;
        }
        public static long dout(this long value)
        {
            Debug.Write(value);
            return value;
        }
        public static long doutl(this long value)
        {
            Debug.WriteLine(value);
            return value;
        }
        public static long ccoutf(this long value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static long ccoutb(this long value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static long ccoutlf(this long value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static long ccoutlb(this long value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static long ccoutf(this long value, System.Drawing.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static long ccoutb(this long value, System.Drawing.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static long ccoutlf(this long value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static long ccoutlb(this long value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        public static long ccoutf(this long value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static long ccoutb(this long value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static long ccoutlf(this long value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static long ccoutlb(this long value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        // Float
        public static float cout(this float value)
        {
            Console.Write(value);
            return value;
        }
        public static float coutl(this float value)
        {
            Console.WriteLine(value);
            return value;
        }
        public static float dout(this float value)
        {
            Debug.Write(value);
            return value;
        }
        public static float doutl(this float value)
        {
            Debug.WriteLine(value);
            return value;
        }
        public static float ccoutf(this float value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static float ccoutb(this float value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static float ccoutlf(this float value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static float ccoutlb(this float value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static float ccoutf(this float value, System.Drawing.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static float ccoutb(this float value, System.Drawing.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static float ccoutlf(this float value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static float ccoutlb(this float value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        public static float ccoutf(this float value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static float ccoutb(this float value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static float ccoutlf(this float value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static float ccoutlb(this float value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        // Double
        public static double cout(this double value)
        {
            Console.Write(value);
            return value;
        }
        public static double coutl(this double value)
        {
            Console.WriteLine(value);
            return value;
        }
        public static double dout(this double value)
        {
            Debug.Write(value);
            return value;
        }
        public static double doutl(this double value)
        {
            Debug.WriteLine(value);
            return value;
        }
        public static double ccoutf(this double value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static double ccoutb(this double value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static double ccoutlf(this double value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static double ccoutlb(this double value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static double ccoutf(this double value, System.Drawing.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static double ccoutb(this double value, System.Drawing.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static double ccoutlf(this double value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static double ccoutlb(this double value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        public static double ccoutf(this double value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static double ccoutb(this double value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static double ccoutlf(this double value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static double ccoutlb(this double value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        // Byte
        public static byte cout(this byte value)
        {
            Console.Write(value);
            return value;
        }
        public static byte coutl(this byte value)
        {
            Console.WriteLine(value);
            return value;
        }
        public static byte dout(this byte value)
        {
            Debug.Write(value);
            return value;
        }
        public static byte doutl(this byte value)
        {
            Debug.WriteLine(value);
            return value;
        }
        public static byte ccoutf(this byte value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static byte ccoutb(this byte value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static byte ccoutlf(this byte value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static byte ccoutlb(this byte value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static byte ccoutf(this byte value, System.Drawing.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static byte ccoutb(this byte value, System.Drawing.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static byte ccoutlf(this byte value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static byte ccoutlb(this byte value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        public static byte ccoutf(this byte value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static byte ccoutb(this byte value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static byte ccoutlf(this byte value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static byte ccoutlb(this byte value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        // Char
        public static char ccoutf(this char value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static char ccoutb(this char value, byte r, byte g, byte b)
        {
            Console.Write(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static char ccoutlf(this char value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cf(r, g, b) + value.ToString());
            return value;
        }
        public static char ccoutlb(this char value, byte r, byte g, byte b)
        {
            Console.WriteLine(cmr.cb(r, g, b) + value.ToString());
            return value;
        }
        public static char ccoutf(this char value, System.Drawing.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static char ccoutb(this char value, System.Drawing.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static char ccoutlf(this char value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static char ccoutlb(this char value, System.Drawing.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
        public static char ccoutf(this char value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cf(c) + value.ToString());
            return value;
        }
        public static char ccoutb(this char value, System.Windows.Media.Color c)
        {
            Console.Write(cmr.cb(c) + value.ToString());
            return value;
        }
        public static char ccoutlf(this char value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cf(c) + value.ToString());
            return value;
        }
        public static char ccoutlb(this char value, System.Windows.Media.Color c)
        {
            Console.WriteLine(cmr.cb(c) + value.ToString());
            return value;
        }
    }
}
