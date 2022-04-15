using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Leagues
{
    public class LeagueCoverageModel
    {
        [JsonProperty("standings")]
        public bool? Standings { get; set; }

        [JsonProperty("fixtures")]
        public LeagueFixturesModel Fixtures { get; set; }

        [JsonProperty("players")]
        public bool? Players { get; set; }

        [JsonProperty("topScorers")]
        public bool? TopScorers { get; set; }

        [JsonProperty("predictions")]
        public bool? Predictions { get; set; }

        [JsonProperty("odds")]
        public bool? Odds { get; set; }
    }
}