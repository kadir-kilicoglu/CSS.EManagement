using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class EmployeeDebitRepository : Repository<EmployeeDebit, int>, IEmployeeDebitRepository
    {
        public EmployeeDebitRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}


