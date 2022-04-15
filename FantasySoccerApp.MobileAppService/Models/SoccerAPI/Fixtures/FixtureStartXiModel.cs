using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureStartXiModel
    {
        [JsonProperty("team_id")]
        public long? TeamId { get; set; }

        [JsonProperty("player_id")]
        public long? PlayerId { get; set; }

        [JsonProperty("player")]
        public string Player { get; set; }

        [JsonProperty("number")]
        public long? Number { get; set; }

        [JsonProperty("pos")]
        public string Pos { get; set; }
    }
}
