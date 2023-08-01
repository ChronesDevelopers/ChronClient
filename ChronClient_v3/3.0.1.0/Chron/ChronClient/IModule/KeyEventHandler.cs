using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient
{
    public class KeyEventHandler
    {
#nullable enable
        public KeyEventHandler(Key key, OnKeyPressedEvent pressed)
        {
            this.Key = key;
            this.OnKeyPressed += pressed;
        }
        public KeyEventHandler(Key key, OnKeyReleasedEvent released)
        {
            this.Key = key;
            this.OnKeyReleased += released;
        }
        public KeyEventHandler(Key key, OnKeyPressedEvent? pressed, OnKeyReleasedEvent? released)
        {
            this.Key = key;
            if (pressed != null)
                this.OnKeyPressed += pressed;
            if (released != null)
                this.OnKeyReleased += released;
        }
        public KeyEventHandler(Key key, OnKeyPressedEvent[]? pressed, OnKeyReleasedEvent[]? released)
        {
            this.Key = key;
            if (pressed != null)
                foreach (var obj in pressed)
                    this.OnKeyPressed += obj;
            if (released != null)
                foreach (var obj in released)
                    this.OnKeyReleased += obj;
        }

        // Values
        public Key Key;
        public event OnKeyPressedEvent? OnKeyPressed;
        public event OnKeyReleasedEvent? OnKeyReleased;

        // Types
        public delegate void OnKeyPressedEvent();
        public delegate void OnKeyReleasedEvent();
#nullable disable
    }
}
