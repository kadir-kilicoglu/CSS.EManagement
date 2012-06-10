using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Companies 
{
    
    public class CompanyType : EntityBase<int>, IAggregateRoot 
    {
        public CompanyType() 
        {
			Companies = new List<Company>();
        }

        public virtual IList<Company> Companies { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICompanyTypeRepository : IRepository<CompanyType, int>
    {
    }
}
