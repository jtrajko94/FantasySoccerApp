namespace FantasySoccerApp.Models.Individuals
{
    public class AboutInformationListItem
    {
        public string InformationName { get; set; }
        public string InformationValueDescription { get; set; }

        public AboutInformationListItem() { }

        public AboutInformationListItem(string informationName, string informationValueDescription)
        {
            InformationName = informationName;
            InformationValueDescription = informationValueDescription;

        }
    }
}
