using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.OperationCenters;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class OperationCenterTyperRepository : Repository<OperationCenterType, int>, IOperationCenterTypeRepository
    {
        public OperationCenterTyperRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}