using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteDebitStatusResponse : ResponseBase
    {
        public IEnumerable<DebitStatusSummaryView> DebitStatuses { get; set; }
    }
}
