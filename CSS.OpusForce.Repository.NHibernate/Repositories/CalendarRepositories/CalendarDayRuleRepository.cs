using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Calendars;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class CalendarDayRuleRepository : Repository<CalendarDayRule, CalendarDayRuleIdentifier>, ICalendarDayRuleRepository
    {
        public CalendarDayRuleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
