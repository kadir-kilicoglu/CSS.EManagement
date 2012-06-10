using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Calendars 
{
    
    public class DayRule : EntityBase<int>, IAggregateRoot 
    {
        public DayRule() 
        {
			CalendarDayRules = new List<CalendarDayRule>();
        }
        
        public virtual IList<CalendarDayRule> CalendarDayRules { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual int StartHour { get; set; }
        public virtual System.Nullable<int> EndHour { get; set; }
        public virtual double Coefficient { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IDayRuleRepository : IRepository<DayRule, int>
    {
    }
}
