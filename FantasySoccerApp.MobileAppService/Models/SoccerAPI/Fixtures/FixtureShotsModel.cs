using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureShotsModel
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("on")]
        public int? On { get; set; }
    }
}
