using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using FantasySoccerApp.ViewModels.Leagues;

namespace FantasySoccerApp.Views.Leagues
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsView
    {
        private ResultsViewModel ViewModel
        {
            get { return (ResultsViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public ResultsView()
        {
            InitializeComponent();
            ViewModel = new ResultsViewModel();
            BindingContext = ViewModel;
        }
    }
}