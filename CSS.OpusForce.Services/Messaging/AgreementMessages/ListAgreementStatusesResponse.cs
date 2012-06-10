using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListAgreementStatusesResponse : ResponseBase
    {
        public IEnumerable<AgreementStatusSummaryView> AgreementStatuses { get; set; }
    }
}

