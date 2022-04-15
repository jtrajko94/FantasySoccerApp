namespace FantasySoccerApp.Models.API.Fixtures
{
    public class FixtureEventModel
    {
        public long? Elapsed { get; set; }
        public long? ElapsedPlus { get; set; }
        public long? TeamId { get; set; }
        public string TeamName { get; set; }
        public long? PlayerId { get; set; }
        public string Player { get; set; }
        public long? AssistId { get; set; }
        public string Assist { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public string Comments { get; set; }
    }
}
