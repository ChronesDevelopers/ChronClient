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
using Chrones.Cmr.Win32API;
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
            Console.SetBufferSize(Console.BufferWidth, 300);
            cmr.DisableQuickEdit();
            Process.Start("minecraft://");
            Memory0.mem = new Chrones.Cmr.MemoryManagement.Memory("Minecraft.Windows");
            StartScreen();
            Console.WriteLine($@"{cmr.cf(255, 255, 255)}Thanks for using ChronClient :D");
            cmr.clogl(ConsoleData.ChronClientLogName, "Loading Application");
            StroringInformationSetup.FileSetup();
            Thread.Sleep(100);
            Modules.ModuleManagment.OnLoad.Start();
            Threads.ThreadManagement.StartAllThreads();
            cmr.clogl(ConsoleData.ChronClientLogName, "Finished!");
            cmr.clogl("Tips and Tricks", $"{cmr.cr}Use {cmr.cf(173, 255, 243)}{cmr.cb(16, 26, 24)}Control+RightShift{cmr.cr} to open the Console when playing Minecraft {cmr.cf(252, 255, 94)}:D{cmr.cr}");
            cmr.clogl("Tips and Tricks", $"{cmr.cr}Use {cmr.cf(173, 255, 243)}{cmr.cb(16, 26, 24)}P+MouseDown{cmr.cr} to enable AutoClicker {cmr.cf(252, 255, 94)}[Click]{cmr.cr}");

            while (true)
            {
                Modules.ModuleCommandManagment.GetCommand();
            }
        }

        public static void StartScreen()
        {
            Console.Clear();
            cmr_font.SetConsoleFont("Consolas", 13, 27);
            cmr.CenterConsole();
            //cmr.MaximizeConsole();
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
    }
}
