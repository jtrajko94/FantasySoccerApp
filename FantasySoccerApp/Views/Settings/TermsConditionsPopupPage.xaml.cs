using FantasySoccerApp.ViewModels.Settings;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermsConditionsPopupPage
    {
        private TermsConditionsViewModel ViewModel
        {
            get { return (TermsConditionsViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public TermsConditionsPopupPage()
        {
            InitializeComponent();

            ViewModel = new TermsConditionsViewModel();
            BindingContext = ViewModel;
        }
    }
}
