using System;
using System.Linq;
using System.Globalization;

using CSS.Infrastructure.Querying;
using CSS.OpusForce.Model.Projects;
using CSS.OpusForce.Model.Companies;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

namespace CSS.OpusForce.Services.Implementations
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectTypeRepository _projectTypeRepository;
        private readonly IProjectStatusRepository _projectStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICompanyRepository _companyRepository;

        public ProjectServices(IProjectRepository projectRepository,
            IProjectTypeRepository projectTypeRepository,
            IProjectStatusRepository projectStatusRepository,
            IUnitOfWork unitOfWork,
            ICompanyRepository companyRepository)
        {
            _projectRepository = projectRepository;
            _projectTypeRepository = projectTypeRepository;
            _projectStatusRepository = projectStatusRepository;
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        /*********************************************************/
        /*               Project Implementations                 */
        /*********************************************************/
        #region Project Implementations
        public CreateProjectResponse CreateProject(CreateProjectRequest request)
        {
            CreateProjectResponse response = new CreateProjectResponse();
            response.ExceptionState = false;

            Project project = new Project();
            project.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            project.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));
            project.Company = _companyRepository.FindBy(request.CompanyId);
            project.ProjectStatus = _projectStatusRepository.FindBy(request.ProjectStatusId);
            project.ProjectType = _projectTypeRepository.FindBy(request.ProjectTypeId);
            project.StartDate = request.StartDate;
            project.EndDate = request.EndDate;

            Query query = new Query();
            query.Add(Criterion.Create<Project>(c => c.Name, project.Name, CriteriaOperator.Equal));
            if (_projectRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir proje zaten var. Lütfen farklı bir proje ekleyin ya da mevcut projelerden birini düzenleyin.";

                return response;
            }

            object identityToken = _projectRepository.Add(project);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Proje kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.Project = _projectRepository.FindBy((int)identityToken).ConvertToProjectView();

            return response;
        }

        public ReadProjectResponse ReadProject(ReadProjectRequest request)
        {
            ReadProjectResponse response = new ReadProjectResponse();
            response.ExceptionState = false;

            response.Project = _projectRepository.FindBy(request.Id).ConvertToProjectView();

            return response;
        }

        public UpdateProjectResponse UpdateProject(UpdateProjectRequest request)
        {
            UpdateProjectResponse response = new UpdateProjectResponse();
            response.ExceptionState = false;

            Project project = new Project();
            project.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            project.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));
            project.Company = _companyRepository.FindBy(request.CompanyId);
            project.ProjectStatus = _projectStatusRepository.FindBy(request.ProjectStatusId);
            project.ProjectType = _projectTypeRepository.FindBy(request.ProjectTypeId);
            project.StartDate = request.StartDate;
            project.EndDate = request.EndDate;

            if (project.Name != _projectRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<Project>(c => c.Name, project.Name, CriteriaOperator.Equal));
                if (_projectStatusRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir proje zaten var. Lütfen proje  adını benzersiz bir isim olarak düzenleyin.";

                    response.Project = project.ConvertToProjectView();

                    return response;
                }
            }

            _projectRepository.Save(project);
            _unitOfWork.Commit();

            response.Project = project.ConvertToProjectView();

            return response;
        }

        public DeleteProjectResponse DeleteProject(DeleteProjectRequest request)
        {
            DeleteProjectResponse response = new DeleteProjectResponse();
            response.ExceptionState = false;

            // TODO : Prevent Deletion on operation center

            _projectRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.Projects = _projectRepository.FindAll().ConvertToProjectSummaryView();

            return response;
        }

        public ListProjectsResponse ListProjects(ListProjectsRequest request)
        {
            ListProjectsResponse response = new ListProjectsResponse();
            response.ExceptionState = false;

            response.Projects = _projectRepository.FindAll().ConvertToProjectSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*             ProjectType Implementations               */
        /*********************************************************/
        #region ProjectType Implementations
        public CreateProjectTypeResponse CreateProjectType(CreateProjectTypeRequest request)
        {
            CreateProjectTypeResponse response = new CreateProjectTypeResponse();
            response.ExceptionState = false;

            ProjectType projectType = new ProjectType();
            projectType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            projectType.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<ProjectType>(c => c.Name, projectType.Name, CriteriaOperator.Equal));
            if (_projectTypeRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir proje tipi zaten var. Lütfen proje tipi adını benzersiz bir isim olarak düzenleyin.";

                response.ProjectType = projectType.ConvertToProjectTypeView();

                return response;
            }

            object identityToken = _projectTypeRepository.Add(projectType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Proje tipi kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.ProjectType = _projectTypeRepository.FindBy((int)identityToken).ConvertToProjectTypeView();

            return response;
        }

        public ReadProjectTypeResponse ReadProjectType(ReadProjectTypeRequest request)
        {
            ReadProjectTypeResponse response = new ReadProjectTypeResponse();
            response.ExceptionState = false;

            response.ProjectType = _projectTypeRepository.FindBy(request.Id).ConvertToProjectTypeView();

            return response;
        }

        public UpdateProjectTypeResponse UpdateProjectType(UpdateProjectTypeRequest request)
        {
            UpdateProjectTypeResponse response = new UpdateProjectTypeResponse();
            response.ExceptionState = false;

            ProjectType projectType = new ProjectType();
            projectType.Id = request.Id;
            projectType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            projectType.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (projectType.Name != _projectTypeRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<ProjectType>(c => c.Name, projectType.Name, CriteriaOperator.Equal));
                if (_projectTypeRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir projec tipi zaten var. Lütfen proje tipi adını benzersiz bir isim olarak düzenleyin.";

                    response.ProjectType = projectType.ConvertToProjectTypeView();

                    return response;
                }
            }

            _projectTypeRepository.Save(projectType);
            _unitOfWork.Commit();

            response.ProjectType = projectType.ConvertToProjectTypeView();

            return response;
        }

        public DeleteProjectTypeResponse DeleteProjectType(DeleteProjectTypeRequest request)
        {
            DeleteProjectTypeResponse response = new DeleteProjectTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<Project>(c => c.ProjectType.Id, request.Id, CriteriaOperator.Equal));
            if (_projectRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini proje tipini kullanan projeler var. Lütfen önce bu projeleri silip ya da düzenleyip tekrar deneyin.";
                response.ProjectTypes = _projectTypeRepository.FindAll().ConvertToProjectTypeSummaryView();

                return response;
            }

            _projectTypeRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.ProjectTypes = _projectTypeRepository.FindAll().ConvertToProjectTypeSummaryView();

            return response;
        }

        public ListProjectTypesResponse ListProjectTypes(ListProjectTypesRequest request)
        {
            ListProjectTypesResponse response = new ListProjectTypesResponse();
            response.ExceptionState = false;

            response.ProjectTypes = _projectTypeRepository.FindAll().ConvertToProjectTypeSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*            ProjectStatus Implementations              */
        /*********************************************************/
        #region ProjectStatus Implementations
        public CreateProjectStatusResponse CreateProjectStatus(CreateProjectStatusRequest request)
        {
            CreateProjectStatusResponse response = new CreateProjectStatusResponse();
            response.ExceptionState = false;

            ProjectStatus projectStatus = new ProjectStatus();
            projectStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            projectStatus.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<ProjectStatus>(c => c.Name, projectStatus.Name, CriteriaOperator.Equal));
            if (_projectStatusRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir proje durumu zaten var. Lütfen proje durumu adını benzersiz bir isim olarak düzenleyin.";

                response.ProjectStatus = projectStatus.ConvertToProjectStatusView();

                return response;
            }

            object identityToken = _projectStatusRepository.Add(projectStatus);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Proje durumu kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.ProjectStatus = _projectStatusRepository.FindBy((int)identityToken).ConvertToProjectStatusView();

            return response;
        }

        public ReadProjectStatusResponse ReadProjectStatus(ReadProjectStatusRequest request)
        {
            ReadProjectStatusResponse response = new ReadProjectStatusResponse();
            response.ExceptionState = false;

            response.ProjectStatus = _projectStatusRepository.FindBy(request.Id).ConvertToProjectStatusView();

            return response;
        }

        public UpdateProjectStatusResponse UpdateProjectStatus(UpdateProjectStatusRequest request)
        {
            UpdateProjectStatusResponse response = new UpdateProjectStatusResponse();
            response.ExceptionState = false;

            ProjectStatus projectStatus = new ProjectStatus();
            projectStatus.Id = request.Id;
            projectStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            projectStatus.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (projectStatus.Name != _projectStatusRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<ProjectStatus>(c => c.Name, projectStatus.Name, CriteriaOperator.Equal));
                if (_projectStatusRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir proje durumu zaten var. Lütfen proje durumu adını benzersiz bir isim olarak düzenleyin.";

                    response.ProjectStatus = projectStatus.ConvertToProjectStatusView();

                    return response;
                }
            }

            _projectStatusRepository.Save(projectStatus);
            _unitOfWork.Commit();

            response.ProjectStatus = projectStatus.ConvertToProjectStatusView();

            return response;
        }

        public DeleteProjectStatusResponse DeleteProjectStatus(DeleteProjectStatusRequest request)
        {
            DeleteProjectStatusResponse response = new DeleteProjectStatusResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<Project>(c => c.ProjectStatus.Id, request.Id, CriteriaOperator.Equal));
            if (_projectRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini proje durumunu kullanan projeler var. Lütfen önce bu projeleri silip ya da düzenleyip tekrar deneyin.";
                response.ProjectStatuses = _projectStatusRepository.FindAll().ConvertToProjectStatusSummaryView();

                return response;
            }

            _projectStatusRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.ProjectStatuses = _projectStatusRepository.FindAll().ConvertToProjectStatusSummaryView();

            return response;
        }

        public ListProjectStatusesResponse ListProjectStatuses(ListProjectStatusesRequest request)
        {
            ListProjectStatusesResponse response = new ListProjectStatusesResponse();
            response.ExceptionState = false;

            response.ProjectStatuses = _projectStatusRepository.FindAll().ConvertToProjectStatusSummaryView();

            return response;
        }
        #endregion
    }
}
