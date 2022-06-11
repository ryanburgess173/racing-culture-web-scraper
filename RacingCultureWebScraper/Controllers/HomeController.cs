using Microsoft.AspNetCore.Mvc;
using RacingCultureWebScraper.Models;
using RacingCultureWebScraper.BAL.Models;
using System.Diagnostics;
using RacingCultureWebScraper.BAL;

namespace RacingCultureWebScraper.Controllers
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
            List<Division> racingDivisions = new List<Division>();
            racingDivisions.Add(new Division(1, "NASCAR Cup Series"));
            racingDivisions.Add(new Division(2, "NASCAR Busch Series"));
            racingDivisions.Add(new Division(3, "Formula 1"));
            return View(new HomeViewModel { divisions = racingDivisions});
        }

        [HttpPost]
        public IActionResult FormSubmitSeasonStats()
        {
            string selectedDivision = HttpContext.Request.Form["seriesDropDown"];
            int selectedYear = Int32.Parse(HttpContext.Request.Form["yearsDropDown"]);
            BusinessLogicCenter cc = new BusinessLogicCenter(selectedYear, selectedDivision, "SeasonStats");
            return Content("Submitted!");
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