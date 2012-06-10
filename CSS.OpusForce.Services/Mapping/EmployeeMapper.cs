using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Employees;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class EmployeeMapper
    {
        public static IEnumerable<FileTypeSummaryView> ConvertToFileTypeSummaryView(this IEnumerable<FileType> fileTypes)
        {
            List<FileTypeSummaryView> tempList = new List<FileTypeSummaryView>();

            foreach (FileType p in fileTypes)
            {
                FileTypeSummaryView tempView = new FileTypeSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static FileTypeView ConvertToFileTypeView(this FileType fileType)
        {
            FileTypeView tempView = new FileTypeView();
            tempView.Id = fileType.Id;
            tempView.Name = fileType.Name;
            tempView.Description = fileType.Description;

            return tempView;
        }

        public static IEnumerable<FileStatusSummaryView> ConvertToFileStatusSummaryView(this IEnumerable<FileStatus> fileStatuses)
        {
            List<FileStatusSummaryView> tempList = new List<FileStatusSummaryView>();

            foreach (FileStatus p in fileStatuses)
            {
                FileStatusSummaryView tempView = new FileStatusSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static FileStatusView ConvertToFileStatusView(this FileStatus fileStatus)
        {
            FileStatusView tempView = new FileStatusView();
            tempView.Id = fileStatus.Id;
            tempView.Name = fileStatus.Name;
            tempView.Description = fileStatus.Description;

            return tempView;
        }

        public static IEnumerable<DebitTypeSummaryView> ConvertToDebitTypeSummaryView(this IEnumerable<DebitType> debitTypes)
        {
            List<DebitTypeSummaryView> tempList = new List<DebitTypeSummaryView>();

            foreach (DebitType p in debitTypes)
            {
                DebitTypeSummaryView tempView = new DebitTypeSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static DebitTypeView ConvertToDebitTypeView(this DebitType debitType)
        {
            DebitTypeView tempView = new DebitTypeView();
            tempView.Id = debitType.Id;
            tempView.Name = debitType.Name;
            tempView.Description = debitType.Description;

            return tempView;
        }

        public static IEnumerable<DebitStatusSummaryView> ConvertToDebitStatusSummaryView(this IEnumerable<DebitStatus> debitStatuses)
        {
            List<DebitStatusSummaryView> tempList = new List<DebitStatusSummaryView>();

            foreach (DebitStatus p in debitStatuses)
            {
                DebitStatusSummaryView tempView = new DebitStatusSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static DebitStatusView ConvertToDebitStatusView(this DebitStatus debitStatus)
        {
            DebitStatusView tempView = new DebitStatusView();
            tempView.Id = debitStatus.Id;
            tempView.Name = debitStatus.Name;
            tempView.Description = debitStatus.Description;

            return tempView;
        }
    }
}