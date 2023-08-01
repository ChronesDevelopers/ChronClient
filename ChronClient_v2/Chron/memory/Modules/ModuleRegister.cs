using ChronClient.Instance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.Modules
{
    public static class ModuleRegister
    {
#nullable enable
        public static List<ModuleClass> ModuleList { get; private set; } = new List<ModuleClass>();
        
        public static void RegisterModule(ModuleClass module)
        {
            if (module != null)
            {
                ModuleList.Add(module);
                if (module.Tick10 != null)
                {
                    RegisterTick10(module.Tick10);
                }
                if (module.Tick100 != null)
                {
                    RegisterTick100(module.Tick100);
                }
                if (module.Tick1000 != null)
                {
                    RegisterTick1000(module.Tick1000);
                }
            }
        }
        public static string[]? GetCategoriesArray()
        {
            var ret = GetCategoriesList();
            if (ret != null)
            {
                return ((List<string>)ret).ToArray();
            }
            return null;
        }

        public static List<string> GetCategoriesList()
        {
            List<string> ret = new List<string>();
            return ret;
        }
        #region Tick
        public static List<ModuleClass.TickEvent> Tick10 { get; private set; } = new List<ModuleClass.TickEvent>();
        public static List<ModuleClass.TickEvent> Tick100 { get; private set; } = new List<ModuleClass.TickEvent>();
        public static List<ModuleClass.TickEvent> Tick1000 { get; private set; } = new List<ModuleClass.TickEvent>();

        public static void RegisterTick10(ModuleClass.TickEvent tick)
        {
            Tick10.Add(tick);
        }
        public static void RegisterTick100(ModuleClass.TickEvent tick)
        {
            Tick100.Add(tick);
        }
        public static void RegisterTick1000(ModuleClass.TickEvent tick)
        {
            Tick1000.Add(tick);
        }
        #endregion

        public static List<string> GetModuleListModuleNames()
        {
            List<string> _ret = new List<string>();
            foreach (ModuleClass mod in ModuleList)
            {
                if (mod.ShowInListGUI == true)
                {
                    if (mod.GetShowInListGUI != null)
                    {
                        if (mod.GetShowInListGUI() == true)
                        {
                            if (mod.ModuleName != null)
                            {
                                _ret.Add(mod.ModuleName);
                            }
                        }
                    }
                }
            }
            return _ret;
        }
#nullable disable
    }
}
