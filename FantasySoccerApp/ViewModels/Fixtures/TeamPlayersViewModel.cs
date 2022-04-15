using System.Collections.ObjectModel;
using System.ComponentModel;
using FantasySoccerApp.Models.Fixtures;
using MvvmHelpers;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    public class TeamPlayersViewModel : ObservableRangeCollection<TeamPlayerViewModel>, INotifyPropertyChanged
    {
        private ObservableCollection<TeamPlayerViewModel> players = new ObservableRangeCollection<TeamPlayerViewModel>();
        public TeamPlayersViewModel(TeamListItem team, bool expanded = true)
        {
            Team = team;
            _expanded = expanded;
            foreach (PlayerListItem player in team.Players)
            {
                players.Add(new TeamPlayerViewModel(player));
            }
            if (expanded) AddRange(players);
        }
        public TeamPlayersViewModel() { }
        private bool _expanded;
        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Expanded"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StateIcon"));
                    if (_expanded)
                    {
                        AddRange(players);
                    }
                    else
                    {
                        Clear();
                    }
                }
            }
        }
        public string StateIcon
        {
            get
            {
                if (Expanded)
                {
                    return "arrow_a.png";
                }
                else
                {
                    return "arrow_b.png";
                }
            }
        }
        public string Name
        {
            get
            {
                return Team.Name;
            }
        }
        public TeamListItem Team
        {
            get;
            set;
        }

        public string Image
        {
            get
            {
                return Team.Image;
            }
        }

        public int PlayerCount
        {
            get
            {
                return Team.PlayerCount;
            }
        }
    }
}
