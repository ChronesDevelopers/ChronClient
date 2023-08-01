using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UIModuleSection : UIElement
    {
        public override string Name { get; set; } = "UIModuleSection";
        public override UIType Type { get; set; } = UIType.ModuleSection;
        public List<CE> Content { get; set; } = null;
        public UIModuleSection()
        {

        }
        public UIModuleSection(CE content)
        {
            var list = new List<CE>();
            list.Add(content);
            Content = list;
        }
        public UIModuleSection(List<CE> list)
        {
            Content = list;
        }
        public UIModuleSection(params CE[] array)
        {
            Content = array.ToList<CE>();
        }
    }
}
