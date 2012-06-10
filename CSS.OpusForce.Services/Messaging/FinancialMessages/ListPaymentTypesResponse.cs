using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListPaymentTypesResponse : ResponseBase
    {
        public IEnumerable<PaymentTypeSummaryView> PaymentTypes { get; set; }
    }
}
