using EPiServer.Core;
using Site.Business.Charts.Data;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Site.Business.Charts
{
    public class PageModifiedAtChart : BaseChartType
    {
        public PageModifiedAtChart()
        {
            Id = Guid.Parse("3ED23A83-62F0-4692-81A0-B1739A978109");
            Name = "Page modified at";
            Type = ChartType.LineChart;
        }

        public override ChartData GetChartData(ContentReference contentReference)
        {
            var lineChartData = new LineChartData();

            var xLabelList = new List<object>();
            var seriesList = new List<int>();
            var random = new Random();
            for (int i = 1; i <= 12; i++)
            {                
                xLabelList.Add(new { Value= i, Text= CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i) });
                seriesList.Add(random.Next(0, 20));
            }

            lineChartData.XLabels = xLabelList.ToArray();
            lineChartData.Series = seriesList.ToArray();

            return lineChartData;
        }
    }
}