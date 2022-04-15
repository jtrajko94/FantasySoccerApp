using System.Collections.ObjectModel;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using FantasySoccerApp.Models.Home;
using Xamarin.Forms;

namespace FantasySoccerApp.ViewModels.Home
{
    public class SearchViewModel
    {
        public ObservableCollection<SearchListItem> SearchResults { get; set; }

        public SearchViewModel()
        {
            SearchResults = new ObservableCollection<SearchListItem>();
            SearchResultClickCommand = new Command(() => ExecuteSearchResultClickCommand());
            SearchClickCommand = new Command(() => ExecuteSearchClickCommand());
        }

        public Command SearchClickCommand
        {
            get;
            set;
        }

        public Command SearchResultClickCommand
        {
            get;
            set;
        }

        private void ExecuteSearchClickCommand()
        {
            SearchResults.Clear();
            SearchResults.Add(new SearchListItem("123", "Cristiano Ronaldo", "icon", "Player"));
            SearchResults.Add(new SearchListItem("123", "Ronaldinho", "icon", "Player"));
            SearchResults.Add(new SearchListItem("123", "Ronaldo de Souza", "icon", "Player"));
            SearchResults.Add(new SearchListItem("123", "Real Madrid", "icon", "Team"));
            SearchResults.Add(new SearchListItem("123", "Barcelona", "icon", "Team"));
        }

        private async void ExecuteSearchResultClickCommand()
        {
            Template template = new Template();
            template.Name = "Individual";
            template.PageName = "Views.Individuals.IndividualPage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
        }
    }
}

