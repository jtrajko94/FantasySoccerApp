using System;
namespace FantasySoccerApp.Models.Individuals
{
    public class FixtureListItem
    {
        public string FixtureID { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public DateTime? DateTime { get; set; }
        public string Competition { get; set; }
        public string HomeScoreLabel { get; set; }
        public string AwayScoreLabel { get; set; }

        public FixtureListItem() { }
        public FixtureListItem(string fixtureID, string homeTeamName, string awayTeamName, DateTime? datetime,
            string competition, string homeScoreLabel, string awayScoreLabel)
        {
            FixtureID = fixtureID;
            HomeTeamName = homeTeamName;
            AwayTeamName = awayTeamName;
            DateTime = datetime;
            Competition = competition;
            HomeScoreLabel = homeScoreLabel;
            AwayScoreLabel = awayScoreLabel;
        }
    }
}
