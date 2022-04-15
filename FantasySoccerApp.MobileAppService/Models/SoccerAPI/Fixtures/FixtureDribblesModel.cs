using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureDribblesModel
    {
        [JsonProperty("attempts")]
        public int? Attempts { get; set; }

        [JsonProperty("success")]
        public int? Success { get; set; }

        [JsonProperty("past")]
        public int? Past { get; set; }
    }
}
