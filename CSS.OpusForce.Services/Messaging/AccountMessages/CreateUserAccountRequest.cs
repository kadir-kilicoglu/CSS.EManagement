using System.Collections.Generic;

namespace CSS.OpusForce.Services.Messaging
{
    public class CreateUserAccountRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable<int> RoleIds { get; set; }
    }
}
