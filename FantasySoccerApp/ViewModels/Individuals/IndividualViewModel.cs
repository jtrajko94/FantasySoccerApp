using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Individuals;
using Xamarin.Forms;

namespace FantasySoccerApp.ViewModels.Individuals
{
    public class IndividualViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Id { get; set; }
        public string SelectedSeason { get; set; } = "2019-2020";
        public ObservableCollection<SeasonListItem> SeasonListItems { get; set; }

        public IndividualViewModel()
        {
            Name = "Cristiano Ronaldo";
            Type = "Player";
            Icon = "image";
            Id = "123";

            SeasonSelectedCommand = new Command(() => ExecuteSeasonSelectedCommand());

            SeasonListItems = new ObservableCollection<SeasonListItem>();
            SeasonListItems.Add(new SeasonListItem("123", "2019-2020"));
            SeasonListItems.Add(new SeasonListItem("123", "2018-2019"));
            SeasonListItems.Add(new SeasonListItem("123", "2017-2018"));
            SeasonListItems.Add(new SeasonListItem("123", "2016-2017"));
            SeasonListItems.Add(new SeasonListItem("123", "2015-2016"));
            SeasonListItems.Add(new SeasonListItem("123", "2014-2015"));
        }

        #region Commands
        public Command FixtureClickCommand
        {
            get;
            set;
        }

        public Command TeamClickCommand
        {
            get;
            set;
        }

        public Command SeasonSelectedCommand
        {
            get;
            set;
        }
        private void ExecuteSeasonSelectedCommand()
        {
            //TODO: refresh the views
        }
        #endregion
    }
}
