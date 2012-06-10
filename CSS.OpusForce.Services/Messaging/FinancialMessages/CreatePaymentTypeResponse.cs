using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class CreatePaymentTypeResponse : ResponseBase
    {
        public PaymentTypeView PaymentType { get; set; }
    }
}
