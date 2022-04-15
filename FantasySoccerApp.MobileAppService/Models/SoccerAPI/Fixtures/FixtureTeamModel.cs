using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureTeamModel
    {
        [JsonProperty("team_id")]
        public long? TeamId { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
