using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface ICalendarServices
    {
        CreateCalendarResponse CreateCalendar(CreateCalendarRequest request);
        ReadCalendarResponse ReadCalendar(ReadCalendarRequest request);
        UpdateCalendarResponse UpdateCalendar(UpdateCalendarRequest request);
        DeleteCalendarResponse DeleteCalendar(DeleteCalendarRequest request);
        ListCalendarsResponse ListCalendars(ListCalendarsRequest request);

        CreateCalendarDayTypeResponse CreateCalendarDayType(CreateCalendarDayTypeRequest request);
        ReadCalendarDayTypeResponse ReadCalendarDayType(ReadCalendarDayTypeRequest request);
        UpdateCalendarDayTypeResponse UpdateCalendarDayType(UpdateCalendarDayTypeRequest request);
        DeleteCalendarDayTypeResponse DeleteCalendarDayType(DeleteCalendarDayTypeRequest request);
        ListCalendarDayTypesResponse ListCalendarDayTypes(ListCalendarDayTypesRequest request);
    }
}
