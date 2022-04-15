using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FantasySoccerApp.Models.Fixtures;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    public class EventTimelineViewModel
    {
        public IList<EventTimelineItem> Events { get; set; }

        public EventTimelineViewModel()
        {
            Events = new ObservableCollection<EventTimelineItem>
            {
                new EventTimelineItem("Luka Modric", 9, "Tackle", "icon"),
                new EventTimelineItem("Vinicius Junior", 33, "Substitution (Eden Hazard OUT)", "icon"),
                new EventTimelineItem("Luka Modric", 37, "Goal (1-0)", "icon"),
                new EventTimelineItem("Karim Benzema", 39, "Goal (2-0)", "icon"),
                new EventTimelineItem("Luka Modric", 42, "Yellow Card", "icon"),
                new EventTimelineItem("Half Time (1-0)", 45, "", "icon", false),
                new EventTimelineItem("Lionel Messi", 52, "Goal (2-1)", "icon"),
                new EventTimelineItem("Karim Benzema", 58, "Goal (3-1)", "icon"),
                new EventTimelineItem("Luka Modric", 67, "Yellow Card (sent off)", "icon"),
                new EventTimelineItem("Sergio Busquets", 82, "Red Card", "icon"),
                new EventTimelineItem("Martin Braithwaite", 85, "Substitution (Luis Suarez OUT)", "icon"),
                new EventTimelineItem("Final Time (3-1)", 90, "", "icon", false)
            };
        }
    }
}
