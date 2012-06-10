using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteRoleResponse : ResponseBase
    {
        public IEnumerable<RoleSummaryView> Roles { get; set; }
    }
}
