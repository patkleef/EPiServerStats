using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using Site.Models.Pages;

namespace Site.Business.UI
{
    /// <summary>
    /// View configuration for the charts dashboard view
    /// </summary>
    [ServiceConfiguration(typeof(ViewConfiguration))]
    public class ChartsDasboardView : ViewConfiguration<PageData>
    {
        /// <summary>
        /// Public constructor
        /// Set the ControllerType to chartsdahboardview Dojo widget and some layout settings
        /// </summary>
        public ChartsDasboardView()
        {
            SortOrder = 1;
            Key = "chartsDashboard";
            Name = "Charts dashboard view";
            Description = "Charts dashboard view";
            ControllerType = "app/editors/chartdashboardview";
            HideFromViewMenu = false;
            IconClass = "epi-iconLayout";
        }
    }    
}