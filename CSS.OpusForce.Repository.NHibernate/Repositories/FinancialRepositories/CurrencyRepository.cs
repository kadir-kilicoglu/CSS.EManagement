using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Financials;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class CurrencyRepository : Repository<Currency, int>, ICurrencyRepository
    {
        public CurrencyRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}