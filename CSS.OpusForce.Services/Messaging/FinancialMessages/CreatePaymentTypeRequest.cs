using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSS.OpusForce.Services.Messaging.FinancialMessages
{
    class CreatePaymentTypeRequest
    {
    }
}
namespace CSS.OpusForce.Services.Messaging
{
    public class CreatePaymentTypeRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
