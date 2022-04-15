using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Countries
{
    public class CountryModel
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }
    }
}
