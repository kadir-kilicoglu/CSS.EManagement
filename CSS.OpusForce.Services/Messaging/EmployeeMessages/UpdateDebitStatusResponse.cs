using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateDebitStatusResponse : ResponseBase
    {
        public DebitStatusView DebitStatus { get; set; }
    }
}
