using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.Settings
{
    [Preserve(AllMembers = true)]
    public class HelpRequestViewModel : BaseViewModel
    {
        #region Fields

        public string Email { get; set; }
        public string Message { get; set; }

        #endregion

        #region Constructor

        public HelpRequestViewModel()
        {
            Email = "loggedinuser@gmail.com";
            CloseClickCommand = new Command(() => ExecuteCloseClickCommand());
            SubmitClickCommand = new Command(() => ExecuteSubmitClickCommand()); 
        }

        #endregion

        #region Commands

        public Command CloseClickCommand { get; set; }
        public Command SubmitClickCommand { get; set; }

        private async void ExecuteSubmitClickCommand()
        {
            //show notification that request has been submitted
            await PopupNavigation.Instance.PopAsync();
        }

        private async void ExecuteCloseClickCommand()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        #endregion
    }
}
