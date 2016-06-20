using EPiServer.Core;
using EPiServer.DataAnnotations;
using Site.Business.Charts.Data;
using Site.Business.Charts.Data.Models.Pie;

namespace Site.Business.Charts
{
    /// <summary>
    /// Page modified by chart
    /// </summary>
    [ContentType(DisplayName = "Page modified by chart", GUID = "D4E38D41-D8D0-4EA0-ADEF-B2343FC111CA", Description = "")]
    public class PageModifiedByChart : ChartData
    {
        /// <summary>
        /// Pie chart
        /// </summary>
        public override ChartType ChartType
        {
            get
            {
                return ChartType.PieChart;
            }
        }

        /// <summary>
        /// Get chart data source
        /// </summary>
        /// <param name="contentReference"></param>
        /// <returns></returns>
        public override ChartDataSource GetChartDataSource(ContentReference contentReference)
        {
            // TODO: get the information by retrieving all versions of the page

            var pieChartData = new PieChartDataSource();
            pieChartData.Series = new PieDataSeries
            {
                Name = "Page modified by",
                DataItems = new[]
                {
                    new PieDataItem {Y = 10, Text = "Patrick"},
                    new PieDataItem {Y = 30, Text = "Brian"},
                    new PieDataItem {Y = 10, Text = "Frederik"}
                }
            };
            return pieChartData;
        }
    }
}