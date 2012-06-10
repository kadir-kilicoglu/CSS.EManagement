using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteCompanyResponse : ResponseBase
    {
        public IEnumerable<CompanySummaryView> Companies { get; set; }
    }
}
