using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListCalendarsResponse : ResponseBase
    {
        public IEnumerable<CalendarSummaryView> Calendars { get; set; }
    }
}
