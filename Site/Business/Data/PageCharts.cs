using EPiServer.Core;
using EPiServer.Data.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Data;

namespace Site.Business.Data
{
    public class PageCharts : IDynamicData
    {
        public Identity Id { get; set; }
        
        public Guid[] ChartTypes { get; set; }
    }
}