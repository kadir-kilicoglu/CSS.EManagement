using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ReadUserAccountResponse : ResponseBase
    {
        public UserAccountView UserAccount { get; set; }
    }
}
