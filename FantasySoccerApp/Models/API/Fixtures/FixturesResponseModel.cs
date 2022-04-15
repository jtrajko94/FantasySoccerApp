using System.Collections.Generic;
using Newtonsoft.Json;

namespace FantasySoccerApp.Models.API.Fixtures
{
    public class FixturesResponseModel
    {
        public long Results { get; set; }
        public List<FixtureModel> Fixtures { get; set; }
    }
}
