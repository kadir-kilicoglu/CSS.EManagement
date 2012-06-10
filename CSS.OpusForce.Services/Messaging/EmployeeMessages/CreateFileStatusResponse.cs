using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class CreateFileStatusResponse : ResponseBase
    {
        public FileStatusView FileStatus { get; set; }
    }
}
