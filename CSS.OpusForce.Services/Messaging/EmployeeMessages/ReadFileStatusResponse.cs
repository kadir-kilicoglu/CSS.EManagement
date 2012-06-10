using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ReadFileStatusResponse : ResponseBase
    {
        public FileStatusView FileStatus { get; set; }
    }
}
