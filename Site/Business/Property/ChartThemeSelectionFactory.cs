using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business.Property
{
    public class ChartThemeSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
            {
                new SelectItem() { Text = "Dollar", Value = "Dollar" },
                new SelectItem() { Text = "Electric", Value = "Electric" },
                new SelectItem() { Text = "Julie", Value = "Julie" },
                new SelectItem() { Text = "PurpleRain", Value = "PurpleRain" },
                new SelectItem() { Text = "Renkoo", Value = "Renkoo" }
            };
        }
    }
}