using System;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using Xamarin.Forms;

namespace FantasySoccerApp.Views.Home
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            Template template = new Template();
            template.Name = "Search";
            template.PageName = "Views.Home.SearchPage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
        }
    }
}
