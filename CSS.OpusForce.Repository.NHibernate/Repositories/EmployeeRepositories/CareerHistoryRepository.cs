using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class CareerHistoryRepository : Repository<CareerHistory, int>, ICareerHistoryRepository
    {
        public CareerHistoryRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
