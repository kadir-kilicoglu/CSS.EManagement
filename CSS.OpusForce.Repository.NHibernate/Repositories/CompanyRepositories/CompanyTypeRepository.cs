using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Companies;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class CompanyTypeRepository : Repository<CompanyType, int>, ICompanyTypeRepository
    {
        public CompanyTypeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
