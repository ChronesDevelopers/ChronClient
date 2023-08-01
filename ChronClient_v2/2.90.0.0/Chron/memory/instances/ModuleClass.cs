using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Instance
{
    public class ModuleClass
    {
#nullable enable
        public delegate void TickEvent();
        public delegate void RefreshEvent();
        public delegate bool? GetToggleStateEvent();
        public delegate void SetToggleStateEvent(bool? ToggleState);
        public delegate bool? GetShowInListGUIEvent();
        public delegate string? GetModuleNameInListGUIEvent();

        public string? ModuleName = null;
        public string? Category = null;
        public string? Description1 = null;
        public string? Description2 = null;
        public string? Description3 = null;
        public bool? HasToggleState = null;
        public GetToggleStateEvent? GetToggleState = null;
        public SetToggleStateEvent? SetToggleState = null;
        public TickEvent? Tick10 = null;
        public TickEvent? Tick100 = null;
        public TickEvent? Tick1000 = null;
        public bool? ShowInTabGUI = null;
        public bool? ShowInListGUI = null;
        public GetShowInListGUIEvent? GetShowInListGUI = null;
        public bool? ToggleState
        {
            get
            {
                try
                {
                    if (HasToggleState != null && HasToggleState != false)
                    {
                        if (GetToggleState != null)
                        {
                            return GetToggleState();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                try
                {
                    if (HasToggleState != null && HasToggleState != false)
                    {
                        if (SetToggleState != null)
                        {
                            SetToggleState(value);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }
            }
        }
#nullable disable
    }
}
