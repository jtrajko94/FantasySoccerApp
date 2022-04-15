using System.Collections.Generic;
using Newtonsoft.Json;

namespace FantasySoccerApp.MobileAppService.Models.SoccerAPI.Leagues
{
    public class LeaguesResponseModel
    {
        [JsonProperty("results")]
        public long Results { get; set; }

        [JsonProperty("leagues")]
        public List<LeagueModel> Leagues { get; set; }
    }
}