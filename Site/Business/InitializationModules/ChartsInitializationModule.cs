using System;
using System.Linq;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using InitializationModule = EPiServer.Web.InitializationModule;

namespace Site.Business.InitializationModules
{
    /// <summary>
    /// Initialization module for the chart gadget component
    /// </summary>
    [ModuleDependency(typeof(InitializationModule))]
    public class ChartsInitialization : IInitializableModule
    {
        public const string ChartsRootName = "Charts";
        public static Guid ChartsRootGuid = new Guid("2EB33E01-D9F1-48EB-A35F-0CBC7895FFF7");

        public static ContentReference ChartsRoot;

        /// <summary>
        /// Initialize method
        /// </summary>
        /// <param name="context"></param>
        public void Initialize(InitializationEngine context)
        {
            var contentRootService = ServiceLocator.Current.GetInstance<ContentRootService>();
            var contentSecurityRepository = ServiceLocator.Current.GetInstance<IContentSecurityRepository>();

            contentRootService.Register<ContentFolder>(ChartsRootName, ChartsRootGuid, ContentReference.RootPage);

            ChartsRoot = contentRootService.Get(ChartsRootName);
            
            var securityDescriptor = contentSecurityRepository.Get(ChartsRoot).CreateWritableClone() as IContentSecurityDescriptor;

            if (securityDescriptor != null)
            {
                securityDescriptor.IsInherited = false;
                
                var everyoneEntry = securityDescriptor.Entries.FirstOrDefault(e => e.Name.Equals("everyone", StringComparison.InvariantCultureIgnoreCase));

                if (everyoneEntry != null)
                {
                    securityDescriptor.RemoveEntry(everyoneEntry);
                    contentSecurityRepository.Save(ChartsRoot, securityDescriptor, SecuritySaveType.Replace);
                }
            }
        }

        /// <summary>
        /// Uninitialize
        /// </summary>
        /// <param name="context"></param>
        public void Uninitialize(InitializationEngine context)
        {
        }
    }
}