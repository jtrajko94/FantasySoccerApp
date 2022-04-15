using FantasySoccerApp.ViewModels.Individuals;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Individuals
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutView
    {
        private AboutViewModel ViewModel
        {
            get { return (AboutViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public AboutView()
        {
            InitializeComponent();

            ViewModel = new AboutViewModel();
            BindingContext = ViewModel;
        }
    }
}
