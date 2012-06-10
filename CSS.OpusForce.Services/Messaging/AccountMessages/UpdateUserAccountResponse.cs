using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateUserAccountResponse : ResponseBase
    {
        public UserAccountView UserAccount { get; set; }
    }
}
