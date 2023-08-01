using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UISection : UIElement
    {
        public override string Name { get; set; } = "UISection";
        public override UIType Type { get; set; } = UIType.Section;
        public List<CE> Content { get; set; } = null;
        public UISection()
        {

        }
        public UISection(CE content)
        {
            var list = new List<CE>();
            list.Add(content);
            Content = list;
        }
        public UISection(List<CE> list)
        {
            Content = list;
        }
        public UISection(params CE[] array)
        {
            Content = array.ToList<CE>();
        }
    }
}
