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
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectService;
        private readonly ICompanyServices _companyService;

        public ProjectController(IProjectServices projectService, ICompanyServices companyService)
        {
            _projectService = projectService;
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
        /*                      Project Actions                            */
        /*******************************************************************/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectList()
        {
            // 1. Get Project list
            // 2. View ProjectList (Grid)

            ResetInfoMessages();

            ListProjectsResponse response = _projectService.ListProjects(null);
            return View(response.Projects);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectCreate()
        {
            // 1. View ProjectCreate (Empty Form)

            ResetInfoMessages();

            var companies = _companyService.ListCompanies(null).Companies.OrderBy(c => c.Name);
            var companyList = new SelectList(companies, "Id", "Name");
            TempData["Companies"] = companyList;

            var projectTypes = _projectService.ListProjectTypes(null).ProjectTypes.OrderBy(c => c.Name);
            var projectTypeList = new SelectList(projectTypes, "Id", "Name");
            TempData["ProjectTypes"] = projectTypeList;

            var projectStatuses = _projectService.ListProjectStatuses(null).ProjectStatuses.OrderBy(c => c.Name);
            var projectStatusList = new SelectList(projectStatuses, "Id", "Name");
            TempData["projectStatuses"] = projectStatusList;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectCreate(ProjectView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View ProjectCreate (Empty Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View ProjectCreate (Empty Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Add to true
            // 4. View ProjectRead
            // 5. View SuccessBox

            ResetInfoMessages();

            var companies = _companyService.ListCompanies(null).Companies.OrderBy(c => c.Name);
            var companyList = new SelectList(companies, "Id", "Name");
            TempData["Companies"] = companyList;

            var projectTypes = _projectService.ListProjectTypes(null).ProjectTypes.OrderBy(c => c.Name);
            var projectTypeList = new SelectList(projectTypes, "Id", "Name");
            TempData["ProjectTypes"] = projectTypeList;

            var projectStatuses = _projectService.ListProjectStatuses(null).ProjectStatuses.OrderBy(c => c.Name);
            var projectStatusList = new SelectList(projectStatuses, "Id", "Name");
            TempData["projectStatuses"] = projectStatusList;

            if (ModelState.IsValid)
            {
                CreateProjectRequest request = new CreateProjectRequest();
                request.Name = view.Name;
                request.Description = view.Description;
                request.CompanyId = view.CompanyId;
                request.ProjectTypeId = view.ProjectTypeId;
                request.ProjectStatusId = view.ProjectStatusId;
                request.StartDate = view.StartDate;
                request.EndDate = view.EndDate;

                CreateProjectResponse response = _projectService.CreateProject(request);

                if (response.ExceptionState)
                {
                    TempData["Error"] = response.ExceptionMessage;
                    return View();
                }

                TempData["Add"] = true;
                return View("ProjectRead", response.Project);
            }
            else
            {
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectRead(int id)
        {
            // 1. Get Project (by Id)
            // 2. View ProjectRead

            ResetInfoMessages();

            ReadProjectRequest request = new ReadProjectRequest();
            request.Id = id;

            ReadProjectResponse response = new ReadProjectResponse();
            response = _projectService.ReadProject(request);

            return View("ProjectRead", response.Project);
        }
        /*******************************************************************/
        /*                    ProjectType Actions                          */
        /*******************************************************************/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectTypeList()
        {
            // 1. Get ProjectType list
            // 2. View ProjectTypeList (Grid)

            ResetInfoMessages();

            ListProjectTypesResponse response = _projectService.ListProjectTypes(null);
            return View(response.ProjectTypes);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectTypeCreate()
        {
            // 1. View ProjectTypeCreate (Empty Form)

            ResetInfoMessages();

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectTypeCreate(ProjectTypeView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View ProjectTypeCreate (Empty Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View ProjectTypeCreate (Empty Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Add to true
            // 4. View ProjectTypeRead
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                CreateProjectTypeRequest request = new CreateProjectTypeRequest();
                request.Name = view.Name;
                request.Description = view.Description;

                CreateProjectTypeResponse response = _projectService.CreateProjectType(request);

                if (response.ExceptionState)
                {
                    TempData["Error"] = response.ExceptionMessage;
                    return View();
                }

                TempData["Add"] = true;
                return View("ProjectTypeRead", response.ProjectType);
            }
            else
            {
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectTypeRead(int id)
        {
            // 1. Get ProjectType (by Id)
            // 2. View ProjectTypeRead

            ResetInfoMessages();

            ReadProjectTypeRequest request = new ReadProjectTypeRequest();
            request.Id = id;

            ReadProjectTypeResponse response = new ReadProjectTypeResponse();
            response = _projectService.ReadProjectType(request);

            return View("ProjectTypeRead", response.ProjectType);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectTypeUpdate(int id)
        {
            // 1. Get ProjectType (by Id)
            // 2. View ProjectType (Filled Form)

            ResetInfoMessages();

            ReadProjectTypeRequest request = new ReadProjectTypeRequest();
            request.Id = id;

            ReadProjectTypeResponse response = new ReadProjectTypeResponse();
            response = _projectService.ReadProjectType(request);

            return View(response.ProjectType);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectTypeUpdate(ProjectTypeView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View ProjectTypeCreate (Filled Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View ProjectTypeCreate (Filled Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Update to true
            // 4. View ProjectTypeDetail
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                UpdateProjectTypeRequest request = new UpdateProjectTypeRequest();
                request.Id = view.Id;
                request.Name = view.Name;
                request.Description = view.Description;

                UpdateProjectTypeResponse response = new UpdateProjectTypeResponse();
                response = _projectService.UpdateProjectType(request);

                if (response.ExceptionState)
                {
                    TempData["Error"] = response.ExceptionMessage;
                    return View(view);
                }

                TempData["Update"] = true;
                return View("ProjectTypeRead", response.ProjectType);
            }
            else
            {
                return View(view);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectTypeDelete(int id)
        {
            // 1. Try delete record
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View ProjectTypeList
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Delete record
            // 4. Set Delete to true
            // 5. View ComanyTypeList

            ResetInfoMessages();

            DeleteProjectTypeRequest request = new DeleteProjectTypeRequest();
            request.Id = id;

            DeleteProjectTypeResponse response = new DeleteProjectTypeResponse();
            response = _projectService.DeleteProjectType(request);

            if (response.ExceptionState)
            {
                TempData["Error"] = response.ExceptionMessage;
                return View("ProjectTypeList", response.ProjectTypes);
            }

            TempData["Delete"] = true;
            return View("ProjectTypeList", response.ProjectTypes);
        }

        /*******************************************************************/
        /*                    ProjectStatus Actions                          */
        /*******************************************************************/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectStatusList()
        {
            // 1. Get ProjectStatus list
            // 2. View ProjectStatusList (Grid)

            ResetInfoMessages();

            ListProjectStatusesResponse response = _projectService.ListProjectStatuses(null);
            return View(response.ProjectStatuses);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectStatusCreate()
        {
            // 1. View ProjectStatusCreate (Empty Form)

            ResetInfoMessages();

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectStatusCreate(ProjectStatusView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View ProjectStatusCreate (Empty Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View ProjectStatusCreate (Empty Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Add to true
            // 4. View ProjectStatusRead
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                CreateProjectStatusRequest request = new CreateProjectStatusRequest();
                request.Name = view.Name;
                request.Description = view.Description;

                CreateProjectStatusResponse response = _projectService.CreateProjectStatus(request);

                if (response.ExceptionState)
                {
                    TempData["Error"] = response.ExceptionMessage;
                    return View();
                }

                TempData["Add"] = true;
                return View("ProjectStatusRead", response.ProjectStatus);
            }
            else
            {
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectStatusRead(int id)
        {
            // 1. Get ProjectStatus (by Id)
            // 2. View ProjectStatusRead

            ResetInfoMessages();

            ReadProjectStatusRequest request = new ReadProjectStatusRequest();
            request.Id = id;

            ReadProjectStatusResponse response = new ReadProjectStatusResponse();
            response = _projectService.ReadProjectStatus(request);

            return View("ProjectStatusRead", response.ProjectStatus);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ProjectStatusUpdate(int id)
        {
            // 1. Get ProjectStatus (by Id)
            // 2. View ProjectStatus (Filled Form)

            ResetInfoMessages();

            ReadProjectStatusRequest request = new ReadProjectStatusRequest();
            request.Id = id;

            ReadProjectStatusResponse response = new ReadProjectStatusResponse();
            response = _projectService.ReadProjectStatus(request);

            return View(response.ProjectStatus);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectStatusUpdate(ProjectStatusView view)
        {
            // 1. If ModelState is not valid
            // ------------------------------
            // 1.1. View ProjectStatusCreate (Filled Form)
            // 1.2. Enable ValidationSummary
            // ------------------------------
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View ProjectStatusCreate (Filled Form)
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Set Update to true
            // 4. View ProjectStatusDetail
            // 5. View SuccessBox

            ResetInfoMessages();

            if (ModelState.IsValid)
            {
                UpdateProjectStatusRequest request = new UpdateProjectStatusRequest();
                request.Id = view.Id;
                request.Name = view.Name;
                request.Description = view.Description;

                UpdateProjectStatusResponse response = new UpdateProjectStatusResponse();
                response = _projectService.UpdateProjectStatus(request);

                if (response.ExceptionState)
                {
                    TempData["Error"] = response.ExceptionMessage;
                    return View(view);
                }

                TempData["Update"] = true;
                return View("ProjectStatusRead", response.ProjectStatus);
            }
            else
            {
                return View(view);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ProjectStatusDelete(int id)
        {
            // 1. Try delete record
            // 2. If ExceptionState is true
            // ------------------------------
            // 2.1. View ProjectStatusList
            // 2.2. Enable ErrorBox
            // ------------------------------
            // 3. Delete record
            // 4. Set Delete to true
            // 5. View ComanyStatusList

            ResetInfoMessages();

            DeleteProjectStatusRequest request = new DeleteProjectStatusRequest();
            request.Id = id;

            DeleteProjectStatusResponse response = new DeleteProjectStatusResponse();
            response = _projectService.DeleteProjectStatus(request);

            if (response.ExceptionState)
            {
                TempData["Error"] = response.ExceptionMessage;
                return View("ProjectStatusList", response.ProjectStatuses);
            }

            TempData["Delete"] = true;
            return View("ProjectStatusList", response.ProjectStatuses);
        }
    }
}
