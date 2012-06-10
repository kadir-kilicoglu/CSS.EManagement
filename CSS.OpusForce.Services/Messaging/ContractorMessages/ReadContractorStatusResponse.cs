using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ReadContractorStatusResponse : ResponseBase
    {
        public ContractorStatusView ContractorStatus { get; set; }
    }
}
