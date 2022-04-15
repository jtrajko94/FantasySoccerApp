using FantasySoccerApp.Views.AccountAccess;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.AccountAccess
{
    /// <summary>
    /// ViewModel for forgot password page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class ForgotPasswordViewModel
    {
        #region Constructor

        public ForgotPasswordViewModel()
        {
            this.SignUpCommand = new Command(this.SignUpClicked);
            this.SendCommand = new Command(this.SendClicked);
        }

        #endregion

        #region Property

        public string Email { get; set; }

        #endregion

        #region Command

        public Command SendCommand { get; set; }

        public Command SignUpCommand { get; set; }

        #endregion

        #region Methods

        private async void SendClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ResetPassword());
        }

        private async void SignUpClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TabbedLoginForm());
        }

        #endregion
    }
}
