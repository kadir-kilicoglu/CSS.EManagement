using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class CreateContractorStatusResponse : ResponseBase
    {
        public ContractorStatusView ContractorStatus { get; set; }
    }
}
