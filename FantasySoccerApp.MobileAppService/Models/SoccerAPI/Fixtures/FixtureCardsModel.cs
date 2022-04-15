using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Fixtures
{
    public class FixtureCardsModel
    {
        [JsonProperty("yellow")]
        public int? Yellow { get; set; }

        [JsonProperty("red")]
        public int? Red { get; set; }
    }
}
