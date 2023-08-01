using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.File
{
    public class ProfileClassSetting
    {
        public string Name { get; set; }
        [JsonIgnore]
        public Type Type { get { if (Value != null) { return Value.GetType(); } else { return null; } } }
        public object Value { get; set; }
    }
}
