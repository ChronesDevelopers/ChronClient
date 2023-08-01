using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChronClient.Threads
{
    public static class ColorRGBUpdate
    {
        public static BackgroundWorker worker;
        public static double ColorRGBCounter = 0;

        public static void Start()
        {
            worker = new BackgroundWorker();

            if (!worker.IsBusy)
            {
                worker.DoWork += new DoWorkEventHandler(Loop);
                worker.RunWorkerAsync();
            }
        }

        private static void Loop(object sender, EventArgs e)
        {
            while (true)
            {
                try
                {
                    ColorRGBCounter += Data.GlobalData.ColorRGBCounter.ColorRGBCounterSpeed;
                    ColorRGBCounter = Math.Max(ColorRGBCounter, 0);
                    ColorRGBCounter %= 1536;
                }
                catch
                {
                    ColorRGBCounter = 0;
                }
                Thread.Sleep(10);
            }
        }
    }
}
