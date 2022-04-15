using System.Collections.ObjectModel;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using FantasySoccerApp.Models.Fixtures;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    [Preserve(AllMembers = true)]
    public class PlayerStatisticsViewModel : BaseViewModel
    {
        #region Fields

        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string HomeScoreLabel { get; set; }
        public string AwayScoreLabel { get; set; }
        public string DateTimeLabel { get; set; }
        public string LeagueLabel { get; set; }
        public ObservableCollection<PlayerStatisticListItem> PlayerStatisticEntries { get; set; }

        #endregion

        #region Constructor

        public PlayerStatisticsViewModel()
        {
            HomeTeamName = "Real Madrid";
            AwayTeamName = "Barcelona";
            HomeScoreLabel = "3";
            AwayScoreLabel = "1";
            DateTimeLabel = "March 3rd, 2020";
            LeagueLabel = "La Liga Santander 2019-2020";

            PlayerProfileClickCommand = new Command(() => ExecutePlayerProfileClickCommand());
            CloseClickCommand = new Command(() => ExecuteCloseClickCommand());

            PlayerStatisticEntries = new ObservableCollection<PlayerStatisticListItem>()
            {
                new PlayerStatisticListItem("Minutes", "72"),
                new PlayerStatisticListItem("Goals", "1"),
                new PlayerStatisticListItem("Assists", "0"),
                new PlayerStatisticListItem("Passes", "67/72"),
                new PlayerStatisticListItem("Dribbles", "4"),
                new PlayerStatisticListItem("Tackles", "3"),
                new PlayerStatisticListItem("Shots", "2"),
                new PlayerStatisticListItem("Save", "0")
            };
        }

        #endregion

        #region Commands

        public Command PlayerProfileClickCommand { get; set; }
        public Command CloseClickCommand { get; set; }

        private async void ExecutePlayerProfileClickCommand()
        {
            Template template = new Template();
            template.Name = "Individual";
            template.PageName = "Views.Individuals.IndividualPage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
            await PopupNavigation.Instance.PopAsync();
        }

        private async void ExecuteCloseClickCommand()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        #endregion
    }
}
