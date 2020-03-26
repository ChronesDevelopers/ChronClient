using ChronClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChronClient.Threads
{
    public static class ThreadManagement
    {
        public static void StartAllThreads()
        {
            ColorRGBManagment.StartColorRGBCounter();
            CInputManagment.StartThread();
            OverlayManagment.StartOverlay();
        }

        public static class CInputManagment
        {
            public static void StartThread()
            {
                ChronClient.Input.CInput.StartThread();
            }
        }

        public static class Application
        {
            public static Thread ConsoleThread;

            public static string[] args = Environment.GetCommandLineArgs();

            public static void InitializeThread()
            {
                ConsoleThread = new Thread(new ThreadStart(ConsoleMain));
                ConsoleThread.SetApartmentState(ApartmentState.STA);
                ConsoleThread.Start();
            }

            public static void ConsoleMain()
            {
                ChronClientConsole.Start(args);
            }
        }

        public static class OldOverlayManagment
        {
            public static Thread OverlayThread;
            public static void StartOverlay()
            {
                OverlayThread = new Thread(OverlayLoop);
                OverlayThread.SetApartmentState(ApartmentState.STA);
                OverlayThread.Start();
            }

            private static void OverlayLoop()
            {
                System.Windows.Forms.Application.EnableVisualStyles();
                CommunicationData.Overlay.overlay = new ChronClient.GUI.Forms.OldOverlay();
                System.Windows.Forms.Application.Run(CommunicationData.Overlay.overlay);
                CommunicationData.Overlay.overlay.Show();
            }
        }

        public static class OverlayManagment
        {
            public static GUI.Overlay overlay;
            public static Thread OverlayThread;

            public static void StartOverlay()
            {
                OverlayThread = new Thread(OverlayStart);
                OverlayThread.SetApartmentState(ApartmentState.STA);
                OverlayThread.Priority = ThreadPriority.AboveNormal;
                OverlayThread.Start();
            }

            private static void OverlayStart()
            {
                overlay = new GUI.Overlay();
                overlay.InitializeComponent();
                overlay.Show();
                System.Windows.Threading.Dispatcher.Run();
            }
        }

        public static class ColorRGBManagment
        {
            public static Thread ColorRGBCounterThread;

            public static void StartColorRGBCounter()
            {
                ColorRGBCounterThread = new Thread(new ThreadStart(ColorRGBCounterLoop));
                ColorRGBCounterThread.Priority = ThreadPriority.BelowNormal;
                ColorRGBCounterThread.Start();
            }

            private static void ColorRGBCounterLoop()
            {
                while (true)
                {
                    try
                    {
                        Data.CommunicationData.GUI.ColorRGBCounter += ChronClient.Data.GUI_Data.ColorRGBCounterSpeed;
                        Data.CommunicationData.GUI.ColorRGBCounter = Math.Max(Data.CommunicationData.GUI.ColorRGBCounter, 0);
                        Data.CommunicationData.GUI.ColorRGBCounter %= 1536;
                    }
                    catch
                    {
                        Data.CommunicationData.GUI.ColorRGBCounter = 0;
                    }
                    Thread.Sleep(10);
                }
            }
        }
    }
}
