using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Companies;

namespace CSS.OpusForce.Model.Accounts 
{
    
    public class UserAccount : EntityBase<int>, IAggregateRoot 
    {
        public UserAccount() 
        {
			UserRoles = new List<UserRole>();
        }

        public virtual Company Company { get; set; }
        public virtual IList<UserRole> UserRoles { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IUserAccountRepository : IRepository<UserAccount, int>
    {
    }
}
