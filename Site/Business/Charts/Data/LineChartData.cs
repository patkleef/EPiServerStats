using Site.Business.Charts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business.Charts.Data
{
    public class LineChartData : ChartDataSource
    {
        public AxLabel XAxLabel { get; set; }
        public AxLabel YAxLabel { get; set; }

        public IEnumerable<DataSeries> Series { get; set; }
    }
}