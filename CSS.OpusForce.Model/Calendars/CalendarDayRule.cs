using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Calendars 
{
    
    public class CalendarDayRule : IAggregateRoot 
    {
        public CalendarDayRule() 
        { 
        }

        private CalendarDayRuleIdentifier _calendarDayRuleIdentifier = new CalendarDayRuleIdentifier();
        public virtual CalendarDayRuleIdentifier CalendarDayRuleIdentifier
        {
            get { return _calendarDayRuleIdentifier; }
            set { _calendarDayRuleIdentifier = value; }
        }

        private CalendarDay _calendarDay;
        public virtual CalendarDay CalendarDay
        {
            get { return _calendarDay; }
            set
            {
                _calendarDay = value;
                _calendarDayRuleIdentifier.CalendarDayId = _calendarDay.Id;
            }
        }

        private DayRule _dayRule;
        public virtual DayRule DayRule
        {
            get { return _dayRule; }
            set
            {
                _dayRule = value;
                _calendarDayRuleIdentifier.RuleId = _dayRule.Id;
            }
        }
    }

    public interface ICalendarDayRuleRepository : IRepository<CalendarDayRule, CalendarDayRuleIdentifier>
    {
    }
}
