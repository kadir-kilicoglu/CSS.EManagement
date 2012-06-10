using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListCompanyTypesResponse : ResponseBase
    {
        public IEnumerable<CompanyTypeSummaryView> CompanyTypes { get; set; }
    }
}
