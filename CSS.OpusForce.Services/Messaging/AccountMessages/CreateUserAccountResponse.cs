using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class CreateUserAccountResponse : ResponseBase
    {
        public UserAccountView UserAccount { get; set; }
    }
}
