using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Site.Business.Property
{
    public class ChartsSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var chartRegistration = ServiceLocator.Current.GetInstance<ChartRegistration>();

            //return chartRegistration.Charts.Select(c => new SelectItem { Text = c.Name, Value = c.Id.ToString() });
            return Enumerable.Empty<ISelectItem>();
        }
    }
}