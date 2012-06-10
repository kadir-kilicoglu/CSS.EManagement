using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.ScoreCards 
{
    
    public class ScoreCardVariance : EntityBase<int>, IAggregateRoot 
    {
        public ScoreCardVariance() 
        { 
        }

        public virtual ScoreCard ScoreCard { get; set; }
        public virtual VarianceType VarianceType { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal VarianceAmount { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IScoreCardVarianceRepository : IRepository<ScoreCardVariance, int>
    {
    }
}
