using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Agreements 
{
    
    public class AgreementStatus : EntityBase<int>, IAggregateRoot 
    {
        public AgreementStatus() 
        {
			Agreements = new List<Agreement>();
        }
        
        public virtual IList<Agreement> Agreements { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IAgreementStatusRepository : IRepository<AgreementStatus, int>
    {
    }
}
