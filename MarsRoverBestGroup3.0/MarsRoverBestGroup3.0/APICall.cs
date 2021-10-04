using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json;
using MarsRoverBestGroup3._0.Models;

namespace MarsRoverBestGroup3._0
{
    public class APICall
    {
        /* To use on a webpage add the block of code below :)
         * 
         * @{var astronomy_photo = APICall.AstronomyPhotoOfTheDay();}
         * <h3>@astronomy_photo.title</h3>
         * <img src=@astronomy_photo.url>
         * <small>@astronomy_photo.explanation</small> 
         *
         * There's also a date and hdurl variable attached to the APOD model*/
        public static APOD AstronomyPhotoOfTheDay() 
        {
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            var client = new RestClient("https://api.nasa.gov/planetary/apod/");
            var request = new RestRequest($"/?api_key={apiKey}", DataFormat.Json);
            var response = client.Get(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                    throw new Exception("API call invalid");
            }
            var apod = JsonConvert.DeserializeObject<APOD>(response.Content);
            return apod;
        }
    }
}
