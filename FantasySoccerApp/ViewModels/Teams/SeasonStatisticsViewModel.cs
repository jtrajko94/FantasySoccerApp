using System.Collections.Generic;
using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Teams;
using Xamarin.Forms;

namespace FantasySoccerApp.ViewModels.Teams
{
    public class SeasonStatisticsViewModel
    {
        public ObservableCollection<PieChartDataPoint> OverallResults { get; set; }
        public ObservableCollection<PieChartDataPoint> HomeResults { get; set; }
        public ObservableCollection<PieChartDataPoint> AwayResults { get; set; }

        public ObservableCollection<PieChartDataPoint> OverallGoals { get; set; }
        public ObservableCollection<PieChartDataPoint> HomeGoals { get; set; }
        public ObservableCollection<PieChartDataPoint> AwayGoals { get; set; }

        public List<Color> resultsPieColors { get; set; } = new List<Color>
        {
            Color.Green,
            Color.Red,
            Color.Yellow
        };

        public List<Color> goalsPieColors { get; set; } = new List<Color>
        {
            Color.Green,
            Color.Red
        };

        public SeasonStatisticsViewModel()
        {
            OverallResults = new ObservableCollection<PieChartDataPoint>
            {
                new PieChartDataPoint("Wins", 22),
                new PieChartDataPoint("Losses", 10),
                new PieChartDataPoint("Draws", 4)
            };

            HomeResults = new ObservableCollection<PieChartDataPoint>
            {
                new PieChartDataPoint("Wins", 16),
                new PieChartDataPoint("Losses", 2),
                new PieChartDataPoint("Draws", 2)
            };

            AwayResults = new ObservableCollection<PieChartDataPoint>
            {
                new PieChartDataPoint("Wins", 6),
                new PieChartDataPoint("Losses", 8),
                new PieChartDataPoint("Draws", 2)
            };

            OverallGoals = new ObservableCollection<PieChartDataPoint>
            {
                new PieChartDataPoint("Scored", 97),
                new PieChartDataPoint("Conceded", 33)
            };

            HomeGoals = new ObservableCollection<PieChartDataPoint>
            {
                new PieChartDataPoint("Scored", 55),
                new PieChartDataPoint("Conceded", 9)
            };

            AwayGoals = new ObservableCollection<PieChartDataPoint>
            {
                new PieChartDataPoint("Scored", 42),
                new PieChartDataPoint("Conceded", 24)
            };
        }
    }
}
