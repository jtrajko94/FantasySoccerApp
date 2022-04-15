using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixturePlayerModel
    {
        [JsonProperty("event_id")]
        public long? EventId { get; set; }

        [JsonProperty("updateAt")]
        public long? UpdateAt { get; set; }

        [JsonProperty("player_id")]
        public long? PlayerId { get; set; }

        [JsonProperty("player_name")]
        public string PlayerName { get; set; }

        [JsonProperty("team_id")]
        public long? TeamId { get; set; }

        [JsonProperty("team_name")]
        public string TeamName { get; set; }

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("minutes_played")]
        public int? MinutesPlayed { get; set; }

        [JsonProperty("captain")]
        public bool? Captain { get; set; }

        [JsonProperty("substitute")]
        public bool? Substitute { get; set; }

        [JsonProperty("offsides")]
        public int? Offsides { get; set; }

        [JsonProperty("shots")]
        public int? Shots { get; set; }

        [JsonProperty("goals")]
        public int? Goals { get; set; }

        [JsonProperty("passes")]
        public int? Passes { get; set; }

        [JsonProperty("tackles")]
        public int? Tackles { get; set; }

        [JsonProperty("duels")]
        public int? Duels { get; set; }

        [JsonProperty("dribbles")]
        public int? Dribbles { get; set; }

        [JsonProperty("fouls")]
        public int? Fouls { get; set; }

        [JsonProperty("cards")]
        public int? Cards { get; set; }

        [JsonProperty("penalty")]
        public int? Penalty { get; set; }
    }
}
