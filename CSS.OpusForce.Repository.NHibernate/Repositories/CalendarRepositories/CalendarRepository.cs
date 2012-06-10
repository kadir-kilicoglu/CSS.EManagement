using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Calendars;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class CalendarRepository : Repository<Calendar, int>, ICalendarRepository
    {
        public CalendarRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
