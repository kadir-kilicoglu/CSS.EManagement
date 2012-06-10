using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Calendars;
using CSS.OpusForce.Model.Financials;

namespace CSS.OpusForce.Model.Employees 
{
    
    public class AssignedDuty : EntityBase<int>, IAggregateRoot 
    {
        public AssignedDuty() 
        {
			Employees = new List<Employee>();
        }

        public virtual Currency Currency { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual PaymentPeriod PaymentPeriod { get; set; }
        public virtual Calendar Calendar { get; set; }
        public virtual IList<Employee> Employees { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IAssignedDutyRepository : IRepository<AssignedDuty, int>
    {
    }
}
