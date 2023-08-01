using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UIElement : CE
    {
        public virtual string Name { get; set; }
        public virtual UIType Type { get; set; } = UIType.Element;
        public virtual List<CE> ToList()
        {
            var ret = new List<CE>();
            ret.Add(this);
            return ret;
        }
    }
}
