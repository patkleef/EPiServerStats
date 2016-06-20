using EPiServer.Shell;
using Site.Business.Charts;

namespace Site.Business.UI
{
    /// <summary>
    /// UIDescriptor for the ChartData types
    /// </summary>
    [UIDescriptorRegistration]
    public class ChartDataUIDescriptor : UIDescriptor<ChartData>
    {
        /// <summary>
        /// Public constructor, set the default view to the chart preview widget
        /// Disable the onPageEditView, because we don't need that one
        /// </summary>
        public ChartDataUIDescriptor()
        {
            DefaultView = "chartPreviewContent";
            AddDisabledView(CmsViewNames.OnPageEditView);
        }
    }
}