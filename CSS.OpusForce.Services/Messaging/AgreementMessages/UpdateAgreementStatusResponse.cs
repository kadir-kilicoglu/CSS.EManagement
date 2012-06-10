using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateAgreementStatusResponse : ResponseBase
    {
        public AgreementStatusView AgreementStatus { get; set; }
    }
}
