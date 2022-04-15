namespace FantasySoccerApp.Models.Teams
{
    public class PieChartDataPoint
    {
        public string Key { get; set; }
        public int Value { get; set; }

        public PieChartDataPoint(string key, int value = 0)
        {
            Key = key;
            Value = value;
        }
    }
}
