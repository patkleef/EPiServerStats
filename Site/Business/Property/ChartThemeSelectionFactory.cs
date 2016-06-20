using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;

namespace Site.Business.Property
{
    /// <summary>
    /// Selection factory for all chart themes
    /// </summary>
    public class ChartThemeSelectionFactory : ISelectionFactory
    {
        /// <summary>
        /// Gets theme options
        /// </summary>
        /// <param name="metadata"></param>
        /// <returns></returns>
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