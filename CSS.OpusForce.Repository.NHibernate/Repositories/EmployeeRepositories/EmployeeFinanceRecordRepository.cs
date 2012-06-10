using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class EmployeeFinanceRecordRepository : Repository<EmployeeFinanceRecord, int>, IEmployeeFinanceRecordRepository
    {
        public EmployeeFinanceRecordRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}


