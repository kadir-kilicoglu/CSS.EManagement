using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Model.Calendars 
{
    
    public class Calendar : EntityBase<int>, IAggregateRoot 
    {
        public Calendar() 
        {
			AssignedDuties = new List<AssignedDuty>();
			CalendarMonths = new List<CalendarMonth>();
        }
        
        public virtual IList<AssignedDuty> AssignedDuties { get; set; }
        public virtual IList<CalendarMonth> CalendarMonths { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICalendarRepository : IRepository<Calendar, int>
    {
    }
}
