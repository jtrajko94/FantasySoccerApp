using FantasySoccerApp.ViewModels.Fixtures;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace FantasySoccerApp.Views.Fixtures
{
    public partial class EventsTimelineView
    {
        public EventsTimelineView()
        {
            InitializeComponent();
            BindingContext = new EventTimelineViewModel().Events;
        }

        private async void timelineListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PlayerPerformancePopupPage());
        }
    }
}
