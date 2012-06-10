using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteProjectStatusResponse : ResponseBase
    {
        public IEnumerable<ProjectStatusSummaryView> ProjectStatuses { get; set; }
    }
}
