using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Calendars;
using CSS.OpusForce.Model.Contractors;

namespace CSS.OpusForce.Model.ScoreCards 
{
    
    public class ScoreCardCount : IAggregateRoot 
    {
        public ScoreCardCount() 
        { 
        }

        private ScoreCardCountIdentifier _scoreCardCountIdentifier = new ScoreCardCountIdentifier();
        public virtual ScoreCardCountIdentifier ScoreCardCountIdentifier
        {
            get { return _scoreCardCountIdentifier; }
            set { _scoreCardCountIdentifier = value; }
        }

        private Contractor _contractor;
        public virtual Contractor Contractor
        {
            get { return _contractor; }
            set
            {
                _contractor = value;
                _scoreCardCountIdentifier.ContractorId = _contractor.Id;
            }
        }

        private CalendarDay _calendarDay;
        public virtual CalendarDay CalendarDay
        {
            get { return _calendarDay; }
            set
            {
                _calendarDay = value;
                _scoreCardCountIdentifier.CalendarDayId = _calendarDay.Id;
            }
        }

        public virtual int Count { get; set; }
    }

    public interface IScoreCardCountRepository : IRepository<ScoreCardCount, ScoreCardCountIdentifier>
    {
    }
}
