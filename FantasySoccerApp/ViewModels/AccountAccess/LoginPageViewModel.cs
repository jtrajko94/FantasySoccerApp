using System.Threading.Tasks;
using FantasySoccerApp.Models.API.Accounts;
using FantasySoccerApp.Services;
using FantasySoccerApp.Views.AccountAccess;
using FantasySoccerApp.Views.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.AccountAccess
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginPageViewModel
    {
        APIAccountService _apiAccountService = new APIAccountService();

        #region property

        public string Email { get; set; }

        public string Password { get; set; }

        #endregion

        #region Constructor

        public LoginPageViewModel()
        {
            this.LoginCommand = new Command(this.LoginClickedAsync);
            this.ForgotPasswordCommand = new Command(this.ForgotPasswordClicked);
            this.SocialMediaLoginCommand = new Command(this.SocialLoggedIn);
        }

        #endregion

        #region Command

        public Command LoginCommand { get; set; }

        public Command ForgotPasswordCommand { get; set; }

        public Command SocialMediaLoginCommand { get; set; }

        #endregion

        #region methods

        private async void LoginClickedAsync(object obj)
        {
            var token = _apiAccountService.Login(new UserModel
            {
                Email = Email,
                Password = Password
            });

            if(token == null)
            {
                await App.Current.MainPage.DisplayAlert("We're Sorry", "An error has occurred. Please try again.", "Ok");
            }
            else if (token.validation.IsValid == false)
            {
                await App.Current.MainPage.DisplayAlert("Please Address the Following", string.Join("\n",token.validation.Issues.Values), "Ok");
            }
            else
            {
                Utilities.Settings.CurrentUserAccessToken = token.access_token;
                Utilities.Settings.CurrentUserEmail = Email;
                Utilities.Settings.CurrentUserPassword = Password;
                Utilities.Settings.CurrentUserAccessTokenExpiration = token.expires.Value;
                await Application.Current.MainPage.Navigation.PushAsync(new BottomNavigationPage());
            }
        }

        private async void ForgotPasswordClicked(object obj)
        {
            var label = obj as Label;
            label.BackgroundColor = Color.FromHex("#70FFFFFF");
            await Task.Delay(100);
            label.BackgroundColor = Color.Transparent;

            await Application.Current.MainPage.Navigation.PushAsync(new ForgotPassword());
        }

        private async void SocialLoggedIn(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BottomNavigationPage());
        }

        #endregion
    }
}

