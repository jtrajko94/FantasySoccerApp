using System.Windows.Input;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    [Preserve(AllMembers = true)]
    public class FixtureViewModel : BaseViewModel
    {
        #region Fields

        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string HomeScoreLabel { get; set; }
        public string AwayScoreLabel { get; set; }
        public string DateTimeLabel { get; set; }
        public string LeagueLabel { get; set; }

        #endregion

        #region Commands
        public Command TeamSelectedCommand
        {
            get;
            set;
        }

        private async void ExecuteTeamSelectedCommand()
        {
            Template template = new Template();
            template.Name = "Team";
            template.PageName = "Views.Teams.TeamPage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
        }

        #endregion

        #region Constructor

        public FixtureViewModel()
        {
            HomeTeamName = "Real Madrid";
            AwayTeamName = "Barcelona";
            HomeScoreLabel = "3";
            AwayScoreLabel = "1";
            DateTimeLabel = "March 3rd, 2020";
            LeagueLabel = "La Liga Santander 2019-2020";

            TeamSelectedCommand = new Command(() => ExecuteTeamSelectedCommand());
        }

        #endregion
    }
}
