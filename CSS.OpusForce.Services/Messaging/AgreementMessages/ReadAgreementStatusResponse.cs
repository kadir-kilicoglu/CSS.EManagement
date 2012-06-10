using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ReadAgreementStatusResponse : ResponseBase
    {
        public AgreementStatusView AgreementStatus { get; set; }
    }
}

