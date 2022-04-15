using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureH2HTeamModel
    {
        [JsonProperty("team_id")]
        public long? TeamId { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("team_logo")]
        public string TeamLogo { get; set; }

        [JsonProperty("statistics")]
        public FixtureH2HStatisticsModel Statistics { get; set; }
    }
}
