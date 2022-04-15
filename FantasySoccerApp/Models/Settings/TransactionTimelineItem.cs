using Xamarin.Forms.Internals;

namespace FantasySoccerApp.Models.Settings
{
    [Preserve(AllMembers = true)]
    public class TransactionTimelineItem
    {
        public string Color { get; set; }

        public string Amount { get; set; }

        public string Date { get; set; }

        public string AccountBalance { get; set; }

        public string Description { get; set; }

        public TransactionTimelineItem(string color, string amount, string date, string accountBalance, string description)
        {
            Color = color;
            Amount = amount;
            Date = date;
            AccountBalance = accountBalance;
            Description = description;
        }
    }
}
