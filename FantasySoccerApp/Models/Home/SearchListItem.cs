namespace FantasySoccerApp.Models.Home
{
    public class SearchListItem
    {
        public string EntryID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        
        public SearchListItem() { }
        public SearchListItem(string entryID, string name, string icon, string type)
        {
            EntryID = entryID;
            Name = name;
            Icon = icon;
            Type = type;
        }
    }
}
