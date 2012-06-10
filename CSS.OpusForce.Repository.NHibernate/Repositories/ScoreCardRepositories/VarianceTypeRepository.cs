using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.ScoreCards;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class VarianceTypeRepository : Repository<VarianceType, int>, IVarianceTypeRepository
    {
        public VarianceTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}