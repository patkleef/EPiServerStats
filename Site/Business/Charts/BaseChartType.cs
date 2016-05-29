using EPiServer.Core;
using Site.Business.Charts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business.Charts
{
    public abstract class BaseChartType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ChartType Type { get; set; }
        public abstract ChartData GetChartData(ContentReference contentReference);
    }
}