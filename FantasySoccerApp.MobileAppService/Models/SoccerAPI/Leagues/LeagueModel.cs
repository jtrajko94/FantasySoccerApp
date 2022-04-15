using Newtonsoft.Json;
using System;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Leagues
{
    public class LeagueModel
    {
        [JsonProperty("league_id")]
        public long? LeagueId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("season")]
        public long? Season { get; set; }

        [JsonProperty("season_start")]
        public DateTime? SeasonStart { get; set; }

        [JsonProperty("season_end")]
        public DateTime? SeasonEnd { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("standings")]
        public long? Standings { get; set; }

        [JsonProperty("is_current")]
        public bool? IsCurrent { get; set; }

        [JsonProperty("coverage")]
        public LeagueCoverageModel Coverage { get; set; }
    }
}