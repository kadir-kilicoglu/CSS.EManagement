using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Accounts;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class RoleRepository : Repository<Role, int>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
