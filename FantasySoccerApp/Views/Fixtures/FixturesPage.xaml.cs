using System;
using System.Collections.Generic;
using System.Diagnostics;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using FantasySoccerApp.Models.Fixtures;
using FantasySoccerApp.ViewModels.Fixtures;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;

namespace FantasySoccerApp.Views.Fixtures
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FixturesPage : ContentPage
    {
        private CountriesGroupViewModel ViewModel
        {
            get { return (CountriesGroupViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        private List<CountryFixtureListItem> ListCountries = new List<CountryFixtureListItem>();

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                if (ViewModel.Items.Count == 0)
                {
                    ViewModel.LoadCountriesCommand.Execute(null);
                }
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
        }

        //Custom Initialization
        public FixturesPage(CountriesGroupViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = new CountriesGroupViewModel();
            this.ViewModel = viewModel;
        }

        //Default Initialization
        public FixturesPage()
        {
            InitializeComponent();
            BindingContext = new CountriesGroupViewModel();
            this.ViewModel = new CountriesGroupViewModel();
        }

        /// <summary>
        /// Invoked when search button is clicked.
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">Event Args</param>
        private async void CalendarButton_Clicked(object sender, EventArgs e)
        {
            Template template = new Template();
            template.Name = "Choose a Fixture Date";
            template.PageName = "Views.Fixtures.CalendarPage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
        }
    }
}
