using System.Collections.Generic;

namespace CSS.OpusForce.Services.ViewModels
{
    public class UserAccountSummaryView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public IEnumerable<RoleView> Roles { get; set; }
    }
}
