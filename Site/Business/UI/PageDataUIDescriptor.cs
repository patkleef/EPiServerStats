using EPiServer.Shell;
using Site.Models.Pages;

namespace Site.Business.UI
{
    /// <summary>
    /// UIDescriptor for the HomePage page
    /// </summary>
    [UIDescriptorRegistration]
    public class PageDataUIDescriptor : UIDescriptor<HomePage>
    {
        /// <summary>
        /// Public constructor, set the default view when the home page is loaded int the CMS
        /// </summary>
        public PageDataUIDescriptor()
        {
            DefaultView = "chartsDashboard";
        }
    }
}