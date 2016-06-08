using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using EPiServer.Shell.Services.Rest;
using EPiServer.Shell.ViewComposition;
using Site.Business.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InitializationModule = EPiServer.Web.InitializationModule;

namespace Site.Business.Widgets
{
    [Component]
    public class TestComponent : ComponentDefinitionBase
    {
        public TestComponent() : base("epi-cms.widget.HierarchicalList")
        {
            Categories = new string[] { "content" };
            Title = "Charts";
            Description = "";
            SortOrder = 1000;
            PlugInAreas = new[] { PlugInArea.AssetsDefaultGroup };
            Settings.Add(new Setting("repositoryKey", "charts"));
        }
    }

    [ServiceConfiguration(typeof(IContentRepositoryDescriptor))]
    public class TemplatesRepositoryDescriptor : ContentRepositoryDescriptorBase
    {
        public static string RepositoryKey
        {
            get { return "charts"; }
        }

        public override string Key
        {
            get
            {
                return RepositoryKey;
            }
        }

        public override string Name
        {
            get { return "Charts"; }
        }

        public override IEnumerable<Type> MainNavigationTypes
        {
            get
            {
                return new[]
                {
                    typeof(ContentFolder)
                };
            }
        }

        public override IEnumerable<Type> ContainedTypes
        {
            get
            {
                return new[]
                {
                    typeof(ContentFolder),
                    typeof(ChartData)
                };
            }
        }

        public override IEnumerable<string> MainViews { get { return new string[] { }; } }

        public override IEnumerable<Type> CreatableTypes
        {
            get
            {
                return new System.Type[]
                {
                    typeof(ChartData)
                };
            }
        }

        public override IEnumerable<ContentReference> Roots
        {
            get
            {
                return new[] { ChartsInitialization.TemplateRoot };
            }
        }
    }


    [ModuleDependency(typeof(InitializationModule))]
    public class ChartsInitialization : IInitializableModule
    {
        public const string TemplateRootName = "Charts";
        public static Guid TemplateRootGuid = new Guid("2EB33E01-D9F1-48EB-A35F-0CBC7895FFF7");

        public static ContentReference TemplateRoot;

        public void Initialize(InitializationEngine context)
        {
            var contentRootService = ServiceLocator.Current.GetInstance<ContentRootService>();
            var contentSecurityRepository = ServiceLocator.Current.GetInstance<IContentSecurityRepository>();

            contentRootService.Register<ContentFolder>(TemplateRootName, TemplateRootGuid, ContentReference.RootPage);

            TemplateRoot = contentRootService.Get(TemplateRootName);

            // make sure everyone is removed from the public list
            var securityDescriptor = contentSecurityRepository.Get(TemplateRoot).CreateWritableClone() as IContentSecurityDescriptor;

            if (securityDescriptor != null)
            {
                securityDescriptor.IsInherited = false;

                // remove everyone group
                var everyoneEntry = securityDescriptor.Entries.FirstOrDefault(e => e.Name.Equals("everyone", StringComparison.InvariantCultureIgnoreCase));

                if (everyoneEntry != null)
                {
                    securityDescriptor.RemoveEntry(everyoneEntry);
                    contentSecurityRepository.Save(TemplateRoot, securityDescriptor, SecuritySaveType.Replace);
                }
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }

    [RestStore("chartstore1")]
    public class InstantTemplatesStore : RestControllerBase
    {

        public InstantTemplatesStore()
        {
        }

        public RestResult Get(string id)
        {
            
            return Rest(null);
        }
    }

}