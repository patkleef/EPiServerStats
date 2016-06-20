using EPiServer.ServiceLocation;
using EPiServer.Shell;
using Site.Business.Charts;

namespace Site.Business.UI
{
    /// <summary>
    /// ViewConfiguration for the chart preview widget
    /// </summary>
    [ServiceConfiguration(typeof(ViewConfiguration))]
    public class ChartPreviewContentView : ViewConfiguration<ChartData>
    {
        /// <summary>
        /// Public constructor
        /// Set path to the Dojo widget and some layout settings
        /// </summary>
        public ChartPreviewContentView()
        {
            SortOrder = 1;
            Key = "chartPreviewContent";
            Name = "Chart preview";
            Description = "Charts content view";
            ControllerType = "app/editors/chartpreview";
            IconClass = "epi-iconLayout";
            HideFromViewMenu = false;
        }
    }    
}