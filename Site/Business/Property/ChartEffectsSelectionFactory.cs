using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Business.Property
{
    public class ChartEffectsSelectionFactory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
            {
                new SelectItem() { Text = "Highlight", Value = "Highlight" },
                new SelectItem() { Text = "Magnify", Value = "Magnify" },
                new SelectItem() { Text = "MoveSlice", Value = "MoveSlice" },
                new SelectItem() { Text = "Shake", Value = "Shake" },
                new SelectItem() { Text = "Tooltip", Value = "Tooltip" },
                new SelectItem() { Text = "MouseZoomAndPan", Value = "MouseZoomAndPan" },
                new SelectItem() { Text = "MouseIndicator", Value = "MouseIndicator" }
            };
        }
    }
}