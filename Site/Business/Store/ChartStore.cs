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

                var model = CreateModel(chartId.Value, currentPage.ContentLink);

                return Rest(model);
            }
            else if(currentPageId.HasValue && !chartId.HasValue)
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

        public ChartViewModel CreateModel(int chartId, ContentReference contentReferece)
        {
            var chart = _contentRepository.Get<ChartData>(new ContentReference(chartId));

            var model = new ChartViewModel();
            model.Id = chart.ContentLink.ID;
            model.ActionAndEffects = chart.ActionAndEffects;
            model.ChartType = chart.ChartType;
            model.Description = chart.Description;
            model.ShowLegend = chart.ShowLegend;
            model.Theme = chart.Theme;
            model.Title = chart.Title;
            model.TitlePosition = chart.TitlePosition;
            model.Data = chart.GetChartDataSource(contentReferece);
            model.ChartType = chart.ChartType;

            return model;
        }

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
    }
}