using System.Collections.Generic;
using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Countries
{
    public class CountriesResponseModel
    {
        [JsonProperty("results")]
        public long Results { get; set; }

        [JsonProperty("countries")]
        public List<CountryModel> Countries { get; set; }
    }
}
