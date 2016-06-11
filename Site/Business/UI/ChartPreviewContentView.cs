using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using Site.Business.Charts;
using Site.Models.Pages;

namespace Site.Business.UI
{
    [ServiceConfiguration(typeof(ViewConfiguration))]
    public class ChartPreviewContentView : ViewConfiguration<ChartData>
    {
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