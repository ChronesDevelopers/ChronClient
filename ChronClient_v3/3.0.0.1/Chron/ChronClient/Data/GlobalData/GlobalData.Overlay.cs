using Chrones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Data
{
    public static partial class GlobalData
    {
        public static partial class Overlay
        {
            public static UI.Overlay Window;
            public static IntPtr WindowHandle;
            public static OverlayMode Mode = OverlayMode.Normal;
            public static OverlayMode SET_MODE
            {
                get { return Mode; }
                set
                {
                    if (Window != null)
                    {
                        Window.Dispatcher.Invoke
                            (() =>
                            {
                                if (value == OverlayMode.Normal)
                                {
                                    Mode = value;
                                    Window.SetWindowTransparent();
                                    Window.SetOverlayMode(UI.Overlay.OverlayMode.Normal);
                                }
                                else if (value == OverlayMode.ClickGUI)
                                {
                                    Mode = value;
                                    Window.SetWindowNormal();
                                    Window.SetOverlayMode(UI.Overlay.OverlayMode.ClickGUI);
                                } else
                                {
                                    Mode = value;
                                }
                            });
                    }
                }
            }
            public static TimeSpan TimerInterval = TimeSpan.FromMilliseconds(20);
            public enum OverlayMode
            {
                None,
                Normal,
                ClickGUI
            }
        }
    }
}
