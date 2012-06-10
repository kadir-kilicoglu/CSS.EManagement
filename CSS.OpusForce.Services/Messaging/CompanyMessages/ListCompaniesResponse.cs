using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListCompaniesResponse : ResponseBase
    {
        public IEnumerable<CompanySummaryView> Companies { get; set; }
    }
}
