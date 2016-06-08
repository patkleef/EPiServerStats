using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Framework.TypeScanner;
using EPiServer.ServiceLocation;
using Site.Business.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class ChartTypeInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            var chartRegistration = ServiceLocator.Current.GetInstance<ChartRegistration>();

            /*var typeScannerLookup = ServiceLocator.Current.GetInstance<ITypeScannerLookup>();
            var sourceTypes = typeScannerLookup.AllTypes.Where(
                t => typeof(BaseChartType).IsAssignableFrom(t) && t != typeof(BaseChartType));

            foreach(var sourceType in sourceTypes)
            {
                var type = (BaseChartType)ServiceLocator.Current.GetInstance(sourceType);

                chartRegistration.Charts.Add(type);
            }*/
        }

        public void Uninitialize(InitializationEngine context)
        {

        }
    }
}