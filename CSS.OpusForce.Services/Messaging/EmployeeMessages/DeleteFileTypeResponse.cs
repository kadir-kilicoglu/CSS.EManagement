using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteFileTypeResponse : ResponseBase
    {
        public IEnumerable<FileTypeSummaryView> FileTypes { get; set; }
    }
}
