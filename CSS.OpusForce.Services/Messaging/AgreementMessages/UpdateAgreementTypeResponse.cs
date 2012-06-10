using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateAgreementTypeResponse : ResponseBase
    {
        public AgreementTypeView AgreementType { get; set; }
    }
}