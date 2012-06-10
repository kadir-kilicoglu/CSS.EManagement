using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Projects;
using CSS.OpusForce.Model.Companies;
using CSS.OpusForce.Model.Agreements;

namespace CSS.OpusForce.Model.OperationCenters 
{
    
    public class OperationCenter : EntityBase<int>, IAggregateRoot 
    {
        public OperationCenter() 
        {
			Agreements = new List<Agreement>();
        }

        public virtual Project Project { get; set; }
        public virtual Company ResponsibleCompany { get; set; }
        public virtual OperationCenterType OperationCenterType { get; set; }
        public virtual OperationCenterStatus OperationCenterStatus { get; set; }
        public virtual IList<Agreement> Agreements { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IOperationCenterRepository : IRepository<OperationCenter, int>
    {
    }
}
