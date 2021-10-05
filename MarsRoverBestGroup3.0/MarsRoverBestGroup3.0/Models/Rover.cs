using Newtonsoft.Json;

namespace MarsRoverBestGroup3._0.Models
{
    public class Rover
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("landing_date")]
        public string LandingDate { get; set; }

        [JsonProperty("launch_date")]
        public string LaunchDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}