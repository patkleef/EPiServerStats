using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Site.Models.Pages
{
    [ContentType(DisplayName = "HomePage", GUID = "4bcccb85-1db6-4687-803d-48c9455bfbfc", Description = "")]
    public class HomePage : PageData
    {
        [Display(
            Name = "Conten At",
            Description = "Content A",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual ContentArea ContentA { get; set; }
    }
}