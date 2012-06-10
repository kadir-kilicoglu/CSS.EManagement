using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListProjectTypesResponse : ResponseBase
    {
        public IEnumerable<ProjectTypeSummaryView> ProjectTypes { get; set; }
    }
}
