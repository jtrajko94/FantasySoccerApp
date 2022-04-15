using System.Collections.Generic;

namespace FantasySoccerApp.Models.Fixtures
{
    public class TeamListItem
    {
        public string Name { get; set; }

        public List<PlayerListItem> Players { get; set; }

        public bool IsVisible { get; set; } = true;

        public string Image { get; set; }

        public int PlayerCount { get; set; }

        public TeamListItem() { }
        public TeamListItem(string name, List<PlayerListItem> players, string image)
        {
            Name = name;
            Players = players;
            Image = image;
            PlayerCount = players.Count;
        }
    }
}
