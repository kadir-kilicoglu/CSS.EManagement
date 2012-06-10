using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Projects;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class ProjectTypeRepository : Repository<ProjectType, int>, IProjectTypeRepository
    {
        public ProjectTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}