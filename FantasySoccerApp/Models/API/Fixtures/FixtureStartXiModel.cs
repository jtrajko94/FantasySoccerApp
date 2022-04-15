using System;
using Newtonsoft.Json;

namespace FantasySoccerApp.Models.API.Fixtures
{
    public class FixtureStartXiModel
    {
        public long? TeamId { get; set; }
        public long? PlayerId { get; set; }
        public string Player { get; set; }
        public long? Number { get; set; }
        public string Pos { get; set; }
    }
}
