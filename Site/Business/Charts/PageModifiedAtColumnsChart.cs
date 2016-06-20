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
    /// Page modified at column chart
    /// </summary>
    [ContentType(DisplayName = "Page modified at columns chart", GUID = "{89ED14E0-8DF8-4589-95E9-6AA888D4E680}", Description = "")]
    public class PageModifiedAtColumnsChart : ChartData
    {
        /// <summary>
        /// Coolumns chart
        /// </summary>
        public override ChartType ChartType
        {
            get
            {
                return ChartType.ColumnsChart;
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
            var columnsChartData = new LineChartDataSource();

            var xLabelList = new List<AxLabelItem>();
            var seriesList = new List<int>();
            var random = new Random();
            for (int i = 1; i <= 12; i++)
            {                
                xLabelList.Add(new AxLabelItem { Value = i, Text= CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i) });
                seriesList.Add(random.Next(0, 20));
            }

            columnsChartData.XAxLabel = new AxLabel
            {
                Title = "Month",
                TitleOrientation = AxTitleOrientation.Away,
                FixLowerOption = AxFixOption.None,
                FixUpperOption = AxFixOption.None,
                Items = xLabelList
            };
            columnsChartData.YAxLabel = new AxLabel
            {
                Title = "Month",
                TitleOrientation = AxTitleOrientation.Away,
                FixLowerOption = AxFixOption.Major,
                FixUpperOption = AxFixOption.Major,
                Vertical = true
            };
            columnsChartData.Series = new[] { new DataSeries { Name = "Series 1", Color = "blue", Series = seriesList.ToArray() } };

            return columnsChartData;
        }
    }
}