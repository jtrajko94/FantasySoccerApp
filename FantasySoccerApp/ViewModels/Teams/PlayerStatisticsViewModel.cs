using System.Collections.ObjectModel;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using FantasySoccerApp.Models.Teams;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.Teams
{
    [Preserve(AllMembers = true)]
    public class PlayerStatisticsViewModel : BaseViewModel
    {
        #region Fields

        public string TeamName { get; set; }
        public string Season { get; set; }
        public string PlayerName { get; set; }
        public ObservableCollection<PlayerStatisticListItem> PlayerStatisticEntries { get; set; }

        #endregion

        #region Constructor

        public PlayerStatisticsViewModel()
        {
            TeamName = "Real Madrid";
            PlayerName = "Luka Modric";
            Season = "2019-2020";

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
