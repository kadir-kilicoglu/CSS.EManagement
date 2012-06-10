using System;
using System.Linq;
using System.Globalization;

using CSS.Infrastructure.Querying;
using CSS.OpusForce.Model.Accounts;
using CSS.OpusForce.Model.Companies;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

namespace CSS.OpusForce.Services.Implementations
{      
    public class AccountServices : IAccountServices
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountServices(ICompanyRepository companyRepository,
            IUserAccountRepository userAccountRepository,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository,
            IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _userAccountRepository = userAccountRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }

        /*********************************************************/
        /*                Role Implementations                   */
        /*********************************************************/
        #region Role Implementations
        public CreateRoleResponse CreateRole(CreateRoleRequest request)
        {
            CreateRoleResponse response = new CreateRoleResponse();
            response.ExceptionState = false;

            Role role = new Role();
            role.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            role.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<Role>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_roleRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir rol zaten var. Lütfen rol adını benzersiz bir isim olarak düzenleyin.";

                response.Role = role.ConvertToRoleView();

                return response;
            }

            object identityToken = _roleRepository.Add(role);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Rol kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.Role = _roleRepository.FindBy((int)identityToken).ConvertToRoleView();

            return response;
        }

        public ReadRoleResponse ReadRole(ReadRoleRequest request)
        {
            ReadRoleResponse response = new ReadRoleResponse();
            response.ExceptionState = false;

            response.Role = _roleRepository.FindBy(request.Id).ConvertToRoleView();

            return response;
        }

        public UpdateRoleResponse UpdateRole(UpdateRoleRequest request)
        {
            UpdateRoleResponse response = new UpdateRoleResponse();
            response.ExceptionState = false;

            Role role = new Role();
            role.Id = request.Id;
            role.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            role.Description = string.IsNullOrEmpty(role.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (role.Name != _roleRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<Role>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_roleRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir rol zaten var. Lütfen rol adını benzersiz bir isim olarak düzenleyin.";

                    response.Role = role.ConvertToRoleView();

                    return response;
                }
            }

            _roleRepository.Save(role);
            _unitOfWork.Commit();

            response.Role = role.ConvertToRoleView();

            return response;
        }

        public DeleteRoleResponse DeleteRole(DeleteRoleRequest request)
        {
            DeleteRoleResponse response = new DeleteRoleResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<UserRole>(c => c.Role.Id, request.Id, CriteriaOperator.Equal));
            if (_userRoleRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini rolü kullanan hesaplar var. Lütfen önce bu hesapları silip ya da düzenleyip tekrar deneyin.";
                response.Roles = _roleRepository.FindAll().ConvertToRoleSummaryView();

                return response;
            }

            _roleRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.Roles = _roleRepository.FindAll().ConvertToRoleSummaryView();

            return response;
        }

        public ListRolesResponse ListRoles(ListRolesRequest request)
        {
            ListRolesResponse response = new ListRolesResponse();
            response.ExceptionState = false;

            response.Roles = _roleRepository.FindAll().ConvertToRoleSummaryView();

            return response;
        }
    #endregion

        /*********************************************************/
        /*             UserAccount Implementations               */
        /*********************************************************/
        #region UserAccount Implementations
        public CreateUserAccountResponse CreateUserAccount(CreateUserAccountRequest request)
        {
            CreateUserAccountResponse response = new CreateUserAccountResponse();
            response.ExceptionState = false;

            UserAccount userAccount = new UserAccount();
            userAccount.Username = request.Name;
            userAccount.Password = request.Password;
            userAccount.Company = _companyRepository.FindBy(request.CompanyId);

            Query query = new Query();
            query.Add(Criterion.Create<UserAccount>(c => c.Username, request.Name, CriteriaOperator.Equal));
            if (_userAccountRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir kullanıcı zaten var. Lütfen kullanıcı adını benzersiz bir isim olarak düzenleyin.";

                response.UserAccount = userAccount.ConvertToUserAccountView();

                return response;
            }

            object identityToken = _userAccountRepository.Add(userAccount);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Kullanıcı kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            //if (request.RoleIds.Count() > 0)
            //{
            //    foreach (int i in request.RoleIds)
            //    {
            //        userAccount.UserRoles.Add(_userRoleRepository.FindBy(new UserRoleIdentifier() { UserId = (int)identityToken, RoleId = i }));
            //    }

            //    userAccount.Id = (int)identityToken;
            //    _userAccountRepository.Save(userAccount);
            //}
            

            response.UserAccount = userAccount.ConvertToUserAccountView();

            return response;
        }

        public ReadUserAccountResponse ReadUserAccount(ReadUserAccountRequest request)
        {
            ReadUserAccountResponse response = new ReadUserAccountResponse();
            response.ExceptionState = false;

            response.UserAccount = _userAccountRepository.FindBy(request.Id).ConvertToUserAccountView();

            return response;
        }

        public UpdateUserAccountResponse UpdateUserAccount(UpdateUserAccountRequest request)
        {
            UpdateUserAccountResponse response = new UpdateUserAccountResponse();
            response.ExceptionState = false;

            UserAccount userAccount = new UserAccount();
            userAccount.Id = request.Id;
            userAccount.Username = request.Name;
            userAccount.Password = request.Password;
            userAccount.Company = _companyRepository.FindBy(request.CompanyId);
            foreach (int i in request.RoleIds.Distinct())
            {
                userAccount.UserRoles.Add(_userRoleRepository.FindBy(new UserRoleIdentifier() { UserId = request.Id, RoleId = i }));
            }

            if (userAccount.Username != _userAccountRepository.FindBy(request.Id).Username)
            {
                Query query = new Query();
                query.Add(Criterion.Create<UserAccount>(c => c.Username, request.Name, CriteriaOperator.Equal));
                if (_userAccountRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir kullanıcı zaten var. Lütfen kullanıcı adını benzersiz bir isim olarak düzenleyin.";

                    response.UserAccount = userAccount.ConvertToUserAccountView();

                    return response;
                }
            }            

            _userAccountRepository.Save(userAccount);
            _unitOfWork.Commit();

            response.UserAccount = userAccount.ConvertToUserAccountView();

            return response;
        }

        public DeleteUserAccountResponse DeleteUserAccount(DeleteUserAccountRequest request)
        {
            DeleteUserAccountResponse response = new DeleteUserAccountResponse();
            response.ExceptionState = false;

            _userAccountRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.UserAccounts = _userAccountRepository.FindAll().ConvertToUserAccountSummaryView();

            return response;
        }

        public ListUserAccountsResponse ListUserAccounts(ListUserAccountsRequest request)
        {
            ListUserAccountsResponse response = new ListUserAccountsResponse();
            response.ExceptionState = false;

            response.UserAccounts = _userAccountRepository.FindAll().ConvertToUserAccountSummaryView();

            return response;
        }
        #endregion
    }
}
