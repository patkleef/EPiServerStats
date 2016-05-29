using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Site.Models.Pages;
using EPiServer.ServiceLocation;
using EPiServer.DataAbstraction;

namespace Site.Controllers
{
    public class HomePageController : PageController<HomePage>
    {
        private readonly IContentRepository _contentRepository;
        private readonly IContentVersionRepository _contentVersionRepository;
        private readonly IContentSoftLinkRepository _contentSoftLinkRepository;

        public HomePageController()
        {
            _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            _contentVersionRepository = ServiceLocator.Current.GetInstance<IContentVersionRepository>();

            _contentSoftLinkRepository = ServiceLocator.Current.GetInstance<IContentSoftLinkRepository>();
        }

        public ActionResult Index(HomePage currentPage)
        {
            /* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates */

            var list = _contentRepository.GetChildren<NewsItemPage>(ContentReference.StartPage);

            var versions = _contentVersionRepository.List(list.Last().ContentLink);

            var links = _contentSoftLinkRepository.Load(ContentReference.StartPage, true);
            

            return View(currentPage);
        }
    }
}