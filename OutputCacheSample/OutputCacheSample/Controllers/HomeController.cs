using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OutputCacheSample.Controllers
{
    public class HomeController : Controller
    {

        [OutputCache(Duration = 10, Location = OutputCacheLocation.Any, VaryByParam = "none")]
        public ActionResult Index()
        {
            ViewBag.CurrentDate = DateTime.UtcNow;
            return View();
        }

        [OutputCache(Duration = 10, Location = OutputCacheLocation.Client, VaryByParam = "none")]
        public ActionResult About()
        {
            ViewBag.UserId = Guid.NewGuid().ToString("d");
            return View();
        }

        [OutputCache(CacheProfile = "CacheForTenSeconds")]
        public ActionResult Contact()
        {
            ViewBag.CurrentDate = DateTime.UtcNow;
            return View("Index");
        }

        [OutputCache(Duration = 10, Location = OutputCacheLocation.Any, VaryByParam = "id")]
        public ActionResult Details(int id)
        {
            ViewBag.CurrentDate = DateTime.UtcNow;
            ViewBag.IdParam = id;
            return View();
        }
    }
}