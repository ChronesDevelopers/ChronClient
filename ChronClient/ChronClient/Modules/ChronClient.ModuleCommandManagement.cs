using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chrones.Cmr;

namespace ChronClient.Modules
{
    public static class ModuleCommandManagment
    {
        public static bool ProcessCommand(string command)
        {
            #region Standard

            if (command == "module list" || command == "mod list" || command == "list module" || command == "list mod")
            {
                Console.Write($"{cmr.cr}");
                cmr.ccoutl($"{cmr.cf(255, 59, 59)}ChronClient", $"{cmr.cf(255, 253, 112)}Listing the Modules that ChronClient has:");
                Console.Write($"{cmr.cf(220, 220, 220)}╔═════════ {cmr.cf(176, 255, 158)}Module List{cmr.tr} ═════════╗\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ┌ {cmr.cf(171, 230, 255)}TabGUI{cmr.cf(220, 220, 220)}                     ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}ListGUI{cmr.cf(220, 220, 220)}                    ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}Airjump{cmr.cf(220, 220, 220)}                    ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}Speed{cmr.cf(220, 220, 220)}                      ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}Reach{cmr.cf(220, 220, 220)}                      ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}AutoClick{cmr.cf(220, 220, 220)}                  ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}NoKnockBack{cmr.cf(220, 220, 220)}                ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}NoFall{cmr.cf(220, 220, 220)}                     ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  └ {cmr.cf(171, 230, 255)}NoSwing{cmr.cf(220, 220, 220)}                    ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}╚═══════════════════════════════╝\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cr}");
            } else if (command == "list")
            {
                Console.Write($"{cmr.cr}");
                cmr.ccoutl($"{cmr.cf(255, 59, 59)}ChronClient", $"{cmr.cf(255, 253, 112)}Listing the Commands that ChronClient has:");
                Console.Write($"{cmr.cf(220, 220, 220)}╔═════════ {cmr.cf(176, 255, 158)}Command List{cmr.tr} ═════════╗\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ┌ {cmr.cf(171, 230, 255)}help{cmr.cf(220, 220, 220)}                        ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}list{cmr.cf(220, 220, 220)}                        ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}module{cmr.cf(220, 220, 220)}                      ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}discord{cmr.cf(220, 220, 220)}                     ║\n"); Console.Write($"{cmr.cr}"); 
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}patreon{cmr.cf(220, 220, 220)}                     ║\n"); Console.Write($"{cmr.cr}"); 
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}update{cmr.cf(220, 220, 220)}                      ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}about{cmr.cf(220, 220, 220)}                       ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  ├ {cmr.cf(171, 230, 255)}clear{cmr.cf(220, 220, 220)}                       ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}║  └ {cmr.cf(171, 230, 255)}exit{cmr.cf(220, 220, 220)}                        ║\n"); Console.Write($"{cmr.cr}");
                Console.Write($"{cmr.cf(220, 220, 220)}╚════════════════════════════════╝\n"); Console.Write($"{cmr.cr}");
            }            
            
            if (command == "discord")
            {
                cmr.ccoutl("ChronClient", "Do you want to open the Discord invite link in your browser? [Y|N]");
                Console.Write($"{cmr.cf(153, 242, 194)}[]{cmr.cr} {cmr.cf(255, 59, 59)}<{cmr.cr} {cmr.cf(255, 241, 89)}{cmr.cb(44, 49, 54)}");
                ConsoleKeyInfo ResultKey;
                ResultKey = Console.ReadKey();
                Console.WriteLine($"{cmr.cr}");
                if (ResultKey.Key == ConsoleKey.Y)
                {
                    System.Diagnostics.Process.Start("http://discord.chrones.cc");
                    cmr.clogl("ChronClient", "The Discord Link was opened in your browser.");
                } else
                {
                    cmr.ccoutl("ChronClient", "Stopped.");
                }
            }

#endregion

            #region Module
            if (command == "speed.value")
            {
                Console.Write($"{cmr.cf(173, 255, 243)}{cmr.cb(16, 26, 24)}Enter the value here:{cmr.cr} {cmr.cf(255, 255, 255)}");
                float value;
                try
                {
                    value = Convert.ToSingle(Console.ReadLine());
                    value = value / 100;
                    Module.Speed.Value = value;
                    Console.Write($"{cmr.cr}");
                    cmr.clogl("Module_Speed", $"Speedvalue set to {value}{cmr.cr}");
                }
                catch
                {
                    Console.Write($"{cmr.cr}");
                    Console.WriteLine($"{cmr.cf(255, 30, 30)}There was an error!{cmr.cr}");
                }
            }

            if (command == "highjump.value")
            {
                Console.Write($"{cmr.cf(173, 255, 243)}{cmr.cb(16, 26, 24)}Enter the value here:{cmr.cr} {cmr.cf(255, 255, 255)}");
                float value;
                try
                {
                    value = Convert.ToSingle(Console.ReadLine());
                    value = value / 100;
                    Module.Highjump.Value = value;
                    Module.Highjump.Refresh();
                    Console.Write($"{cmr.cr}");
                    cmr.clogl("Module_Highjump", $"Speedvalue set to {value}{cmr.cr}");
                }
                catch
                {
                    Console.Write($"{cmr.cr}");
                    Console.WriteLine($"{cmr.cf(255, 30, 30)}There was an error!{cmr.cr}");
                }
            }

            if (command == "tp" || command == "teleport")
            {

            }

            if (command == "pos" || command == "position" || command == "get pos" || command == "get position" || command == "pos get" || command == "position get")
            {
                Vector3 Position = Module.Teleport.GetPosition();
                Console.WriteLine($"{cmr.cb(30, 32, 36)}{cmr.cf(112, 119, 255)}X: {cmr.cf(166, 184, 255)}{Position.X} {cmr.cf(112, 119, 255)}Y: {cmr.cf(166, 184, 255)}{Position.Y} {cmr.cf(112, 119, 255)}Z: {cmr.cf(166, 184, 255)}{Position.Z}{cmr.cr}");
            }

#endregion

            return false;
        }

        public static void GetCommand()
        {
            cmr.EnableQuickEdit();
            Console.Write($"{cmr.cf(153, 242, 194)}[]{cmr.cr} {cmr.cf(255, 59, 59)}<{cmr.cr} {cmr.cf(166, 216, 255)}");
            string Input;
            Input = Console.ReadLine();
            Console.Write($"{cmr.cr}");
            cmr.DisableQuickEdit();

            if (Input == "exit !" || Input == "exit!")
            {
                cmr.ccoutl($"{cmr.cf(255, 153, 0)}ChronClient", $"{cmr.cf(255, 153, 0)}Exiting...");
                cmr.ExitApplication(false);
            }

            if (Input == "exit")
            {
                cmr.ExitApplicationPrint();
            }

            if (Input == "clear")
            {
                Console.Clear();
                cmr.clogl("ChronClient", "Console was cleared");
            }

            if (Input == "clear !" || Input == "clear!")
            {
                Console.Clear();
            }

            Modules.ModuleCommandManagment.ProcessCommand(Input);
        }
    }
}
