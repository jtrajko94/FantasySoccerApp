using Newtonsoft.Json;
using System.Collections.Generic;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureLineupModel
    {
        [JsonProperty("coach")]
        public string Coach { get; set; }

        [JsonProperty("coach_id")]
        public long? CoachId { get; set; }

        [JsonProperty("formation")]
        public string Formation { get; set; }

        [JsonProperty("startXI")]
        public List<FixtureStartXiModel> StartXi { get; set; }

        [JsonProperty("substitutes")]
        public List<FixtureStartXiModel> Substitutes { get; set; }

        [JsonProperty("teamname")]
        public string TeamName { get; set; }
    }
}
