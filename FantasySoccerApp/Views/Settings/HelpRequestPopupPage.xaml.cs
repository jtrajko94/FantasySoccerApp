using FantasySoccerApp.ViewModels.Settings;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRequestPopupPage
    {
        private HelpRequestViewModel ViewModel
        {
            get { return (HelpRequestViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public HelpRequestPopupPage()
        {
            InitializeComponent();

            ViewModel = new HelpRequestViewModel();
            BindingContext = ViewModel;
        }
    }
}
