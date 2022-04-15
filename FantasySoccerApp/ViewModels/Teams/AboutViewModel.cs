using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Teams;

namespace FantasySoccerApp.ViewModels.Teams
{
    public class AboutViewModel
    {
        public ObservableCollection<CompetitionResultListItem> CompetitionResults { get; set; }
        public string CountryLocation { get; set; }
        public string CountryIcon { get; set; }
        public string VenueName { get; set; }
        public string VenueLocation { get; set; }

        public AboutViewModel()
        {
            CountryLocation = "Madrid, Spain";
            CountryIcon = "image";

            VenueName = "Estadio Santiago Bernabeu";
            VenueLocation = "Madrid, Spain";

            CompetitionResults = new ObservableCollection<CompetitionResultListItem>
            {
                new CompetitionResultListItem("123", "La Liga Santander", "1st", "Champions League Qualification"),
                new CompetitionResultListItem("123", "UEFA Champions League", "Semi-Finals"),
                new CompetitionResultListItem("123", "Copa Del Rey", "Quarter Finals"),
                new CompetitionResultListItem("123", "UEFA Super Cup", "1st", "Champions")
            };
        }
    }
}
