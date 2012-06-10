using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ReadDebitStatusResponse : ResponseBase
    {
        public DebitStatusView DebitStatus { get; set; }
    }
}
