using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Calendars;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class CalendarDayTypeRepository : Repository<CalendarDayType, int>, ICalendarDayTypeRepository
    {
        public CalendarDayTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
