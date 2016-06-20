using EPiServer.Shell;
using EPiServer.Shell.ViewComposition;

namespace Site.Business.UI.ChartsGadget
{
    /// <summary>
    /// Define a component for the charts gadget (assets pane)
    /// </summary>
    [Component]
    public class ChartsGadgetComponent : ComponentDefinitionBase
    {
        /// <summary>
        /// Public constructor
        /// Set that the HierarchicalList Dojo widget needs to be used
        /// Set for which are this plug-in is, assets default group in this case
        /// Which content type repository needs to be used 
        /// </summary>
        public ChartsGadgetComponent() : base("epi-cms.widget.HierarchicalList")
        {
            Categories = new string[] { "content" };
            Title = "Charts";
            Description = "Gadget for charts";
            SortOrder = 1000;
            PlugInAreas = new[] { PlugInArea.AssetsDefaultGroup };
            Settings.Add(new Setting("repositoryKey", "charts"));
        }
    }
}