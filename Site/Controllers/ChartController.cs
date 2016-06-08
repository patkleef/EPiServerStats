using EPiServer.Web.Mvc;
using Site.Business.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class ChartController : ContentController<ChartData>
    {
        public ActionResult Index(ChartData currentPage)
        {
            return View(currentPage);
        }
    }
}