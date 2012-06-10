using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class SkillRepository : Repository<Skill, int>, ISkillRepository
    {
        public SkillRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}

