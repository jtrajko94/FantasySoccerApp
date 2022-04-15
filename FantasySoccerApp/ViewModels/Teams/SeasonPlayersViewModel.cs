using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Teams;
using FantasySoccerApp.Views.Teams;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace FantasySoccerApp.ViewModels.Teams
{
    public class SeasonPlayersViewModel
    {
        public ObservableCollection<PlayerListItem> Players { get; set; }

        public SeasonPlayersViewModel()
        {
            PlayerClickCommand = new Command(() => ExecutePlayerClickCommand());

            Players = new ObservableCollection<PlayerListItem>
            {
                new PlayerListItem("123", "Luka Modric", "image"),
                new PlayerListItem("123", "Karim Benzema", "image"),
                new PlayerListItem("123", "Gareth Bale", "image"),
                new PlayerListItem("123", "Eden Hazard", "image"),
                new PlayerListItem("123", "Toni Kroos", "image"),
                new PlayerListItem("123", "Casemiro", "image"),
                new PlayerListItem("123", "Isco Alcaron", "image"),
                new PlayerListItem("123", "Lucas Vazquez", "image"),
                new PlayerListItem("123", "Sergio Ramos", "image"),
                new PlayerListItem("123", "Nacho Fernandez", "image"),
                new PlayerListItem("123", "Rafael Varane", "image"),
                new PlayerListItem("123", "Marcelo", "image"),
                new PlayerListItem("123", "Ferland Mendy", "image"),
                new PlayerListItem("123", "Federico Valverde", "image"),
            };
        }

        #region Commands

        public Command PlayerClickCommand
        {
            get;
            set;
        }

        private async void ExecutePlayerClickCommand()
        {
            await PopupNavigation.Instance.PushAsync(new PlayerPerformancePopupPage());
        }

        #endregion
    }
}
