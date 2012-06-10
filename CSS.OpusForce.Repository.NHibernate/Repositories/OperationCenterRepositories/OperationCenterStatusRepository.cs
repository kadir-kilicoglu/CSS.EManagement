using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.OperationCenters;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class OperationCenterStatusRepository : Repository<OperationCenterStatus, int>, IOperationCenterStatusRepository
    {
        public OperationCenterStatusRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
