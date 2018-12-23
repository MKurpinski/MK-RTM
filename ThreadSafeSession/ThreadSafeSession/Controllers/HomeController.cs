using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThreadSafeSession.Models;
using ThreadSafeSession.Session;

namespace ThreadSafeSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessionProvider _sessionProvider;
        private const string SessionKey = "sessionKey";

        public HomeController(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }
        public IActionResult Index()
        {
            Parallel.For(0, 10, (_) => _sessionProvider.Set(SessionKey, DateTime.UtcNow));
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            var dateTime = _sessionProvider.Get<DateTime>(SessionKey);

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
