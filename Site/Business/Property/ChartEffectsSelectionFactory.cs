using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;

namespace Site.Business.Property
{
    /// <summary>
    /// Chart effects selection factory
    /// </summary>
    public class ChartEffectsSelectionFactory : ISelectionFactory
    {
        /// <summary>
        /// Get all different action and effects options
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
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