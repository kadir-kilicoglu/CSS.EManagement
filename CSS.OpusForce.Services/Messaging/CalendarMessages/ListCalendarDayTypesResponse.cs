using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListCalendarDayTypesResponse : ResponseBase
    {
        public IEnumerable<CalendarDayTypeSummaryView> CalendarDayTypes { get; set; }
    }
}
