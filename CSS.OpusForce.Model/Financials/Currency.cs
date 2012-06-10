using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Model.Financials 
{
    
    public class Currency : EntityBase<int>, IAggregateRoot 
    {
        public Currency() 
        {
			AssignedDuties = new List<AssignedDuty>();
			EmployeeDebits = new List<EmployeeDebit>();
        }

        public virtual IList<AssignedDuty> AssignedDuties { get; set; }
        public virtual IList<EmployeeDebit> EmployeeDebits { get; set; }
        public virtual string Name { get; set; }
        public virtual double ToBaseConversion { get; set; }
        public virtual double FromBaseConversion { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICurrencyRepository : IRepository<Currency, int>
    {
    }
}
