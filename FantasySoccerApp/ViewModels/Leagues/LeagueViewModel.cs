using FantasySoccerApp.Models.Leagues;
using System.Collections.ObjectModel;

namespace FantasySoccerApp.ViewModels.Leagues
{
    public class LeagueViewModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Id { get; set; }
        public string SelectedSeason { get; set; } = "2019-2020";
        public ObservableCollection<SeasonListItem> SeasonListItems { get; set; }

        public LeagueViewModel()
        {
            Name = "English Premier League";
            Icon = "image";
            Id = "123";

            SeasonListItems = new ObservableCollection<SeasonListItem>();
            SeasonListItems.Add(new SeasonListItem("123", "2019-2020"));
            SeasonListItems.Add(new SeasonListItem("123", "2018-2019"));
            SeasonListItems.Add(new SeasonListItem("123", "2017-2018"));
            SeasonListItems.Add(new SeasonListItem("123", "2016-2017"));
            SeasonListItems.Add(new SeasonListItem("123", "2015-2016"));
            SeasonListItems.Add(new SeasonListItem("123", "2014-2015"));
        }
    }
}
