using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Accounts;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class UserAccountRepository : Repository<UserAccount, int>, IUserAccountRepository
    {
        public UserAccountRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
