using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureFoulsModel
    {
        [JsonProperty("drawn")]
        public int? Drawn { get; set; }

        [JsonProperty("committed")]
        public int? Committed { get; set; }
    }
}
