using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Contractors 
{
    
    public class ContractorStatus : EntityBase<int>, IAggregateRoot 
    {
        public ContractorStatus() 
        {
			Contractors = new List<Contractor>();
        }

        public virtual IList<Contractor> Contractors { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IContractorStatusRepository : IRepository<ContractorStatus, int>
    {
    }
}
