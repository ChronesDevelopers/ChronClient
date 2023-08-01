using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChronClient
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Console.Title = "ChronClient";
            Console.WriteLine("Starting...");

            Thread.Sleep(200);

            Threads.ThreadManagement.Application.InitializeThread();
            App app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
