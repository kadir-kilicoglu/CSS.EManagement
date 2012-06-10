using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Calendars 
{
    
    public class CalendarMonth : EntityBase<int>, IAggregateRoot 
    {
        public CalendarMonth() 
        {
			CalendarDays = new List<CalendarDay>();
        }
        
        public virtual Calendar Calendar { get; set; }
        public virtual IList<CalendarDay> CalendarDays { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual System.DateTime StartDate { get; set; }
        public virtual System.DateTime EndDate { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICalendarMonthRepository : IRepository<CalendarMonth, int>
    {
    }
}
