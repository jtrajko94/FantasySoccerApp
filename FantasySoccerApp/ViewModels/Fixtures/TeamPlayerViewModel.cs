using System;
using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Fixtures;
using FantasySoccerApp.Views.Fixtures;
using Xamarin.Forms;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    public class FixturesViewModel
    {
        private FixtureListItem _fixture;
        public FixturesViewModel(FixtureListItem fixture)
        {
            _fixture = fixture;
        }


        public string HomeTeamName
        {
            get
            {
                return _fixture.HomeTeamName;
            }
        }

        public string AwayTeamName
        {
            get
            {
                return _fixture.AwayTeamName;
            }
        }

        public DateTime? DateTime
        {
            get
            {
                return _fixture.DateTime;
            }
        }

        public string FixtureID
        {
            get
            {
                return _fixture.FixtureID;
            }
        }

        public FixtureListItem FixtureListItem
        {
            get => _fixture;
        }
    }
}
