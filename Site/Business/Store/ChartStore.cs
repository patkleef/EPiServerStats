using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Services.Rest;
using Site.Business.Charts;
using Site.Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Site.Business.Store
{
    [RestStore("chartstore")]
    public class ChartStore : RestControllerBase
    {
        private readonly IContentRepository _contentRepository;
        private readonly IContentVersionRepository _contentVersionRepository;
        private readonly IContentSoftLinkRepository _contentSoftLinkRepository;
        private readonly IContentTypeRepository _contentTypeRepository;
        private readonly PageChartsRepository _pageChartRepository;
        private readonly ChartRegistration _chartRegistration;

        public ChartStore()
        {
            _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            _contentVersionRepository = ServiceLocator.Current.GetInstance<IContentVersionRepository>();
            _contentSoftLinkRepository = ServiceLocator.Current.GetInstance<IContentSoftLinkRepository>();
            _contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            _chartRegistration = ServiceLocator.Current.GetInstance<ChartRegistration>();

            _pageChartRepository = new PageChartsRepository();
        }

        [HttpGet]
        public RestResult Get(int? currentPageId, int? chartId)
        {
            if (currentPageId.HasValue && chartId.HasValue)
            {
                var currentPage = _contentRepository.Get<PageData>(new ContentReference(currentPageId.Value));
                var chart = _contentRepository.Get<ChartData>(new ContentReference(chartId.Value));

                var data = chart.GetChartDataSource(currentPage.ContentLink);

                return Rest(data);
            }
            return Rest(string.Empty);






            /*if (currentPageId.HasValue && chartTypeId.HasValue)
            {
                var chart = _chartRegistration.Charts.FirstOrDefault(c => c.Id == chartTypeId.Value);

                var currentPage = _contentRepository.Get<PageData>(new ContentReference(currentPageId.Value));

                return Rest(ChartViewModel.FromBaseChartType(chart, currentPage.ContentLink));
            }
            else if (currentPageId.HasValue)
            {
                var currentPage = _contentRepository.Get<PageData>(new ContentReference(currentPageId.Value));

                var pageCharts = _pageChartRepository.GetByContentGuid(currentPage.ContentGuid);

                var list = new List<ChartViewModel>();
                if (pageCharts != null && pageCharts.ChartTypes != null)
                {
                    foreach (var guid in pageCharts.ChartTypes)
                    {
                        var chart = _chartRegistration.Charts.FirstOrDefault(c => c.Id == guid);
                        if (chart != null)
                        {
                            list.Add(ChartViewModel.FromBaseChartType(chart, currentPage.ContentLink));
                        }
                    }
                }
                return Rest(list);
            }
            else
            {
                return Rest(_chartRegistration.Charts);
            }    */
            return Rest(string.Empty);     
        }

        [HttpPost]
        public RestResult Post(int? currentPageId, Guid[] guids)
        {
            if(currentPageId.HasValue)
            {
                var currentPage = _contentRepository.Get<PageData>(new ContentReference(currentPageId.Value));

                var pageCharts = new PageCharts();
                pageCharts.Id = EPiServer.Data.Identity.NewIdentity(currentPage.ContentGuid);
                pageCharts.ChartTypes = guids;

                _pageChartRepository.Save(pageCharts);
            }            

            return Rest(string.Empty);
        }

        /*[HttpGet]
        public RestResult Get(int? currentPageId)
        {
            var currentPage = _contentRepository.Get<PageData>(new ContentReference(currentPageId));

            var pageStats = new PageStats();
            pageStats.ModifiedAt = GetPageModifiedAt(currentPage.ContentLink);
            pageStats.ModifiedBy = GetPageModifiedBy(currentPage.ContentLink);
            pageStats.LinksToPage = GetLinksToPage(currentPage.ContentLink);

            return Rest(pageStats);
        }

        [HttpGet]
        public RestResult GetChartsMenu()
        {
            var list = new List<ChartViewModel>
            {
                new ChartViewModel { Id = Guid.NewGuid(), Name = "Page modified by" },
                new ChartViewModel{ Id = Guid.NewGuid(), Name = "Page modified at" },
                new ChartViewModel { Id = Guid.NewGuid(), Name = "Links to page" }
            };
            return Rest(list);
        }*/

        /*private List<Stats> GetPageModifiedAt(ContentReference contentReference)
        {
            var list = new List<Stats>();

            /*var versions = _contentVersionRepository.List(contentReference)
               .GroupBy(c => c.Saved.Month);

           
            for (int i = 1; i <= 12; i++)
            {
                var stats = new Stats();
                stats.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i);
                if (versions.FirstOrDefault(v => v.Key == i) != null)
                {
                    stats.Number = versions.FirstOrDefault(v => v.Key == i).Count();
                }
                else
                {
                    stats.Number = new Random().Next(0, 20);
                }
                list.Add(stats);
            }
            return list;
        }*/

        /* private List<ModifiedByStats> GetPageModifiedBy(ContentReference contentReference)
         {
             var list = new List<ModifiedByStats>();
             var versions = _contentVersionRepository.List(contentReference)
                .GroupBy(c => c.SavedBy);                


             /*foreach(var group in versions)
             {
                 var stats = new ModifiedByStats();
                 stats.User = group.Key;
                 stats.Number = group.Count();
                 list.Add(stats);
             }
             return list;
             }
             */
    

    /*private List<LinksToPageStats> GetLinksToPage(ContentReference contentReference)
        {
            var list = new List<LinksToPageStats>();
            var links = _contentSoftLinkRepository.Load(contentReference, true);

            
            list.Add(new LinksToPageStats { ContentType = "News type", Number = 15 });
            list.Add(new LinksToPageStats { ContentType = "Article type", Number = 6 });
            list.Add(new LinksToPageStats { ContentType = "Blog type", Number = 21 });
            list.Add(new LinksToPageStats { ContentType = "Content type", Number = 4 });
            list.Add(new LinksToPageStats { ContentType = "Landing type", Number = 2 });

            return list;
            foreach (var link in links)
            {
                var content = _contentRepository.Get<IContent>(link.OwnerContentLink);
                var contentType = _contentTypeRepository.Load(content.ContentTypeID);

                var item = list.FirstOrDefault(l => l.ContentType.Equals(contentType.Name));
                if(item != null)
                {
                    item.Number++;
                }
                else
                {
                    item = new LinksToPageStats
                    {
                        ContentType = contentType.Name,
                        Number = 1
                    };
                    list.Add(item);
                }
            return list;
            }*/

    }
}