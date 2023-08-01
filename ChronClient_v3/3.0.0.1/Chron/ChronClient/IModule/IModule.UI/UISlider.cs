using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UISlider : UIElement
    {
        public override string Name { get; set; } = "UISlider";
        public override UIType Type { get; set; } = UIType.Slider;
        public float Min { get; set; } = 0f;
        public float Max { get; set; } = 100f;
        public float Value { get; set; } = 50f;
        public UISlider()
        {

        }
        public UISlider(float value)
        {
            Value = value;
        }
        public UISlider(float min, float max, float value)
        {
            Min = min;
            Max = max;
            Value = value;
        }
    }
}
