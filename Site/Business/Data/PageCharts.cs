using EPiServer.Core;
using EPiServer.Data.Dynamic;
using EPiServer.Data;

namespace Site.Business.Data
{
    /// <summary>
    /// Class to store all charts for a page
    /// </summary>
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class PageCharts : IDynamicData
    {
        public Identity Id { get; set; }
        
        public int[] Charts { get; set; }
    }
}