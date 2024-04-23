using CursoMod165.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CursoMod165.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Contador de visualizações da página MyPage
        static int Counter { get; set; } = 0;




        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MyPage()
        {
            HomeController.Counter = HomeController.Counter + 1;

            TempData["Author"] = "Diogo";
            TempData["Data"] = DateTime.Now;

            ViewData["Y"] = "YYYYYYYYYYY";

            ViewBag.X = "XXXXXXXXXXXX";


            List<string> list = new List<string>()
            {
                "Primeiro",
                "Segundo",
                "Terceiro"
            };

            ViewData["list"] = list;
            ViewBag.list = list;

            return View(HomeController.Counter);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
