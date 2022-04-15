namespace FantasySoccerApp.Models.Individuals
{
    public class SeasonListItem
    {
        public string SeasonID { get; set; }
        public string Name { get; set; }

        public SeasonListItem() { }

        public SeasonListItem(string seasonID, string name)
        {
            SeasonID = seasonID;
            Name = name;
        }
    }
}
