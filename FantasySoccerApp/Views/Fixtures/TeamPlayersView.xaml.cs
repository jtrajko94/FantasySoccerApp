using System.Collections.Generic;
using FantasySoccerApp.Models.Fixtures;
using FantasySoccerApp.ViewModels.Fixtures;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Fixtures
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamPlayersView
    {
        private TeamPlayersGroupViewModel ViewModel
        {
            get { return (TeamPlayersGroupViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        private List<TeamListItem> ListCountries = new List<TeamListItem>();

        public TeamPlayersView()
        {
            InitializeComponent();

            ViewModel = new TeamPlayersGroupViewModel();
            if (ViewModel.Items.Count == 0)
            {
                ViewModel.LoadTeamPlayersCommand.Execute(null);
            }
            BindingContext = ViewModel;
        }

        public TeamPlayersView(TeamPlayersGroupViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = new TeamPlayersGroupViewModel();
            this.ViewModel = viewModel;
        }
    }
}
