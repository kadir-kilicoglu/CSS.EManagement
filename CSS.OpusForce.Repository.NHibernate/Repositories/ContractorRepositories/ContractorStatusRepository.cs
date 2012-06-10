using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Contractors;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class ContractorStatusRepository : Repository<ContractorStatus, int>, IContractorStatusRepository
    {
        public ContractorStatusRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
