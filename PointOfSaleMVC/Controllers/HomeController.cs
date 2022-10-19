using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PointOfSaleAPI.Models;
using PointOfSaleMVC.Models;
using System.Diagnostics;

namespace PointOfSaleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        } public IActionResult Purchase()
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