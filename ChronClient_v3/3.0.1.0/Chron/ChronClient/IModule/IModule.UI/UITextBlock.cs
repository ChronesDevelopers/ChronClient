using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UITextBlock : UIElement
    {
        public override string Name { get; set; } = "UITextBlock";
        public override UIType Type { get; set; } = UIType.TextBlock;
        public string Content { get; set; } = null;
        public FontSizes FontSize { get; set; } = FontSizes.Normal;
        public UITextBlock()
        {

        }
        public UITextBlock(string text)
        {
            Content = text;
        }

        public enum FontSizes
        {
            Normal,
            Header1,
            Header2
        }
    }
}
