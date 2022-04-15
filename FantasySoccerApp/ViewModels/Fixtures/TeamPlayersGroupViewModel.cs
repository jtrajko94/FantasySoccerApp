using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using FantasySoccerApp.Models.Fixtures;
using FantasySoccerApp.Views.Fixtures;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    public class TeamPlayersGroupViewModel : BaseViewModel
    {
        private TeamPlayersViewModel _oldTeamPlayers;
        private ObservableCollection<TeamPlayersViewModel> items;
        public ObservableCollection<TeamPlayersViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }
        public Command LoadTeamPlayersCommand
        {
            get;
            set;
        }
        public Command<TeamPlayersViewModel> RefreshItemsCommand
        {
            get;
            set;
        }
        public Command PlayerClickCommand
        {
            get;
            set;
        }
        public TeamPlayersGroupViewModel()
        {
            items = new ObservableCollection<TeamPlayersViewModel>();
            Items = new ObservableCollection<TeamPlayersViewModel>();
            LoadTeamPlayersCommand = new Command(() => ExecuteLoadItemsCommand());
            RefreshItemsCommand = new Command<TeamPlayersViewModel>((item) => ExecuteRefreshItemsCommand(item));
            PlayerClickCommand = new Command(() => ExecutePlayerClickCommand());
        }
        public bool isExpanded = true;
        private void ExecuteRefreshItemsCommand(TeamPlayersViewModel item)
        {
            if (_oldTeamPlayers == item)
            {
                // click twice on the same item will hide it  
                item.Expanded = !item.Expanded;
            }
            else
            {
                if (_oldTeamPlayers != null)
                {
                    // hide previous selected item  
                    item.Expanded = false;
                }
                // show selected item  
                item.Expanded = true;
            }
            _oldTeamPlayers = item;
        }
        private async void ExecutePlayerClickCommand()
        {
            await PopupNavigation.Instance.PushAsync(new PlayerPerformancePopupPage());
        }
        void ExecuteLoadItemsCommand()
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                Items.Clear();
                List<PlayerListItem> Team1Players = new List<PlayerListItem>()
                {
                    new PlayerListItem("123", "Luka Modric"),
                    new PlayerListItem("123", "Karim Benzema"),
                    new PlayerListItem("123", "Toni Kroos")
                };
                List<PlayerListItem> Team2Players = new List<PlayerListItem>()
                {
                    new PlayerListItem("123", "Lionel Messi"),
                    new PlayerListItem("123", "Antoine Griezmann"),
                    new PlayerListItem("123", "Luis Suarez")
                };
                List<TeamListItem> items = new List<TeamListItem>()
                {
                    new TeamListItem("Real Madrid", Team1Players, "imageurl"),
                    new TeamListItem("Barcelona", Team2Players, "imageurl"),
                };

                if (items != null && items.Count > 0)
                {
                    foreach (var team in items)
                        Items.Add(new TeamPlayersViewModel(team));
                }
                else { IsEmpty = true; }

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
