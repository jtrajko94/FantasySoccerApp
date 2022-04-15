using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureGoalsModel
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("conceded")]
        public int? Conceded { get; set; }

        [JsonProperty("assists")]
        public int? Assists { get; set; }
    }
}
