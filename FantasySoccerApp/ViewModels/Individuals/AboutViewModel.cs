using System;
using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Individuals;

namespace FantasySoccerApp.ViewModels.Individuals
{
    public class AboutViewModel
    {
        public string TeamName { get; set; }
        public string TeamCountry { get; set; }
        public string TeamIcon { get; set; }
        public string InternationalTeam { get; set; }

        public ObservableCollection<AboutInformationListItem> InformationEntries { get; set; }

        public AboutViewModel()
        {
            TeamName = "Juventus";
            TeamCountry = "Italy";
            TeamIcon = "image";
            InternationalTeam = "Portugal";

            InformationEntries = new ObservableCollection<AboutInformationListItem>()
            {
                new AboutInformationListItem("Age", "33"),
                new AboutInformationListItem("Birth Date", DateTime.Now.AddYears(-3).ToString("MM/dd/yyyy")),
                new AboutInformationListItem("Hometown", "Madeira, Portugal"),
                new AboutInformationListItem("Position", "Winger"),
                new AboutInformationListItem("Height", "6'1"),
                new AboutInformationListItem("Weight", "150 lbs"),
                new AboutInformationListItem("Preferred Foot", "Right"),
            };
        }
    }
}
