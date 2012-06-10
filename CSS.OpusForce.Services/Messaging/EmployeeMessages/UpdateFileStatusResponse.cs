using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateFileStatusResponse : ResponseBase
    {
        public FileStatusView FileStatus { get; set; }
    }
}
