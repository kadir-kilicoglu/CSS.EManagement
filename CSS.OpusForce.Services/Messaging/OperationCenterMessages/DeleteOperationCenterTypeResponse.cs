using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteOperationCenterTypeResponse : ResponseBase
    {
        public IEnumerable<OperationCenterTypeSummaryView> OperationCenterTypes { get; set; }
    }
}
