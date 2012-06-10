using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Projects;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class ProjectRepository : Repository<Project, int>, IProjectRepository
    {
        public ProjectRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
