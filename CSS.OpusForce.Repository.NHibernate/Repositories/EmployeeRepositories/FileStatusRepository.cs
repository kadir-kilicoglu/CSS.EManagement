using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class FileStatusRepository : Repository<FileStatus, int>, IFileStatusRepository
    {
        public FileStatusRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}

