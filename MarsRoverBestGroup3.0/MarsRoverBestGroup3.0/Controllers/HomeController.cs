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
        private APICall _apiCall = new APICall();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "welcome to mars";
            ViewBag.Motto = "we got:";
            return View();
        }
        public IActionResult Martian()
        {
            ViewBag.Title = "watch out";
            ViewBag.Motto = "they're approaching";
            return View();
        }
        public IActionResult MarsData()
        {
            ViewBag.Title = "welcome to mars";
            ViewBag.Motto = "we got:";
            return View(new HomepageViewModel());
        }

        public IActionResult Gallery()
        {
            ViewBag.Title = "gallery";
            ViewBag.Motto = "get rover pics";
            DateTime defaultDate = new DateTime(2020, 08, 15);
            GalleryModel galleryModel = new GalleryModel();
            galleryModel.date = defaultDate;
            galleryModel.rover = "curiosity";
            galleryModel.camera = "all";
            galleryModel.photos = _apiCall.GetMarsRoverPhotosByDateAndRover(defaultDate);
            return View(galleryModel);
        }

        [HttpPost]
        public ActionResult Gallery(GalleryPostModel postModel)
        {
            ViewBag.Title = "gallery";
            ViewBag.Motto = "get rover pics";
            GalleryModel galleryModel = new GalleryModel();
            galleryModel.date = postModel.date;
            galleryModel.rover = postModel.rover;
            galleryModel.camera = postModel.camera;
            galleryModel.photos = _apiCall.GetMarsRoverPhotosByDateAndRover(postModel.date, postModel.rover, postModel.camera);
            return View(galleryModel);
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
            try
            {
                var marsDate = DateConverter.EarthToMarsDate(dates.earthInputDate);
                var convertedDate = new HomepageViewModel { marsOutputDate = marsDate };
                return View("Marsdata", convertedDate);
            }
            catch (ArgumentException exception)
            {
                var dateError = new HomepageViewModel { DateErrorMessage = exception.Message };
                return View("Marsdata", dateError);
            }
        }

        [HttpPost]
        public IActionResult ConvertMarsDate(Dates dates)
        {
            try
            {
                var earthDate = DateConverter.MarsToEarthDate(dates.marsInputDate);
                var convertedDate = new HomepageViewModel { earthOutputDate = earthDate };
                return View("MarsData", convertedDate);
            }
            catch(ArgumentOutOfRangeException outOfRange)
            {
                var dateError = new HomepageViewModel { ParameterErrorMessage = outOfRange.Message };
                return View("Marsdata", dateError);
            }
        }
    }
}
