using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureModel
    {
        [JsonProperty("fixture_id")]
        public long? FixtureId { get; set; }

        [JsonProperty("league_id")]
        public long? LeagueId { get; set; }

        [JsonProperty("league")]
        public  FixtureLeagueModel League { get; set; }

        [JsonProperty("event_date")]
        public DateTime? EventDate { get; set; }

        [JsonProperty("event_timestamp")]
        public long? EventTimestamp { get; set; }

        [JsonProperty("firstHalfStart")]
        public long? FirstHalfStart { get; set; }

        [JsonProperty("secondHalfStart")]
        public long? SecondHalfStart { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("statusShort")]
        public string StatusShort { get; set; }

        [JsonProperty("elapsed")]
        public int? Elapsed { get; set; }

        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("referee")]
        public string Referee { get; set; }

        [JsonProperty("homeTeam")]
        public FixtureTeamModel HomeTeam { get; set; }

        [JsonProperty("awayTeam")]
        public FixtureTeamModel AwayTeam { get; set; }

        [JsonProperty("goalsHomeTeam")]
        public int? GoalsHomeTeam { get; set; }

        [JsonProperty("goalsAwayTeam")]
        public int? GoalsAwayTeam { get; set; }

        [JsonProperty("score")]
        public FixtureScoreModel Score { get; set; }

        [JsonProperty("events")]
        public List<FixtureEventModel> Events { get; set; }

        [JsonProperty("lineups")]
        public Dictionary<string, JObject> TempLineups { get; set; }
        public List<FixtureLineupModel> Lineups { get; set; }
    }
}
