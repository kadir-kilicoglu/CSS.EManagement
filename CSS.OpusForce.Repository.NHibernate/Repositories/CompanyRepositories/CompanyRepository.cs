using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Companies;

namespace CSS.OpusForce.Repository.NHibernate.Repositories
{
    public class CompanyRepository : Repository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
