using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using FantasySoccerApp.Models.Fixtures;
using FantasySoccerApp.Services;
using FantasySoccerApp.Utilities;
using MoreLinq;
using Xamarin.Forms;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    public class CountriesGroupViewModel : BaseViewModel
    {
        public string HeaderText { get; set; } = "Fixtures";
        public DateTime FilterDate { get; set; } = DateTime.Now;
        private CountriesViewModel _oldCountry;
        private ObservableCollection<CountriesViewModel> items;
        public ObservableCollection<CountriesViewModel> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }
        public Command LoadCountriesCommand
        {
            get;
            set;
        }
        public Command<CountriesViewModel> RefreshItemsCommand
        {
            get;
            set;
        }
        public Command FixtureClickCommand
        {
            get;
            set;
        }
        public Command DateSelectedCommand
        {
            get;
            set;
        }
        public CountriesGroupViewModel()
        {
            items = new ObservableCollection<CountriesViewModel>();
            Items = new ObservableCollection<CountriesViewModel>();
            LoadCountriesCommand = new Command(() => ExecuteLoadItemsCommand());
            RefreshItemsCommand = new Command<CountriesViewModel>((item) => ExecuteRefreshItemsCommand(item));
            FixtureClickCommand = new Command(() => ExecuteFixtureClickCommand());
            DateSelectedCommand = new Command(() => ExecuteDateChosen());
        }
        public bool isExpanded = false;
        private void ExecuteRefreshItemsCommand(CountriesViewModel item)
        {
            if (_oldCountry == item)
            {
                // click twice on the same item will hide it  
                item.Expanded = !item.Expanded;
            }
            else
            {
                if (_oldCountry != null)
                {
                    // hide previous selected item  
                    item.Expanded = false;
                }
                // show selected item  
                item.Expanded = true;
            }
            _oldCountry = item;
        }
        private async void ExecuteFixtureClickCommand()
        {
            Template template = new Template();
            template.Name = "Fixture";
            template.PageName = "Views.Fixtures.FixturePage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
        }
        private async void ExecuteDateChosen()
        {
            Template template = new Template();
            template.Name = "Fixtures";
            template.PageName = "Views.Fixtures.FixturePage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
        }
        void ExecuteLoadItemsCommand()
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                Items.Clear();

                List<CountryFixtureListItem> leagueResults = new List<CountryFixtureListItem>();

                var fixtures = APIFixtureService.GetFixturesByDate(DateTime.Now, Utilities.Settings.CurrentUserAccessToken);

                var leagueCategories = fixtures.Fixtures.Select(x => $"{x.League.Country} - {x.League.Name}").Distinct().ToList();

                foreach(var leagueCategory in leagueCategories)
                {
                    var leagueFixtures = new List<FixtureListItem>();
                    foreach(var fixture in fixtures.Fixtures.Where(x => $"{x.League.Country} - {x.League.Name}" == leagueCategory))
                    {
                        leagueFixtures.Add(new FixtureListItem(fixture.FixtureId.ToString(), fixture.HomeTeam.TeamName, fixture.AwayTeam.TeamName, fixture.EventDate));
                    }
                    leagueResults.Add(new CountryFixtureListItem(leagueCategory, leagueFixtures, ""));
                }

                if (leagueResults != null && leagueResults.Count > 0)
                {
                    foreach (var league in leagueResults)
                        Items.Add(new CountriesViewModel(league));
                }
                else { IsEmpty = true; }

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
