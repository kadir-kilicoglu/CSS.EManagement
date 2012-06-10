using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Projects;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class ProjectStatusRepository : Repository<ProjectStatus, int>, IProjectStatusRepository
    {
        public ProjectStatusRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
