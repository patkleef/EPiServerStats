using EPiServer.Core;
using Site.Business.Charts.Data;
using System;

namespace Site.Business.Charts
{
    public class PageModifiedByChart : BaseChartType
    {
        public PageModifiedByChart()
        {
            Id = Guid.Parse("73987E48-A770-4C13-8DBA-D65AAC52C43C");
            Name = "Page modified by";
            Type = ChartType.PieChart;
        }

        public override ChartData GetChartData(ContentReference contentReference)
        {
            var pieChart = new PieChartData();
            pieChart.Series = new[] {
                new { y = 10, Text = "Patrick" },
                new { y = 30, Text = "Kelly" },
                new { y = 10, Text = "Jan" }};

            return pieChart;
        }
    }
}