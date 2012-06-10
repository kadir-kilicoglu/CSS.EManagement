using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Contractors;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class ContractorRepository : Repository<Contractor, int>, IContractorRepository
    {
        public ContractorRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
