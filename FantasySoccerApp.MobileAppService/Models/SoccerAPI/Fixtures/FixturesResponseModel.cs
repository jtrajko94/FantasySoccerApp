using System.Collections.Generic;
using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixturesResponseModel
    {
        [JsonProperty("results")]
        public long Results { get; set; }

        [JsonProperty("fixtures")]
        public List<FixtureModel> Fixtures { get; set; }
    }
}