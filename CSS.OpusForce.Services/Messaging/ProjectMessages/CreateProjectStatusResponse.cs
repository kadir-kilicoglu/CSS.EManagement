using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class CreateProjectStatusResponse : ResponseBase
    {
        public ProjectStatusView ProjectStatus { get; set; }
    }
}
