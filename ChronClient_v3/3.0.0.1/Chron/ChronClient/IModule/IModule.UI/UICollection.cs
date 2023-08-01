using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UICollection : UIElement
    {
        public override string Name { get; set; } = "UIElement";
        public override UIType Type { get; set; } = UIType.Collection;
        public List<CE> Content { get; set; } = null;
        public UICollection()
        {

        }
        public UICollection(CE content)
        {
            var list = new List<CE>();
            list.Add(content);
            Content = list;
        }
        public UICollection(List<CE> list)
        {
            Content = list;
        }
        public UICollection(params CE[] array)
        {
            Content = array.ToList<CE>();
        }
    }
}
