using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class CE
    {
        public static List<CE> Array(CE[] array)
        {
            return array.ToList();
        }

        public static UIModuleButton UIModuleButton()
        {
            return new UIModuleButton();
        }
        public static UIModuleButton UIModuleButton(string text)
        {
            return new UIModuleButton(text);
        }
        public static UIModuleButton UIModuleButton(string text, Module module)
        {
            return new UIModuleButton(text, module);
        }
        public static UIButton UIButton()
        {
            return new UIButton();
        }
        public static UIButton UIButton(string text)
        {
            return new UIButton(text);
        }
        public static UIButton UIButton(string text, UIButton.ClickEvent click)
        {
            return new UIButton(text, click);
        }
        public static UICollection UICollection()
        {
            return new UICollection();
        }
        public static UICollection UICollection(CE content)
        {
            return new UICollection(content);
        }
        public static UICollection UICollection(List<CE> list)
        {
            return new UICollection(list);
        }
        public static UICollection UICollection(params CE[] array)
        {
            return new UICollection(array);
        }
        public static UIGrid UIGrid()
        {
            return new UIGrid();
        }
        public static UIGrid UIGrid(CE content)
        {
            return new UIGrid(content);
        }
        public static UIGrid UIGrid(List<CE> list)
        {
            return new UIGrid(list);
        }
        public static UIGrid UIGrid(params CE[] array)
        {
            return new UIGrid(array);
        }
        public static UIGridElement UIGridElement()
        {
            return new UIGridElement();
        }
        public static UIGridElement UIGridElement(CE content)
        {
            return new UIGridElement(content);
        }
        public static UIGridElement UIGridElement(List<CE> list)
        {
            return new UIGridElement(list);
        }
        public static UIGridElement UIGridElement(params CE[] array)
        {
            return new UIGridElement(array);
        }
        public static UISection UISection()
        {
            return new UISection();
        }
        public static UISection UISection(CE content)
        {
            return new UISection(content);
        }
        public static UISection UISection(List<CE> list)
        {
            return new UISection(list);
        }
        public static UISection UISection(params CE[] array)
        {
            return new UISection(array);
        }
        public static UIModuleSection UIModuleSection()
        {
            return new UIModuleSection();
        }
        public static UIModuleSection UIModuleSection(CE content)
        {
            return new UIModuleSection(content);
        }
        public static UIModuleSection UIModuleSection(List<CE> list)
        {
            return new UIModuleSection(list);
        }
        public static UIModuleSection UIModuleSection(params CE[] array)
        {
            return new UIModuleSection(array);
        }
        public static UIStackPanel UIStackPanel()
        {
            return new UIStackPanel();
        }
        public static UIStackPanel UIStackPanel(CE content)
        {
            return new UIStackPanel(content);
        }
        public static UIStackPanel UIStackPanel(List<CE> list)
        {
            return new UIStackPanel(list);
        }
        public static UIStackPanel UIStackPanel(params CE[] array)
        {
            return new UIStackPanel(array);
        }
        public static UITextBlock UITextBlock()
        {
            return new UITextBlock();
        }
        public static UITextBlock UITextBlock(string text)
        {
            return new UITextBlock(text);
        }
        public static UISlider UISlider()
        {
            return new UISlider();
        }
        public static UISlider UISlider(float value)
        {
            return new UISlider(value);
        }
        public static UISlider UISlider(float min, float max, float value)
        {
            return new UISlider(min, max, value);
        }
    }
}
