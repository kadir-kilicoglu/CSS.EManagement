using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListDebitTypesResponse : ResponseBase
    {
        public IEnumerable<DebitTypeSummaryView> DebitTypes { get; set; }
    }
}
