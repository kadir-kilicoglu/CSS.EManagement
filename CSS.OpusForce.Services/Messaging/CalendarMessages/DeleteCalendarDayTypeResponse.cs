using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteCalendarDayTypeResponse : ResponseBase
    {
        public IEnumerable<CalendarDayTypeSummaryView> CalendarDayTypes { get; set; }
    }
}

