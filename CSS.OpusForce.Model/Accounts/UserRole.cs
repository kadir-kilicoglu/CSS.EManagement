using System.Collections.Generic;

using CSS.Infrastructure.Domain;

namespace CSS.OpusForce.Model.Accounts 
{
    
    public class UserRole : IAggregateRoot 
    {
        public UserRole() 
        { 
        } 

        private UserRoleIdentifier _userRoleIdentifier = new UserRoleIdentifier();
        public virtual UserRoleIdentifier UserRoleIdentifier
        {
            get { return _userRoleIdentifier; }
            set { _userRoleIdentifier = value; }
        }

        private UserAccount _userAccount;
        public virtual UserAccount UserAccount
        {
            get { return _userAccount; }
            set
            {
                _userAccount = value;
                _userRoleIdentifier.UserId = _userAccount.Id;
            }
        }

        private Role _role;
        public virtual Role Role
        {
            get { return _role; }
            set
            {
                _role = value;
                _userRoleIdentifier.RoleId = _role.Id;
            }
        }
    }

    public interface IUserRoleRepository : IRepository<UserRole, UserRoleIdentifier>
    {
    }
}
