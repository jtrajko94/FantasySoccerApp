using FantasySoccerApp.ViewModels.Individuals;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Individuals
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeasonStatisticsView
    {
        private SeasonStatisticsViewModel ViewModel
        {
            get { return (SeasonStatisticsViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public SeasonStatisticsView()
        {
            InitializeComponent();

            ViewModel = new SeasonStatisticsViewModel();
            BindingContext = ViewModel;
        }
    }
}
