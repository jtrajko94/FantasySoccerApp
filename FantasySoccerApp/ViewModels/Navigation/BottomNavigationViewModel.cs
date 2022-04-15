using FantasySoccerApp.ViewModels.Fixtures;

namespace FantasySoccerApp.ViewModels.Navigation
{
    public class BottomNavigationViewModel
    {
        public CountriesGroupViewModel CountriesGroupViewModel { get; set; }

        public BottomNavigationViewModel()
        {
            CountriesGroupViewModel = new CountriesGroupViewModel();
        }
    }
}
