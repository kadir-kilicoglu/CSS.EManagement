using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListFileTypesResponse : ResponseBase
    {
        public IEnumerable<FileTypeSummaryView> FileTypes { get; set; }
    }
}
