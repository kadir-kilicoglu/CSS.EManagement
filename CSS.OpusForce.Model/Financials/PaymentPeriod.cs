using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Model.Financials 
{
    
    public class PaymentPeriod : EntityBase<int>, IAggregateRoot 
    {
        public PaymentPeriod() 
        {
			AssignedDuties = new List<AssignedDuty>();
        }

        public virtual IList<AssignedDuty> AssignedDuties { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IPaymenPeriodRepository : IRepository<PaymentPeriod, int>
    {
    }
}
