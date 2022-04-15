using System.Collections.Generic;
using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Settings;

namespace FantasySoccerApp.ViewModels.Settings
{
    public class BalanceTransactionsViewModel
    {
        public IList<TransactionTimelineItem> Events { get; set; }

        public BalanceTransactionsViewModel()
        {
            Events = new ObservableCollection<TransactionTimelineItem>
            {
                new TransactionTimelineItem("Green","0.07","March 3, 2020", "5.07", "WIN: La Liga Copa Del Rey Draft"),
                new TransactionTimelineItem("Red", "10.00", "February 21, 2020", "5.00", "Withdrawal"),
                new TransactionTimelineItem("Green", "5.00", "January 1, 2020", "15.00", "WIN: La Liga Copa Del Rey Draft"),
                new TransactionTimelineItem("Green", "10.00", "December 31, 2020", "10.00", "Deposit")
            };
        }
    }
}
