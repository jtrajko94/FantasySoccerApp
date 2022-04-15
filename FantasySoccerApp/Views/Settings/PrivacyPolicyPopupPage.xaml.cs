using FantasySoccerApp.ViewModels.Settings;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrivacyPolicyPopupPage
    {
        private PrivacyPolicyViewModel ViewModel
        {
            get { return (PrivacyPolicyViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public PrivacyPolicyPopupPage()
        {
            InitializeComponent();

            ViewModel = new PrivacyPolicyViewModel();
            BindingContext = ViewModel;
        }
    }
}
