using MarsRoverBestGroup3._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MarsRoverBestGroup3._0.ViewModels;

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

        public IActionResult MarsData()
        {
            Viewmodel viewmodel = new Viewmodel();
            RoverSols newSol = new RoverSols();
            HomepageViewModel hpvm = new HomepageViewModel();
            newSol.CuriositySolOutput = DateConverter.CuriositySol(DateTime.Now);
            newSol.PerserveranceSolOutput = DateConverter.PerseveranceSol(DateTime.Now);
            newSol.OpportunitySolOutput = DateConverter.OpportunitySol(DateTime.Now);
            newSol.SpiritSolOutput = DateConverter.SpiritSol(DateTime.Now);
            newSol.SojournerSolOutput = DateConverter.SojournerSol(DateTime.Now);
            viewmodel.RoverSols = newSol;
            viewmodel.HomePage = hpvm;
            ViewBag.Title = "welcome to mars";
            ViewBag.Motto = "we got:";
            return View ("marsData", viewmodel);
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
            Viewmodel viewmodel = new Viewmodel();
            RoverSols newSol = new RoverSols();
            HomepageViewModel hpvm = new HomepageViewModel();
            newSol.CuriositySolOutput = DateConverter.CuriositySol(DateTime.Now);
            newSol.PerserveranceSolOutput = DateConverter.PerseveranceSol(DateTime.Now);
            newSol.OpportunitySolOutput = DateConverter.OpportunitySol(DateTime.Now);
            newSol.SpiritSolOutput = DateConverter.SpiritSol(DateTime.Now);
            newSol.SojournerSolOutput = DateConverter.SojournerSol(DateTime.Now);
            viewmodel.RoverSols = newSol;

            try
            {
                hpvm.marsOutputDate =DateConverter.EarthToMarsDate(dates.earthInputDate);
                viewmodel.HomePage = hpvm;
                
                return View("MarsData", viewmodel);
                
                
            }
            catch (ArgumentException exception)
            {
                hpvm.DateErrorMessage = exception.Message;
                viewmodel.HomePage = hpvm;
                return View("Marsdata", viewmodel);
            }
        }

        [HttpPost]
        public IActionResult ConvertMarsDate(Dates dates)
        {
            Viewmodel viewmodel = new Viewmodel();
            RoverSols newSol = new RoverSols();
            HomepageViewModel hpvm = new HomepageViewModel();
            newSol.CuriositySolOutput = DateConverter.CuriositySol(DateTime.Now);
            newSol.PerserveranceSolOutput = DateConverter.PerseveranceSol(DateTime.Now);
            newSol.OpportunitySolOutput = DateConverter.OpportunitySol(DateTime.Now);
            newSol.SpiritSolOutput = DateConverter.SpiritSol(DateTime.Now);
            newSol.SojournerSolOutput = DateConverter.SojournerSol(DateTime.Now);
            viewmodel.RoverSols = newSol;

        
                try
                {
                    hpvm.earthOutputDate = DateConverter.MarsToEarthDate(dates.marsInputDate);
                    viewmodel.HomePage = hpvm;

                    return View("MarsData", viewmodel);


                }
                catch (ArgumentException exception)
                {
                    hpvm.DateErrorMessage = exception.Message;
                    viewmodel.HomePage = hpvm;
                    return View("Marsdata", viewmodel);
                }
            }
        /*
        public IActionResult DisplayCuriositySols(RoverSols roverSols)
        {
            Viewmodel viewmodel = new Viewmodel();
            var newSol = new RoverSols();
            newSol.CuriositySolOutput = DateConverter.CuriositySol(DateTime.Now);
            newSol.PerserveranceSolOutput = DateConverter.PerseveranceSol(DateTime.Now);
            newSol.OpportunitySolOutput= DateConverter.OpportunitySol(DateTime.Now);
            newSol.SpiritSolOutput = DateConverter.SpiritSol(DateTime.Now);
            newSol.SojournerSolOutput = DateConverter.SojournerSol(DateTime.Now);
            viewmodel.RoverSols = newSol;
            return View("MarsData", newSol);
        }

        
        
        public IActionResult DisplayPerseveranceSols(RoverSols roverSols)
        {
            var roverDays = DateConverter.PerseveranceSol(roverSols.roverSolInput);
            var newSol = new RoverSols();
            newSol.roverSolOutput = roverDays;
            return View("MarsData", newSol);
        }
        public IActionResult DisplayOpportunitySols(RoverSols roverSols)
        {
            var roverDays = DateConverter.OpportunitySol(roverSols.roverSolInput);
            var newSol = new RoverSols();
            newSol.roverSolOutput = roverDays;
            return View("MarsData", newSol);
        }
        public IActionResult DisplaySpiritSols(RoverSols roverSols)
        {
            var roverDays = DateConverter.OpportunitySol(roverSols.roverSolInput);
            var newSol = new RoverSols();
            newSol.roverSolOutput = roverDays;
            return View("MarsData", newSol);
        }
        public IActionResult DisplaySojournerSols(RoverSols roverSols)
        {
            var roverDays = DateConverter.OpportunitySol(roverSols.roverSolInput);
            var newSol = new RoverSols();
            newSol.roverSolOutput = roverDays;
            return View("MarsData", newSol);
        }
        */
    }

}
