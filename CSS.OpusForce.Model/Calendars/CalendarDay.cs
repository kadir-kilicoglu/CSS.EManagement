using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.ScoreCards;

namespace CSS.OpusForce.Model.Calendars 
{
    
    public class CalendarDay : EntityBase<int>, IAggregateRoot 
    {
        public CalendarDay() 
        {
			CalendarDayRules = new List<CalendarDayRule>();
			ScoreCards = new List<ScoreCard>();
			ScoreCardCounts = new List<ScoreCardCount>();
        }
        
        public virtual CalendarMonth CalendarMonth { get; set; }
        public virtual CalendarDayType CalendarDayType { get; set; }
        public virtual IList<CalendarDayRule> CalendarDayRules { get; set; }
        public virtual IList<ScoreCard> ScoreCards { get; set; }
        public virtual IList<ScoreCardCount> ScoreCardCounts { get; set; }
        public virtual System.DateTime DayDate { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string StartTime { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICalendarDayRepository : IRepository<CalendarDay, int>
    {
    }
}
