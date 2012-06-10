using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ReadFinancialActivityTypeResponse : ResponseBase
    {
        public FinancialActivityTypeView FinancialActivityType { get; set; }
    }
}
