using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Financials;

namespace CSS.OpusForce.Model.Employees {
    
    public class EmployeeDebit : EntityBase<int>, IAggregateRoot 
    {
        public EmployeeDebit() 
        {
			EmployeeFinanceRecords = new List<EmployeeFinanceRecord>();
        }

        public virtual Employee Employee { get; set; }
        public virtual DebitType DebitType { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual DebitStatus DebitStatus { get; set; }
        public virtual IList<EmployeeFinanceRecord> EmployeeFinanceRecords { get; set; }
        public virtual string Description { get; set; }
        public virtual System.DateTime TransactionDate { get; set; }
        public virtual System.Nullable<System.DateTime> DueDate { get; set; }
        public virtual decimal Amount { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IEmployeeDebitRepository : IRepository<EmployeeDebit, int>
    {
    }
}
