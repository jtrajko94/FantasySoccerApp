using System;

namespace FantasySoccerApp.Models.Fixtures
{
    public class FixtureListItem
    {
        public string FixtureID { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public DateTime? DateTime { get; set; }

        public FixtureListItem() { }
        public FixtureListItem(string fixtureID, string homeTeamName, string awayTeamName, DateTime? datetime)
        {
            FixtureID = fixtureID;
            HomeTeamName = homeTeamName;
            AwayTeamName = awayTeamName;
            DateTime = datetime;
        }
    }
}
