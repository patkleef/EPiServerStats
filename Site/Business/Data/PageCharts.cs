using EPiServer.Core;
using EPiServer.Data.Dynamic;
using EPiServer.Data;

namespace Site.Business.Data
{
    [EPiServerDataStore(AutomaticallyCreateStore = true, AutomaticallyRemapStore = true)]
    public class PageCharts : IDynamicData
    {
        public Identity Id { get; set; }
        
        public int[] Charts { get; set; }
    }
}