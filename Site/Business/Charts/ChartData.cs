using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors.SelectionFactories;
using EPiServer.Shell.ObjectEditing;
using Site.Business.Property;
using Site.Business.Charts.Data;

namespace Site.Business.Charts
{ 
    public abstract class ChartData : ContentBase
    {
        [Display(
            Name = "Title",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string Title { get; set; }

        [SelectOne(SelectionFactoryType = typeof(ChartTitlePositionSelectionFactory))]
        [Display(
            Name = "Title position",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string TitlePosition { get; set; }

        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "Description",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 35)]
        public virtual string Description { get; set; }

        [SelectOne(SelectionFactoryType = typeof(ChartThemeSelectionFactory))]
        [Display(
            Name = "Theme",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual string Theme { get; set; }

        [SelectMany(SelectionFactoryType = typeof(ChartEffectsSelectionFactory))]
        [Display(
            Name = "Action and effects",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual string ActionAndEffects { get; set; }

        [Display(
            Name = "Show chart legend",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual bool ShowLegend { get; set; }

        [Editable(false)]
        public abstract ChartType ChartType { get; }

        public abstract ChartDataSource GetChartDataSource(ContentReference contentReference);        
    }
}