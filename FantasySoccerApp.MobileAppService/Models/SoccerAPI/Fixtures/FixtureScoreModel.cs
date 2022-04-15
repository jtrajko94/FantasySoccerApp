using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureScoreModel
    {
        [JsonProperty("halftime")]
        public string Halftime { get; set; }

        [JsonProperty("fulltime")]
        public string Fulltime { get; set; }

        [JsonProperty("extratime")]
        public string Extratime { get; set; }

        [JsonProperty("penalty")]
        public string Penalty { get; set; }
    }
}
