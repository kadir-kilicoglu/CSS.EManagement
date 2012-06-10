using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Calendars;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class CalendarDayRepository : Repository<CalendarDay, int>, ICalendarDayRepository
    {
        public CalendarDayRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
