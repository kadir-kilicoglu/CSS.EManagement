﻿using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteAgreementTypeResponse : ResponseBase
    {
        public IEnumerable<AgreementTypeSummaryView> AgreementTypes { get; set; }
    }
}
