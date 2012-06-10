using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdatePaymentTypeResponse : ResponseBase
    {
        public PaymentTypeView PaymentType { get; set; }
    }
}
