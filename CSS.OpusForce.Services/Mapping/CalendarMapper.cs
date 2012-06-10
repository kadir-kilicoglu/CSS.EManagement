using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Calendars;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class CalendarMapper
    {
        public static IEnumerable<CalendarDayTypeSummaryView> ConvertToCalendarDayTypeSummaryView(this IEnumerable<CalendarDayType> calendarDayTypes)
        {
            List<CalendarDayTypeSummaryView> tempList = new List<CalendarDayTypeSummaryView>();

            foreach (CalendarDayType c in calendarDayTypes)
            {
                CalendarDayTypeSummaryView tempView = new CalendarDayTypeSummaryView();
                tempView.Id = c.Id;
                tempView.Name = c.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static CalendarDayTypeView ConvertToCalendarDayTypeView(this CalendarDayType calendarDayType)
        {
            CalendarDayTypeView tempView = new CalendarDayTypeView();
            tempView.Id = calendarDayType.Id;
            tempView.Name = calendarDayType.Name;
            tempView.Description = calendarDayType.Description;

            return tempView;
        }

        public static IEnumerable<CalendarSummaryView> ConvertToCalendarSummaryView(this IEnumerable<Calendar> calendars)
        {
            List<CalendarSummaryView> tempList = new List<CalendarSummaryView>();

            foreach (Calendar c in calendars)
            {
                CalendarSummaryView tempView = new CalendarSummaryView();
                tempView.Id = c.Id;
                tempView.Name = c.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static CalendarView ConvertToCalendarView(this Calendar calendar)
        {
            CalendarView tempView = new CalendarView();
            tempView.Id = calendar.Id;
            tempView.Name = calendar.Name;
            tempView.Description = calendar.Description;

            return tempView;
        }
    }
}
