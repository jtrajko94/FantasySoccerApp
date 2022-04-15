using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FantasySoccerApp.Models.API.Fixtures
{
    public class FixtureModel
    {
        public long? FixtureId { get; set; }
        public long? LeagueId { get; set; }
        public FixtureLeagueModel League { get; set; }
        public DateTime? EventDate { get; set; }
        public long? EventTimestamp { get; set; }
        public long? FirstHalfStart { get; set; }
        public long? SecondHalfStart { get; set; }
        public string Round { get; set; }
        public string Status { get; set; }
        public string StatusShort { get; set; }
        public int? Elapsed { get; set; }
        public string Venue { get; set; }
        public string Referee { get; set; }
        public FixtureTeamModel HomeTeam { get; set; }
        public FixtureTeamModel AwayTeam { get; set; }
        public int? GoalsHomeTeam { get; set; }
        public int? GoalsAwayTeam { get; set; }
        public FixtureScoreModel Score { get; set; }
        public List<FixtureEventModel> Events { get; set; }
        public List<FixtureLineupModel> Lineups { get; set; }
    }
}
