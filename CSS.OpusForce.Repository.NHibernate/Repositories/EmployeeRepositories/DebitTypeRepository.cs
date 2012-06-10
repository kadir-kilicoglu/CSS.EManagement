using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class DebitTypeRepository : Repository<DebitType, int>, IDebitTypeRepository
    {
        public DebitTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
