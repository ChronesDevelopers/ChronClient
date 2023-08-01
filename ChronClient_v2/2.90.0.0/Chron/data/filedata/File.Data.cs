using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Data
{
    public static class FileData
    {
        public static readonly string SaveDataKey = @$"1526";
        public static readonly string UserSaveDataPath = @$"C:\Program Files\chrones\app\chronclient\data\{SaveDataKey}\User.json";
        public static readonly string DataDirectory = @$"C:\Program Files\chrones\app\chronclient\data\{SaveDataKey}";
    }
}
