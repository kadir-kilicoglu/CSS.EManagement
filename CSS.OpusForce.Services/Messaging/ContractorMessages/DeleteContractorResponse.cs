using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteContractorResponse : ResponseBase
    {
        public IEnumerable<ContractorSummaryView> Contractors { get; set; }
    }
}
