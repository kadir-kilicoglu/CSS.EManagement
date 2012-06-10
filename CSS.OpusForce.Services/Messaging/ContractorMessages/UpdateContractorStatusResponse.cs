using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateContractorStatusResponse : ResponseBase
    {
        public ContractorStatusView ContractorStatus { get; set; }
    }
}
