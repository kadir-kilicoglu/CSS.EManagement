using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class CreateOperationCenterStatusResponse : ResponseBase
    {
        public OperationCenterStatusView OperationCenterStatus { get; set; }
    }
}
