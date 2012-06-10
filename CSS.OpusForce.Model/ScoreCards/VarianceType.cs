using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.ScoreCards 
{
    
    public class VarianceType : EntityBase<int>, IAggregateRoot 
    {
        public VarianceType() 
        {
			ScoreCardVariances = new List<ScoreCardVariance>();
        }
        
        public virtual IList<ScoreCardVariance> ScoreCardVariances { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IVarianceTypeRepository : IRepository<VarianceType, int>
    {
    }
}
