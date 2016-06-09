using EPiServer.Framework.Web.Resources;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Business.Helper
{
    public static class EPiServerInitializationHelper
    {
        public static IEnumerable<ModuleViewModel> GetModuleSettings()
        {
            // Adapted from EPiServer.Shell.UI.Bootstrapper.CreateViewModel

            // Creates a data structure that contains module resource paths (JS and CSS) and settings.

            var modules = ServiceLocator.Current.GetInstance<ModuleTable>();
            var resourceService = ServiceLocator.Current.GetInstance<IClientResourceService>();

            var moduleList = modules.GetModules().Where(m => new string[] { "CMS", "Shell" }.Contains(m.Name))
                .Select(m => m.CreateViewModel(modules, resourceService))
                /*modules.GetModules()
                .Select(m => m.CreateViewModel(modules, resourceService))
                .OrderBy(mv => mv.ModuleDependencies != null ? mv.ModuleDependencies.Count : 0)*/
                ;

            //foreach (ModuleViewModel mvm in moduleList)
                   //mvm.ScriptResources.RemoveWhere(r => r.EndsWith("/ReportCenter.js", StringComparison.OrdinalIgnoreCase));

                return moduleList;
        }

        public static void RemoveWhere<T>(this ICollection<T> Coll,
                                      Func<T, bool> Criteria)
        {
            List<T> forRemoval = Coll.Where(Criteria).ToList();

            foreach (T obj in forRemoval)
            {
                Coll.Remove(obj);
            }
        }
    }
}