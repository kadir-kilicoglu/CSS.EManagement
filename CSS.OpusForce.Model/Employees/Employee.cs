using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Companies;
using CSS.OpusForce.Model.Agreements;
using CSS.OpusForce.Model.ScoreCards;
using CSS.OpusForce.Model.Contractors;

namespace CSS.OpusForce.Model.Employees 
{
    
    public class Employee : EntityBase<int>, IAggregateRoot 
    {
        public Employee() 
        {
			Agreements = new List<Agreement>();
			CareerHistories = new List<CareerHistory>();
			EmployeeDebits = new List<EmployeeDebit>();
			EmployeeFiles = new List<EmployeeFile>();
			ScoreCards = new List<ScoreCard>();
        }

        public virtual Company Company { get; set; }
        public virtual Contractor Contractor { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual Agreement Agreement { get; set; }
        public virtual AssignedDuty AssignedDuty { get; set; }
        public virtual IList<Agreement> Agreements { get; set; }
        public virtual IList<CareerHistory> CareerHistories { get; set; }
        public virtual IList<EmployeeDebit> EmployeeDebits { get; set; }
        public virtual IList<EmployeeFile> EmployeeFiles { get; set; }
        public virtual IList<ScoreCard> ScoreCards { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string SSN { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Address { get; set; }
        public virtual string PhoneNumber1 { get; set; }
        public virtual string PhoneNumber2 { get; set; }
        public virtual string BankAccountNumber { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IEmployeeRepository : IRepository<Employee, int>
    {
    }
}
