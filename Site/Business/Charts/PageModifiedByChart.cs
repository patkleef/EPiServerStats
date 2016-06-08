using EPiServer.Core;
using EPiServer.DataAnnotations;
using Site.Business.Charts.Data;
using Site.Business.Charts.Data.Models;
using System;
using System.Collections.Generic;

namespace Site.Business.Charts
{
    [ContentType(DisplayName = "Page modified by chart", GUID = "D4E38D41-D8D0-4EA0-ADEF-B2343FC111CA", Description = "")]
    public class PageModifiedByChart : ChartData
    {
        public override ChartType ChartType
        {
            get
            {
                return ChartType.PieChart;
            }
        }

        public override ChartDataSource GetChartDataSource(ContentReference contentReference)
        {
            var pieChart = new PieChartData();
            pieChart.Series = new List<PieDataSet> {
                new PieDataSet { Y = 10, Text = "Patrick" },
                new PieDataSet { Y = 30, Text = "Kelly" },
                new PieDataSet { Y = 10, Text = "Jan" }};

            return pieChart;
        }
    }
}