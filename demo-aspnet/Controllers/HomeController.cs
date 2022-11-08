using demo_aspnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace demo_aspnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      
        public string demo()
        {
            return "hello cc";
        }

        public ViewResult Index()
        {
            string hour = string.Empty;
            hour = "cc";
            ViewBag.WhoIAm = "my name is";
            ViewBag.Hour = hour ?? hour;
            return View("myView");
        }
        public IActionResult Register()
        {
            return View("Register");
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}