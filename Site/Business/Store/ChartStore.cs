using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Shell.Services.Rest;
using Site.Business.Charts;
using Site.Business.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Site.Business.Store
{
    /// <summary>
    /// Rest store for charts
    /// </summary>
    [RestStore("chartstore")]
    public class ChartStore : RestControllerBase
    {
        private readonly IContentRepository _contentRepository;
        private readonly PageChartsRepository _pageChartRepository;

        /// <summary>
        /// Public constructor
        /// </summary>
        public ChartStore()
        {
            _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();

            _pageChartRepository = new PageChartsRepository();
        }

        /// <summary>
        /// Get method
        /// Used when a page is loaded and when a chart is dropped on the dashboard
        /// </summary>
        /// <param name="currentPageId"></param>
        /// <param name="chartId"></param>
        /// <returns></returns>
        [HttpGet]
        public RestResult Get(int? currentPageId, int? chartId)
        {
            if (currentPageId.HasValue && chartId.HasValue) // chart is dropped in the dashboard
            {
                var currentPage = _contentRepository.Get<PageData>(new ContentReference(currentPageId.Value));

                var model = CreateModel(chartId.Value, currentPage.ContentLink);

                return Rest(model);
            }
            else if(currentPageId.HasValue && !chartId.HasValue) // page is loaded so get all charts
            {
                var currentPage = _contentRepository.Get<PageData>(new ContentReference(currentPageId.Value));
                var pageCharts = _pageChartRepository.GetByContentGuid(currentPage.ContentGuid);

                var list = new List<ChartViewModel>();
                if (pageCharts != null && pageCharts.Charts != null)
                {
                    foreach (var id in pageCharts.Charts)
                    {
                        list.Add(CreateModel(id, currentPage.ContentLink));
                    }
                }

                return Rest(list);
            }
            return Rest(string.Empty);  
        }

        /// <summary>
        /// Post method
        /// Used when a chart is dropped on the dashboard
        /// </summary>
        /// <param name="currentPageId"></param>
        /// <param name="charts"></param>
        /// <returns></returns>
        [HttpPost]
        public RestResult Post(int? currentPageId, int[] charts)
        {
            if(currentPageId.HasValue)
            {
                var currentPage = _contentRepository.Get<PageData>(new ContentReference(currentPageId.Value));

                var pageCharts = new PageCharts();
                pageCharts.Id = EPiServer.Data.Identity.NewIdentity(currentPage.ContentGuid);
                pageCharts.Charts = charts;

                _pageChartRepository.Save(pageCharts);
            }            

            return Rest(string.Empty);
        }

        /// <summary>
        /// Create model to return to the chart dashboard widget
        /// </summary>
        /// <param name="chartId"></param>
        /// <param name="contentReferece"></param>
        /// <returns></returns>
        private ChartViewModel CreateModel(int chartId, ContentReference contentReferece)
        {
            var chart = _contentRepository.Get<ChartData>(new ContentReference(chartId));

            var model = new ChartViewModel();
            model.Id = chart.ContentLink.ID;
            model.ActionAndEffects = chart.ActionAndEffects;
            model.Description = chart.Description;
            model.ShowLegend = chart.ShowLegend;
            model.Theme = chart.Theme;
            model.Title = chart.Title;
            model.TitlePosition = chart.TitlePosition;
            model.Data = chart.GetChartDataSource(contentReferece);
            model.ChartType = chart.ChartType;

            return model;
        }
    }
}