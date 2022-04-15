using System;
using System.ComponentModel;
using FantasySoccerApp.Models.Individuals;
using Xamarin.Forms.Extended;
using Xamarin.Forms;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FantasySoccerApp.ViewModels.Teams
{
    public class SeasonFixturesViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        private const int PageSize = 10;

        public InfiniteScrollCollection<FixtureListItem> Fixtures { get; set; }

        public InfiniteScrollCollection<FixtureListItem> fixtureData { get; set; } = new InfiniteScrollCollection<FixtureListItem>
        {
            new FixtureListItem("123", "Real Madrid", "Barcelona", DateTime.Now.AddDays(3), "La Liga Santander", "-", "-"),
            new FixtureListItem("123", "Celta Vigo", "Real Madrid", DateTime.Now.AddDays(1), "UEFA Champions League", "-", "-"),
            new FixtureListItem("123", "Real Madrid", "Mallorca", DateTime.Now.AddDays(-1), "La Liga Santander", "3", "1"),
            new FixtureListItem("123", "Eibar", "Real Madrid", DateTime.Now.AddDays(-3), "La Liga Santander", "2", "2"),
            new FixtureListItem("123", "Real Madrid", "Valencia", DateTime.Now.AddDays(-7), "La Liga Santander", "1", "3"),
            new FixtureListItem("123", "Real Sociedad", "Real Madrid", DateTime.Now.AddDays(-10), "La Liga Santander", "2", "4"),
            new FixtureListItem("123", "Real Madrid", "Atletico Madrid", DateTime.Now.AddDays(-15), "La Liga Santander", "2", "0"),
            new FixtureListItem("123", "Borrussia Dortmund", "Real Madrid", DateTime.Now.AddDays(-20), "UEFA Champions League", "1", "0"),
            new FixtureListItem("123", "Real Madrid", "Real Betis", DateTime.Now.AddDays(-22), "La Liga Santander", "5", "1"),
            new FixtureListItem("123", "Barcelona", "Real Madrid", DateTime.Now.AddDays(-33), "La Liga Santander", "2", "1"),
            new FixtureListItem("123", "Real Madrid", "Atletico Madrid", DateTime.Now.AddDays(-38), "La Liga Santander", "1", "4"),
            new FixtureListItem("123", "Valencia", "Real Madrid", DateTime.Now.AddDays(-41), "La Liga Santander", "0", "2"),
            new FixtureListItem("123", "Real Madrid", "Deportivo La Coruna", DateTime.Now.AddDays(-45), "La Liga Santander", "1", "1"),
            new FixtureListItem("123", "Espanyol", "Real Madrid", DateTime.Now.AddDays(-47), "La Liga Santander", "2", "3"),
            new FixtureListItem("123", "Real Madrid", "Chelsea", DateTime.Now.AddDays(-50), "UEFA Champions League", "3", "5")
        };

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public SeasonFixturesViewModel()
        {
            FixtureClickCommand = new Command(() => ExecuteFixtureClickCommand());        

            Fixtures = new InfiniteScrollCollection<FixtureListItem>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;

                    // load the next page
                    var page = fixtureData.Count / PageSize;

                    var items = await GetItemsAsync(page, PageSize);

                    IsBusy = false;

                    // return the items that need to be added
                    return items;
                },
                OnCanLoadMore = () =>
                {
                    //TODO: Need to address this
                    return Fixtures.Count < fixtureData.Count;
                }
            };

            _ = DownloadData();
        }

        private async Task DownloadData()
        {
            var items = await GetItemsAsync(pageIndex: 0, pageSize: PageSize);
            Fixtures.Clear();
            Fixtures.AddRange(items);
        }

        public async Task<List<FixtureListItem>> GetItemsAsync(int pageIndex, int pageSize)
        {
            await Task.Delay(300);

            return fixtureData.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Commands

        public Command FixtureClickCommand
        {
            get;
            set;
        }

        private async void ExecuteFixtureClickCommand()
        {
            Template template = new Template();
            template.Name = "Fixture";
            template.PageName = "Views.Fixtures.FixturePage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
        }

        #endregion
    }
}
