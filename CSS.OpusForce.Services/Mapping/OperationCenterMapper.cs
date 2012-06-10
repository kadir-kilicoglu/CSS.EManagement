using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.OperationCenters;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class OperationCenterMapper
    {
        public static IEnumerable<OperationCenterTypeSummaryView> ConvertToOperationCenterTypeSummaryView(this IEnumerable<OperationCenterType> operationCenterTypes)
        {
            List<OperationCenterTypeSummaryView> tempList = new List<OperationCenterTypeSummaryView>();

            foreach (OperationCenterType p in operationCenterTypes)
            {
                OperationCenterTypeSummaryView tempView = new OperationCenterTypeSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static OperationCenterTypeView ConvertToOperationCenterTypeView(this OperationCenterType operationCenterType)
        {
            OperationCenterTypeView tempView = new OperationCenterTypeView();
            tempView.Id = operationCenterType.Id;
            tempView.Name = operationCenterType.Name;
            tempView.Description = operationCenterType.Description;

            return tempView;
        }

        public static IEnumerable<OperationCenterStatusSummaryView> ConvertToOperationCenterStatusSummaryView(this IEnumerable<OperationCenterStatus> operationCenterStatuses)
        {
            List<OperationCenterStatusSummaryView> tempList = new List<OperationCenterStatusSummaryView>();

            foreach (OperationCenterStatus p in operationCenterStatuses)
            {
                OperationCenterStatusSummaryView tempView = new OperationCenterStatusSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static OperationCenterStatusView ConvertToOperationCenterStatusView(this OperationCenterStatus operationCenterStatus)
        {
            OperationCenterStatusView tempView = new OperationCenterStatusView();
            tempView.Id = operationCenterStatus.Id;
            tempView.Name = operationCenterStatus.Name;
            tempView.Description = operationCenterStatus.Description;

            return tempView;
        }
    }
}
