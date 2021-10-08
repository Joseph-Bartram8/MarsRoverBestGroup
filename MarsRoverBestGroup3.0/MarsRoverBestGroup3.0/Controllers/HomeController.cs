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
            return View(new HomepageViewModel());
        }

        public IActionResult Gallery()
        {
            DateTime default_date = new DateTime(2020, 08, 15);
            GalleryModel gallery_model = new GalleryModel();
            gallery_model.date = default_date;
            gallery_model.photos = APICall.GetMarsRoverPhotosByDate(default_date);
            return View(gallery_model);
        }

        [HttpPost]
        public ActionResult Gallery(PostDateModel date_model)
        {
            GalleryModel gallery_model = new GalleryModel();
            gallery_model.date = date_model.date;
            gallery_model.photos = APICall.GetMarsRoverPhotosByDate(date_model.date);
            return View(gallery_model);
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

            
            var marsDate = DateConverter.EarthToMarsDate(dates.earthInputDate);


            var convertedDate = new HomepageViewModel { marsOutputDate= marsDate };


            return View("Index", convertedDate);
        }

        [HttpPost]
        public IActionResult ConvertMarsDate(Dates dates)
        {


            var earthDate = DateConverter.MarsToEarthDate(dates.marsInputDate);


            var convertedDate = new HomepageViewModel { earthOutputDate = earthDate };


            return View("Index", convertedDate);
        }
    }
}
