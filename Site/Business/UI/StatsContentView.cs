using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell;
using Site.Models.Pages;

namespace Site.Business.UI
{
    [ServiceConfiguration(typeof(ViewConfiguration))]
    public class StatsContentView : ViewConfiguration<IContentData>
    {
        public StatsContentView()
        {
            SortOrder = 1;
            Key = "chartsContent";
            Name = "Charts content view";
            Description = "Charts content view";
            //ControllerType = "epi-cms/widget/IFrameController";
            ControllerType = "app/editors/chartcontentview";
            //ViewType = "app/editors/chartcontentview";
            HideFromViewMenu = false;
        }
    }    
}