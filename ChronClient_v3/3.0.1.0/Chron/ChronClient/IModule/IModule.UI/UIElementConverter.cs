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
        public virtual Thickness DefaultMargin { get; set; } = new Thickness(2);
        public virtual Brush TextBlock_Foreground { get; set; } = null;
        public virtual Brush TextBlock_Background { get; set; } = null;
        public virtual Brush ModuleSection_BorderBrush { get; set; } = new SolidColorBrush(Color.FromArgb(0x60, 255, 255, 255));
        public virtual Brush ModuleSection_Background { get; set; } = new SolidColorBrush(Colors.Black);
        public virtual Thickness ModuleSection_BorderThickness { get; set; } = new Thickness(2);
        public virtual CornerRadius ModuleSection_CornerRadius { get; set; } = new CornerRadius(10);
        public virtual Thickness ModuleSection_Padding { get; set; } = new Thickness(2);
        public virtual Thickness ModuleSection_Margin { get; set; } = new Thickness(0, 3, 0, 3);

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
            if (content is UISection)
            {
                return UISectionToWPF(content as UISection);
            }
            if (content is UIModuleSection)
            {
                return UIModuleSectionToWPF(content as UIModuleSection);
            }
            if (content is UIButton)
            {
                return UIButtonToWPF(content as UIButton);
            }
            if (content is UIModuleButton)
            {
                return UIModuleButtonToWPF(content as UIModuleButton);
            }
            return null;
        }

        public virtual GUI.ChronUI.CU_ToggleButton UIModuleButtonToWPF(UIModuleButton content)
        {
            var ret = new GUI.ChronUI.CU_ToggleButton();
            ret.Text = content.Content;
            ret.ToolTip = content.ToolTip;
            ret.Margin = new Thickness(2, 4, 2, 2);
            //ret.Click += (object sender, RoutedEventArgs e) =>
            //{
            //    content.StartClick();
            //};
            return ret;
        }
        public virtual Button UIButtonToWPF(UIButton content)
        {
            var ret = new Button();
            ret.Content = content.Content;
            ret.ToolTip = content.ToolTip;
            ret.Margin = DefaultMargin;
            ret.Click += (object sender, RoutedEventArgs e) =>
            {
                content.StartClick();
            };
            return ret;
        }
        public virtual Grid UICollectionToWPF(UICollection content)
        {
            var ret = new Grid();
            ret.Margin = DefaultMargin;
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
            Grid.SetColumn(ret, content.Column);
            Grid.SetRow(ret, content.Row);
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
            for (int i = 0; i < content.Columns; i++)
            {
                ret.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < content.Columns; i++)
            {
                ret.RowDefinitions.Add(new RowDefinition());
            }
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
        public virtual Border UISectionToWPF(UISection content)
        {
            var ret = new Border();
            ret.Margin = DefaultMargin;
            var ret_child = new Grid();
            foreach (UIElement e in content.Content)
            {
                object? o = this.ToWPF(e);
                if (o is System.Windows.UIElement)
                {
                    ret_child.Children.Add(o as System.Windows.UIElement);
                }
            }
            ret.Child = ret_child;
            return ret;
        }
        public virtual Border UIModuleSectionToWPF(UIModuleSection content)
        {
            var ret = new Border();
            var ret_child = new StackPanel();
            ret.BorderBrush = ModuleSection_BorderBrush;
            ret.Background = ModuleSection_Background;
            ret.Padding = ModuleSection_Padding;
            ret.Margin = ModuleSection_Margin;
            ret.BorderThickness = ModuleSection_BorderThickness;
            ret.CornerRadius = ModuleSection_CornerRadius;
            ret.VerticalAlignment = VerticalAlignment.Top;
            foreach (UIElement e in content.Content)
            {
                object? o = this.ToWPF(e);
                if (o is System.Windows.UIElement)
                {
                    ret_child.Children.Add(o as System.Windows.UIElement);
                }
            }
            ret.Child = ret_child;
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
            ret.Margin = DefaultMargin;
            ret.Text = content.Content;
            ret.TextWrapping = TextWrapping.Wrap;
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
            ret.Margin = DefaultMargin;
            ret.Minimum = content.Min;
            ret.Maximum = content.Max;
            ret.Value = content.Value;
            return ret;
        }
    }
}
