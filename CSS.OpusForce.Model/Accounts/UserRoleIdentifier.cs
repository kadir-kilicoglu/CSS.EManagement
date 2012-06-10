using System;
using System.Collections.Generic;

namespace CSS.OpusForce.Model.Accounts
{
    [Serializable]
    public class UserRoleIdentifier
    {
        public virtual int UserId { get; set; }
        public virtual int RoleId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var t = obj as UserRoleIdentifier;
            if (t == null)
                return false;
            if (UserId == t.UserId && RoleId == t.RoleId)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return (UserId + "|" + RoleId).GetHashCode();
        }
    }
}
