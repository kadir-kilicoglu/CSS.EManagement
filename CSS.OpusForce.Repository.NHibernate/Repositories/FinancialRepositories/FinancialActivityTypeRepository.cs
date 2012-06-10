using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Financials;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class FinancialActivityTypeRepository : Repository<FinancialActivityType, int>, IFinancialActivityTypeRepository
    {
        public FinancialActivityTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}