using Xamarin.Essentials;
using Xamarin.Forms;
using FantasySoccerApp.Utilities;
using FantasySoccerApp.Views.Navigation;
using FantasySoccerApp.Views.AccountAccess;
using System;
using FantasySoccerApp.Services;
using FantasySoccerApp.Models.API.Accounts;

namespace FantasySoccerApp
{
    public partial class App : Application
    {
        APIAccountService _apiAccountService = new APIAccountService();

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjM5NjMyQDMxMzgyZTMxMmUzMEF1cFlnMUZJdXVNY0t5dmFkcGN3ZWFoUS9QRENZRzc2WE9KOUQveHJqVEE9");

            InitializeComponent();

            SetMainPage();
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.CurrentUserAccessToken))
            {
                if(DateTime.UtcNow.AddHours(1) > Settings.CurrentUserAccessTokenExpiration)
                {
                    var token = _apiAccountService.Login(new UserModel
                    {
                        Email = Settings.CurrentUserEmail,
                        Password = Settings.CurrentUserPassword
                    });
                    Settings.CurrentUserAccessToken = token.access_token;
                    Settings.CurrentUserAccessTokenExpiration = token.expires.Value;
                }
                MainPage = new NavigationPage(new BottomNavigationPage());
            }
            else
            {
                MainPage = new NavigationPage(new TabbedLoginForm());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
