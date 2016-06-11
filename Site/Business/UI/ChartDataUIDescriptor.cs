using EPiServer.Shell;
using Site.Business.Charts;

namespace Site.Business.UI
{
    [UIDescriptorRegistration]
    public class ChartDataUIDescriptor : UIDescriptor<ChartData>
    {
        public ChartDataUIDescriptor()
        {
            DefaultView = "chartPreviewContent";
            AddDisabledView(CmsViewNames.OnPageEditView);
        }
    }
}