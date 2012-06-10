using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Agreements;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class AgreementRepository : Repository<Agreement, int>, IAgreementRepository
    {
        public AgreementRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
