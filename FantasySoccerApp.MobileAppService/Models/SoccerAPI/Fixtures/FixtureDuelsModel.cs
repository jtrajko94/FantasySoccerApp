using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureDuelsModel
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("won")]
        public int? Won { get; set; }
    }
}
