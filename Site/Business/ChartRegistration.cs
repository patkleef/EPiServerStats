using EPiServer.ServiceLocation;
using Site.Business.Charts;
using System.Collections.Generic;

namespace Site.Business
{
    [ServiceConfiguration(typeof(ChartRegistration), Lifecycle = ServiceInstanceScope.Singleton)]
    public class ChartRegistration
    {
        public IList<BaseChartType> Charts = new List<BaseChartType>();
    }
}