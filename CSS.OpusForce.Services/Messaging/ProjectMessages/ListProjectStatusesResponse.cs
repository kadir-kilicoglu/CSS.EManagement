using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListProjectStatusesResponse : ResponseBase
    {
        public IEnumerable<ProjectStatusSummaryView> ProjectStatuses { get; set; }
    }
}
