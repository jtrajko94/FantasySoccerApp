using System.Collections.Generic;

namespace FantasySoccerApp.Models.Fixtures
{
    public class CountryFixtureListItem
    {
        public string Name { get; set; }

        public List<FixtureListItem> Fixtures { get; set; }

        public bool IsVisible { get; set; } = false;

        public string Image { get; set; }

        public int FixtureCount { get; set; }

        public CountryFixtureListItem() { }
        public CountryFixtureListItem(string name, List<FixtureListItem> fixtures, string image)
        {
            Name = name;
            Fixtures = fixtures;
            Image = image;
            FixtureCount = fixtures.Count;
        }
    }
}
