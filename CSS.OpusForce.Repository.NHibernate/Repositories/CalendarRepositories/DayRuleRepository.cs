using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Calendars;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class DayRuleRepository : Repository<DayRule, int>, IDayRuleRepository
    {
        public DayRuleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
