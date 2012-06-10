using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Projects;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class ProjectMapper
    {
        public static IEnumerable<ProjectTypeSummaryView> ConvertToProjectTypeSummaryView(this IEnumerable<ProjectType> projectTypes)
        {
            List<ProjectTypeSummaryView> tempList = new List<ProjectTypeSummaryView>();

            foreach (ProjectType p in projectTypes)
            {
                ProjectTypeSummaryView tempView = new ProjectTypeSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static ProjectTypeView ConvertToProjectTypeView(this ProjectType projectType)
        {
            ProjectTypeView tempView = new ProjectTypeView();
            tempView.Id = projectType.Id;
            tempView.Name = projectType.Name;
            tempView.Description = projectType.Description;

            return tempView;
        }

        public static IEnumerable<ProjectStatusSummaryView> ConvertToProjectStatusSummaryView(this IEnumerable<ProjectStatus> projectStatuses)
        {
            List<ProjectStatusSummaryView> tempList = new List<ProjectStatusSummaryView>();

            foreach (ProjectStatus p in projectStatuses)
            {
                ProjectStatusSummaryView tempView = new ProjectStatusSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static ProjectStatusView ConvertToProjectStatusView(this ProjectStatus projectStatus)
        {
            ProjectStatusView tempView = new ProjectStatusView();
            tempView.Id = projectStatus.Id;
            tempView.Name = projectStatus.Name;
            tempView.Description = projectStatus.Description;

            return tempView;
        }

        public static IEnumerable<ProjectSummaryView> ConvertToProjectSummaryView(this IEnumerable<Project> projects)
        {
            List<ProjectSummaryView> tempList = new List<ProjectSummaryView>();

            foreach (Project p in projects)
            {
                ProjectSummaryView tempView = new ProjectSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;
                tempView.ProjectStatusName = p.ProjectStatus.Name;
                tempView.ProjectTypeName = p.ProjectStatus.Name;
            }

            return tempList;
        }

        public static ProjectView ConvertToProjectView(this Project project)
        {
            ProjectView tempView = new ProjectView();
            tempView.Id = project.Id;
            tempView.Name = project.Name;
            tempView.Description = project.Description;
            tempView.CompanyId = project.Company.Id;
            tempView.CompanyName = project.Company.Name;
            tempView.ProjectStatusId = project.ProjectStatus.Id;
            tempView.ProjectStatusName = project.ProjectStatus.Name;
            tempView.ProjectTypeId = project.ProjectType.Id;
            tempView.ProjectTypeName = project.ProjectType.Name;
            tempView.StartDate = project.StartDate;
            tempView.EndDate = project.EndDate;

            return tempView;
        }
    }
}
