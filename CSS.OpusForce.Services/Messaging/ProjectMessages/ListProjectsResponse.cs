using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListProjectsResponse : ResponseBase
    {
        public IEnumerable<ProjectSummaryView> Projects { get; set; }
    }
}
