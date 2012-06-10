using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Employees;
using CSS.OpusForce.Model.Agreements;
using CSS.OpusForce.Model.ScoreCards;

namespace CSS.OpusForce.Model.Contractors 
{
    
    public class Contractor : EntityBase<int>, IAggregateRoot 
    {
        public Contractor() 
        {
			Agreements = new List<Agreement>();
			Employees = new List<Employee>();
			ScoreCardCounts = new List<ScoreCardCount>();
        }
        
        public virtual ContractorStatus ContractorStatus { get; set; }
        public virtual IList<Agreement> Agreements { get; set; }
        public virtual IList<Employee> Employees { get; set; }
        public virtual IList<ScoreCardCount> ScoreCardCounts { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string ResponsibleHead { get; set; }
        public virtual string Address { get; set; }
        public virtual string PhoneNumber1 { get; set; }
        public virtual string PhoneNumber2 { get; set; }
        public virtual string MailAddress { get; set; }
        public virtual string BankAccountNumber { get; set; }
        public virtual string InvoiceName { get; set; }
        public virtual string InvoiceAddress { get; set; }
        public virtual string TaxOffice { get; set; }
        public virtual string TaxNumber { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IContractorRepository : IRepository<Contractor, int>
    {
    }
}
