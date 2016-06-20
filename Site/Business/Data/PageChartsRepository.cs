using EPiServer.Data.Dynamic;
using System;

namespace Site.Business.Data
{
    /// <summary>
    /// Page charts repository
    /// </summary>
    public class PageChartsRepository
    {
        private readonly DynamicDataStore _store;

        /// <summary>
        /// Public constructor
        /// </summary>
        public PageChartsRepository()
        {
            _store = DynamicDataStoreFactory.Instance.CreateStore(typeof(PageCharts));
        }

        /// <summary>
        /// Get PageChart object by content guid
        /// </summary>
        /// <param name="contentGuid"></param>
        /// <returns></returns>
        public PageCharts GetByContentGuid(Guid contentGuid)
        {
            return _store.Load<PageCharts>(EPiServer.Data.Identity.NewIdentity(contentGuid));
        }

        /// <summary>
        /// Save a PageChart object
        /// </summary>
        /// <param name="pageCharts"></param>
        public void Save(PageCharts pageCharts)
        {
            _store.Save(pageCharts);
        }
    }
}