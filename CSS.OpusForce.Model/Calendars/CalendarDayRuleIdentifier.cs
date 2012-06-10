using System;
using System.Collections.Generic;

namespace CSS.OpusForce.Model.Calendars
{
    [Serializable]
    public class CalendarDayRuleIdentifier
    {
        public virtual int CalendarDayId { get; set; }
        public virtual int RuleId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as CalendarDayRuleIdentifier;
            if (t == null)
                return false;
            if (CalendarDayId == t.CalendarDayId && RuleId == t.RuleId)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (CalendarDayId + "|" + RuleId).GetHashCode();
        }
    }
}
