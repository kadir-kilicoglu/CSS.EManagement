using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Calendars;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class CalendarMonthRepository : Repository<CalendarMonth, int>, ICalendarMonthRepository
    {
        public CalendarMonthRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
