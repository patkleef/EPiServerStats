using EPiServer.Data.Dynamic;
using System;

namespace Site.Business.Data
{
    public class PageChartsRepository
    {
        private readonly DynamicDataStore _store;

        public PageChartsRepository()
        {
            _store = DynamicDataStoreFactory.Instance.CreateStore(typeof(PageCharts));
        }

        public PageCharts GetByContentGuid(Guid contentGuid)
        {
            return _store.Load<PageCharts>(EPiServer.Data.Identity.NewIdentity(contentGuid));
        }

        public void Save(PageCharts pageCharts)
        {
            _store.Save(pageCharts);
        }
    }
}