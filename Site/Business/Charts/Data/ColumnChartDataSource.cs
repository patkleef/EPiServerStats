using Site.Business.Charts.Data.Models;
using System.Collections.Generic;

namespace Site.Business.Charts.Data
{
    /// <summary>
    /// Column chart data
    /// </summary>
    public class ColumnChartDataSource : ChartDataSource
    {
        public List<AxLabel> XLabels { get; set; }

        public int[] Series { get; set; }
    }
}