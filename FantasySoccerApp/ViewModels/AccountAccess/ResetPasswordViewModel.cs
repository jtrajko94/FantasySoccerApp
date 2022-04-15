using FantasySoccerApp.Views.AccountAccess;
using FantasySoccerApp.Views.Navigation;
using FantasySoccerApp.Views.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.AccountAccess
{
    /// <summary>
    /// ViewModel for reset password page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ResetPasswordViewModel : BaseViewModel
    {
        #region Constructor

        public ResetPasswordViewModel()
        {
            this.SubmitCommand = new Command(this.SubmitClicked);
            this.SignUpCommand = new Command(this.SignUpClicked);
        }

        #endregion

        #region Command

        public Command SubmitCommand { get; set; }

        public Command SignUpCommand { get; set; }

        #endregion

        #region Public property

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        #endregion

        #region Methods

        private async void SubmitClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new BottomNavigationPage());
        }

        private async void SignUpClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TabbedLoginForm());
        }

        #endregion
    }
}
