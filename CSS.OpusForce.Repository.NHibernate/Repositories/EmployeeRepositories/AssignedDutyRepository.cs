using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class AssignedDutyRepository : Repository<AssignedDuty, int>, IAssignedDutyRepository
    {
        public AssignedDutyRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
