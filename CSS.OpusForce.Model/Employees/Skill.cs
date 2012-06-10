using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Employees 
{
    
    public class Skill : EntityBase<int>, IAggregateRoot 
    {
        public Skill() 
        {
			Employees = new List<Employee>();
        }

        public virtual IList<Employee> Employees { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ISkillRepository : IRepository<Skill, int>
    {
    }
}
