using System;

namespace FantasySoccerApp.Models.Fixtures
{
    public class PlayerListItem
    {
        public string FixturePlayerID { get; set; }
        public string Name { get; set; }

        public PlayerListItem() { }
        public PlayerListItem(string fixturePlayerID, string name)
        {
            FixturePlayerID = fixturePlayerID;
            Name = name;
        }
    }
}
