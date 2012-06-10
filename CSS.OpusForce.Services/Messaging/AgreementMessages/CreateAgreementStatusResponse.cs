using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class CreateAgreementStatusResponse : ResponseBase
    {
        public AgreementStatusView AgreementStatus { get; set; }
    }
}
