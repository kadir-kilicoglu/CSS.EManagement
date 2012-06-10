using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListContractorsResponse : ResponseBase
    {
        public IEnumerable<ContractorSummaryView> Contractors { get; set; }
    }
}
