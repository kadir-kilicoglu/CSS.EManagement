using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Employees 
{
    
    public class DebitType : EntityBase<int>, IAggregateRoot 
    {
        public DebitType() 
        {
			EmployeeDebits = new List<EmployeeDebit>();
        }
        
        public virtual IList<EmployeeDebit> EmployeeDebits { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IDebitTypeRepository : IRepository<DebitType, int>
    {
    }
}
