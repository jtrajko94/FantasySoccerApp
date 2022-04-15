using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Fixtures;

namespace FantasySoccerApp.ViewModels.Individuals
{
    public class SeasonStatisticsViewModel
    {
        public ObservableCollection<SeasonStatisticListItem> SeasonStatisticEntries { get; set; }

        public SeasonStatisticsViewModel()
        {
            SeasonStatisticEntries = new ObservableCollection<SeasonStatisticListItem>()
            {
                new SeasonStatisticListItem("Matches", "35"),
                new SeasonStatisticListItem("Minutes", "72"),
                new SeasonStatisticListItem("Goals", "1"),
                new SeasonStatisticListItem("Assists", "0"),
                new SeasonStatisticListItem("Attempted Passes", "72"),
                new SeasonStatisticListItem("Successful Passes", "67"),
                new SeasonStatisticListItem("Dribbles", "4"),
                new SeasonStatisticListItem("Tackles", "3"),
                new SeasonStatisticListItem("Shots", "2"),
                new SeasonStatisticListItem("Saves", "0")
            };
        }
    }
}
