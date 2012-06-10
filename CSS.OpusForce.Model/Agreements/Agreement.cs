using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Companies;
using CSS.OpusForce.Model.Employees;
using CSS.OpusForce.Model.Contractors;
using CSS.OpusForce.Model.OperationCenters;

namespace CSS.OpusForce.Model.Agreements 
{
    
    public class Agreement : EntityBase<int>, IAggregateRoot 
    {
        public Agreement() 
        {
			Employees = new List<Employee>();
        }

        public virtual AgreementType AgreementType { get; set; }
        public virtual AgreementStatus AgreementStatus { get; set; }
        public virtual OperationCenter OperationCenter { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Contractor Contractor { get; set; }
        public virtual IList<Employee> Employees { get; set; }
        public virtual string AgreementNumber { get; set; }
        public virtual string Name { get; set; }
        public virtual System.DateTime SignDate { get; set; }
        public virtual System.DateTime StartDate { get; set; }
        public virtual System.Nullable<System.DateTime> EndDate { get; set; }
        public virtual string Description { get; set; }
        public virtual string ContractFile { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IAgreementRepository : IRepository<Agreement, int>
    {
    }
}
