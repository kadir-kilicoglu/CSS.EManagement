using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Financials;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class PaymentTypeRepository : Repository<PaymentType, int>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}