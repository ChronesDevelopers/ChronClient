using System;

namespace Chrones.Cmr.Color
{
    public static class cmr_color
    {
        public static System.Drawing.Color CounterToColor(double counter)
        {
            counter = Math.Max(counter, 0);
            int _counter = Convert.ToInt32(counter);
            counter %= 1536;
            counter = Math.Min(counter, 1536);
            System.Drawing.Color _return;

            if (counter < 256)
            {
                _counter %= 256;
                _return = System.Drawing.Color.FromArgb(255, 255, _counter, 0);
            } else if (counter < 511)
            {
                _counter %= 256;
                _return = System.Drawing.Color.FromArgb(255, 255 - _counter, 255, 0);
            }
            else if (counter < 768)
            {
                _counter %= 256;
                _return = System.Drawing.Color.FromArgb(255, 0, 255, _counter);
            }
            else if (counter < 1024)
            {
                _counter %= 256;
                _return = System.Drawing.Color.FromArgb(255, 0, 255 - _counter, 255);
            }
            else if (counter < 1280)
            {
                _counter %= 256;
                _return = System.Drawing.Color.FromArgb(255, _counter, 0, 255);
            }
            else if (counter < 1536)
            {
                _counter %= 256;
                _return = System.Drawing.Color.FromArgb(255, 255, 0, 255 -_counter);
            } else _return = System.Drawing.Color.FromArgb(255, 255, 255, 255);

            return _return;
        }

        public static System.Windows.Media.Color WindowsCounterToColor(double counter)
        {
            System.Drawing.Color color = CounterToColor(counter);
            return System.Windows.Media.Color.FromArgb(255, color.R, color.G, color.B);
        }
    }
}
