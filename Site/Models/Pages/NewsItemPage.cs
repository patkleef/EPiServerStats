using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace Site.Models.Pages
{
    [ContentType(DisplayName = "NewsItemPage", GUID = "5afb696c-0b13-479a-b9fd-c34dd99f043b", Description = "")]
    public class NewsItemPage : PageData
    {
        [Display(
            Name = "Content",
            Description = "Content",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual XhtmlString Content { get; set; }
    }
}