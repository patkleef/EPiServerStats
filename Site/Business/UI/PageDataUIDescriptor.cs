using EPiServer.Core;
using EPiServer.Shell;
using Site.Models.Pages;

namespace Site.Business.UI
{
    [UIDescriptorRegistration]
    public class PageDataUIDescriptor : UIDescriptor<HomePage>
    {
        public PageDataUIDescriptor()
        {
            DefaultView = "chartsContent";
        }
    }
}