using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChronClient.Instance
{
    public class Keybind
    {
        public delegate void OnKeyPressedEvent();
        public Key targetkey;
        public List<OnKeyPressedEvent> OnKeyPressed = new List<OnKeyPressedEvent>();
        public bool LastKeyState = false;
    }
}
