using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Agreements;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class AgreementStatusRepository : Repository<AgreementStatus, int>, IAgreementStatusRepository
    {
        public AgreementStatusRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
