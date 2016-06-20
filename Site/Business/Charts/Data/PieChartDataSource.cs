using Site.Business.Charts.Data.Models.Pie;

namespace Site.Business.Charts.Data
{
    /// <summary>
    /// Pie chart data
    /// </summary>
    public class PieChartDataSource : ChartDataSource
    {
        public PieDataSeries Series { get; set; }
    }
}