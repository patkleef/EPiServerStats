using Site.Business.Charts;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Site.Business.Charts.Data;

namespace Site.Business.Store
{
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