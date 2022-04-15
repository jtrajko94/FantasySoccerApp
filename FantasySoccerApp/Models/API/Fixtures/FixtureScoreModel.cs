using Newtonsoft.Json;

namespace FantasySoccerApp.Models.API.Fixtures
{
    public class FixtureScoreModel
    {
        public string Halftime { get; set; }
        public string Fulltime { get; set; }
        public string Extratime { get; set; }
        public string Penalty { get; set; }
    }
}
