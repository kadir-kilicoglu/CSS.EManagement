using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Accounts;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class UserRoleRepository : Repository<UserRole, UserRoleIdentifier>, IUserRoleRepository
    {
        public UserRoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
