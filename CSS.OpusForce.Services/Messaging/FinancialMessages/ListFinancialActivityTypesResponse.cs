﻿using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListFinancialActivityTypesResponse : ResponseBase
    {
        public IEnumerable<FinancialActivityTypeSummaryView> FinancialActivityTypes { get; set; }
    }
}
