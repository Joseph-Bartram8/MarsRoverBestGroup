using MarsRoverBestGroup3._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRoverBestGroup3._0.Controllers
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
            ViewData["Test"] = "Test";
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



        [HttpPost]
        public IActionResult ConvertEarthDate(Dates dates)
        {

            
            var marsDate = MarsDate.EarthToMarsDate(dates.earthInputDate);


            var convertedDate = new Dates { marsOutputDate= marsDate };


            return View(convertedDate);
        }


    }
}
