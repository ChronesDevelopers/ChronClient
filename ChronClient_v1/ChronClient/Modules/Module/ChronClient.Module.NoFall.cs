using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Module
{
    public static class NoFall
    {
        public static Modules.ModuleType ModuleType = new Modules.ModuleType("NoFall", "Player", true, ref _ToggleState, new Action(OnEnable), new Action(OnDisable), null, null, null, null, new Action(Refresh), new Action(Toggle));

        public static void OnLoad()
        {
            Modules.ModuleManagment.ValueRegister.RegisterModule(ModuleType);
        }

        public static bool _ToggleState = false;

        public static bool ToggleState
        {
            get { return _ToggleState; }
            set
            {
                if (_ToggleState != value)
                {
                    if (value)
                    {
                        OnEnable();
                        _ToggleState = value;
                    }
                    else if (!value)
                    {
                        OnDisable();
                        _ToggleState = value;
                    }
                }
            }
        }

        public static void OnEnable()
        {
            // Nop Memory
            Memory0.mem.PatchMemory("Minecraft.Windows.exe", 0x1216D73, new byte[] { 0xC6, 0x83, 0x94, 0x1, 0x0, 0x0, 0x0, 0x90});
        }

        public static void OnDisable()
        {
            // Restore Memory
            Memory0.mem.PatchMemory("Minecraft.Windows.exe", 0x1216D73, new byte[] { 0xF3, 0x0F, 0x11, 0x83, 0x94, 0x01, 0x0, 0x0 });
        }

        public static void Toggle()
        {
            _ToggleState = !_ToggleState;
        }

        public static void Refresh()
        {
            if (ToggleState)
            {
                OnEnable();
            }
            else if (!ToggleState)
            {
                OnDisable();
            }
        }
    }
}
