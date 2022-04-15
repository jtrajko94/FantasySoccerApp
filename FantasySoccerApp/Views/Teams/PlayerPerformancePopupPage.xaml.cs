using FantasySoccerApp.ViewModels.Teams;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Teams
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPerformancePopupPage
    {
        private PlayerStatisticsViewModel ViewModel
        {
            get { return (PlayerStatisticsViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public PlayerPerformancePopupPage()
        {
            InitializeComponent();

            ViewModel = new PlayerStatisticsViewModel();
            BindingContext = ViewModel;
        }
    }
}
