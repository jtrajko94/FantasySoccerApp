using System.Collections.Generic;
using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixturesRoundsResponseModel
    {
        [JsonProperty("results")]
        public long Results { get; set; }

        [JsonProperty("fixtures")]
        public List<string> Fixtures { get; set; }
    }
}