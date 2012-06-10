using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateOperationCenterStatusResponse : ResponseBase
    {
        public OperationCenterStatusView OperationCenterStatus { get; set; }
    }
}
