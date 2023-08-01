using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChronClient.IModule.UI
{
    public class UIGrid : UIElement
    {
        public override string Name { get; set; } = "UIGrid";
        public override UIType Type { get; set; } = UIType.Grid;
        public List<CE> Content { get; set; } = null;
        public ulong Rows { get; set; } = 0;
        public ulong Columns { get; set; } = 0;
        public UIGrid()
        {

        }
        public UIGrid(CE content)
        {
            var list = new List<CE>();
            list.Add(content);
            Content = list;
        }
        public UIGrid(List<CE> list)
        {
            Content = list;
        }
        public UIGrid(params CE[] array)
        {
            Content = array.ToList<CE>();
        }
    }
}
