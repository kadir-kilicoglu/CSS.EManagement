using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateProjectStatusResponse : ResponseBase
    {
        public ProjectStatusView ProjectStatus { get; set; }
    }
}
