using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureH2HResultModel
    {
        [JsonProperty("home")]
        public int? Home { get; set; }

        [JsonProperty("away")]
        public int? Away { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }
}
