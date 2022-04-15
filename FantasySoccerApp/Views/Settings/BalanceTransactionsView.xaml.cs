using FantasySoccerApp.ViewModels.Settings;
using Xamarin.Forms;

namespace FantasySoccerApp.Views.Settings
{
    public partial class BalanceTransactionsView
    {
        public BalanceTransactionsView()
        {
            InitializeComponent();
            BindingContext = new BalanceTransactionsViewModel().Events;
        }

        private void timelineListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Not sure if needed
        }
    }
}
