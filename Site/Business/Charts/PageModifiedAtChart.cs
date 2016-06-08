using EPiServer.Core;
using EPiServer.DataAnnotations;
using Site.Business.Charts.Data;
using Site.Business.Charts.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Site.Business.Charts
{
    [ContentType(DisplayName = "Page modified at chart", GUID = "8E70D0ED-D559-4B7C-A7D7-6608380F36C5", Description = "")]
    public class PageModifiedAtChart : ChartData
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
            var lineChartData = new LineChartData();

            var xLabelList = new List<AxLabel>();
            var seriesList = new List<int>();
            var random = new Random();
            for (int i = 1; i <= 12; i++)
            {                
                xLabelList.Add(new AxLabel { Value = i, Text= CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i) });
                seriesList.Add(random.Next(0, 20));
            }

            lineChartData.XLabels = xLabelList;
            lineChartData.Series = seriesList.ToArray();

            return lineChartData;
        }
    }
}