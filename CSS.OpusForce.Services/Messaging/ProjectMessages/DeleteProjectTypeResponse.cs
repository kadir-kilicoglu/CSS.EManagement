using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteProjectTypeResponse : ResponseBase
    {
        public IEnumerable<ProjectTypeSummaryView> ProjectTypes { get; set; }
    }
}
