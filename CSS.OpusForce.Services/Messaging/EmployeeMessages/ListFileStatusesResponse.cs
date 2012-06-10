using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListFileStatusesResponse : ResponseBase
    {
        public IEnumerable<FileStatusSummaryView> FileStatuses { get; set; }
    }
}
