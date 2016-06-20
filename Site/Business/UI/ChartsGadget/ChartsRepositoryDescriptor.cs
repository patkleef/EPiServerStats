using System;
using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using Site.Business.Charts;
using Site.Business.InitializationModules;

namespace Site.Business.UI.ChartsGadget
{
    /// <summary>
    /// Repository descriptor for charts (ChartData)
    /// </summary>
    [ServiceConfiguration(typeof(IContentRepositoryDescriptor))]
    public class ChartsRepositoryDescriptor : ContentRepositoryDescriptorBase
    {
        /// <summary>
        /// Set the repository key, used in the ChartsGadgetComponent class
        /// </summary>
        public static string RepositoryKey
        {
            get { return "charts"; }
        }

        /// <summary>
        /// Key of this repository descriptor
        /// </summary>
        public override string Key
        {
            get
            {
                return RepositoryKey;
            }
        }

        /// <summary>
        /// Name of the repository
        /// </summary>
        public override string Name
        {
            get { return "Charts"; }
        }

        /// <summary>
        /// Navigation type, only a content folder
        /// </summary>
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

        /// <summary>
        /// Both folders and of course ChartData types
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public override IEnumerable<string> MainViews { get { return new string[] { }; } }

        /// <summary>
        /// Which items can be created, ChartData
        /// </summary>
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

        /// <summary>
        /// Root of the gadget
        /// </summary>
        public override IEnumerable<ContentReference> Roots
        {
            get
            {
                return new[] { ChartsInitialization.ChartsRoot };
            }
        }
    }
}