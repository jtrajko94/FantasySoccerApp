namespace FantasySoccerApp.Models.Leagues
{
    public class ResultsListItem
    {
        public string Image { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }
        public string GoalDifferential { get; set; }
        public string Points { get; set; }
        public string[] MatchResults { get; set; }

        public ResultsListItem(string position, string image, string teamName, string goalDifferential, string points, string[] matchResults)
        {
            Position = position;
            Image = image;
            TeamName = teamName;
            GoalDifferential = goalDifferential;
            Points = points;
            MatchResults = matchResults;
        }
    }
}
