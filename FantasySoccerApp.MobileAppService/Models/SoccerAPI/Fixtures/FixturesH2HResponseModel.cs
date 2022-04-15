using System.Collections.Generic;
using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixturesH2HResponseModel
    {
        [JsonProperty("results")]
        public long Results { get; set; }

        [JsonProperty("fixtures")]
        public List<FixtureModel> Fixtures { get; set; }

        [JsonProperty("teams")]
        public List<FixtureH2HTeamModel> Teams { get; set; }
    }
}