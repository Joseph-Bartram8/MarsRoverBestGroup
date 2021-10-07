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
        public static APOD AstronomyPhotoOfTheDay() 
        {
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            var client = new RestClient("https://api.nasa.gov");
            var request = new RestRequest($"/planetary/apod?api_key={apiKey}", DataFormat.Json);
            var response = client.Get(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("API call invalid");
            }
            var apod = JsonConvert.DeserializeObject<APOD>(response.Content);
            return apod;
        }
        public static List<Photo> GetMarsRoverPhotosByDateAndRover(DateTime earth_date, string rover_name = "curiosity", string camera_name = null)
        {
            var earth_date_to_string = earth_date.ToString("yyyy-MM-dd");
            var api_key = ConfigurationManager.AppSettings["APIKey"];
            var client = new RestClient("https://api.nasa.gov");
            var request = new RestRequest($"/mars-photos/api/v1/rovers/{rover_name}/photos", DataFormat.Json);
            request.AddParameter("earth_date", earth_date_to_string);
            if (camera_name is not null)
            {
                request.AddParameter("camera", camera_name);
            }
            request.AddParameter("api_key", api_key);
            var response = client.Get(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("API call invalid");
            }
            var mars_rover_pictures = JsonConvert.DeserializeObject<MarsRoverPhotosResponse>(response.Content);
            return mars_rover_pictures.photos;
        }
    }
}
