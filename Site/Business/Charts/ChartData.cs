using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Site.Business.Charts
{ 
    [ContentType(DisplayName = "ChartData", GUID = "328d9aaf-acef-433e-8aa9-7c34c2e4c405", Description = "")]
    public class ChartData1 : ContentBase
    {
        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "Description",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Description { get; set; }
    }
}