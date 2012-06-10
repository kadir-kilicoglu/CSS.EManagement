using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListContractorStatusesResponse : ResponseBase
    {
        public IEnumerable<ContractorStatusSummaryView> ContractorStatuses { get; set; }
    }
}
