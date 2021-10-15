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
        public IActionResult Martian()
        {
            ViewBag.Title = "watch out";
            ViewBag.Motto = "they're approaching";
            return View();
        }
        public IActionResult MarsData()
        {
            
            RoverSols newSol = new RoverSols();
            HomepageViewModel hpvm = new HomepageViewModel();
            newSol.CuriositySolOutput = DateConverter.CuriositySol(DateTime.Now);
            newSol.PerserveranceSolOutput = DateConverter.PerseveranceSol(DateTime.Now);
            newSol.OpportunitySolOutput = DateConverter.OpportunitySol(DateTime.Now);
            newSol.SpiritSolOutput = DateConverter.SpiritSol(DateTime.Now);
            newSol.SojournerSolOutput = DateConverter.SojournerSol(DateTime.Now);
            hpvm.RoverSols = newSol;
            
            ViewBag.Title = "welcome to mars";
            ViewBag.Motto = "we got:";
            newSol.apod = _apiCall.AstronomyPhotoOfTheDay();
            return View ("marsData", hpvm);
        }

        public IActionResult Gallery()
        {
            try
            {
                ViewBag.Title = "gallery";
                ViewBag.Motto = "get rover pics";
                DateTime defaultDate = new DateTime(2020, 08, 15);
                GalleryModel galleryModel = new GalleryModel();
                galleryModel.date = defaultDate;
                galleryModel.rover = "curiosity";
                galleryModel.photos = _apiCall.GetMarsRoverPhotosByDateAndRover(defaultDate);
                galleryModel.APIStatus = true;
                return View(galleryModel);

            }
            catch 
            {
                
                var ApiError = new GalleryModel { APIStatus = false };
                return View("Gallery", ApiError);
            }
            
        }

        [HttpPost]
        public ActionResult Gallery(GalleryPostModel postModel)
        {
            try
            {
                ViewBag.Title = "gallery";
                ViewBag.Motto = "get rover pics";
                GalleryModel galleryModel = new GalleryModel();
                galleryModel.date = postModel.date;
                galleryModel.rover = postModel.rover;
                galleryModel.photos = _apiCall.GetMarsRoverPhotosByDateAndRover(postModel.date, postModel.rover);
                galleryModel.APIStatus = true;
                return View(galleryModel);

            }
            catch
            {
                var ApiError = new GalleryModel { APIStatus = false };
                return View("Gallery", ApiError);
            }
            
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
            
            RoverSols newSol = new RoverSols();
            HomepageViewModel hpvm = new HomepageViewModel();
            newSol.CuriositySolOutput = DateConverter.CuriositySol(DateTime.Now);
            newSol.PerserveranceSolOutput = DateConverter.PerseveranceSol(DateTime.Now);
            newSol.OpportunitySolOutput = DateConverter.OpportunitySol(DateTime.Now);
            newSol.SpiritSolOutput = DateConverter.SpiritSol(DateTime.Now);
            newSol.SojournerSolOutput = DateConverter.SojournerSol(DateTime.Now);
            hpvm.RoverSols = newSol;

            try
            {
                hpvm.marsOutputDate =DateConverter.EarthToMarsDate(dates.earthInputDate);
                //.HomePage = hpvm;
                
                return View("MarsData", hpvm );
                
                
            }
            catch (ArgumentException exception)
            {
                hpvm.DateErrorMessage = exception.Message;
                //viewmodel.HomePage = hpvm;
                return View("Marsdata", hpvm);
            }
        }

        [HttpPost]
        public IActionResult ConvertMarsDate(Dates dates)
        {
            
            RoverSols newSol = new RoverSols();
            HomepageViewModel hpvm = new HomepageViewModel();
            newSol.CuriositySolOutput = DateConverter.CuriositySol(DateTime.Now);
            newSol.PerserveranceSolOutput = DateConverter.PerseveranceSol(DateTime.Now);
            newSol.OpportunitySolOutput = DateConverter.OpportunitySol(DateTime.Now);
            newSol.SpiritSolOutput = DateConverter.SpiritSol(DateTime.Now);
            newSol.SojournerSolOutput = DateConverter.SojournerSol(DateTime.Now);
            hpvm.RoverSols = newSol;

        
                try
                {
                    hpvm.earthOutputDate = DateConverter.MarsToEarthDate(dates.marsInputDate);
                   

                    return View("MarsData", hpvm);


                }catch (ArgumentOutOfRangeException outOfRange)
                {
                   
                    hpvm.ParameterErrorMessage = outOfRange.Message;
                    
                    return View("Marsdata", hpvm);
                }
                catch (Exception notANumber)
                {
                    hpvm.ParameterErrorMessage = notANumber.Message;
                    
                    return View("Marsdata", hpvm);

                
                }
                
            

        }
        
    }

}
