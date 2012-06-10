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
    public class CompanyController : Controller
    {
        private readonly ICompanyServices _companyService;        

        public CompanyController(ICompanyServices companyService)
        {
            _companyService = companyService;

            ResetInfoMessages();
        }

        private void ResetInfoMessages()
        {
            if (TempData["Error"] == null)
                TempData["Error"] = string.Empty;
            if (TempData["Add"] == null)
                TempData["Add"] = false;
            if (TempData["Update"] == null)
                TempData["Update"] = false;
            if (TempData["Delete"] == null)
                TempData["Delete"] = false;
        }

        /*******************************************************************/
        /*                      Company Actions                            */
        /*******************************************************************/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CompanyList()
        {
            // 1. Get Company list
            // 2. View CompanyList (Grid)

            ResetInfoMessages();

            ListCompaniesResponse response = _companyService.ListCompanies(null);
            return View(response.Companies);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CompanyCreate()
        {
            // 1. View CompanyCreate (Empty Form)

            ResetInfoMessages();

            var companyTypes = _companyService.ListCompanyTypes(null).CompanyTypes.OrderBy(c => c.Name);
            var companyTypeList = new SelectList(companyTypes, "Id", "Name");
            TempData["CompanyTypes"] = companyTypeList;

            var companies = _companyService.ListCompanies(null).Companies.OrderBy(c => c.Name);
            var companyList = new SelectList(companies, "Id", "Name");
            TempData["Companies"] = companyList;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyCreate(CompanyView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View CompanyCreate (Empty Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View CompanyCreate (Empty Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Add to true
            // 4. View CompanyRead
            // 5. View SuccessBox

            ResetInfoMessages();

            var companyTypes = _companyService.ListCompanyTypes(null).CompanyTypes.OrderBy(c => c.Name);
            var companyTypeList = new SelectList(companyTypes, "Id", "Name");
            TempData["CompanyTypes"] = companyTypeList;

            var companies = _companyService.ListCompanies(null).Companies.OrderBy(c => c.Name);
            var companyList = new SelectList(companies, "Id", "Name");
            TempData["Companies"] = companyList;

            if (ModelState.IsValid)
            {
                CreateCompanyRequest request = new CreateCompanyRequest();
                request.Name = view.Name;
                request.Description = view.Description;
                request.IsActive = view.IsActive;
                request.CompanyTypeId = view.CompanyTypeId;
                request.ParentCompanyId = (int?) view.ParentCompanyId;

                CreateCompanyResponse response = _companyService.CreateCompany(request);

                if (response.ExceptionState)
                {
                    TempData["Error"] = response.ExceptionMessage;
                    return View();
                }

                TempData["Add"] = true;
                return View("CompanyRead", response.Company);
            }
            else
            {
                return View();
            }  
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CompanyRead(int id)
        {
            // 1. Get Company (by Id)
            // 2. View CompanyRead

            ResetInfoMessages();

            ReadCompanyRequest request = new ReadCompanyRequest();
            request.Id = id;

            ReadCompanyResponse response = new ReadCompanyResponse();
            response = _companyService.ReadCompany(request);

            return View("CompanyRead", response.Company);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CompanyUpdate(int id)
        {
            // 1. Get Company (by Id)
            // 2. View Company (Filled Form)

            ResetInfoMessages();

            ReadCompanyRequest request = new ReadCompanyRequest();
            request.Id = id;

            ReadCompanyResponse response = new ReadCompanyResponse();
            response = _companyService.ReadCompany(request);

            var companyTypes = _companyService.ListCompanyTypes(null).CompanyTypes.OrderBy(c => c.Name);
            var companyTypeList = new SelectList(companyTypes, "Id", "Name", response.Company.CompanyTypeId);
            TempData["CompanyTypes"] = companyTypeList;

            var companies = _companyService.ListCompanies(null).Companies.OrderBy(c => c.Name);
            var companyList = new SelectList(companies, "Id", "Name", response.Company.ParentCompanyId);
            TempData["Companies"] = companyList;

            return View(response.Company);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyUpdate(CompanyView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View CompanyUpdate (Filled Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View CompanyUpdate (Filled Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Update to true
            // 4. View CompanyRead
            // 5. View SuccessBox

            ResetInfoMessages();

            var companyTypes = _companyService.ListCompanyTypes(null).CompanyTypes.OrderBy(c => c.Name);
            var companyTypeList = new SelectList(companyTypes, "Id", "Name", view.CompanyTypeId);
            TempData["CompanyTypes"] = companyTypeList;

            var companies = _companyService.ListCompanies(null).Companies.OrderBy(c => c.Name);
            var companyList = new SelectList(companies, "Id", "Name", view.ParentCompanyId);
            TempData["Companies"] = companyList;

            if (ModelState.IsValid)
            {
                UpdateCompanyRequest request = new UpdateCompanyRequest();
                request.Id = view.Id;
                request.Name = view.Name;
                request.Description = view.Description;
                request.IsActive = view.IsActive;
                request.CompanyTypeId = view.CompanyTypeId;
                request.ParentCompanyId = (int?) view.ParentCompanyId;

                UpdateCompanyResponse response = _companyService.UpdateCompany(request);

                if (response.ExceptionState)
                {
                    TempData["Error"] = response.ExceptionMessage;
                    return View(view);
                }

                TempData["Update"] = true;
                return View("CompanyRead", response.Company);
            }
            else
            {
                return View(view);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyDelete(int id)
        {
            // 1. Try delete record
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View CompanyList
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Delete record
            // 4. Set Delete to true
            // 5. View CompanyList

            ResetInfoMessages();

            DeleteCompanyRequest request = new DeleteCompanyRequest();
            request.Id = id;

            DeleteCompanyResponse response = new DeleteCompanyResponse();
            response = _companyService.DeleteCompany(request);

            if (response.ExceptionState)
            {
                TempData["Error"] = response.ExceptionMessage;
                return View("CompanyList", response.Companies);
            }

            TempData["Delete"] = true;
            return RedirectToAction("CompanyList");
        }
        /*******************************************************************/
        /*                    CompanyType Actions                          */
        /*******************************************************************/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CompanyTypeList()
        {
            // 1. Get CompanyType list
            // 2. View CompanyTypeList (Grid)

            ResetInfoMessages();

            ListCompanyTypesResponse response = _companyService.ListCompanyTypes(null);
            return View(response.CompanyTypes);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CompanyTypeCreate()
        {
            // 1. View CompanyTypeCreate (Empty Form)

            ResetInfoMessages();

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyTypeCreate(CompanyTypeView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View CompanyTypeCreate (Empty Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View CompanyTypeCreate (Empty Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Add to true
            // 4. View CompanyTypeRead
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                CreateCompanyTypeRequest request = new CreateCompanyTypeRequest();
                request.Name = view.Name;
                request.Description = view.Description;

                CreateCompanyTypeResponse response = _companyService.CreateCompanyType(request);

                if (response.ExceptionState)
                {
                    TempData["Error"] = response.ExceptionMessage;
                    return View();
                }

                TempData["Add"] = true;
                return View("CompanyTypeRead", response.CompanyType);
            }
            else
            {
                return View();
            }           
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CompanyTypeRead(int id)
        {
            // 1. Get CompanyType (by Id)
            // 2. View CompanyTypeRead

            ResetInfoMessages();

            ReadCompanyTypeRequest request = new ReadCompanyTypeRequest();
            request.Id = id;

            ReadCompanyTypeResponse response = new ReadCompanyTypeResponse();
            response = _companyService.ReadCompanyType(request);

            return View("CompanyTypeRead", response.CompanyType);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CompanyTypeUpdate(int id)
        {
            // 1. Get CompanyType (by Id)
            // 2. View CompanyType (Filled Form)

            ResetInfoMessages();

            ReadCompanyTypeRequest request = new ReadCompanyTypeRequest();
            request.Id = id;

            ReadCompanyTypeResponse response = new ReadCompanyTypeResponse();
            response = _companyService.ReadCompanyType(request);

            return View(response.CompanyType);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyTypeUpdate(CompanyTypeView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View CompanyTypeCreate (Filled Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View CompanyTypeCreate (Filled Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Update to true
            // 4. View CompanyTypeDetail
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                UpdateCompanyTypeRequest request = new UpdateCompanyTypeRequest();
                request.Id = view.Id;
                request.Name = view.Name;
                request.Description = view.Description;

                UpdateCompanyTypeResponse response = new UpdateCompanyTypeResponse();
                response = _companyService.UpdateCompanyType(request);

                if (response.ExceptionState)
                {
                    TempData["Error"] = response.ExceptionMessage;
                    return View(view);
                }

                TempData["Update"] = true;
                return View("CompanyTypeRead", response.CompanyType);
            }
            else
            {
                return View(view);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyTypeDelete(int id)
        {
            // 1. Try delete record
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View CompanyTypeList
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Delete record
            // 4. Set Delete to true
            // 5. View ComanyTypeList

            ResetInfoMessages();

            DeleteCompanyTypeRequest request = new DeleteCompanyTypeRequest();
            request.Id = id;

            DeleteCompanyTypeResponse response = new DeleteCompanyTypeResponse();
            response = _companyService.DeleteCompanyType(request);

            if (response.ExceptionState)
            {
                TempData["Error"] = response.ExceptionMessage;
                return View("CompanyTypeList", response.CompanyTypes);
            }

            TempData["Delete"] = true;
            return View("CompanyTypeList", response.CompanyTypes);
        }
    }
}

//.DataRouteValues(route => route.Add(o => o.Id).RouteKey("CompanyTypeId"))
