using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Calendars 
{
    
    public class CalendarDayType : EntityBase<int>, IAggregateRoot 
    {
        public CalendarDayType() 
        {
			CalendarDays = new List<CalendarDay>();
        }
        
        public virtual IList<CalendarDay> CalendarDays { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICalendarDayTypeRepository : IRepository<CalendarDayType, int>
    {
    }
}
