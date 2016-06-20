using Site.Business.Charts;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Site.Business.Charts.Data;

namespace Site.Business.Store
{
    /// <summary>
    /// View model used to return to the chart dashboard widget
    /// </summary>
    public class ChartViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string TitlePosition { get; set; }

        public string Description { get; set; }

        public string Theme { get; set; }

        public string ActionAndEffects { get; set; }

        public bool ShowLegend { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ChartType ChartType { get; set; }

        public ChartDataSource Data { get; set; }
    }
}