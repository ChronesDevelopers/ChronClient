using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChronClient.File
{
    public static class User
    {
        public static List<UserClass> GetUser()
        {
            if (!Directory.Exists(Data.FileData.DataDirectory))
            {
                Directory.CreateDirectory(Data.FileData.DataDirectory);
            }

            if (!System.IO.File.Exists(Data.FileData.UserSaveDataPath))
            {
                System.IO.File.Create(Data.FileData.UserSaveDataPath);
            }

            List<UserClass> UserClassList = new List<UserClass>();
            UserClassList.Add(DefaultUser);

            using (StreamReader filestream = System.IO.File.OpenText(Data.FileData.UserSaveDataPath))
            {
                string text = filestream.ReadToEnd();
                UserClass[] UserClassesRead = JsonConvert.DeserializeObject<UserClass[]>(text);
                foreach (var item in UserClassesRead)
                {
                    Console.WriteLine($"Object: {item.Name}");
                }
            }

            return UserClassList;
        }

        public static void WriteUser(List<UserClass> UserClassList)
        {
            if (!Directory.Exists(Data.FileData.DataDirectory))
            {
                Directory.CreateDirectory(Data.FileData.DataDirectory);
            }

            if (!System.IO.File.Exists(Data.FileData.UserSaveDataPath))
            {
                System.IO.File.Create(Data.FileData.UserSaveDataPath);
            }

            string WriteText = JsonConvert.SerializeObject(UserClassList.ToArray());
            System.IO.File.WriteAllText(Data.FileData.UserSaveDataPath, string.Empty);
            FileInfo fi = new FileInfo(Data.FileData.UserSaveDataPath);
            using (TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.Truncate)))
            {
                txtWriter.Write(WriteText);
            }
        }

        public static UserClass DefaultUser
        {
            get
            {
                UserClass _return = new UserClass();
                _return.Name = "Default";
                return _return;
            }
        }
    }
}
