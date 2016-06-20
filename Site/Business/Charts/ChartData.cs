using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Web;
using EPiServer.Shell.ObjectEditing;
using Site.Business.Property;
using Site.Business.Charts.Data;

namespace Site.Business.Charts
{ 
    /// <summary>
    /// ChartData class inherit from ContentBase (IContent)
    /// </summary>
    public abstract class ChartData : ContentBase
    {
        /// <summary>
        /// Title of the chart
        /// </summary>
        [Display(
            Name = "Title",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string Title { get; set; }

        /// <summary>
        /// Position of the title
        /// </summary>
        [SelectOne(SelectionFactoryType = typeof(ChartTitlePositionSelectionFactory))]
        [Display(
            Name = "Title position",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        public virtual string TitlePosition { get; set; }

        /// <summary>
        /// Descripton of the chart
        /// </summary>
        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "Description",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 35)]
        public virtual string Description { get; set; }

        /// <summary>
        /// Theme of the chart
        /// </summary>
        [SelectOne(SelectionFactoryType = typeof(ChartThemeSelectionFactory))]
        [Display(
            Name = "Theme",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual string Theme { get; set; }

        /// <summary>
        /// Action and effects
        /// </summary>
        [SelectMany(SelectionFactoryType = typeof(ChartEffectsSelectionFactory))]
        [Display(
            Name = "Action and effects",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual string ActionAndEffects { get; set; }

        /// <summary>
        /// Show legend
        /// </summary>
        [Display(
            Name = "Show chart legend",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 60)]
        public virtual bool ShowLegend { get; set; }

        /// <summary>
        /// Type of the chart (line, columns, etc)
        /// </summary>
        [Editable(false)]
        public abstract ChartType ChartType { get; }

        /// <summary>
        /// Method for returning the datasource of the chart
        /// </summary>
        /// <param name="contentReference"></param>
        /// <returns></returns>
        public abstract ChartDataSource GetChartDataSource(ContentReference contentReference);        
    }
}