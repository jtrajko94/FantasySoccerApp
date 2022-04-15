using System;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using FantasySoccerApp.Views.AccountAccess;
using FantasySoccerApp.Views.Settings;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.Settings
{
    /// <summary>
    /// ViewModel for Setting page 
    /// </summary> 
    [Preserve(AllMembers = true)]
    public class SettingViewModel : BaseViewModel
    {
        public string HeaderText { get; set; } = "Settings";

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingViewModel" /> class
        /// </summary>
        public SettingViewModel()
        {
            this.BackButtonCommand = new Command(this.BackButtonClicked);
            this.BalanceCommand = new Command(this.BalanceClicked);
            this.ChangePasswordCommand = new Command(this.ChangePasswordClicked);
            this.HelpCommand = new Command(this.HelpClicked);
            this.TermsCommand = new Command(this.TermsServiceClicked);
            this.PolicyCommand = new Command(this.PrivacyPolicyClicked);
            this.ReviewCommand = new Command(this.ReviewClicked);
            this.LogOutCommand = new Command(this.LogOutClicked);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command is executed when the favourite button is clicked.
        /// </summary>
        public Command BackButtonCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the balance option is clicked.
        /// </summary>
        public Command BalanceCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the change password option is clicked.
        /// </summary>
        public Command ChangePasswordCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the help option is clicked.
        /// </summary>
        public Command HelpCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the terms of service option is clicked.
        /// </summary>
        public Command TermsCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the privacy policy option is clicked.
        /// </summary>
        public Command PolicyCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the Review option is clicked.
        /// </summary>
        public Command ReviewCommand { get; set; }

        /// <summary>
        /// Gets or sets the command is executed when the Logout Button is clicked.
        /// </summary>
        public Command LogOutCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the back button clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void BackButtonClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the edit profile option clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private async void BalanceClicked(object obj)
        {
            Template template = new Template();
            template.Name = "Account Balance";
            template.PageName = "Views.Settings.BalancePage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
        }

        /// <summary>
        /// Invoked when the change password clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private void ChangePasswordClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the terms of service clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private async void TermsServiceClicked(object obj)
        {
            await PopupNavigation.Instance.PushAsync(new TermsConditionsPopupPage());
        }

        /// <summary>
        /// Invoked when the privacy and policy clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private async void PrivacyPolicyClicked(object obj)
        {
            await PopupNavigation.Instance.PushAsync(new PrivacyPolicyPopupPage());
        }

        /// <summary>
        /// Invoked when the Review button is clicked
        /// </summary>
        /// <param name="obj">The object</param>
        /// 

        private void ReviewClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the help option is clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private async void HelpClicked(object obj)
        {
            await PopupNavigation.Instance.PushAsync(new HelpRequestPopupPage());
        }

        /// <summary>
        /// Invoked when the log out button is clicked
        /// </summary>
        /// <param name="obj">The object</param>
        private async void LogOutClicked(object obj)
        {
            Utilities.Settings.CurrentUserAccessToken = "";
            Utilities.Settings.CurrentUserEmail = "";
            Utilities.Settings.CurrentUserPassword = "";
            Utilities.Settings.CurrentUserAccessTokenExpiration = DateTime.UtcNow;
            await Application.Current.MainPage.Navigation.PushAsync(new TabbedLoginForm());
        }

        #endregion
    }
}
