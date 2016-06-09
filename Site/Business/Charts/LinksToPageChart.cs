using EPiServer.Core;
using EPiServer.DataAnnotations;
using Site.Business.Charts.Data;
using Site.Business.Charts.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Site.Business.Charts
{
    [ContentType(DisplayName = "Links to page chart", GUID = "328d9aaf-acef-433e-8aa9-7c34c2e4c405", Description = "")]
    public class LinksToPageChart : ChartData
    {
        public override ChartType ChartType
        {
            get
            {
                return ChartType.LineChart;
            }
        }

        public override ChartDataSource GetChartDataSource(ContentReference contentReference)
        {
            var barChartData = new ColumnChartData();
            var xLabelList = new List<AxLabelItem>();
            var seriesList = new List<int>();
            var random = new Random();
            for (int i = 1; i <= 12; i++)
            {
                xLabelList.Add(new AxLabelItem { Value = i, Text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i) });
                seriesList.Add(random.Next(0, 20));
            }

            //barChartData.XLabels = xLabelList;
            barChartData.Series = seriesList.ToArray();
            return barChartData;
        }
    }
}