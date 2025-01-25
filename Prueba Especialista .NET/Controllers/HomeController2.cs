using Microsoft.AspNetCore.Mvc;
using Prueba_Especialista_.NET.Models;
using System.Diagnostics;

namespace Prueba_Especialista_.NET.Controllers
{
    public class HomeController2 : Controller
    {
        private readonly ILogger<HomeController2> _logger;

        public HomeController2(ILogger<HomeController2> logger)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}