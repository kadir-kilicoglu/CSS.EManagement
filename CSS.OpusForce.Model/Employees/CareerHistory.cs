using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Employees {
    
    public class CareerHistory : EntityBase<int>, IAggregateRoot 
    {
        public CareerHistory() 
        { 
        }

        public virtual Employee Employee { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContractorName { get; set; }
        public virtual string SkillName { get; set; }
        public virtual string AssignedDutyName { get; set; }
        public virtual System.Nullable<decimal> AssignedDutyRate { get; set; }
        public virtual string AssignedDutyRateCurrency { get; set; }
        public virtual string AgreementNumber { get; set; }
        public virtual System.DateTime StartDate { get; set; }
        public virtual System.Nullable<System.DateTime> EndDate { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ICareerHistoryRepository : IRepository<CareerHistory, int>
    {
    }
}
