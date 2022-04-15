using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureH2HStatisticsModel
    {
        [JsonProperty("played")]
        public FixtureH2HResultModel Played { get; set; }

        [JsonProperty("wins")]
        public FixtureH2HResultModel Wins { get; set; }

        [JsonProperty("draws")]
        public FixtureH2HResultModel Draws { get; set; }

        [JsonProperty("loses")]
        public FixtureH2HResultModel Loses { get; set; }
    }
}
