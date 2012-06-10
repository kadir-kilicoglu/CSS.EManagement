using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Accounts {
    
    public class Role : EntityBase<int>, IAggregateRoot 
    {
        public Role() 
        {
			UserRoles = new List<UserRole>();
        }

        public virtual IList<UserRole> UserRoles { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IRoleRepository : IRepository<Role, int>
    {
    }
}
