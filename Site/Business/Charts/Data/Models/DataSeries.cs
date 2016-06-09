using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business.Charts.Data.Models
{
    public class DataSeries
    {
        public string Name { get; set; }
        public int[] Series { get; set; }
        public string Color { get; set; }
    }
}