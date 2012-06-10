using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteOperationCenterStatusResponse : ResponseBase
    {
        public IEnumerable<OperationCenterStatusSummaryView> OperationCenterStatuses { get; set; }
    }
}
