namespace FantasySoccerApp.Models.Fixtures
{
    public class OddsListItem
    {
        public string SourceName { get; set; }
        public string SourceImage { get; set; }
        public double HomeResult { get; set; }
        public double AwayResult { get; set; }
        public double DrawResult { get; set; }

        public OddsListItem() { }
        public OddsListItem(string sourceName, string sourceImage, double homeResult, double awayResult, double drawResult)
        {
            SourceName = sourceName;
            SourceImage = sourceImage;
            HomeResult = homeResult;
            AwayResult = awayResult;
            DrawResult = drawResult;
        }
    }
}
