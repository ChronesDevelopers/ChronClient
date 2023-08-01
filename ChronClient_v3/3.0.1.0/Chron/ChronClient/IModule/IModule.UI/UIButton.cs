using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UIButton : UIElement
    {
        public override string Name { get; set; } = "UIButton";
        public override UIType Type { get; set; } = UIType.Button;
        public string Content { get; set; }
        public string ToolTip { get; set; } = null;

        public event ClickEvent Click;

        public UIButton()
        {

        }
        public UIButton(string text)
        {
            Content = text;
        }
        public UIButton(string text, ClickEvent click)
        {
            Content = text;
            Click += click;
        }
        public void StartClick()
        {
            Click?.Invoke();
        }

        public delegate void ClickEvent();
    }
}
