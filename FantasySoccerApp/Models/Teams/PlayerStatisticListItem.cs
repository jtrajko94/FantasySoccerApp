namespace FantasySoccerApp.Models.Teams
{
    public class PlayerStatisticListItem
    {
        public string StatisticName { get; set; }
        public string StatisticValueDescription { get; set; }

        public PlayerStatisticListItem() { }
        public PlayerStatisticListItem(string statisticName, string statisticValueDescription)
        {
            StatisticName = statisticName;
            StatisticValueDescription = statisticValueDescription;
        }
    }
}
