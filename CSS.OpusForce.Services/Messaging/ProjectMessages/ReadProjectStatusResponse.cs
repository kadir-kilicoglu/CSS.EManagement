using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ReadProjectStatusResponse : ResponseBase
    {
        public ProjectStatusView ProjectStatus { get; set; }
    }
}
