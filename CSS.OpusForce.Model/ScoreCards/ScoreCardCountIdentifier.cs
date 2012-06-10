using System;
using System.Collections.Generic;

namespace CSS.OpusForce.Model.ScoreCards
{
    [Serializable]
    public class ScoreCardCountIdentifier
    {
        public virtual int ContractorId { get; set; }
        public virtual int CalendarDayId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as ScoreCardCountIdentifier;
            if (t == null)
                return false;
            if (ContractorId == t.ContractorId && CalendarDayId == t.CalendarDayId)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (ContractorId + "|" + CalendarDayId).GetHashCode();
        }
    }
}
