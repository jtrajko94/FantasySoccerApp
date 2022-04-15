using FantasySoccerApp.ViewModels.Teams;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Teams
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonPlayersView
    {
        private SeasonPlayersViewModel ViewModel
        {
            get { return (SeasonPlayersViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public SeasonPlayersView()
        {
            InitializeComponent();

            ViewModel = new SeasonPlayersViewModel();
            BindingContext = ViewModel;
        }
    }
}
