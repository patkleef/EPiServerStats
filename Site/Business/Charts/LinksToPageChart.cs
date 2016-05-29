using EPiServer.Core;
using Site.Business.Charts.Data;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Site.Business.Charts
{
    public class LinksToPageChart : BaseChartType
    {
        public LinksToPageChart()
        {
            Id = Guid.Parse("A223B9E3-0279-4B10-A606-B048D85003D6");
            Name = "Links to page";
            Type = ChartType.ColumnsChart;
        }

        public override ChartData GetChartData(ContentReference contentReference)
        {
            var barChartData = new ColumnChartData();
            var xLabelList = new List<object>();
            var seriesList = new List<int>();
            var random = new Random();
            for (int i = 1; i <= 12; i++)
            {
                xLabelList.Add(new { Value = i, Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i) });
                seriesList.Add(random.Next(0, 20));
            }

            barChartData.XLabels = xLabelList.ToArray();
            barChartData.Series = seriesList.ToArray();
            return barChartData;
        }
    }
}