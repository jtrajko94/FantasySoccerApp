using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixturePenaltyModel
    {
        [JsonProperty("won")]
        public int? Won { get; set; }

        [JsonProperty("commited")]
        public int? Commited { get; set; }

        [JsonProperty("success")]
        public int? Success { get; set; }

        [JsonProperty("missed")]
        public int? Missed { get; set; }

        [JsonProperty("saved")]
        public int? Saved { get; set; }
    }
}
