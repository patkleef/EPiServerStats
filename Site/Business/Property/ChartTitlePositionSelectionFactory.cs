using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;

namespace Site.Business.Property
{
    /// <summary>
    /// Selection factory for title position options
    /// </summary>
    public class ChartTitlePositionSelectionFactory : ISelectionFactory
    {
        /// <summary>
        /// Get all title position options
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[]
            {
                new SelectItem() { Text = "Top", Value = "Top" },
                new SelectItem() { Text = "Bottom", Value = "Bottom" }
            };
        }
    }
}