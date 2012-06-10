using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Agreements 
{
    
    public class AgreementType : EntityBase<int>, IAggregateRoot 
    {
        public AgreementType() 
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

    public interface IAgreementTypeRepository : IRepository<AgreementType, int>
    {
    }
}
