using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ChronClient.IModule.UI;
using Chrones;

namespace ChronClient.Modules
{
    public class Template : Module
    {
        public override string Name { get; } = "Template";
        public override string Category { get; } = null;
        public override string Description { get; } = "This is a Template";
        public override bool HasToggleState { get; } = true;
        public override void Loaded()
        {
            InputManager_KeyEventHandlers = new List<KeyEventHandler>();
            InputManager_KeyEventHandlers.Add(new KeyEventHandler
            (
                new Key(Key.VirtualKeys.Control),
                () =>
                {
                    Debug.WriteLine("Hello");
                },
                null
            ));
            InputManager_KeyEventHandlers.Add(new KeyEventHandler
            (
                new Key(Key.VirtualKeys.Shift),
                () =>
                {
                    Debug.WriteLine("Hello Lol");
                },
                null
            ));
        }
        public override void Destroy(DestroyReason reason)
        {
            if (reason == DestroyReason.ApplicationLeave)
            {

            }
        }
        public override void OnEnabled()
        {

        }
        public override void OnDisabled()
        {

        }

        public override string Overlay_GetModuleName
        {
            get
            {
                string str = Name;
                str += $" (Value) ";
                str += $" [{System.Windows.Input.Key.LeftCtrl}]";
                return str;
            }
        }
        public UICollection ModuleUI = CE.UICollection(
            CE.UIGrid(
                CE.UIStackPanel(
                    CE.UITextBlock("Hello"),
                    CE.UITextBlock("This is a Test"),
                    new UIGrid {
                        Columns = 2,
                        Rows = 5,
                        Content = new UIGridElement {
                            Column = 0,
                            Row = 1,
                            Content = CE.UIStackPanel(
                            ).ToList()
                        }.ToList()
                    }
                )
            )
        );
    }
}
