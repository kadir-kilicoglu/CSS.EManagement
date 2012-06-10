using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Agreements;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class AgreementTypeRepository : Repository<AgreementType, int>, IAgreementTypeRepository
    {
        public AgreementTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
