using System.Collections.ObjectModel;
using System.ComponentModel;
using FantasySoccerApp.Models.Fixtures;
using MvvmHelpers;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    public class CountriesViewModel : ObservableRangeCollection<FixturesViewModel>, INotifyPropertyChanged
    {
        private ObservableCollection<FixturesViewModel> fixtures = new ObservableRangeCollection<FixturesViewModel>();
        public CountriesViewModel(CountryFixtureListItem country, bool expanded = false)
        {
            Country = country;
            _expanded = expanded;
            foreach (FixtureListItem fixture in country.Fixtures)
            {
                fixtures.Add(new FixturesViewModel(fixture));
            }
            if (expanded) AddRange(fixtures);
        }
        public CountriesViewModel() { }
        private bool _expanded;
        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Expanded"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StateIcon"));
                    if (_expanded)
                    {
                        AddRange(fixtures);
                    }
                    else
                    {
                        Clear();
                    }
                }
            }
        }
        public string StateIcon
        {
            get
            {
                if (Expanded)
                {
                    return "arrow_a.png";
                }
                else
                {
                    return "arrow_b.png";
                }
            }
        }
        public string Name
        {
            get
            {
                return Country.Name;
            }
        }
        public CountryFixtureListItem Country
        {
            get;
            set;
        }

        public string Image
        {
            get
            {
                return Country.Image;
            }
        }

        public int FixtureCount
        {
            get
            {
                return Country.FixtureCount;
            }
        }
    }
}
