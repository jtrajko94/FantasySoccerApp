using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Leagues;

namespace FantasySoccerApp.ViewModels.Leagues
{
    public class ResultsViewModel
    {
        public ObservableCollection<ResultsListItem> Results { get; set; }

        public ResultsViewModel()
        {
            Results = new ObservableCollection<ResultsListItem>
            {
                new ResultsListItem("1", "image", "Liverpool", "+28", "49", new string[5]{ "#7ed321", "#7ed321", "#7ed321", "#7ed321", "#7ed321" }),
                new ResultsListItem("2", "image", "Leicester City", "+29", "39", new string[5]{ "#7ed321", "#7ed321", "#7ed321", "#7ed321", "#b2b8c2" }),
                new ResultsListItem("3", "image", "Manchester City", "+28", "39", new string[5]{ "#7ed321", "#7ed321", "#7ed321", "#7ed321", "#b2b8c2" }),
                new ResultsListItem("4", "image", "Leicester City", "+29", "37", new string[5]{ "#7ed321", "#7ed321", "#7ed321", "#7ed321", "#b2b8c2" }),
                new ResultsListItem("5", "image", "Chelsea", "+20", "33", new string[5]{ "#7ed321", "#b2b8c2", "#7ed321", "#7ed321", "#b2b8c2" }),
                new ResultsListItem("6", "image", "Manchester United", "+12", "26", new string[5]{ "#7ed321", "#b2b8c2", "#7ed321", "#7ed321", "#b2b8c2" }),
                new ResultsListItem("7", "image", "Tottenham Hotspur", "+9", "24", new string[5]{ "#7ed321", "#7ed321", "#7ed321", "#b2b8c2", "#b2b8c2" }),
                new ResultsListItem("8", "image", "Wolverhampton Wanderers", "+1", "18", new string[5]{ "#7ed321", "#7ed321", "#7ed321", "#7ed321", "#b2b8c2" }),
                new ResultsListItem("9", "image", "Burnley", "-7", "9", new string[5]{ "#7ed321", "#7ed321", "#b2b8c2", "#7ed321", "#b2b8c2" }),
                new ResultsListItem("10", "image", "Everton", "-15", "3", new string[5]{ "#7ed321", "#ff4a4a", "#7ed321", "#b2b8c2", "#b2b8c2" }),
                new ResultsListItem("11", "image", "Leicester City", "+29", "39", new string[5]{ "#ff4a4a", "#7ed321", "#b2b8c2", "#b2b8c2", "#b2b8c2" }),
                new ResultsListItem("12", "image", "Leicester City", "+29", "39", new string[5]{ "#b2b8c2", "#b2b8c2", "#ff4a4a", "#ff4a4a", "#b2b8c2" }),
            };
        }
    }
}
