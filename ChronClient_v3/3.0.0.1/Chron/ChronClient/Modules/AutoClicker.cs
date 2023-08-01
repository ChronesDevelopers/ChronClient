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
    public class AutoClicker : Module
    {
        public override string Name { get; } = "AutoClicker";
        public override string Category { get; } = null;
        public override string Description { get; } = "Clicks automaticly";
        public override bool HasToggleState { get; } = true;
        public override void Loaded()
        {
            
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
                str += $" (CPS Min: {Math.Round(CPSMin, 1)} | CPS Max: {Math.Round(CPSMax, 1)}) ";
                str += $" [{System.Windows.Input.Key.F}]";
                return str;
            }
        }
        public UICollection ModuleUI = new UICollection(
            CE.UIStackPanel(
                CE.UITextBlock("Min:"),
                CE.UISlider(0, 20, 10),
                CE.UISlider(0, 20, 20)
            )
        );

        public float CPS = 15;
        public float CPSMin = 10;
        public float CPSMax = 20;
    }
}
