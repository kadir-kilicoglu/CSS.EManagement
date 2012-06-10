using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class DebitStatusRepository : Repository<DebitStatus, int>, IDebitStatusRepository
    {
        public DebitStatusRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
