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
        private readonly string _apiKey;
        private RestClient _restClient;
        public APICall()
        {
            _apiKey = Environment.GetEnvironmentVariable("API_KEY");
            _restClient = new RestClient("https://api.nasa.gov");
        }
        public APOD AstronomyPhotoOfTheDay() 
        {
            var request = new RestRequest($"/planetary/apod?api_key={_apiKey}", DataFormat.Json);
            var response = _restClient.Get(request);
            var apod = JsonConvert.DeserializeObject<APOD>(response.Content);
            return apod;
        }
        public List<Photo> GetMarsRoverPhotosByDateAndRover(DateTime earth_date, string rover_name = "curiosity", string camera_name = "all")
        {
            var earth_date_to_string = earth_date.ToString("yyyy-MM-dd");
            var request = new RestRequest($"/mars-photos/api/v1/rovers/{rover_name}/photos", DataFormat.Json);
            request.AddQueryParameter("earth_date", earth_date_to_string);
            if (camera_name != "all")
            {
                request.AddQueryParameter("camera", camera_name);
            }
            request.AddQueryParameter("api_key", _apiKey);
            var response = _restClient.Get<MarsRoverPhotosResponse>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("API Call invalid");
            }
            return response.Data.photos;
        }
    }
}
