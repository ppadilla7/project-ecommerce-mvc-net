using Ecommerce_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ecommerce_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.IsLoggedIn = HttpContext.Session.GetString("IsLoggedIn") == "true";
            ViewBag.UserEmail = HttpContext.Session.GetString("UserEmail");

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