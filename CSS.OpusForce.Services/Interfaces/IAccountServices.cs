using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface IAccountServices
    {
        CreateRoleResponse CreateRole(CreateRoleRequest request);
        ReadRoleResponse ReadRole(ReadRoleRequest request);
        UpdateRoleResponse UpdateRole(UpdateRoleRequest request);
        DeleteRoleResponse DeleteRole(DeleteRoleRequest request);
        ListRolesResponse ListRoles(ListRolesRequest request);

        CreateUserAccountResponse CreateUserAccount(CreateUserAccountRequest request);
        ReadUserAccountResponse ReadUserAccount(ReadUserAccountRequest request);
        UpdateUserAccountResponse UpdateUserAccount(UpdateUserAccountRequest request);
        DeleteUserAccountResponse DeleteUserAccount(DeleteUserAccountRequest request);
        ListUserAccountsResponse ListUserAccounts(ListUserAccountsRequest request);
    }
}
