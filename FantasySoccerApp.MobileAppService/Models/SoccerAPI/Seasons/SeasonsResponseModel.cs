using Newtonsoft.Json;
using System.Collections.Generic;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Seasons
{
    public class SeasonsResponseModel
    {
        [JsonProperty("results")]
        public long Results { get; set; }

        [JsonProperty("seasons")]
        public List<long> Seasons { get; set; }
    }
}