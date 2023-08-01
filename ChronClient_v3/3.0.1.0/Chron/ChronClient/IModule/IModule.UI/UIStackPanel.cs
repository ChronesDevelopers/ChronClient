using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UIStackPanel : UIElement
    {
        public override string Name { get; set; } = "UIStackPanel";
        public override UIType Type { get; set; } = UIType.StackPanel;
        public List<CE> Content { get; set; } = null;
        public UIStackPanel()
        {

        }
        public UIStackPanel(CE content)
        {
            var list = new List<CE>();
            list.Add(content);
            Content = list;
        }
        public UIStackPanel(List<CE> list)
        {
            Content = list;
        }
        public UIStackPanel(params CE[] array)
        {
            Content = array.ToList<CE>();
        }
    }
}
