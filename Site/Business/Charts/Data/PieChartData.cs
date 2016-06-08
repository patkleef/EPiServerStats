using Site.Business.Charts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business.Charts.Data
{
    public class PieChartData : ChartDataSource
    {
        public List<PieDataSet> Series { get; set; }
    }
}