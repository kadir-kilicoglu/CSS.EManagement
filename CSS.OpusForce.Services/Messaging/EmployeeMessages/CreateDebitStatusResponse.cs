using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class CreateDebitStatusResponse : ResponseBase
    {
        public DebitStatusView DebitStatus { get; set; }
    }
}
