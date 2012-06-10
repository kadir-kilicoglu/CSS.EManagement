using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ReadCalendarResponse : ResponseBase
    {
        public CalendarView Calendar { get; set; }
    }
}
