using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Fixtures;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    public class OddsViewModel
    {
        public ObservableCollection<OddsListItem> OddsEntries { get; set; }

        public OddsViewModel()
        {
            this.OddsEntries = new ObservableCollection<OddsListItem>()
            {
                new OddsListItem("Bet365", "image", 1.2, 1.2, 0.8),
                new OddsListItem("Bet Online", "image", 1.2, 0.9, 0.6),
                new OddsListItem("Super Bets", "image", 1.4, 1.5, 0.7),
                new OddsListItem("Random Bets", "image", 1.2, 1.2, 0.1),
                new OddsListItem("Wrong Bets", "image", 3.1, 1.1, 1.8)
            };
        }
    }
}
