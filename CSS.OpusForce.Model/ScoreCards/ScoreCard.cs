using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Employees;
using CSS.OpusForce.Model.Calendars;

namespace CSS.OpusForce.Model.ScoreCards 
{
    
    public class ScoreCard : EntityBase<int>, IAggregateRoot 
    {
        public ScoreCard() 
        {
			ScoreCardVariances = new List<ScoreCardVariance>();
        }

        public virtual Employee Employee { get; set; }
        public virtual CalendarDay CalendarDay { get; set; }
        public virtual IList<ScoreCardVariance> ScoreCardVariances { get; set; }
        public virtual System.Nullable<decimal> EarnedAmount { get; set; }
        public virtual bool IsTransferred { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IScoreCardRepository : IRepository<ScoreCard, int>
    {
    }
}
