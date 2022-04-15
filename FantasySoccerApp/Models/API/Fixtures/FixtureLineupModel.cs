using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FantasySoccerApp.Models.API.Fixtures
{
    public class FixtureLineupModel
    {
        public string Coach { get; set; }
        public long? CoachId { get; set; }
        public string Formation { get; set; }
        public List<FixtureStartXiModel> StartXi { get; set; }
        public List<FixtureStartXiModel> Substitutes { get; set; }
        public string TeamName { get; set; }
    }
}
