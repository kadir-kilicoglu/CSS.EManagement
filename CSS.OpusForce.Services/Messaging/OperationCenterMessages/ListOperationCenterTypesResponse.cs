using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListOperationCenterTypesResponse : ResponseBase
    {
        public IEnumerable<OperationCenterTypeSummaryView> OperationCenterTypes { get; set; }
    }
}
