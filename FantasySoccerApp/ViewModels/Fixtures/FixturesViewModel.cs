using FantasySoccerApp.Models.Fixtures;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    public class TeamPlayerViewModel
    {
        private PlayerListItem _player;
        public TeamPlayerViewModel(PlayerListItem player)
        {
            _player = player;
        }


        public string Name
        {
            get
            {
                return _player.Name;
            }
        }

        public string FixturePlayerID
        {
            get
            {
                return _player.FixturePlayerID;
            }
        }

        public PlayerListItem PlayerListItem
        {
            get => _player;
        }
    }
}
