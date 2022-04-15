namespace FantasySoccerApp.Models.Fixtures
{
    public class SeasonStatisticListItem
    {
        public string StatisticName { get; set; }
        public string StatisticValueDescription { get; set; }

        public SeasonStatisticListItem() { }
        public SeasonStatisticListItem(string statisticName, string statisticValueDescription)
        {
            StatisticName = statisticName;
            StatisticValueDescription = statisticValueDescription;
        }
    }
}
