namespace FantasySoccerApp.Models.Teams
{
    public class PlayerListItem
    {
        public string PlayerID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public PlayerListItem() { }
        public PlayerListItem(string playerID, string name, string icon)
        {
            PlayerID = playerID;
            Name = name;
            Icon = icon;
        }
    }
}
