using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.IModule.UI
{
    public class UIModuleButton : UIElement
    {
        public override string Name { get; set; } = "UIModuleButton";
        public override UIType Type { get; set; } = UIType.ModuleButton;
        public string Content { get; set; }
        public string ToolTip { get; set; } = null;
        public bool IsEnabled
        {
            get => Enabled;
            set
            {
                if (value != Enabled)
                {
                    if (value == true)
                    {
                        OnEnable?.Invoke();
                    }
                    else
                    {
                        OnDisable?.Invoke();
                    }
                }
            }
        }
        public bool Enabled { get; set; } = false;

        public event ClickEvent Click;
        public event OnEnableEvent OnEnable;
        public event OnDisableEvent OnDisable;

        public UIModuleButton()
        {

        }
        public UIModuleButton(string text)
        {
            Content = text;
        }
        public UIModuleButton(string text, OnEnableEvent? onEnable, OnDisableEvent? onDisable)
        {
            Content = text;
            if (onEnable != null)
            {
                OnEnable += onEnable;
            }
            if (onDisable != null)
            {
                OnDisable += onDisable;
            }
        }
        public UIModuleButton(string text, Module module)
        {
            Content = text;
            Enabled = module.IsEnabled;
            OnEnable += () =>
            {
                module.IsEnabled = true;
            };
            OnDisable += () =>
            {
                module.IsEnabled = false;
            };
            if (module.Description != null || module.Description != "")
            {
                ToolTip = module.Description;
            }
        }
        public void StartClick()
        {
            Click?.Invoke();
            IsEnabled = !IsEnabled;
        }

        public delegate void ClickEvent();
        public delegate void OnEnableEvent();
        public delegate void OnDisableEvent();
    }
}
