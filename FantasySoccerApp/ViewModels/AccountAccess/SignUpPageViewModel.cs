using FantasySoccerApp.Models.API.Accounts;
using FantasySoccerApp.Services;
using FantasySoccerApp.Views.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.AccountAccess
{
    [Preserve(AllMembers = true)]
    public class SignUpPageViewModel
    {
        APIAccountService _apiAccountService = new APIAccountService();

        #region Fields

        public string Name { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        #endregion

        #region Constructor

        public SignUpPageViewModel()
        {
            this.SignUpCommand = new Command(this.SignUpClickedAsync);
        }

        #endregion

        #region Command

        public Command SignUpCommand { get; set; }

        #endregion

        #region Methods

        private async void SignUpClickedAsync(object obj)
        {
            var token = _apiAccountService.Register(new UserModel {
                Email = Email,
                Name = Name,
                Password = Password,
                ReEnterPassword = ConfirmPassword,
                Username = UserName
            });

            if (token == null)
            {
                await App.Current.MainPage.DisplayAlert("We're Sorry", "An error has occurred. Please try again.", "Ok");
            }
            else if (token.validation.IsValid == false)
            {
                await App.Current.MainPage.DisplayAlert("Please Address the Following", string.Join("\n", token.validation.Issues.Values), "Ok");
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

        #endregion
    }
}

