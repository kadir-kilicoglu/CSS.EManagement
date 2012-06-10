using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteFinancialActivityTypeResponse : ResponseBase
    {
        public IEnumerable<FinancialActivityTypeSummaryView> FinancialActivityTypes { get; set; }
    }
}
