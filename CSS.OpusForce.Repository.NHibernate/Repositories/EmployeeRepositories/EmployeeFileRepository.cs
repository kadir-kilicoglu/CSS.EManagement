using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class EmployeeFileRepository : Repository<EmployeeFile, int>, IEmployeeFileRepository
    {
        public EmployeeFileRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}


