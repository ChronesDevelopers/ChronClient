using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChronClient.IModule.UI
{
    public class UIElementConverter
    {
        public virtual double FontSize_Normal { get; set; } = 12;
        public virtual double FontSize_Header1 { get; set; } = 22;
        public virtual double FontSize_Header2 { get; set; } = 18;
        public virtual Brush TextBlock_Foreground { get; set; } = null;
        public virtual Brush TextBlock_Background { get; set; } = null;

        public object? ToWPF(UIElement content)
        {
            if (content is UITextBlock)
            {
                return UITextBlockToWPF(content as UITextBlock);
            }
            if (content is UIGrid)
            {
                return UIGridToWPF(content as UIGrid);
            }
            if (content is UIGridElement)
            {
                return UIGridElementToWPF(content as UIGridElement);
            }
            if (content is UIStackPanel)
            {
                return UIStackPanelToWPF(content as UIStackPanel);
            }
            if (content is UICollection)
            {
                return UICollectionToWPF(content as UICollection);
            }
            if (content is UISlider)
            {
                return UISliderToWPF(content as UISlider);
            }
            return null;
        }

        public virtual Grid UICollectionToWPF(UICollection content)
        {
            var ret = new Grid();
            foreach (UIElement e in content.Content)
            {
                object? o = this.ToWPF(e);
                if (o is System.Windows.UIElement)
                {
                    ret.Children.Add(o as System.Windows.UIElement);
                }
            }
            return ret;
        }
        public virtual Grid UIGridElementToWPF(UIGridElement content)
        {
            var ret = new Grid();
            foreach (UIElement e in content.Content)
            {
                object? o = this.ToWPF(e);
                if (o is System.Windows.UIElement)
                {
                    ret.Children.Add(o as System.Windows.UIElement);
                }
            }
            return ret;
        }
        public virtual Grid UIGridToWPF(UIGrid content)
        {
            var ret = new Grid();
            foreach (UIElement e in content.Content)
            {
                object? o = this.ToWPF(e);
                if (o is System.Windows.UIElement)
                {
                    ret.Children.Add(o as System.Windows.UIElement);
                }
            }
            return ret;
        }
        public virtual StackPanel UIStackPanelToWPF(UIStackPanel content)
        {
            var ret = new StackPanel();
            foreach (UIElement e in content.Content)
            {
                object? o = this.ToWPF(e);
                if (o is System.Windows.UIElement)
                {
                    ret.Children.Add(o as System.Windows.UIElement);
                }
            }
            return ret;
        }
        public virtual TextBlock UITextBlockToWPF(UITextBlock content)
        {
            var ret = new TextBlock();
            ret.Text = content.Content;
            switch(content.FontSize)
            {
                case UITextBlock.FontSizes.Normal:
                    ret.FontSize = FontSize_Normal;
                    break;
                case UITextBlock.FontSizes.Header1:
                    ret.FontSize = FontSize_Header1;
                    break;
                case UITextBlock.FontSizes.Header2:
                    ret.FontSize = FontSize_Header2;
                    break;
            }
            if (TextBlock_Foreground != null)
            {
                ret.Foreground = TextBlock_Foreground;
            }
            if (TextBlock_Background != null)
            {
                ret.Background = TextBlock_Background;
            }
            return ret;
        }
        public virtual Slider UISliderToWPF(UISlider content)
        {
            var ret = new Slider();
            ret.Minimum = content.Min;
            ret.Maximum = content.Max;
            ret.Value = content.Value;
            return ret;
        }
    }
}
