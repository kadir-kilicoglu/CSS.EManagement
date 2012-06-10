using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteDebitTypeResponse : ResponseBase
    {
        public IEnumerable<DebitTypeSummaryView> DebitTypes { get; set; }
    }
}
