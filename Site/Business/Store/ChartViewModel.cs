using EPiServer.Core;
using Site.Business.Charts;
using Site.Business.Charts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business.Store
{
    public class ChartViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public ChartData Data { get; set; }

        /*public static ChartViewModel FromBaseChartType(BaseChartType chart, ContentReference contentReference)
        {
            return new ChartViewModel
            {
                Id = chart.Id,
                Name = chart.Name,
                Type = chart.Type.ToString(),
                Data = chart.GetChartData(contentReference)
            };            
        }*/
    }
}