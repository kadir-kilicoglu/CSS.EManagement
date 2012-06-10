using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface IProjectServices
    {
        CreateProjectResponse CreateProject(CreateProjectRequest request);
        ReadProjectResponse ReadProject(ReadProjectRequest request);
        UpdateProjectResponse UpdateProject(UpdateProjectRequest request);
        DeleteProjectResponse DeleteProject(DeleteProjectRequest request);
        ListProjectsResponse ListProjects(ListProjectsRequest request);

        CreateProjectTypeResponse CreateProjectType(CreateProjectTypeRequest request);
        ReadProjectTypeResponse ReadProjectType(ReadProjectTypeRequest request);
        UpdateProjectTypeResponse UpdateProjectType(UpdateProjectTypeRequest request);
        DeleteProjectTypeResponse DeleteProjectType(DeleteProjectTypeRequest request);
        ListProjectTypesResponse ListProjectTypes(ListProjectTypesRequest request);

        CreateProjectStatusResponse CreateProjectStatus(CreateProjectStatusRequest request);
        ReadProjectStatusResponse ReadProjectStatus(ReadProjectStatusRequest request);
        UpdateProjectStatusResponse UpdateProjectStatus(UpdateProjectStatusRequest request);
        DeleteProjectStatusResponse DeleteProjectStatus(DeleteProjectStatusRequest request);
        ListProjectStatusesResponse ListProjectStatuses(ListProjectStatusesRequest request);
    }
}
