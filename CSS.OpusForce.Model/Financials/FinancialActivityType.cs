using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Model.Financials 
{
    
    public class FinancialActivityType : EntityBase<int>, IAggregateRoot 
    {
        public FinancialActivityType() 
        {
			EmployeeFinanceRecords = new List<EmployeeFinanceRecord>();
        }

        public virtual IList<EmployeeFinanceRecord> EmployeeFinanceRecords { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IFinancialActivityTypeRepository : IRepository<FinancialActivityType, int>
    {
    }
}
