using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Lite.Modules
{
    public static class OnLoad
    {
        public static void Start()
        {
            Module.AutoClicker.OnLoad();
            Module.HideWindow.OnLoad();
            Module.KnockbackModifier.OnLoad();
            Module.Reach.OnLoad();
        }
    }
}
