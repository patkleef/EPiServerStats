using EPiServer.Core;
using EPiServer.DataAnnotations;
using Site.Business.Charts.Data;
using Site.Business.Charts.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Site.Business.Charts
{
    /// <summary>
    /// Page modified at line chart
    /// </summary>
    [ContentType(DisplayName = "Page modified at line chart", GUID = "8E70D0ED-D559-4B7C-A7D7-6608380F36C5", Description = "")]
    public class PageModifiedAtLineChart : ChartData
    {
        /// <summary>
        /// Line chart
        /// </summary>
        public override ChartType ChartType
        {
            get
            {
                return ChartType.LineChart;
            }
        }

        /// <summary>
        /// Return data source for this chart
        /// </summary>
        /// <param name="contentReference"></param>
        /// <returns></returns>
        public override ChartDataSource GetChartDataSource(ContentReference contentReference)
        {
            // TODO: get the information by retrieving all versions of the page
            var lineChartData = new LineChartDataSource();

            var xLabelList = new List<AxLabelItem>();
            var seriesList = new List<int>();
            var random = new Random();
            for (int i = 1; i <= 12; i++)
            {                
                xLabelList.Add(new AxLabelItem { Value = i, Text= CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i) });
                seriesList.Add(random.Next(0, 20));
            }

            lineChartData.XAxLabel = new AxLabel
            {
                Title = "Month",
                TitleOrientation = AxTitleOrientation.Away,
                FixLowerOption = AxFixOption.None,
                FixUpperOption = AxFixOption.None,
                Items = xLabelList
            };
            lineChartData.YAxLabel = new AxLabel
            {
                Title = "Month",
                TitleOrientation = AxTitleOrientation.Away,
                FixLowerOption = AxFixOption.Major,
                FixUpperOption = AxFixOption.Major,
                Vertical = true
            };
            lineChartData.Series = new[] { new DataSeries { Name = "Series 1", Color = "blue", Series = seriesList.ToArray() } };

            return lineChartData;
        }
    }
}