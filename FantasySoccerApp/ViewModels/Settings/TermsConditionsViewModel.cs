using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.ViewModels.Settings
{
    [Preserve(AllMembers = true)]
    public class TermsConditionsViewModel
    {
        #region Constructor

        public TermsConditionsViewModel()
        {
            CloseClickCommand = new Command(() => ExecuteCloseClickCommand());
        }

        #endregion

        #region Commands

        public Command CloseClickCommand { get; set; }

        private async void ExecuteCloseClickCommand()
        {
            await PopupNavigation.Instance.PopAsync();
        }

        #endregion
    }
}
