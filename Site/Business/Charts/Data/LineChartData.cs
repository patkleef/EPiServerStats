﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business.Charts.Data
{
    public class LineChartData : ChartData
    {
        public object XLabels { get; set; }
        public int[] Series { get; set; }
    }
}