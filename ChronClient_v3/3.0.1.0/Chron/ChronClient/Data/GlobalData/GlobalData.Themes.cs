using Chrones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChronClient.Data
{
    public static partial class GlobalData
    {
        public static partial class Themes
        {
            public static partial class Overlay
            {
                public static Page CurrentPage { get; private set; }
                private static void ClearFrameHistory(Frame frame)
                {
                    if (!frame.CanGoBack && !frame.CanGoForward)
                    {
                        return;
                    }
                    var entry = frame.RemoveBackEntry();
                    while (entry != null)
                    {
                        entry = frame.RemoveBackEntry();
                    }
                }
                public static Type GetCurrentPage()
                {
                    return GlobalData.Overlay.Window.OverlayNavigationFrame.NavigationService.Content.GetType();
                }
                public static void SetCurrentPage(Page page)
                {
                    ClearFrameHistory(GlobalData.Overlay.Window.OverlayNavigationFrame);
                    CurrentPage = page;
                    if (page == null)
                    {
                        GlobalData.Overlay.Window.OverlayNavigationFrame.NavigationService.Navigate(new ChronClient.GUI.Pages.BlankPage()); ;
                        return;
                    }
                    GlobalData.Overlay.Window.OverlayNavigationFrame.NavigationService.Navigate(page);
                }
            }
            public static partial class ClickGUI
            {
                public static Page CurrentPage { get; private set; }
                private static void ClearFrameHistory(Frame frame)
                {
                    if (!frame.CanGoBack && !frame.CanGoForward)
                    {
                        return;
                    }
                    var entry = frame.RemoveBackEntry();
                    while (entry != null)
                    {
                        entry = frame.RemoveBackEntry();
                    }
                }
                public static Type GetCurrentPage()
                {
                    return GlobalData.Overlay.Window.ClickGUINavigationFrame.NavigationService.Content.GetType();
                }
                public static void SetCurrentPage(Page page)
                {
                    ClearFrameHistory(GlobalData.Overlay.Window.ClickGUINavigationFrame);
                    CurrentPage = page;
                    if (page == null)
                    {
                        GlobalData.Overlay.Window.ClickGUINavigationFrame.NavigationService.Navigate(new ChronClient.GUI.Pages.BlankPage());
                        return;
                    }
                    GlobalData.Overlay.Window.ClickGUINavigationFrame.NavigationService.Navigate(page);
                }
            }
        }
    }
}
