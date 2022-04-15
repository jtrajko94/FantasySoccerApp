using FantasySoccerApp.ViewModels.Teams;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Teams
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonFixturesView
    {
        private SeasonFixturesViewModel ViewModel
        {
            get { return (SeasonFixturesViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public SeasonFixturesView()
        {
            InitializeComponent();

            ViewModel = new SeasonFixturesViewModel();
            BindingContext = ViewModel;
        }
    }
}
