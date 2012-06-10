using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}


