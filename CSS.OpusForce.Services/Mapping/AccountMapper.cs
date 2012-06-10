using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Accounts;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class AccountMapper
    {
        public static IEnumerable<RoleSummaryView> ConvertToRoleSummaryView(this IEnumerable<Role> roles)
        {
            List<RoleSummaryView> tempList = new List<RoleSummaryView>();

            foreach (Role r in roles)
            {
                RoleSummaryView tempView = new RoleSummaryView();
                tempView.Id = r.Id;
                tempView.Name = r.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static RoleView ConvertToRoleView(this Role role)
        {
            RoleView tempView = new RoleView();
            tempView.Id = role.Id;
            tempView.Name = role.Name;
            tempView.Description = role.Description;

            return tempView;
        }

        public static IEnumerable<UserAccountSummaryView> ConvertToUserAccountSummaryView(this IEnumerable<UserAccount> userAccounts)
        {
            List<UserAccountSummaryView> tempList = new List<UserAccountSummaryView>();

            foreach (UserAccount u in userAccounts)
            {
                UserAccountSummaryView tempView = new UserAccountSummaryView();
                tempView.Id = u.Id;
                tempView.UserName = u.Username;
                if (u.Company == null)
                {
                    tempView.CompanyName = string.Empty;
                }
                else
                {
                    tempView.CompanyName = u.Company.Name;
                }

                List<RoleView> tempRoleView = new List<RoleView>();
                foreach (UserRole ur in u.UserRoles)
                {
                    tempRoleView.Add(ur.Role.ConvertToRoleView());
                }
                tempView.Roles = tempRoleView;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static UserAccountView ConvertToUserAccountView(this UserAccount userAccount)
        {
            UserAccountView tempView = new UserAccountView();
            tempView.Id = userAccount.Id;
            tempView.UserName = userAccount.Username;
            tempView.Password = userAccount.Password;
            tempView.Company = userAccount.Company.ConvertToCompanyView();

            List<RoleView> tempRoleView = new List<RoleView>();
            foreach (UserRole ur in userAccount.UserRoles)
            {
                tempRoleView.Add(ur.Role.ConvertToRoleView());
            }
            tempView.Roles = tempRoleView;

            return tempView;
        }
    }
}
