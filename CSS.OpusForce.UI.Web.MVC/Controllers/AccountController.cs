using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSS.OpusForce.Services.Interfaces;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.UI.Web.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountService;
        private readonly ICompanyServices _companyService;

        public AccountController(IAccountServices accountService,
            ICompanyServices companyService)
        {
            _accountService = accountService;
            _companyService = companyService;
            ResetInfoMessages();
        }

        private void ResetInfoMessages()
        {
            if (ViewData["Error"] == null)
                ViewData["Error"] = string.Empty;
            if (ViewData["Add"] == null)
                ViewData["Add"] = false;
            if (ViewData["Update"] == null)
                ViewData["Update"] = false;
            if (ViewData["Delete"] == null)
                ViewData["Delete"] = false;
        }


        /*******************************************************************/
        /*                    UserAccount Actions                          */
        /*******************************************************************/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UserAccountList()
        {
            // 1. Get UserAccounts list
            // 2. View UserAccountList (Grid)

            ResetInfoMessages();

            ListUserAccountsResponse response = _accountService.ListUserAccounts(null);
            return View(response.UserAccounts);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UserAccountCreate()
        {
            // 1. Get companies into ViewData["Companies"]
            // 3. View UserAccountCreate (Empty Form)

            ViewData["Companies"] = _companyService.ListCompanies(null).Companies;
            ResetInfoMessages();

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserAccountCreate(UserAccountView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View UserAccountCreate (Empty Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View UserAccountCreate (Empty Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Add to true
            // 4. View UserAccountRead
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                CreateUserAccountRequest request = new CreateUserAccountRequest();
                request.Name = view.UserName;
                request.Password = view.Password;

                CreateUserAccountResponse response = _accountService.CreateUserAccount(request);

                if (response.ExceptionState)
                {
                    ViewData["Error"] = response.ExceptionMessage;
                    return View();
                }

                ViewData["Add"] = true;
                return View("UserAccountRead", response.UserAccount);
            }
            else
            {
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UserAccountRead(int id)
        {
            // 1. Get UserAccount (by Id)
            // 2. View UserAccountRead

            ResetInfoMessages();

            ReadUserAccountRequest request = new ReadUserAccountRequest();
            request.Id = id;

            ReadUserAccountResponse response = new ReadUserAccountResponse();
            response = _accountService.ReadUserAccount(request);

            return View("UserAccountRead", response.UserAccount);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UserRoleUpdate(int id)
        {
            // 1. Get UserRoles (by User Id)
            // 2. View UserRoleUpdate (grid)

            ResetInfoMessages();

            ReadUserAccountRequest request = new ReadUserAccountRequest();
            request.Id = id;

            ReadUserAccountResponse response = new ReadUserAccountResponse();
            response = _accountService.ReadUserAccount(request);

            TempData["UserAccount"] = response.UserAccount;
            return View("UserAccountRead", response.UserAccount.Roles);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserRoleUpdate(IEnumerable<RoleView> view)
        {
            UpdateUserAccountRequest request = new UpdateUserAccountRequest();

            UserAccountView entity = (UserAccountView) TempData["UserAccount"];
            request.Id = entity.Id;
            request.Name = entity.UserName;
            request.Password = entity.Password;
            request.CompanyId = entity.Company.Id;

            List<int> tempList = new List<int>();
            foreach (RoleView r in view)
            {
                tempList.Add(r.Id);
            }

            request.RoleIds = tempList;

            UpdateUserAccountResponse response = _accountService.UpdateUserAccount(request);

            return View("UserAccountRead", response.UserAccount);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UserAccountUpdate(int id)
        {
            // 1. Get UserAccount (by Id)
            // 2. View UserAccountUpdate (Filled Form)

            ResetInfoMessages();

            ReadUserAccountRequest request = new ReadUserAccountRequest();
            request.Id = id;

            ReadUserAccountResponse response = new ReadUserAccountResponse();
            response = _accountService.ReadUserAccount(request);

            return View(response.UserAccount);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserAccountUpdate(UserAccountView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View UserAccountUpdate (Filled Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View UserAccountUpdate (Filled Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Update to true
            // 4. View UserAccountRead
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                UpdateUserAccountRequest request = new UpdateUserAccountRequest();
                request.Id = view.Id;
                request.Name = view.UserName;
                request.Password = view.Password;
                request.CompanyId = view.Company.Id;

                UpdateUserAccountResponse response = new UpdateUserAccountResponse();
                response = _accountService.UpdateUserAccount(request);

                if (response.ExceptionState)
                {
                    ViewData["Error"] = response.ExceptionMessage;
                    return View(view);
                }

                ViewData["Update"] = true;
                return View("UserAccountRead", response.UserAccount);
            }
            else
            {
                return View(view);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserRoleDelete(int roleId)
        {
            UpdateUserAccountRequest request = new UpdateUserAccountRequest();

            UserAccountView entity = (UserAccountView)TempData["UserAccount"];
            request.Id = entity.Id;
            request.Name = entity.UserName;
            request.Password = entity.Password;
            request.CompanyId = entity.Company.Id;

            List<int> tempList = new List<int>();
            foreach (RoleView r in entity.Roles)
            {
                tempList.Add(r.Id);
            }

            tempList.Remove(roleId);

            request.RoleIds = tempList;

            UpdateUserAccountResponse response = _accountService.UpdateUserAccount(request);

            return View("UserAccountRead", response.UserAccount);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UserAccountDelete(int id)
        {
            // 1. Try delete record
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View UserAccountList
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Delete record
            // 4. Set Delete to true
            // 5. View UserAccountList

            ResetInfoMessages();

            DeleteUserAccountRequest request = new DeleteUserAccountRequest();
            request.Id = id;

            DeleteUserAccountResponse response = new DeleteUserAccountResponse();
            response = _accountService.DeleteUserAccount(request);

            if (response.ExceptionState)
            {
                ViewData["Error"] = response.ExceptionMessage;
                return View("UserAccountList", response.UserAccounts);
            }

            ViewData["Delete"] = true;
            return View("UserAccountList", response.UserAccounts);
        }

        /*******************************************************************/
        /*                           Role Actions                          */
        /*******************************************************************/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RoleList()
        {
            // 1. Get Roles list
            // 2. View RoleList (Grid)

            ResetInfoMessages();
            ListRolesResponse response = _accountService.ListRoles(null);
            return View(response.Roles);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RoleCreate()
        {
            // 1. View RoleCreate (Empty Form)
            
            ResetInfoMessages();

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RoleCreate(RoleView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View RoleCreate (Empty Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View RoleCreate (Empty Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Add to true
            // 4. View RoleDetail
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                CreateRoleRequest request = new CreateRoleRequest();
                request.Name = view.Name;
                request.Description = view.Description;

                CreateRoleResponse response = _accountService.CreateRole(request);

                if (response.ExceptionState)
                {
                    ViewData["Error"] = response.ExceptionMessage;
                    return View();
                }

                ViewData["Add"] = true;
                return View("RoleRead", response.Role);
            }
            else
            {
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RoleRead(int id)
        {
            // 1. Get Role (by Id)
            // 2. View RoleRead

            ResetInfoMessages();

            ReadRoleRequest request = new ReadRoleRequest();
            request.Id = id;

            ReadRoleResponse response = new ReadRoleResponse();
            response = _accountService.ReadRole(request);

            return View("RoleRead", response.Role);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult RoleUpdate(int id)
        {
            // 1. Get Role (by Id)
            // 2. View RoleUpdate (Filled Form)

            ResetInfoMessages();

            ReadRoleRequest request = new ReadRoleRequest();
            request.Id = id;

            ReadRoleResponse response = new ReadRoleResponse();
            response = _accountService.ReadRole(request);

            return View(response.Role);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RoleUpdate(RoleView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View RoleUpdate (Filled Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View RoleUpdate (Filled Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Update to true
            // 4. View RoleRead
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                UpdateRoleRequest request = new UpdateRoleRequest();
                request.Id = view.Id;
                request.Name = view.Name;
                request.Description = view.Description;

                UpdateRoleResponse response = new UpdateRoleResponse();
                response = _accountService.UpdateRole(request);

                if (response.ExceptionState)
                {
                    ViewData["Error"] = response.ExceptionMessage;
                    return View(view);
                }

                ViewData["Update"] = true;
                return View("RoleRead", response.Role);
            }
            else
            {
                return View(view);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RoleDelete(int id)
        {
            // 1. Try delete record
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View RoleList
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Delete record
            // 4. Set Delete to true
            // 5. View RoleList

            ResetInfoMessages();

            DeleteRoleRequest request = new DeleteRoleRequest();
            request.Id = id;

            DeleteRoleResponse response = new DeleteRoleResponse();
            response = _accountService.DeleteRole(request);

            if (response.ExceptionState)
            {
                ViewData["Error"] = response.ExceptionMessage;
                return View("RoleList", response.Roles);
            }

            ViewData["Delete"] = true;
            return View("RoleList", response.Roles);
        }
    }
}
