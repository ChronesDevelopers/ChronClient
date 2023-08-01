using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Data
{
    public static class StroringInformationSetup
    {
        public static void FileSetup()
        {
            if (!Directory.Exists(ConsoleData.DataDir))
            {
                Directory.CreateDirectory(ConsoleData.DataDir);
            }

            foreach (string info in StoringInfomation.Data)
            {
                if (!File.Exists(@$"{ConsoleData.DataDir}\Setting.{info}.ChronClientData"))
                {
                    File.Create(@$"{ConsoleData.DataDir}\Setting.{info}.ChronClientData");
                }
            }
        }
    }
}
