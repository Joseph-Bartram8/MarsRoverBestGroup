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
        public static IRestResponse GenericCall(string rest_request)
        {
            var apiKey = ConfigurationManager.AppSettings["APIKey"];
            var client = new RestClient("https://api.nasa.gov");
            var request = new RestRequest($"{rest_request}api_key={apiKey}", DataFormat.Json);
            var response = client.Get(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("API call invalid");
            }
            return response;
        }
        public static APOD AstronomyPhotoOfTheDay() 
        {
            var response = GenericCall("/planetary/apod?");
            var apod = JsonConvert.DeserializeObject<APOD>(response.Content);
            return apod;
        }
        public static List<Photo> GetMarsRoverPhotosByDate(string earth_date)
        {
            var response = GenericCall($"/mars-photos/api/v1/rovers/curiosity/photos?earth_date={earth_date}&");
            var mars_rover_pictures = JsonConvert.DeserializeObject<MarsRoverPhotosResponse>(response.Content);
            return mars_rover_pictures.photos;
        }
    }
}
