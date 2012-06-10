using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateFileTypeResponse : ResponseBase
    {
        public FileTypeView FileType { get; set; }
    }
}
