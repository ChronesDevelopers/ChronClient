using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

namespace ChronClient
{
    public abstract class Module
    {
        // Overrideable
        public abstract string Name { get; }
        public abstract string Category { get; }
        public abstract string Description { get; }
        public virtual string SaveID { get; }
        public virtual string VersionID { get; }
        public abstract bool HasToggleState { get; }
        public virtual bool IsEnabled
        {
            get => Enabled;
            set
            {
                if (value != Enabled)
                {
                    if (value == true)
                        OnEnabled();
                    if (value == false)
                        OnDisabled();
                    Enabled = value;
                }
            }
        }
        public abstract void Loaded();
        public abstract void Destroy(DestroyReason reason);
        public virtual void ProcessChanged() { }
        public virtual object SaveSettings() { return null; }
        public virtual void LoadSettings(object data) { }
        public virtual void OnEnabled() { }
        public virtual void OnDisabled() { }
        public virtual bool Overlay_ShowInListGUI
        {
            get => (IsEnabled && HasToggleState);
        }
        public virtual bool Overlay_ShowInTabGUI { get; } = false;
        public virtual string Overlay_GetModuleName
        {
            get => Name;
        }
        public virtual List<KeyEventHandler> InputManager_KeyEventHandlers { get; set; }

        // Private
        protected bool Enabled = false;

        // Other
        public event TickEvent Tick10;
        public event TickEvent Tick100;
        public event TickEvent Tick1000;

        // Types
        public delegate void TickEvent();
        public enum DestroyReason
        {
            None,
            ApplicationLeave,
            ProcessLeaved,
            ProcessChanged
        }
    }
}
