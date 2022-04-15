using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureTacklesModel
    {
        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("blocks")]
        public int? Blocks { get; set; }

        [JsonProperty("interceptions")]
        public int? Interceptions { get; set; }
    }
}
