using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.OperationCenters 
{
    
    public class OperationCenterStatus : EntityBase<int>, IAggregateRoot 
    {
        public OperationCenterStatus() 
        {
			OperationCenters = new List<OperationCenter>();
        }

        public virtual IList<OperationCenter> OperationCenters { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IOperationCenterStatusRepository : IRepository<OperationCenterStatus, int>
    {
    }
}
