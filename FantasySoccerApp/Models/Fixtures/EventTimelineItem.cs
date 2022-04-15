using Xamarin.Forms.Internals;

namespace FantasySoccerApp.Models.Fixtures
{
    [Preserve(AllMembers = true)]
    public class EventTimelineItem
    {
        public string PlayerName { get; set; }

        public int Minute { get; set; }

        public string EventType { get; set; }

        public bool MatchEvent { get; set; } = false;

        public string Icon { get; set; }

        public EventTimelineItem() { }
        public EventTimelineItem(string playerName, int minute, string eventType, string icon, bool matchEvent = true)
        {
            PlayerName = playerName;
            Minute = minute;
            EventType = eventType;
            Icon = icon;
            MatchEvent = matchEvent;
        }
    }
}
