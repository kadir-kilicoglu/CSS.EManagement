using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.OperationCenters;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class OperationCenterRepository : Repository<OperationCenter, int>, IOperationCenterRepository
    {
        public OperationCenterRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
