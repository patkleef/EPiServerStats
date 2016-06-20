using Site.Business.Charts.Data.Models;
using System.Collections.Generic;

namespace Site.Business.Charts.Data
{
    /// <summary>
    /// Line chart data
    /// </summary>
    public class LineChartDataSource : ChartDataSource
    {
        public AxLabel XAxLabel { get; set; }
        public AxLabel YAxLabel { get; set; }

        public IEnumerable<DataSeries> Series { get; set; }
    }
}