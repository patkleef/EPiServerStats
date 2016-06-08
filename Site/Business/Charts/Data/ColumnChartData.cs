using Site.Business.Charts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business.Charts.Data
{
    public class ColumnChartData : ChartDataSource
    {
        public List<AxLabel> XLabels { get; set; }

        public int[] Series { get; set; }
    }
}