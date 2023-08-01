using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UIGridElement : UIElement
    {
        public override string Name { get; set; } = "UIGridElement";
        public override UIType Type { get; set; } = UIType.GridElement;
        public List<CE> Content { get; set; } = null;
        public int Row { get; set; } = 0;
        public int Column { get; set; } = 0;
        public UIGridElement()
        {

        }
        public UIGridElement(CE content)
        {
            var list = new List<CE>();
            list.Add(content);
            Content = list;
        }
        public UIGridElement(List<CE> list)
        {
            Content = list;
        }
        public UIGridElement(params CE[] array)
        {
            Content = array.ToList<CE>();
        }
    }
}
