using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Accounts;
using CSS.OpusForce.Model.Projects;
using CSS.OpusForce.Model.Employees;
using CSS.OpusForce.Model.OperationCenters;

namespace CSS.OpusForce.Model.Companies 
{
    
    public class Company : EntityBase<int>, IAggregateRoot 
    {
        public Company() 
        {
			Companies = new List<Company>();
			Employees = new List<Employee>();
			OperationCenters = new List<OperationCenter>();
			Projects = new List<Project>();
			UserAccounts = new List<UserAccount>();
        }

        public virtual Company ParentCompany { get; set; }
        public virtual CompanyType CompanyType { get; set; }
        public virtual IList<Company> Companies { get; set; }
        public virtual IList<Employee> Employees { get; set; }
        public virtual IList<OperationCenter> OperationCenters { get; set; }
        public virtual IList<Project> Projects { get; set; }
        public virtual IList<UserAccount> UserAccounts { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICompanyRepository : IRepository<Company, int>
    {
    }
}
