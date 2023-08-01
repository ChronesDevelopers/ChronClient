using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChronClient.File
{
    public class ProfileClass
    {
        public string Name { get; set; }
        public ulong VERSION { get; set; }
        public string[] Tags { get; set; }
        public ProfileClassSettingsCollection[] ProfileSettings { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        public static ProfileClass ToProfile(string value)
        {
            object? obj = JsonConvert.DeserializeObject(value);
            if (obj.GetType() == typeof(ProfileClass))
            {
                return (ProfileClass)obj;
            }
            else
            {
                return null;
            }
        }


    }
}
