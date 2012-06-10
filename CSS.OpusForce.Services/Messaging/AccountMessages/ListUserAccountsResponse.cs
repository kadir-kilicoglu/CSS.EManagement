using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListUserAccountsResponse : ResponseBase
    {
        public IEnumerable<UserAccountSummaryView> UserAccounts { get; set; }
    }
}
