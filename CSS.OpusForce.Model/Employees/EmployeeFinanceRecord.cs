using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Financials;

namespace CSS.OpusForce.Model.Employees 
{
    
    public class EmployeeFinanceRecord : EntityBase<int>, IAggregateRoot 
    {
        public EmployeeFinanceRecord() 
        { 
        }
        
        public virtual EmployeeDebit EmployeeDebit { get; set; }
        public virtual FinancialActivityType FinancialActivityType { get; set; }
        public virtual System.DateTime RecordDate { get; set; }
        public virtual string Description { get; set; }
        public virtual string FileName { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IEmployeeFinanceRecordRepository : IRepository<EmployeeFinanceRecord, int>
    {
    }
}
