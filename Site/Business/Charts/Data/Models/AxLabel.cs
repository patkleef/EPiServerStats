using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Site.Business.Charts.Data.Models
{
    public class AxLabel
    {
        public string Title { get; set; }
        public bool Vertical { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public AxFixOption FixUpperOption { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public AxFixOption FixLowerOption { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public AxTitleOrientation TitleOrientation { get; set; }
        public IEnumerable<AxLabelItem> Items { get; set; }
    }
}