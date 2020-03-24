using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chrones.Cmr;
using Chrones.Cmr.Font;
using ChronClient.Data;
using ChronClient.GUI.Forms;
using Chrones.Cmr.Imports;
using System.Diagnostics;
using Chrones.Cmr.Color;

namespace ChronClient
{
    public static class ChronClientConsole
    {
        public static void Start(string[] args)
        {
            Console.Title = @"ChronClient Console";
            cmr.EnableVirtualTerminalProcessing();
            cmr.DisableQuickEdit();
            Process.Start("minecraft://");
            StartScreen();
            Console.WriteLine($@"{cmr.cf(255, 255, 255)}Thanks for using ChronClient :D");
            cmr.clogl(ConsoleData.ChronClientLogName, "Loading Application");
            ColorRGBManagment.StartColorRGBCounter();
            StroringInformationSetup.FileSetup();
            Thread.Sleep(500);
            cmr.clogl(ConsoleData.ChronClientLogName, "Loading Cmr");
            Thread.Sleep(300);
            cmr.clogl(ConsoleData.ChronClientLogName, "Loading Console Engine");
            Thread.Sleep(500);
            cmr.clogl(ConsoleData.ChronClientLogName, "Loading GUI");
            Thread.Sleep(800);
            OverlayManagment.StartOverlay();
            cmr.MinimizeConsole();
            Thread.Sleep(200);
            cmr.clogl(ConsoleData.ChronClientLogName, "//Loading Modules");
            Thread.Sleep(200);
            cmr.clogl(ConsoleData.ChronClientLogName, "//Loading Module_AirJump");
            Thread.Sleep(50);
            cmr.clogl(ConsoleData.ChronClientLogName, "//Loading Module_Glide");
            Thread.Sleep(50);
            cmr.clogl(ConsoleData.ChronClientLogName, "//Loading Module_RapidHit");
            Thread.Sleep(50);
            cmr.clogl(ConsoleData.ChronClientLogName, "//Loading Module_ClickTeleport");
            Thread.Sleep(50);
            cmr.clogl(ConsoleData.ChronClientLogName, "//Loading Module_Teleport");
            Thread.Sleep(50);
            cmr.clogl(ConsoleData.ChronClientLogName, "//Loading Module_NoFallDamage");
            Thread.Sleep(50);
            cmr.clogl(ConsoleData.ChronClientLogName, "Finished!");
        }

        public static void StartScreen()
        {
            cmr_font.SetConsoleFont("Consolas", 13, 27);
            cmr.CenterConsole();
            cmr.MaximizeConsole();
            Thread.Sleep(10);
            Console.Write(cmr.cb(71, 255, 123) + cmr.cf(71, 255, 123));
            Console.Write("######################################################################################\n"); Console.Write(cmr.cf(0,0,0));
            Console.Write(" Welcome to the                                                                       \n"); Console.Write(cmr.cf(71, 255, 123));
            Console.Write("######################################################################################\n"); Console.Write(cmr.cf(0,0,0));
            Console.Write("              ██████████  ██      ██  ████████  ██████████  ██        ██              \n");
            Console.Write("              ██          ██      ██  ██    ██  ██      ██  ████      ██              \n");
            Console.Write("              ██          ██████████  ████████  ██      ██  ██  ██    ██              \n");
            Console.Write("              ██          ██      ██  ████      ██      ██  ██    ██  ██              \n");
            Console.Write("              ██          ██      ██  ██  ██    ██      ██  ██      ████              \n");
            Console.Write("              ██████████  ██      ██  ██    ██  ██████████  ██        ██              \n"); Console.Write(cmr.cf(71, 255, 123));
            Console.Write("######################################################################################\n"); Console.Write(cmr.cf(0,0,0));
            Console.Write("           ██████████  ██          ██  ██████████  ██        ██  ██████████           \n");
            Console.Write("           ██          ██          ██  ██          ████      ██      ██               \n");
            Console.Write("           ██          ██          ██  ██████████  ██  ██    ██      ██               \n");
            Console.Write("           ██          ██          ██  ██          ██    ██  ██      ██               \n");
            Console.Write("           ██          ██          ██  ██          ██      ████      ██               \n");
            Console.Write("           ██████████  ██████████  ██  ██████████  ██        ██      ██               \n"); Console.Write(cmr.cf(71, 255, 123));
            Console.Write("######################################################################################\n"); Console.Write(cmr.cf(0, 0, 0));
            Console.Write("                                                                           by Chrones \n"); Console.Write(cmr.cf(71, 255, 123));
            Console.Write("######################################################################################\n"); Console.Write(cmr.cr);
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
                Start(args);
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
                    } catch
                    {
                        Data.CommunicationData.GUI.ColorRGBCounter = 0;
                    }
                    Thread.Sleep(10);
                }
            }
        }
    }
}
