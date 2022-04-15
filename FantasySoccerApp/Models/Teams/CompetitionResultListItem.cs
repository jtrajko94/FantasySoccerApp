namespace FantasySoccerApp.Models.Teams
{
    public class CompetitionResultListItem
    {
        public string CompetitionID { get; set; }
        public string CompetitionName { get; set; }
        public string Result { get; set; }
        public string ResultDescription { get; set; }

        public CompetitionResultListItem() { }
        public CompetitionResultListItem(string competitionID, string competitionName, string result, string resultDescription = "")
        {
            CompetitionID = competitionID;
            CompetitionName = competitionName;
            Result = result;
            ResultDescription = resultDescription;
        }
    }
}
