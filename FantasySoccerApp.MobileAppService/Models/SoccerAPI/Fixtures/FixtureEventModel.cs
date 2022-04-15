using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureEventModel
    {
        [JsonProperty("elapsed")]
        public long? Elapsed { get; set; }

        [JsonProperty("elapsed_plus")]
        public long? ElapsedPlus { get; set; }

        [JsonProperty("team_id")]
        public long? TeamId { get; set; }

        [JsonProperty("teamName")]
        public string TeamName { get; set; }

        [JsonProperty("player_id")]
        public long? PlayerId { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("assist_id")]
        public long? AssistId { get; set; }

        [JsonProperty("assist")]
        public string Assist { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}
