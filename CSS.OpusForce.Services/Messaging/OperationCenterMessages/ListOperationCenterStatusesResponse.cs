using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListOperationCenterStatusesResponse : ResponseBase
    {
        public IEnumerable<OperationCenterStatusSummaryView> OperationCenterStatuses { get; set; }
    }
}
