using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Financials;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class PaymentPeriodRepository : Repository<PaymentPeriod, int>, IPaymenPeriodRepository
    {
        public PaymentPeriodRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}