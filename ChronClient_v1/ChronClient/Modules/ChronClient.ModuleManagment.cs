using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Modules
{
    public static class ModuleManagment
    {
        public static class Write
        {

        }

        public static class OnLoad
        {
            public static void Start()
            {
                // Setup Modules
                Module.Airjump.ToggleState = true;
                Module.NoFall.ToggleState = true;
            }
        }
    }
}
